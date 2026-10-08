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
import { BaseService } from 'src/app/service/base/base.service'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../../components/config-history-popup/config-history-popup.component'
import { firstValueFrom } from 'rxjs'

@Component({
  selector: 'app-product-config',
  templateUrl: './product-config.component.html',
  styleUrl: './product-config.component.scss'
})
export class ProductConfigComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Product Maintenance"
  endpoint: string = "CfgProduct"
  tableName: string = "CFG_PRODUCT"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
  ]
  yesNoDataSource = ["Y", "N"]
  plmStatusDataSource = ["P1", "P2", "P3", "P4", "P5", "P6", "P7"]

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  assignedUserGroups: string[]

  businessPlannerCodeDataSource: any[]

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

  async ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)
    this.pagePermission = this.permission.getUserPermissions()

    await this.populateBusinessPlannerCode()
    //this.setBusinessPlannerCodeValue = this.setBusinessPlannerCodeValue.bind(this)

    this.configureEditableFields()
    this.configureColumns()
  }

  configureEditableFields() {
    const url: string = `${environment.ServiceURL_Main}CfgUserGroup/GetUserUserGroups/${this.base.getUserInfo("USER_ID")}`
    this.send.sendRequest(url, "GET", "").subscribe(
      data => {
        this.assignedUserGroups = data.map(item => item.USER_GROUP_NAME)
        if (this.assignedUserGroups.includes("IT Super Admin") || this.assignedUserGroups.includes("Power User")) {
          this.fieldsAllowEditing.push(
            ...[
              "plmStatus",
              "totalShelfLife",
              "minimumOrderQuantity",
              "standardPackingQuantity",
              "businessPlannerCode",
              "deleteFlag",
            ]
          )
        }
        if (this.assignedUserGroups.includes("OPN Maintenance") || this.assignedUserGroups.includes("MPN Maintenance")) {
          this.fieldsAllowEditing.push("partDescription")
        }
      }
    )
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
        if (column.dataField === "plmStatus") {
          column.lookup = {
            dataSource: this.plmStatusDataSource
          }
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
        if (column.dataField === "businessPlannerCode") {
          column.editCellTemplate = "businessPlannerCodeEditor"
          ///////////////////////column.setCellValue = this.setBusinessPlannerCodeValue
          // column.lookup = {
          //   dataSource: this.businessPlannerCodeDataSource
          // }
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
    if (e.parentType !== "dataRow") {
      return
    }

    // incoming e.editorOptions.readOnly value is based on column.allowEditing

    const row = e.row.data

    if (e.dataField === "partDescription") {
      e.editorOptions.readOnly = true
      if (row.materialType === "ZFER" && this.assignedUserGroups.includes("OPN Maintenance")) {
        e.editorOptions.readOnly = false
      }
      if (row.materialType === "ZHAL" && this.assignedUserGroups.includes("MPN Maintenance")) {
        e.editorOptions.readOnly = false
      }
    }
    if (e.dataField === "plmStatus") {
      const found = this.plmStatusDataSource.find(item => item === e.editorOptions.value)
      if (!found) {
        e.editorOptions.value = null
      }
      if (["ZHAL", "ZROH"].includes(row.materialType) && row.legacyOrganization === "REL") {
        e.editorOptions.readOnly = false
      } else {
        e.editorOptions.readOnly = true
      }
    }
    if (e.dataField === "totalShelfLife") {
      if (row.legacyOrganization == "REL") {
        e.editorOptions.readOnly = true
      }
    }
    if (e.dataField === "minimumOrderQuantity") {
      // if (!(row.materialType === "ZFER")) {
      //   e.editorOptions.readOnly = true
      // } else {
      //   e.editorOptions.readOnly = false
      // }

      // e.editorOptions.onValueChanged = (valueChangedEvent: any) => {
      //   this.onMinimumOrderQuantityChanged(e, valueChangedEvent);
      // };
      e.editorOptions.min = 0;
      e.editorOptions.showSpinButtons = true;

      if (e.row.data.materialType !== "ZFER") {
        e.editorOptions.readOnly = true;
      } else {
        e.editorOptions.readOnly = false;
      }

      e.editorOptions.onValueChanged = (args: any) => {
        this.onMinimumOrderQuantityChanged(e, args);
      };

    }
    if (e.dataField === "standardPackingQuantity") {
      if (!(row.legacyOrganization === "REL" && row.materialType === "ZFER")) {
        e.editorOptions.readOnly = true
      }
    }

    if (e.dataField === "businessPlannerCode") {
      if (["ZFER", "ZHAL"].includes(row.materialType) && ["DLG", "IDT", "ISL", "REL"].includes(row.legacyOrganization)) {
        e.editorOptions.readOnly = false
        //e.editorOptions.searchEnabled = false
        e.editorOptions.acceptCustomValue = false
        e.editorOptions.openOnFieldClick = true
      } else {
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
    //return !this.dataGrid?.instance.hasEditData()
    if (this.dataGrid?.instance.hasEditData()) {
      return false
    } else {
      return true
    }
  }

  hasUnsavedChanges(): boolean {
    return this.dataGrid?.instance?.hasEditData() ?? false;
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  async populateBusinessPlannerCode() {
    const url: string = `${environment.ServiceURL_Main}CfgProduct/GetBusinessPlannerCodeList`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.businessPlannerCodeDataSource = data.data.map(item => item.businessPlannerCode)
    } catch (error) {
      if (error?.status === 404) {
        this.toastr.error(`Error 404`, null, errorToastOptions)
      }
    }
  }

  onBusinessPlannerCodeChanged(cellInfo: any, e: any): void {
    if (e.value === cellInfo.value) {
      return;
    }

    cellInfo.component.cellValue(
      cellInfo.rowIndex,
      "businessPlannerCode",
      e.value
    );
  }

  onMinimumOrderQuantityChanged(editorEvent: EditorPreparingEvent, args: any): void {
    if (args.value === args.previousValue) {
      return;
    }
    const rowIndex = editorEvent.row?.rowIndex;
    if (rowIndex === undefined || rowIndex === null) {
      return;
    }
    //console.log('before:', this.dataGrid?.instance.hasEditData());
    editorEvent.component.cellValue(
      rowIndex,
      'minimumOrderQuantity',
      args.value
    );
    //console.log('after:', this.dataGrid?.instance.hasEditData());
  }

  // setBusinessPlannerCodeValue(newData: any, value: string): void {
  //   console.log('setCellValue called:', value);

  //   newData.businessPlannerCode = value;
  // }
}
