import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../../components/delta-upload/delta-upload.component'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../../components/config-history-popup/config-history-popup.component'
import { confirm } from 'devextreme/ui/dialog'
import { BaseService } from 'src/app/service/base/base.service'
import { firstValueFrom } from 'rxjs'

@Component({
  selector: 'app-production-lotsize-config',
  templateUrl: './production-lotsize-config.component.html',
  styleUrls: ['./production-lotsize-config.component.scss']
})
export class ProductionLotsizeConfigComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Production Lot Size Maintenance"
  endpoint: string = "CfgProductionLotsize"
  tableName: string = "CFG_PRODUCTION_LOTSIZE"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    // "partNumber",
    // "plant",
    // "storageLocation",

    "minimumLotSize",
    "incrementLotSize",
    "maximumLotSize",
    "lotSizingProcedure",
    "deleteFlag",
  ]
  fieldsCreateOnly: string[] = [
    "partNumber",
    "plant",
    "storageLocation",
    "minimumLotSize",
    "incrementLotSize",
    "maximumLotSize",
    "lotSizingProcedure",
    "deleteFlag",
  ]
  yesNoDataSource = ["Y", "N"]
  lspDataSource: any[]

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  plantDataSource: any[]
  plantDropDown: string[]
  storageLocationDataSource: any[]
  storageLocationDropdown: string[]

  // isPlantDropdownReadOnly: boolean = false
  // isStorageLocationDropdownReadOnly: boolean = false

  selectedPartNumber: string

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
    private permission: PermissionService,
    private base: BaseService) {
  }

  ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)

    this.setPartNumberValue = this.setPartNumberValue.bind(this)
    this.setPlantValue = this.setPlantValue.bind(this)

    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
    this.lspDataSource = this.base.getParamData("LOTSIZE_CONFIG_LSP_LIST")
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        // not allow editing
        if (!this.fieldsAllowEditing.includes(column.dataField)) {
          column.allowEditing = false
        }

        // else {
        //   column.allowEditing = true
        // }

        if (column.dataField === "deleteFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
        if (column.dataField === "lotSizingProcedure") {
          column.editCellTemplate = "lspDropdownEditor"
        }
        if (column.dataField === "partNumber") {
          column.editCellTemplate = "partNumberEditor"
          //column.setCellValue = this.setPartNumberValue
        }
        if (column.dataField === "plant") {
          column.editCellTemplate = "plantEditor"
          //column.setCellValue = this.setPlantValue
        }
        if (column.dataField === "storageLocation") {
          column.editCellTemplate = "storageLocationEditor"
          //column.setCellValue = this.setStorageLocationValue
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
    if (action == 'edit') this.lotSizingProcedureConfirmation(e)
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
    // for (const dataField of this.fieldsCreateOnly) {
    //   if (e.parentType === "dataRow" && e.dataField === dataField) {
    //     if (e.row.isNewRow) {
    //       e.editorOptions.readOnly = false //enabled when new row
    //     } else {
    //       e.editorOptions.readOnly = true //disabled when existing row
    //     }
    //   }
    // }
    if (e.parentType !== "dataRow") return

    const isNew = e.row?.isNewRow
    const field = e.dataField

    if (isNew) {
      e.editorOptions.readOnly = !this.fieldsCreateOnly.includes(field)
    } else {
      e.editorOptions.readOnly = !this.fieldsAllowEditing.includes(field)
    }

    // editCellTemplate does not get triggered by onEditorPreparing
    // borrow the event from recordKey to set lineName and supplyLineName readOnly
    if (e.parentType === "dataRow" && e.dataField === "recordKey") {
      this.setPlantSLocDropdownReadOnly(e)
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    e.data.deleteFlag = "N"
    this.resetPlantData()
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  lotSizingProcedureConfirmation(e) {
    if (e.newData.lotSizingProcedure !== e.oldData.lotSizingProcedure) {
      // prevent load panel block confirm dialog
      e.component.option('loadPanel.enabled', false)
      e.cancel = new Promise((resolve) => {
        confirm(
          `This will change all Part Number ${e.newData.partNumber} and Plant ${e.newData.plant} Lot Sizing Procedure to ${e.newData.lotSizingProcedure}.`,
          "Confirmation"
        ).then((dialogResult) => {
          e.component.option('loadPanel.enabled', true)
          if (dialogResult) {
            resolve(false)
          } else {
            resolve(true)
          }
        })
      })
    }
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }










  //////////////////////////////////////////////////////////////////////////////////

  // onEditingStart(e) {
  //   this.resetPlantData()
  // }

  async setPartNumberValue(newData, value) {
    this.selectedPartNumber = value

    newData.partNumber = value
    newData.plant = null
    newData.storageLocation = null

    await this.populatePlant(value)
  }

  async onPartNumberChanged(value: string, cellInfo: any) {
    cellInfo.component.cellValue(cellInfo.row.rowIndex, "partNumber", value)
    cellInfo.component.cellValue(cellInfo.row.rowIndex, "plant", null)
    cellInfo.component.cellValue(cellInfo.row.rowIndex, "storageLocation", null)

    this.selectedPartNumber = value

    await this.populatePlant(value)
  }

  async setPlantValue(newData, value) {
    newData.plant = value
    await this.populateStorageLocation(this.selectedPartNumber, value)
  }

  async onPlantChanged(value: string, cellInfo: any) {
    cellInfo.component.cellValue(cellInfo.row.rowIndex, "plant", value)
    cellInfo.component.cellValue(cellInfo.row.rowIndex, "storageLocation", null)
    await this.populateStorageLocation(this.selectedPartNumber, value)
  }

  setStorageLocationValue(newData, value) {
    newData.storageLocation = value
  }

  onStorageLocationChanged(value: string, cellInfo: any) {
    cellInfo.component.cellValue(cellInfo.row.rowIndex, "storageLocation", value)
  }

  setPlantSLocDropdownReadOnly(e) {
    // this.isPlantDropdownReadOnly = true
    // this.isStorageLocationDropdownReadOnly = true

    if (e.row.isNewRow) {
      // if (this.plantDataSource.length > 0 && this.storageLocationDataSource.length > 0) {
      //   this.isPlantDropdownReadOnly = false
      //   this.isStorageLocationDropdownReadOnly = false
      // }

      // this.isPlantDropdownReadOnly = false
      // this.isStorageLocationDropdownReadOnly = false
    }

    if (!e.row.isNewRow) {
      this.populatePlant(e.row.data.partNumber)
      this.populateStorageLocation(e.row.data.partNumber, e.row.data.plant)
    }
  }

  async populatePlant(partNumber: string) {
    const url1: string = `${environment.ServiceURL_Main}CfgProductionLotSize/GetPlantByPartNumber?${new URLSearchParams({ partNumber: partNumber }).toString()}`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url1, "GET"))
      this.plantDataSource = data
      this.plantDropDown = Array.from(new Set(this.plantDataSource.map(
        item => item.plant
      )))
      //this.isPlantDropdownReadOnly = false
    } catch (error) {
      this.resetPlantData()
      if (error?.status === 404) {
        this.toastr.error(`PartNumber "${partNumber}" not found`, null, errorToastOptions)
      }
    }
  }

  async populateStorageLocation(partNumber: string, plant: string) {
    const url1: string = `${environment.ServiceURL_Main}CfgProductionLotSize/GetSLocByPartNumberPlant?${new URLSearchParams({ partNumber: partNumber, plant: plant }).toString()}`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url1, "GET"))
      this.storageLocationDataSource = data
      this.storageLocationDropdown = Array.from(new Set(this.storageLocationDataSource.map(
        item => item.storageLocation
      )))
      //this.isStorageLocationDropdownReadOnly = false
    } catch (error) {
      this.resetStorageLocationData()
      if (error?.status === 404) {
        this.toastr.error(`PartNumber "${partNumber}", Plant "${plant}" not found`, null, errorToastOptions)
      }
    }
  }

  resetPlantData() {
    this.plantDataSource = null
    this.plantDropDown = null
    this.storageLocationDataSource = null
    this.storageLocationDropdown = null
  }

  resetStorageLocationData() {
    this.storageLocationDataSource = null
    this.storageLocationDropdown = null
  }
}
