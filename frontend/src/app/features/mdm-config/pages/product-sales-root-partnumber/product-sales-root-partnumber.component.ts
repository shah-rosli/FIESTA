import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { DeltaUploadComponent } from '../../../mdm-config/components/delta-upload/delta-upload.component'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { ConfigHistoryPopupComponent } from '../../../mdm-config/components/config-history-popup/config-history-popup.component'
import { firstValueFrom } from 'rxjs'

@Component({
  selector: 'app-product-sales-root-partnumber',
  templateUrl: './product-sales-root-partnumber.component.html',
  styleUrl: './product-sales-root-partnumber.component.scss'
})
export class ProductSalesRootPartnumberComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Product Sales Root PartNumber Master Maintenance"
  endpoint: string = "CfgProductSalesRootPartNumber"
  tableName: string = "CFG_PRODUCT_SALES_ROOT_PARTNUMBER"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    //"partNumberKey",
    //"partNumber",

    // "partDescription",
    // "publishedLeadTimeInWeeks",
    //"isPartRegisterable",
    "isPartSoleSource",
    // "canSample",
    // "canQuote",
    // "canContract",
    // "canOrder",
    // "canSearch",
    // "canDebit",
    // "canOpportunity",
    // "canRegister",
    // "canRotate",
    // "canForecast",
    // "canKit",
    // "isPartNonCancelableNonReschedule",
    // "isPartNotRecommendNewDesign",
    // "isPartPublish",
    // "canFlagMasterComments",
    // "autoApprThresholdFocusSales",
    // "autoApprThresholdNonFocusSales",
    // "autoApprThresholdFocusPL",
    // "autoApprThresholdNonFocusPL",
    // "sampleAutoApprQtyThreshold",
    // "sampleAutoApprTotalValThreshold",
    // "tacticalMarketingMgr",
    // "marketingMgr",
    // "applicationCode3Default",
    // "productHierarchyCode",
    "productHierarchy3Code",
    ////////////////////////////////////////////"productHierarchy3",
    // "productHierarchy2",
    // "productHierarchy1",
    "companyOfOrigin",
    // "materialType",
    // "isSalesRoot",
    // "goldenRecord",
    // "minimumOrderQuantity",
    // "frequencyOrderIncrement",
    "deleteFlag"
  ]

  fieldsRequired: string[] = [
    "partNumberKey",
    "partNumber",
    "companyOfOrigin",
    "deleteFlag"
  ]
  fieldsCreateOnly: string[] = [
    "partNumberKey",
    "partNumber"
  ]
  yesNoDataSource = ["Y", "N"]

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

  productHierarchy3DataSource: any[]
  // productHierarchy3DropDown: string[]

  companyOfOriginDataSource: any[]
  defaultValueDataSource: any[]


  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
  }

  async ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)

    await this.populateProductHierarchy3()
    this.setProductHierarchy3Value = this.setProductHierarchy3Value.bind(this)

    await this.populateCompanyOfOrigin()
    this.setCompanyOfOriginValue = this.setCompanyOfOriginValue.bind(this)

    await this.populateDefaultValue()

    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        if (
          !this.fieldsAllowEditing.includes(column.dataField) &&
          !this.fieldsCreateOnly.includes(column.dataField)
        ) {
          column.allowEditing = false
        } else {
          column.allowEditing = true
        }
        if (this.fieldsRequired.includes(column.dataField)) {
          column.validationRules = [{ type: 'required' }]
        }
        if (column.dataField === "productHierarchy3Code") {
          column.editCellTemplate = "productHierarchy3Editor"
          column.setCellValue = this.setProductHierarchy3Value
        }
        if (column.dataField === "companyOfOrigin") {
          column.editCellTemplate = "companyOfOriginEditor"
          column.setCellValue = this.setCompanyOfOriginValue
        }
        if (column.dataField === "deleteFlag") {
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
    console.log(e.data);
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
    for (const dataField of this.fieldsAllowEditing) {
      if (e.parentType === "dataRow" && e.dataField === dataField) {
        e.editorOptions.readOnly = false
      }
    }
    // editCellTemplate does not get triggered by onEditorPreparing
    // borrow the event from recordKey to set lineName and supplyLegacyLine readOnly
    if (e.parentType === "dataRow" && e.dataField === "recordKey") {
      // this.setLinesDropdownReadOnly(e)
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }
  onInitNewRow(e) {
    e.data.deleteFlag = "N"


    //e.data["isPartRegisterable"] = "999"


    if (this.defaultValueDataSource) {
      this.defaultValueDataSource.forEach(item => {
        if (item.PARAM_KEY) {
          //e.data[item.PARAM_KEY] = this.convertDefaultValue(item.PARAM_VALUE)
          //e.data[String(item.PARAM_KEY)] = this.convertDefaultValue(String(item.PARAM_VALUE));
          e.data[String(item.PARAM_KEY)] = String(item.PARAM_VALUE);

        }
      })
    }
  }
  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }
  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  async populateProductHierarchy3() {
    const url: string = `${environment.ServiceURL_Main}CfgProductSalesRootPartNumber/GetProductHierarchy3`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.productHierarchy3DataSource = data
      // this.productHierarchy3DropDown = Array.from(new Set(this.productHierarchy3DataSource.map(item => item.plant)))
    } catch (error) {
      this.resetProductHierarchy3Data()
      if (error?.status === 404) {
        this.toastr.error(`Product Hierarchy 3 Code:Name DropDown Error`, null, errorToastOptions)
      }
    }
  }

  resetProductHierarchy3Data() {
    this.productHierarchy3DataSource = null
    // this.productHierarchy3DropDown = null
  }

  async setProductHierarchy3Value(newData, value) {
    const filtered = this.productHierarchy3DataSource.filter(item =>
      item.phCode === value
    )
    newData.productHierarchy3Code = filtered[0].phCode
    newData.productHierarchy3Code = value

    newData.productHierarchy3 = filtered[0].phDescription

    const url = `${environment.ServiceURL_Main}CfgProductSalesRootPartNumber/GetProductHierarchy21?ProductHierarchy3=${encodeURIComponent(value)}`;

    try {
      const result = await firstValueFrom(this.send.sendRequest(url, "GET"));

      const level1 = result.find(x => x.level === "1");
      const level2 = result.find(x => x.level === "2");

      if (level1) {
        newData.productHierarchy1 = level1.phDescription;
      }

      if (level2) {
        newData.productHierarchy2 = level2.phDescription;
      }
    } catch (error) {
      console.error(error);
      this.toastr.error("Failed to load Product Hierarchy 1, Product Hierarchy 2", null, errorToastOptions);
    }
  }



  async populateCompanyOfOrigin() {
    const url: string = `${environment.ServiceURL_Main}CfgProductSalesRootPartNumber/GetCompanyOfOrigin`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.companyOfOriginDataSource = data
    } catch (error) {
      this.resetCompanyOfOriginData()
      if (error?.status === 404) {
        this.toastr.error(`Company Of Origin DropDown Error`, null, errorToastOptions)
      }
    }
  }

  resetCompanyOfOriginData() {
    this.productHierarchy3DataSource = null
    // this.productHierarchy3DropDown = null
  }

  setCompanyOfOriginValue(newData, value) {
    const filtered = this.companyOfOriginDataSource.filter(item =>
      item.phCode === value
    )
    newData.companyOfOrigin = filtered[0].phCode
    newData.companyOfOrigin = value



  }



  async populateDefaultValue() {
    const url: string = `${environment.ServiceURL_Main}CfgProductSalesRootPartNumber/GetDefaultValue`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.defaultValueDataSource = data
    } catch (error) {
      if (error?.status === 404) {
        this.toastr.error(`Default Value Error`, null, errorToastOptions)
      }
    }
  }

  convertDefaultValue(value: string) {
    if (value === "0" || value === "1") {
      return Number(value)
    }

    if (!isNaN(Number(value))) {
      return Number(value)
    }

    return value
  }
}