import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../../components/delta-upload/delta-upload.component'
import { Column, EditingStartEvent, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../../components/config-history-popup/config-history-popup.component'
import { catchError, firstValueFrom, of } from 'rxjs'

@Component({
  selector: 'app-cdb-config',
  templateUrl: './cdb-config.component.html',
  styleUrl: './cdb-config.component.scss'
})
export class CdbConfigComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Central Die Bank Maintenance"
  endpoint: string = "CfgCdb"
  tableName: string = "CFG_CDB"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "opn",
    "partNumber",
    "lineName",
    "activeFlag",
  ]
  fieldsCreateOnly: string[] = [
    "opn",
    "partNumber",
  ]
  yesNoDataSource = ["Y", "N"]

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  lineNameDataSource: any[]
  lineNameDropDown: string[]

  isLinesDropdownReadOnly: boolean = false

  //add by Keith 20260922, to disable edit blacklisted OPN
  private allowEditPopup = false
  private validatingOpn = false

  saveButtonOptions = {
    text: 'Save',
    onClick: () => this.dataGrid.instance.saveEditData()
  }

  cancelButtonOptions = {
    text: 'Cancel',
    onClick: () => this.dataGrid.instance.cancelEditData()
  }

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
  }

  ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)
    this.setOPNValue = this.setOPNValue.bind(this) //added by Keith 20260921 to check blacklisted opn
    this.setPartNumberValue = this.setPartNumberValue.bind(this)
    this.setLineNameValue = this.setLineNameValue.bind(this)
    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        // not allow editing
        if (!this.fieldsAllowEditing.includes(column.dataField)) {
          column.allowEditing = false
        }
        if (this.fieldsAllowEditing.includes(column.dataField)) {
          column.validationRules = [{ type: 'required' }]
        }
        if (column.dataField === "opn") {
          column.setCellValue = this.setOPNValue
        }
        if (column.dataField === "partNumber") {
          column.setCellValue = this.setPartNumberValue
        }
        if (column.dataField === "lineName") {
          column.editCellTemplate = "lineNameEditor"
          column.setCellValue = this.setLineNameValue
        }
        if (column.dataField === "activeFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
      })
      mainColumns.push({
        type: "buttons",
        fixed: true,
        fixedPosition: "right",
        buttons: ["edit", {
          hint: "Show History",
          text: "History",
          onClick: this.historyIconClick
        }]
      })
      return mainColumns
    }
    const createHistoryColumns = (columns: Column[]): Column[] => {
      const historyColumns: Column[] = [
        { dataField: `${this.tableName}_HIS_ID`, caption: "History ID" },
        ...columns.map(column => ({
          dataField: column.dataField,
          caption: column.caption,
          dataType: column.dataType,
          format: column.format,
          visible: column.visible
        }))
      ]

      const updateDateColumn = historyColumns.find(col => col.dataField === "updateDateAndTime")
      if (updateDateColumn) {
        updateDateColumn.sortOrder = "desc"
      }

      return historyColumns
    }
    const url: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        this.columnConfig = createMainColumns(data)
        this.deltaUploadColumnConfig = data
        this.historyColumnConfig = createHistoryColumns(data)

        this.setDataSource()
      }
    )
  }

  setDataSource() {
    let url: string = `${environment.ServiceURL_Main}${this.endpoint}`
    this.dataSource = new DataSource({
      store: this.send.sendRequestVirtualConfigurable({
        key: this.dataGridKey,
        loadUrl: url + "/GetAll",
        insertUrl: url,
        updateUrl: url,
      })
    })
  }

  postGridRow(e, action) {
    if (action == 'edit') { e.newData = { ...e.oldData, ...e.newData } }
  }

  async postedGridRow(e, action) {
    if (action == 'create') { this.toastr.success('Record created successfully', 'Success!') }
    if (action == 'edit') { this.toastr.success('Record modified successfully', 'Success!') }
    if (action == 'delete') { this.toastr.success('Record deleted successfully', 'Success!') }
  }

  historyIconClick(e) {
    const ID = e.row.data[this.dataGridKey]
    if (!ID) {
      this.toastr.error("Invalid/No ID", null, errorToastOptions)
      return
    }
    this.historyPopup.open(ID)
  }

  onEditorPreparing(e) {
    for (const dataField of this.fieldsCreateOnly) {
      if (e.parentType === "dataRow" && e.dataField === dataField) {
        if (e.row.isNewRow) {
          e.editorOptions.readOnly = false //enabled when new row
        } else {
          e.editorOptions.readOnly = true //disabled when existing row
        }
      }
    }

    // editCellTemplate does not get triggered by onEditorPreparing
    // borrow the event from recordKey to set lineName and supplyLegacyLine readOnly
    if (e.parentType === "dataRow" && e.dataField === "recordKey") {
      this.setLinesDropdownReadOnly(e)
    }
  }

  setLinesDropdownReadOnly(e) {
    this.isLinesDropdownReadOnly = true

    if (e.row.isNewRow) {
      if (this.lineNameDataSource.length > 0) {
        this.isLinesDropdownReadOnly = false
      }
    }

    if (!e.row.isNewRow) {
      this.populateLinesDataByPartNumber(e.row.data.partNumber)
      this.isLinesDropdownReadOnly = false
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    e.data.activeFlag = "Y"
    this.resetLinesData()
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  //make sure OPN is valid
  async getMdmByOpn(opn: string): Promise<boolean> {
    const url1: string = `${environment.ServiceURL_Main}CfgCdb/GetMdmByOpn?${new URLSearchParams({ opn: opn }).toString()}`
    try {
      const data = await firstValueFrom(
        this.send.sendRequest(url1, 'GET').pipe(
          catchError(() => of([]))
        )
      );

      if (data.errorMessage !== undefined) {
        this.toastr.error(data.errorMessage, null, errorToastOptions)
        return false
      }
      // if (data.length > 0) {
      // } else {
      //   if (data.errorMessage !== undefined) {
      //     this.toastr.error(data.errorMessage, null, errorToastOptions)
      //   }
      // }
      return true
    } catch (error) {
      this.toastr.error('Fail to validate OPN. Please try again.', null, errorToastOptions)
      return false
    }
  }

  async populateLinesDataByPartNumber(partNumber: string) {
    const url: string = `${environment.ServiceURL_Main}CfgCdb/GetMdmByPartNumber?${new URLSearchParams({ partNumber: partNumber }).toString()}`
    try {
      // const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      // this.lineNameDataSource = data
      // this.lineNameDropDown = Array.from(new Set(this.lineNameDataSource.map(item => item.lineName)))
      const data = await firstValueFrom(
        this.send.sendRequest(url, 'GET').pipe(
          catchError(() => of([]))
        )
      );

      if (data.length > 0) {
        this.lineNameDataSource = data
        this.lineNameDropDown = Array.from(new Set(this.lineNameDataSource.map(item => item.lineName)))
      } else {
        this.resetLinesData()
        if (data.errorMessage !== undefined) {
          this.toastr.error(data.errorMessage, null, errorToastOptions)
        }
      }
    } catch (error) {
      this.resetLinesData()
      // if (error?.status === 404) {
      //   this.toastr.error(`partNumber "${partNumber}" not found`, null, errorToastOptions)
      // }
    }
  }

  resetLinesData() {
    this.lineNameDataSource = null
    this.lineNameDropDown = null
  }

  async setOPNValue(newData, value) { //added by Keith 20260921
    await this.getMdmByOpn(value)

    newData.opn = value
  }

  async setPartNumberValue(newData, value) {
    await this.populateLinesDataByPartNumber(value)

    newData.partNumber = value
  }

  setLineNameValue(newData, value) {
    // set other field after user select line
    const filtered = this.lineNameDataSource.filter(item =>
      item.lineName === value
    )
    newData.plant = filtered[0].plant
    newData.storageLocation = filtered[0].storageLocation

    newData.lineName = value
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  //add by Keith 20260922, to disable edit blacklisted OPN
  async onEditingStart(e: any): Promise<void> {
    if (this.allowEditPopup) {
      return
    }
    // 1. Immediately prevent the edit panel from opening.
    e.cancel = true
    if (this.validatingOpn) {
      return
    }
    this.validatingOpn = true

    try {
      // 2. Call the API only after editing has been cancelled.
      const opn = e.data.opn
      const url = `${environment.ServiceURL_Main}CfgCdb/GetMdmByOpn?${new URLSearchParams({
        opn
      }).toString()}`

      const data = await firstValueFrom(
        this.send.sendRequest(url, 'GET')
      )

      // 3. Show the error; the edit panel is already blocked.
      if (data.errorMessage !== undefined) {
        if (!String(data.errorMessage).includes('Production Plant Conversion record not found for Company Code')) {
          this.toastr.error(data.errorMessage, null, errorToastOptions)
          return
        }
      }

      // 4. Open the edit panel only when validation passes.
      const rowIndex = e.component.getRowIndexByKey(e.key)

      if (rowIndex < 0) {
        return
      }

      this.allowEditPopup = true

      try {
        e.component.editRow(rowIndex)
      } finally {
        this.allowEditPopup = false
      }
    } catch {
      this.toastr.error(
        'Unable to validate OPN. Please refresh the page and try again.',
        null,
        errorToastOptions
      )
    } finally {
      this.validatingOpn = false
    }
  }
}