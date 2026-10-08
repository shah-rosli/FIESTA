import { Component, inject, ViewChild } from '@angular/core'
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
import { ProductionPlantConversion } from 'src/app/features/fiesta-config/interfaces/production-plant-conv'
import { firstValueFrom } from 'rxjs'
import CustomStore from "devextreme/data/custom_store"
import { BaseService } from "src/app/service/base/base.service"
import { normalizeToArray } from 'src/app/shared/utils/normalizeToArray'

@Component({
  selector: 'app-product-canflag-pattern',
  templateUrl: './product-canflag-pattern.component.html',
  styleUrl: './product-canflag-pattern.component.scss'
})
export class ProductCanflagPatternComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  private base = inject(BaseService)

  PageTitle: string = "Product Can Flag Pattern Maintenance"
  endpoint: string = "CfgProductCanFlagPattern"
  tableName: string = "CFG_PRODUCT_CANFLAG_PATTERN"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  //image: string = "/content/leadtime-pattern-backend-7v8d3e.png"
  image: string = "/content/can-flag-pattern.png"
  isLoadPanelVisible: boolean = false
  fieldsForCreate: string[] = []
  fieldsForEdit: string[] = [
    "publishedLeadTimeInWeeks",
    "isPartRegisterable",
    "isPartSoleSource",
    "canSample",
    "canQuote",
    "canContract",
    "canOrder",
    "canSearch",
    "canDebit",
    "canOpportunity",
    "canRegister",
    "canRotate",
    "canForecast",
    "canKit",
    "isPartNotRecommendNewDesign",
    "isPartNonCancelableNonReschedule",
    "isPartPublish",
    "canFlagMasterComments",
    "autoApprThresholdFocusSales",
    "autoApprThresholdNonFocusSales",
    "autoApprThresholdFocusPL",
    "autoApprThresholdNonFocusPL",
    "sampleAutoApprQtyThreshold",
    "sampleAutoApprTotalValThreshold",
    "tacticalMarketingMgr",
    "marketingMgr",
    "applicationCode3Default",
    "remark",
    "deleteFlag"
  ]

  fieldsNotRequired: string[] = [
    "publishedLeadTimeInWeeks",
    "isPartRegisterable",
    "isPartSoleSource",
    "canSample",
    "canQuote",
    "canContract",
    "canOrder",
    "canSearch",
    "canDebit",
    "canOpportunity",
    "canRegister",
    "canRotate",
    "canForecast",
    "canKit",
    "isPartNotRecommendNewDesign",
    "isPartNonCancelableNonReschedule",
    "isPartPublish",
    "canFlagMasterComments",
    "autoApprThresholdFocusSales",
    "autoApprThresholdNonFocusSales",
    "autoApprThresholdFocusPL",
    "autoApprThresholdNonFocusPL",
    "sampleAutoApprQtyThreshold",
    "sampleAutoApprTotalValThreshold",
    "tacticalMarketingMgr",
    "marketingMgr",
    "applicationCode3Default",
    "remark"
  ]

  PLMStatusDropDown: string[] = [
    "P1",
    "P2",
    "P3",
    "P4",
    "P5",
    "P6",
    "P7"
  ]

  productHierarchy1DataSource: any[]
  productHierarchy1DropDown: any[]

  productHierarchy2DataSource: any[]
  productHierarchy2DropDown: any[]

  productHierarchy3DataSource: any[]
  productHierarchy3DropDown: any[]

  productHierarchy4DataSource: any[]
  productHierarchy4DropDown: any

  productHierarchy5DataSource: any[]
  productHierarchy5DropDown: any
  // fieldsForRequired: string[] = [
  //   "pattern",
  //   "partNumber",
  //   "plmStatus",
  //   "productHierarchy1",
  //   "productHierarchy2",
  //   "productHierarchy3",
  //   "productHierarchy4",
  //   "productHierarchy5",
  //   "deleteFlag"
  // ]

  yesNoDataSource = ["Y", "N"]
  oneZeroDataSource = ["1", "0"]
  // yesNoData10Source = [
  //   { value: '1', text: 'Y' },
  //   { value: '0', text: 'N' }
  // ]

  columnConfig: Column[]
  deltaUploadColumnConfig: Column[]
  historyColumnConfig: Column[]

  patternDataSource: string[]
  rrSiteDataSource: any
  willCreateOrEdit: "create" | "edit" = null
  isRrSiteDropdownReadOnly: boolean = false

  productionPlantConversion: ProductionPlantConversion[]

  partNumberDataSource: any[]
  partNumberDropDown: any //refresh with search text changed

  applicationLevel3CodeDataSource: any[]
  applicationLevel3CodeDropDown: string[]

  //add by Keith 20260928, to disable all users to edit Pattern P070
  private allowEditPopup = false
  private validatingOpn = false

  isSuperAdmin = false

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

  async ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)

    this.isSuperAdmin = normalizeToArray(this.base.getUserInfo("USER_GROUPS")).includes("Fiesta Admin") //added 29-sep-2026, for "Pattern P070 is non-editable by all users, except IT admin."

    await this.populateProductHierarchy()
    // this.setProductHierarchy1Value = this.setProductHierarchy1Value.bind(this)
    // this.setProductHierarchy2Value = this.setProductHierarchy2Value.bind(this)
    // this.setProductHierarchy3Value = this.setProductHierarchy3Value.bind(this)
    // this.setProductHierarchy4Value = this.setProductHierarchy4Value.bind(this)
    // this.setProductHierarchy5Value = this.setProductHierarchy5Value.bind(this)
    await this.populatePH4()
    await this.populatePH5()

    await this.populatePartNumber()
    this.setOPNValue = this.setOPNValue.bind(this)

    await this.populateApplicationCode3Default()
    this.setApplicationCode3DefaultValue = this.setApplicationCode3DefaultValue.bind(this)

    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        // if (
        //   !this.fieldsForEdit.includes(column.dataField) //&&
        //   //!this.fieldsCreateOnly.includes(column.dataField)
        // ) {
        //   column.allowEditing = false
        // } else {
        //   column.allowEditing = true
        // }


        // if (column.dataField === 'autoApprThresholdFocusSales') {
        //   column.lookup = {
        //     dataSource: this.yesNoDataSource,
        //     valueExpr: 'value',     // value saved: '1' or '0'
        //     displayExpr: 'text'     // value displayed: Y or N
        //   }
        // }

        if (column.dataField === "pattern") {
          column.lookup = {
            dataSource: this.patternDataSource
          }
          const that = this
          column.setCellValue = function (newData, value, currentRowData) {
            return that.setPatternValue.apply(this, [newData, value, currentRowData, that])
          }
        }

        if (column.dataField === "plmStatus") {
          column.lookup = {
            dataSource: this.PLMStatusDropDown
            //return Array.from(new Set(this.productionPlantConversion.map(item => item.plant)))
          }
        }

        if (column.dataField === "productHierarchy1") {
          column.editCellTemplate = "productHierarchy1Editor"
          // column.lookup = {
          //   dataSource: this.productHierarchy1DropDown,
          //   valueExpr: "phCode",
          //   displayExpr: "display"
          // };
          // column.cellTemplate = (cellElement: HTMLElement, cellInfo: any) => {
          //   cellElement.textContent = cellInfo.value ?? "";
          // };
        }
        if (column.dataField === "productHierarchy2") {
          column.editCellTemplate = "productHierarchy2Editor"
          // column.lookup = {
          //   dataSource: this.productHierarchy2DropDown,
          //   valueExpr: "phCode",
          //   displayExpr: "display"
          // };
          // column.cellTemplate = (cellElement: HTMLElement, cellInfo: any) => {
          //   // Grid cell display: only phCode
          //   cellElement.textContent = cellInfo.value ?? "";
          // };
        }
        if (column.dataField === "productHierarchy3") {
          column.editCellTemplate = "productHierarchy3Editor"
          // column.lookup = {
          //   dataSource: this.productHierarchy3DropDown,
          //   valueExpr: "phCode",
          //   displayExpr: "display"
          // };
          // column.cellTemplate = (cellElement: HTMLElement, cellInfo: any) => {
          //   cellElement.textContent = cellInfo.value ?? "";
          // };
        }
        if (column.dataField === "productHierarchy4") {
          column.editCellTemplate = "productHierarchy4Editor"
          // column.lookup = {
          //   dataSource: this.productHierarchy4DropDown,
          //   valueExpr: "phCode",
          //   displayExpr: "display"
          // };
          // column.cellTemplate = (cellElement: HTMLElement, cellInfo: any) => {
          //   // Grid cell display: only phCode
          //   cellElement.textContent = cellInfo.value ?? "";
          // };

          // column.formItem = {
          //   editorType: "dxSelectBox",
          //   editorOptions: {
          //     dataSource: this.productHierarchy4DropDown,
          //     valueExpr: "phCode",
          //     displayExpr: "display",
          //     searchEnabled: true,
          //     showDataBeforeSearch: false,
          //     minSearchLength: 1,
          //     acceptCustomValue: false
          //   }
          // };
        }
        if (column.dataField === "productHierarchy5") {
          column.editCellTemplate = "productHierarchy5Editor"

          // column.lookup = {
          //   dataSource: this.productHierarchy5DropDown,
          //   valueExpr: "phCode",
          //   displayExpr: "display"
          // };
          // column.cellTemplate = (cellElement: HTMLElement, cellInfo: any) => {
          //   // Grid cell display: only phCode
          //   cellElement.textContent = cellInfo.value ?? "";
          // };

          // column.formItem = {
          //   editorType: "dxSelectBox",
          //   editorOptions: {
          //     dataSource: this.productHierarchy5DropDown,
          //     valueExpr: "phCode",
          //     displayExpr: "display",
          //     searchEnabled: true,
          //     showDataBeforeSearch: false,
          //     minSearchLength: 1,
          //     acceptCustomValue: false
          //   }
          // };
        }

        if (column.dataField === "partNumber") {
          column.editCellTemplate = "partNumberEditor"
          // column.setCellValue = this.setOPNValue

          // column.lookup = {
          //   dataSource: this.partNumberDropDown,
          //   valueExpr: "partNumber",
          //   displayExpr: "partNumber"
          // };
        }





        if (column.dataField === "isPartRegisterable") {
          // column.editCellTemplate = "isPartRegisterableEditor"
          // column.setCellValue = function (newData, value, currentRowData) {
          //   newData[this.dataField] = value === undefined ? null : value;
          // }
          column.lookup = { dataSource: this.oneZeroDataSource }

        }
        if (column.dataField === "isPartSoleSource") {
          // column.editCellTemplate = "isPartSoleSourceEditor"
          // column.setCellValue = function (newData, value, currentRowData) {
          //   newData[this.dataField] = value === undefined ? null : value;
          // }
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canSample") {
          // column.editCellTemplate = "canSampleEditor"
          // column.setCellValue = function (newData, value, currentRowData) {
          //   newData[this.dataField] = value === undefined ? null : value;
          // }
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canQuote") {
          // column.editCellTemplate = "canQuoteEditor"
          // column.setCellValue = function (newData, value, currentRowData) {
          //   newData[this.dataField] = value === undefined ? null : value;
          // }
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canContract") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canOrder") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canSearch") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canDebit") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canOpportunity") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canRegister") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canRotate") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canForecast") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "canKit") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "isPartNotRecommendNewDesign") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "isPartNonCancelableNonReschedule") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }
        if (column.dataField === "isPartPublish") {
          column.lookup = { dataSource: this.oneZeroDataSource }
        }

        if (column.dataField === "canFlagMasterComments"
          || column.dataField === "autoApprThresholdFocusSales"
          || column.dataField === "autoApprThresholdNonFocusSales"
          || column.dataField === "autoApprThresholdFocusPL"
          || column.dataField === "autoApprThresholdNonFocusPL"
          || column.dataField === "sampleAutoApprQtyThreshold"
          || column.dataField === "sampleAutoApprTotalValThreshold"
          || column.dataField === "tacticalMarketingMgr"
          || column.dataField === "marketingMgr"
        ) {
          column.editorOptions = {
            ...column.editorOptions,
            maxLength: 70
          }
        }

        if (column.dataField === "applicationCode3Default") {
          column.editCellTemplate = "applicationCode3DefaultEditor"
          // column.lookup = {
          //   dataSource: this.applicationLevel3CodeDropDown
          // }
        }



        if (column.dataField === "deleteFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
        // if (column.dataField === "productHierarchy1") {
        //   column.editCellTemplate = "productHierarchy1Editor"
        //   column.setCellValue = this.setProductHierarchy1Value
        // }
        // if (column.dataField === "productHierarchy2") {
        //   column.editCellTemplate = "productHierarchy2Editor"
        //   column.setCellValue = this.setProductHierarchy2Value
        // }
        // if (column.dataField === "productHierarchy3") {
        //   column.editCellTemplate = "productHierarchy3Editor"
        //   column.setCellValue = this.setProductHierarchy3Value
        // }
        // if (column.dataField === "productHierarchy4") {
        //   column.editCellTemplate = "productHierarchy4Editor"
        //   column.setCellValue = this.setProductHierarchy4Value
        // }
        // if (column.dataField === "productHierarchy5") {
        //   column.editCellTemplate = "productHierarchy5Editor"
        //   column.setCellValue = this.setProductHierarchy5Value
        // }

        // if (column.dataField === "RRSite") {
        //   column.editCellTemplate = "rrSiteDropdownEditor"
        // }
        // if (column.dataField === "plant") {
        //   column.lookup = {
        //     dataSource: () => this.getLookupPlant(),
        //   }
        //   column.setCellValue = this.setPlantValue
        // }
        // if (column.dataField === "storageLocation") {
        //   column.lookup = {
        //     dataSource: (options) => this.getLookupStorageLocation(options),
        //   }
        // }
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

    if (this.fieldsNotRequired.includes(item.dataField)) {
      item.isRequired = false
    }
    // if (item.dataField === "remark") {
    //   item.isRequired = false
    // }
    // if (item.dataField === "publishedLeadTimeInWeeks") {
    //   item.isRequired = false
    // }

    // const allowEditing = this.dataGrid?.instance.columnOption(item.dataField, "allowEditing") !== false

    // item.isRequired = allowEditing && this.fieldsForRequired.includes(item.dataField)
    // if (this.fieldsNotRequired.includes(item.dataField)) {
    //   if (item.column.allowEditing) {
    //     item.isRequired = true
    //   } else {
    //     item.isRequired = false
    //   }
    // } else {
    //   item.isRequired = false
    // }



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

    if (e.parentType === "dataRow" && e.dataField === "recordKey") {
      //this.setRrSiteDropdownReadOnly(e)
    }
  }

  isFieldReadOnly(dataField: string): boolean {
    const editableFields = this.willCreateOrEdit === "create" ? this.fieldsForCreate : this.fieldsForEdit;
    return !editableFields.includes(dataField);
  }

  // setRrSiteDropdownReadOnly(e) {
  //   if (e.row.isNewRow) {
  //     if (this.fieldsForCreate.includes("productHierarchy5")) {
  //       this.isRrSiteDropdownReadOnly = false
  //     } else {
  //       this.isRrSiteDropdownReadOnly = true
  //     }
  //   }

  //   if (!e.row.isNewRow) {
  //     this.isRrSiteDropdownReadOnly = true
  //   }
  // }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    this.willCreateOrEdit = "create"
    this.fieldsForCreate = ["pattern"
      //,
      // "publishedLeadTimeInWeeks",
      // "isPartRegisterable",
      // "isPartSoleSource",
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
      // "isPartNotRecommendNewDesign",
      // "isPartNonCancelableNonReschedule",
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
      // "remark",
      //"deleteFlag"
    ]
    e.data.deleteFlag = "N"
  }

  // onEditingStart() {
  //   this.willCreateOrEdit = "edit"
  // }

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
      if (dataField != "deleteFlag") {
        newData[dataField] = null
      }
    }

    return lastValueFrom(componentContext.send.sendRequest(patternUrl, "GET", "")).then((dataFields: string[]) => {
      //componentContext.fieldsForCreate = ["pattern", "remark", "publishedLeadTimeInWeeks", "isPartRegisterable", ...dataFields]
      componentContext.fieldsForCreate = ["pattern", ...dataFields, ...componentContext.fieldsForEdit] //

      //componentContext.dataGrid?.instance.repaint();

      this.defaultSetCellValue(newData, value)

      // const disablePH5 = !componentContext.fieldsForCreate.includes(
      //   "productHierarchy5"
      // );
      // setTimeout(() => {
      //   const form = componentContext.dataGrid?.instance
      //     .getController("editing")
      //     ?.getEditForm?.();
      //   const ph5Editor = form?.getEditor("productHierarchy5");
      //   if (ph5Editor) {
      //     ph5Editor.option("disabled", disablePH5);
      //   }
      // });
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

  async populateProductHierarchy() {
    const url: string = `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetProductHierarchy123`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))

      this.productHierarchy1DataSource = data.filter(
        item => String(item.level) === "1"
      )
      this.productHierarchy1DropDown = this.productHierarchy1DataSource;
      // this.productHierarchy1DropDown = this.productHierarchy1DataSource.map(
      //   item => item.phCode
      // )

      this.productHierarchy2DataSource = data.filter(
        item => String(item.level) === "2"
      )
      this.productHierarchy2DropDown = this.productHierarchy2DataSource;
      // this.productHierarchy2DropDown = this.productHierarchy2DataSource.map(
      //   item => item.phCode
      // )

      this.productHierarchy3DataSource = data.filter(
        item => String(item.level) === "3"
      )
      this.productHierarchy3DropDown = this.productHierarchy3DataSource;
      // this.productHierarchy3DropDown = this.productHierarchy3DataSource.map(
      //   item => item.phCode
      // )

      // this.productHierarchy4DataSource = data.filter(
      //   item => String(item.level) === "4"
      // )
      // this.productHierarchy4DropDown = this.productHierarchy4DataSource;

      // this.productHierarchy5DataSource = data.filter(
      //   item => String(item.level) === "5"
      // )
      // this.productHierarchy5DropDown = this.productHierarchy5DataSource;



      // this.plantDataSource = data
      // this.plantDropDown = Array.from(new Set(this.plantDataSource.map(item => item.plant)))
    } catch (error) {
      // this.resetProductHierarchy1Data()
      if (error?.status === 404) {
        this.toastr.error(`Product Hierarchy DropDown Error`, null, errorToastOptions)
      }
    }
  }

  // async populatePartNumber(existingPartNumber?: string) {
  //   this.partNumberDropDown = {
  //     store: new CustomStore({
  //       key: "partNumber",

  //       load: async (loadOptions) => {
  //         const search = loadOptions.searchValue || "";

  //         const data: any[] = await firstValueFrom(
  //           this.send.sendRequest(
  //             `${environment.ServiceURL_Main}CfgProductCanFlagPattern/SearchPartNumber?search=${encodeURIComponent(search)}`,
  //             "GET"
  //           )
  //         );

  //         if (!data || data.length === 0) {
  //           this.toastr.warning(
  //             "Part Number Not Found",
  //             "",
  //             { timeOut: 3000 }
  //           );
  //         }
  //         return data;
  //       }
  //       ,
  //       byKey: async (key) => {
  //         const data: any[] = await firstValueFrom(
  //           this.send.sendRequest(
  //             `${environment.ServiceURL_Main}CfgProductCanFlagPattern/SearchPartNumber?search=${encodeURIComponent(key)}`,
  //             "GET"
  //           )
  //         );
  //         return data.find(x => x.partNumber === key);
  //       }
  //     })
  //   };
  // }

  async populatePartNumber(existingPartNumber?: string) {
    this.partNumberDropDown = {
      store: new CustomStore({
        key: "partNumber",

        load: async (loadOptions) => {
          const search = loadOptions.searchValue || "";

          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductCanFlagPattern/SearchPartNumber?search=${encodeURIComponent(search)}`,
              "GET"
            )
          );

          const result = data ? [...data] : [];

          // Add existingPartNumber if not already in dropdown list
          if (
            existingPartNumber &&
            !result.some(x => x.partNumber === existingPartNumber)
          ) {
            result.unshift({
              partNumber: existingPartNumber
            });
          }

          if (!result || result.length === 0) {
            this.toastr.warning(
              "Part Number Not Found",
              "",
              { timeOut: 3000 }
            );
          }

          return result;
        },

        byKey: async (key) => {
          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductCanFlagPattern/SearchPartNumber?search=${encodeURIComponent(key)}`,
              "GET"
            )
          );

          const found = data?.find(x => x.partNumber === key);

          // If API does not return it, use existingPartNumber
          if (!found && existingPartNumber === key) {
            return {
              partNumber: existingPartNumber
            };
          }

          return found;
        }
      })
    };
  }

  async populatePH4() {
    this.productHierarchy4DropDown = {
      store: new CustomStore({
        key: "phCode",

        load: async (loadOptions) => {
          const search = loadOptions.searchValue || "";

          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetProductHierarchyLive?level=4&search=${encodeURIComponent(search)}`,
              "GET"
            )
          );

          if (!data?.length && search) {
            this.toastr.warning(
              "Product Hierarchy 4 Not Found",
              "",
              { timeOut: 3000 }
            );
          }

          return data;
        },

        byKey: async (key) => {
          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetProductHierarchyLive?level=4&search=${encodeURIComponent(key)}`,
              "GET"
            )
          );

          return data.find(x => x.phCode === key);
        }
      })
    };
  }

  async populatePH5() {
    this.productHierarchy5DropDown = {
      store: new CustomStore({
        key: "phCode",

        load: async (loadOptions) => {
          const search = loadOptions.searchValue || "";

          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetProductHierarchyLive?level=5&search=${encodeURIComponent(search)}`,
              "GET"
            )
          );

          if (!data?.length && search) {
            this.toastr.warning(
              "Product Hierarchy 5 Not Found",
              "",
              { timeOut: 3000 }
            );
          }

          return data;
        },

        byKey: async (key) => {
          const data: any[] = await firstValueFrom(
            this.send.sendRequest(
              `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetProductHierarchyLive?level=5&search=${encodeURIComponent(key)}`,
              "GET"
            )
          );

          return data.find(x => x.phCode === key);
        }
      })
    };
  }

  setOPNValue(newData, value) {
    newData.partNumber = value;
  }

  // async populateApplicationCode3Default() {
  //   const url: string = `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetApplicationLevel3Code`
  //   try {
  //     const data = await firstValueFrom(this.send.sendRequest(url, "GET"))

  //     this.applicationLevel3CodeDataSource = data
  //     this.applicationLevel3CodeDropDown = Array.from(new Set(this.applicationLevel3CodeDataSource.map(item => item.applicationLevel3Code)))
  //   } catch (error) {
  //     //this.resetProductHierarchy1Data()
  //     if (error?.status === 404) {
  //       this.toastr.error(`Default Application Code (Level 3) DropDown Error`, null, errorToastOptions)
  //     }
  //   }
  // }

  async populateApplicationCode3Default(existingValue?: string) {
    const url = `${environment.ServiceURL_Main}CfgProductCanFlagPattern/GetApplicationLevel3Code`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.applicationLevel3CodeDataSource = data

      const dropdown = Array.from(
        new Set(
          this.applicationLevel3CodeDataSource
            .map(item => item.applicationLevel3Code)
            .filter(Boolean)
        )
      )

      if (existingValue && !dropdown.includes(existingValue)) {
        dropdown.unshift(existingValue)
      }

      this.applicationLevel3CodeDropDown = dropdown
    } catch (error) {
      if (error?.status === 404) {
        this.toastr.error(`Default Application Code (Level 3) DropDown Error`, null, errorToastOptions)
      }
    }
  }

  setApplicationCode3DefaultValue(newData, value) {
    newData.applicationCode3Default = value;
  }

  //add by Keith 20260928, to disable all users to edit Pattern P070
  async onEditingStart(e: any): Promise<void> {

    this.willCreateOrEdit = "edit"

    const existingValue = e.data?.applicationCode3Default
    await this.populateApplicationCode3Default(existingValue)

    const existingPartNumber = e.data?.partNumber;
    await this.populatePartNumber(existingPartNumber);

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
      // const opn = e.data.opn
      // const url = `${environment.ServiceURL_Main}CfgCdb/GetMdmByOpn?${new URLSearchParams({
      //   opn
      // }).toString()}`

      // const data = await firstValueFrom(
      //   this.send.sendRequest(url, 'GET')
      // )

      // if (data.errorMessage !== undefined) {
      //   if (!String(data.errorMessage).includes('Production Plant Conversion record not found for Company Code')) {
      //     this.toastr.error(data.errorMessage, null, errorToastOptions)
      //     return
      //   }
      // }
      if (e.data.pattern == 'P070' && this.pagePermission.edit && !this.isSuperAdmin) {// && !this.isSuperAdmin
        this.toastr.error("Pattern P070 is non-editable by all users, except IT admin.", null, errorToastOptions)
        return
      }

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
        'Unable to validate Pattern. Please refresh the page and try again.',
        null,
        errorToastOptions
      )
    } finally {
      this.validatingOpn = false
    }
  }
}




