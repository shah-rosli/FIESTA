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
import { finalize, forkJoin, lastValueFrom } from 'rxjs'
import { ProductionPlantConversion } from '../../interfaces/production-plant-conv'

@Component({
  selector: 'app-yield-pattern-backend',
  templateUrl: './yield-pattern-backend.component.html',
  styleUrl: './yield-pattern-backend.component.scss'
})
export class YieldPatternBackendComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Yield Pattern (Backend)"
  endpoint: string = "CfgYieldBackendPattern"
  tableName: string = "CFG_YIELD_BACKEND_PATTERN"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  image: string = "/content/yield-pattern-backend-1b2l3t.png"
  isLoadPanelVisible: boolean = false
  fieldsForCreate: string[] = []
  fieldsForEdit: string[] = [
    "validFromDate",
    "yield",
    "remark",
    "deleteFlag"
  ]
  yesNoDataSource = ["Y", "N"]

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  patternDataSource: string[]
  rrSiteDataSource: any
  willCreateOrEdit: "create" | "edit" = null
  isRrSiteDropdownReadOnly: boolean = false

  productionPlantConversion: ProductionPlantConversion[]

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
    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        if (column.dataField === "deleteFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
        if (column.dataField === "pattern") {
          column.lookup = {
            dataSource: this.patternDataSource
          }
          const that = this
          column.setCellValue = function (newData, value, currentRowData) {
            return that.setPatternValue.apply(this, [newData, value, currentRowData, that])
          }
        }
        if (column.dataField === "RRSite") {
          column.editCellTemplate = "rrSiteDropdownEditor"
        }
        if (column.dataField === "plant") {
          column.lookup = {
            dataSource: () => this.getLookupPlant(),
          }
          column.setCellValue = this.setPlantValue
        }
        if (column.dataField === "storageLocation") {
          column.lookup = {
            dataSource: (options) => this.getLookupStorageLocation(options),
          }
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

    const handlePatternResult = (result) => {
      this.patternDataSource = result
    }

    const handleRrSiteResult = (result) => {
      this.rrSiteDataSource = result
    }

    const handleproductionPlantConvResult = (result) => {
      this.productionPlantConversion = result.data
      this.productionPlantConversion.sort((a, b) => a.plant.localeCompare(b.plant)) //order by "plant"
    }

    const handleColumnConfigResult = (result) => {
      this.columnConfig = createMainColumns(result)
      this.deltaUploadColumnConfig = result
      this.historyColumnConfig = createHistoryColumns(result)

      this.setDataSource()
    }

    const patternUrl: string = `${environment.ServiceURL_Main}CfgSysColumnConfig/GetPatternListing?tableName=${this.tableName}`
    const rrSiteUrl: string = `${environment.ServiceURL_Main}CfgRRSite/GetDropdownList`
    const productionPlantConvUrl: string = `${environment.ServiceURL_Main}MdmProductionPlantConversion`
    const columnConfigUrl: string = `${environment.ServiceURL_Main}CfgSysTableConfig/GetColumnConfigByTableName?tableName=${this.tableName}`

    this.isLoadPanelVisible = true

    forkJoin([
      this.send.sendRequest(patternUrl, "GET", ""),
      this.send.sendRequest(rrSiteUrl, "GET", ""),
      this.send.sendRequest(productionPlantConvUrl, "GET", ""),
      this.send.sendRequest(columnConfigUrl, "GET", "")
    ])
      .pipe(finalize(() => this.isLoadPanelVisible = false))
      .subscribe(([patternResult, rrSiteResult, productionPlantConvResult, columnConfigResult]) => {
        handlePatternResult(patternResult)
        handleRrSiteResult(rrSiteResult)
        handleproductionPlantConvResult(productionPlantConvResult)
        handleColumnConfigResult(columnConfigResult)
      })
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

  customizeItem = (item) => {
    if (this.willCreateOrEdit === "create") {
      if (this.fieldsForCreate.includes(item.dataField)) {
        item.isRequired = true
      }
    }
    if (this.willCreateOrEdit === "edit") {
      if (this.fieldsForEdit.includes(item.dataField)) {
        item.isRequired = true
      }
    }
    if (item.dataField === "remark") {
      item.isRequired = false
    }
  }

  onEditorPreparing(e) {
    if (e.row.isNewRow) {
      if (e.parentType === "dataRow" && this.fieldsForCreate.includes(e.dataField)) {
        e.editorOptions.readOnly = false
      } else {
        e.editorOptions.readOnly = true
      }
    }

    if (!e.row.isNewRow) {
      if (e.parentType === "dataRow" && this.fieldsForEdit.includes(e.dataField)) {
        e.editorOptions.readOnly = false
      } else {
        e.editorOptions.readOnly = true
      }
    }

    // editCellTemplate does not get triggered by onEditorPreparing
    // borrow the event from recordKey to set rrSite readOnly
    if (e.parentType === "dataRow" && e.dataField === "recordKey") {
      this.setRrSiteDropdownReadOnly(e)
    }
  }

  setRrSiteDropdownReadOnly(e) {
    if (e.row.isNewRow) {
      if (this.fieldsForCreate.includes("RRSite")) {
        this.isRrSiteDropdownReadOnly = false
      } else {
        this.isRrSiteDropdownReadOnly = true
      }
    }

    if (!e.row.isNewRow) {
      this.isRrSiteDropdownReadOnly = true
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    this.willCreateOrEdit = "create"
    this.fieldsForCreate = ["pattern", "remark"]
    e.data.deleteFlag = "N"
  }

  onEditingStart() {
    this.willCreateOrEdit = "edit"
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  getLookupPlant() {
    return Array.from(new Set(this.productionPlantConversion.map(item => item.plant)))
  }

  getLookupStorageLocation(options: any) {
    const filtered = options.data
      ? this.productionPlantConversion
        .filter(item => item.plant === options.data.plant)
      : this.productionPlantConversion
    const mapped = filtered.map(item => item.storageLocation)
    return Array.from(new Set(mapped))
  }

  setPatternValue(this, newData, value, currentRowData, componentContext) {
    const patternUrl: string = `${environment.ServiceURL_Main}CfgSysColumnConfig/GetPatternRequiredFields?tableName=${componentContext.tableName}&pattern=${value}`

    for (const dataField of componentContext.fieldsForCreate) {
      newData[dataField] = null
    }

    return lastValueFrom(componentContext.send.sendRequest(patternUrl, "GET", "")).then((dataFields: string[]) => {
      componentContext.fieldsForCreate = ["pattern", "remark", ...dataFields]
      this.defaultSetCellValue(newData, value)
    })
  }

  setPlantValue(this, newData, value, currentRowData) {
    newData.storageLocation = null
    this.defaultSetCellValue(newData, value)
  }

  rrSiteDropdownDisplayExpr(data) {
    return data ? `${data.siteID} - ${data.siteName}` : ""
  }

  handleRowPrepared(e: any): void {
    if (e.rowType !== 'data') return;

    const deleteFlag = e.data?.deleteFlag;

    if (deleteFlag === 'Y') {
      e.rowElement.style.color = 'red';
    }
  }
}