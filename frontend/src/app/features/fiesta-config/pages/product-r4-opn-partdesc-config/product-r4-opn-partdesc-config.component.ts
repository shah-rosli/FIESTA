import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../../components/delta-upload/delta-upload.component'
import { Column, EditorPreparingEvent, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../../components/config-history-popup/config-history-popup.component'

@Component({
  selector: 'app-product-r4-opn-partdesc-config',
  templateUrl: './product-r4-opn-partdesc-config.component.html',
  styleUrls: ['./product-r4-opn-partdesc-config.component.scss']
})
export class ProductR4OpnPartdescConfigComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "OPN (REL) Part Description Maintenance"
  endpoint: string = "CfgProductR4OpnPartDesc"
  tableName: string = "CFG_PRODUCT_R4_OPN_PARTDESC"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "partDescription",
    "deleteFlag",
  ]
  yesNoDataSource = ["Y", "N"]
  plmStatusDataSource = ["P1", "P2", "P3", "P4", "P5", "P6", "P7"]

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
    exportGridToExcel(e, fileName)
  }
}
