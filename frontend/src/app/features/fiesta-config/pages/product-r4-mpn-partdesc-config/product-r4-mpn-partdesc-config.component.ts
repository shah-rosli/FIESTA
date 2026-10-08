import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../../components/delta-upload/delta-upload.component'
import { Column, EditingStartEvent, EditorPreparingEvent, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { Workbook } from 'exceljs'
import { exportDataGrid } from 'devextreme/excel_exporter'
import { saveAs } from 'file-saver'
import { ConfigHistoryPopupComponent } from '../../components/config-history-popup/config-history-popup.component'
import { finalize } from 'rxjs'

@Component({
  selector: 'app-product-r4-mpn-partdesc-config',
  templateUrl: './product-r4-mpn-partdesc-config.component.html',
  styleUrls: ['./product-r4-mpn-partdesc-config.component.scss']
})
export class ProductR4MpnPartdescConfigComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "MPN (REL) Part Description Maintenance"
  endpoint: string = "CfgProductR4MpnPartDesc"
  tableName: string = "CFG_PRODUCT_R4_MPN_PARTDESC"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "partDescription",
    "deleteFlag",
  ]
  yesNoDataSource = ["Y", "N"]
  plmStatusDataSource = ["P1", "P2", "P3", "P4", "P5", "P6", "P7"]
  showApprovalButton: boolean = false
  approvalRecordKey: any = null

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  approveButtonOptions = {
    text: 'Approve',
    onClick: () => this.approveButtonClick()
  }

  rejectButtonOptions = {
    text: 'Reject',
    onClick: () => this.rejectButtonClick()
  }

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
    this.approvalIconClick = this.approvalIconClick.bind(this)
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
        if (column.dataField === "deleteFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
        if (column.dataField === "materialGroup") {
          console.error("not expect column materialGroup, will not load lookup data")
        }
        if (column.dataField === "plmStatus") {
          column.lookup = {
            dataSource: this.plmStatusDataSource
          }
        }
        if (column.dataField === "isPartNotRecommendNewDesign") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
        if (column.dataField === "totalShelfLife") {
          column.validationRules = [
            { type: 'range', min: 0, message: "Value must be greater than or equal to zero" },
          ]
        }
        if (column.dataField === "minimumOrderQuantity") {
          column.validationRules = [
            { type: 'range', min: 0, message: "Value must be greater than or equal to zero" },
          ]
        }
        if (column.dataField === "autoShipping") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
      })
      mainColumns.push({
        type: "buttons",
        fixed: true,
        fixedPosition: "right",
        buttons: [{
          name: "edit",
          visible: options => options.row.data.needApproval !== "Yes",
        }, {
          text: "Approval",
          visible: options => options.row.data.needApproval === "Yes",
          onClick: this.approvalIconClick
        }, {
          hint: "Show History",
          text: "History",
          onClick: this.historyIconClick
        }]
      })
      return mainColumns
    }
    const createHistoryColumns = (columns: Column[]): Column[] => {
      const historyColumns: Column[] = [
        { dataField: `CFG_PRODUCT_HIS_ID`, caption: "History ID", },
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

  onEditorPreparing(e: EditorPreparingEvent) {
    if (e.parentType === "dataRow" && e.dataField === "plmStatus") {
      const found = this.plmStatusDataSource.find(item => item === e.editorOptions.value)
      if (!found) {
        e.editorOptions.value = null
      }
    }
    if (e.parentType === "dataRow" && e.dataField === "partDescription") {
      if (e.row.data.needApproval === "Yes") {
        e.editorOptions.readOnly = true
      }
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    e.data.deleteFlag = "N"
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    const workbook = new Workbook()
    const worksheet = workbook.addWorksheet('Sheet')

    exportDataGrid({
      component: e.component,
      worksheet,
    }).then(() => {
      try {
        worksheet.spliceColumns(5, 0, [])
        worksheet.getCell(1, 5).value = "To-Be Part Description"
        worksheet.getCell(1, 5).style = { font: { bold: true } }
        worksheet.getCell(1, 5).alignment = { horizontal: 'center' }
        worksheet.getColumn(5).width = "To-Be Part Description".length

        workbook.xlsx.writeBuffer().then((buffer) => {
          saveAs(new Blob([buffer], { type: 'application/octet-stream' }), `${fileName}.xlsx`)
        })
      } catch (error) {
        console.error(error)
      }
    })
  }

  approvalIconClick(e) {
    this.dataGrid.instance.editRow(e.row.rowIndex)
  }

  onEditingStart(e: EditingStartEvent) {
    this.showApprovalButton = e.data.needApproval === "Yes" ? true : false
    this.approvalRecordKey = e.data.recordKey
  }

  approveButtonClick() {
    this.send
      .sendRequest(`${environment.ServiceURL_Main}CfgProductR4MpnPartDesc/Approve?values=${this.approvalRecordKey}`, "PUT", "")
      .pipe(finalize(() => this.dataGrid.instance.cancelEditData()))
      .subscribe({
        next: data => data.SuccessMsg && this.toastr.success("Approved"),
        error: () => this.toastr.error(null, "Error!", errorToastOptions),
      })
  }

  rejectButtonClick() {
    this.send
      .sendRequest(`${environment.ServiceURL_Main}CfgProductR4MpnPartDesc/Reject?values=${this.approvalRecordKey}`, "PUT", "")
      .pipe(finalize(() => this.dataGrid.instance.cancelEditData()))
      .subscribe({
        next: data => data.SuccessMsg && this.toastr.success("Rejected"),
        error: () => this.toastr.error(null, "Error!", errorToastOptions),
      })
  }
}
