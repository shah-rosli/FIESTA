import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../delta-upload/delta-upload.component'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../config-history-popup/config-history-popup.component'

interface AddButtonData {
  partNumber: any,
  supplyPlant: any,
  supplyStorageLocation: any,
  supplyLegacyLine: any,
  priority: any,
  updateDateAndTime: any,
  lastUpdateBy: any,
}

@Component({
  selector: 'app-production-alt-priority',
  templateUrl: './production-alt-priority.component.html',
  styleUrls: ['./production-alt-priority.component.scss']
})
export class ProductionAltPriorityComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Production Priority Mix Ratios (Priority)"
  endpoint: string = "CfgProductionAlternativesMixRatios"
  tableName: string = "CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey = ["partNumber", "supplyPlant", "supplyStorageLocation"]
  fieldsAllowEditing: string[] = [
    "priority",
    "deleteFlag",
  ]
  fieldsCreateOnly: string[] = []
  yesNoDataSource = ["Y", "N"]
  addButtonData: AddButtonData

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

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
    this.onClickAddButton = this.onClickAddButton.bind(this)
    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
    this.resetAddButtonData()
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
      })
      mainColumns.push({
        type: "buttons",
        fixed: true,
        fixedPosition: "right",
        buttons: [
          {
            name: "edit",
            visible: this.pagePermission.edit //this.editAndHistoryButtonVisible
          },
          {
            hint: "Show History",
            text: "History",
            onClick: this.historyIconClick,
            visible: this.editAndHistoryButtonVisible
          },
          {
            // this right here is the add button
            hint: "Add row using current row data",
            text: "Add",
            onClick: this.onClickAddButton,
            visible: this.addButtonVisible
          }
        ]
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
    const ID = e.row.data.recordKey
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
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    e.data.partNumber = this.addButtonData.partNumber
    e.data.supplyPlant = this.addButtonData.supplyPlant
    e.data.supplyStorageLocation = this.addButtonData.supplyStorageLocation
    e.data.supplyLegacyLine = this.addButtonData.supplyLegacyLine
    e.data.priority = this.addButtonData.priority
    e.data.updateDateAndTime = this.addButtonData.updateDateAndTime
    e.data.lastUpdateBy = this.addButtonData.lastUpdateBy

    // default delete flag
    e.data.deleteFlag = "N"
    // clear
    this.resetAddButtonData()
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  resetAddButtonData() {
    this.addButtonData = {
      partNumber: null,
      supplyPlant: null,
      supplyStorageLocation: null,
      supplyLegacyLine: null,
      priority: null,
      updateDateAndTime: null,
      lastUpdateBy: null,
    }
  }

  addButtonVisible(option) {
    if (option.row.rowType === "data") {
      // if recordKey falsy
      if (!option.row.data.recordKey) {
        return true
      }
    }
    return false
  }

  editAndHistoryButtonVisible(option) {
    if (option.row.rowType === "data") {
      // if recordKey falsy
      if (!option.row.data.recordKey) {
        return false
      }
    }
    return true
  }

  onClickAddButton(e) {
    this.addButtonData = {
      partNumber: e.row.data.partNumber,
      supplyPlant: e.row.data.supplyPlant,
      supplyStorageLocation: e.row.data.supplyStorageLocation,
      supplyLegacyLine: e.row.data.supplyLegacyLine,
      priority: e.row.data.priority,
      updateDateAndTime: e.row.data.updateDateAndTime,
      lastUpdateBy: e.row.data.lastUpdateBy,
    }
    this.dataGrid.instance.addRow()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
