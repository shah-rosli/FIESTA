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
  selector: 'app-plants',
  templateUrl: './plants.component.html',
  styleUrl: './plants.component.scss'
})



export class PlantsComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Plants Maintenance"
  endpoint: string = "CfgPlants"
  tableName: string = "CFG_PLANTS"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "plant",
    "name1",
    "valuationArea",
    "customerNumberOfPlant",
    "supplierNumberOfPlant",
    "factoryCalendar",
    "name2",
    "streetAndHouseNumber",
    "poBox",
    "postalCode",
    "city",
    "purchOrganization",
    "salesOrganization",
    "batchStatusMgmt",
    "condsAtPlantLevel",
    "sourceList",
    "reqmtsPlanning",
    "countryRegionKey",
    "region",
    "countyCode",
    "cityCode",
    "address",
    "planningPlant",
    "taxJurisdiction",
    "distribchannel",
    "intCOBillingDiv",
    "languageKey",
    "sopPlant",
    "varianceKey",
    "batchStatusMgmtOld",
    "plantCat",
    "salesDistrict",
    "supplyRegion",
    "taxIndicatorPlant",
    "regularSupplier",
    "firstReminderExped",
    "secondReminderExped",
    "thirdReminderExped",
    "text1stDunning",
    "text2ndDunning",
    "text3rdDunning",
    "poTolerance",
    "businessPlace",
    "salesAreaDetrm",
    "distribProfileOfPlant",
    "archivingMarker",
    "batchRecDMSType",
    "nodeTypesupplyChain",
    "namingStructure",
    "costObjControlling",
    "mixedCosting",
    "actualCosting",
    "shippingPointReceivingPt",
    "actualActivitiesUpdated",
    "controlOfCreditOfCostCenters",
    "afSrceDetViaATP",
    "batchManagementNotActiveByDefault",
    "supplyAssignmentARun",
    "seasonActiveInInventoryManagement",
    "controlDataForBOM",
    "activateVariantGrouping",
    "assignBatchesInARun",
    "exchangeValuation",
    "vendorType",
    "credIPI",
    "storeCat",
    "superiorDeptStore",
    "ownership",
    "company",
    "activeFlag"
  ]
  fieldsRequired: string[] = [
    "plant",
    "company",
    "activeFlag"
  ]
  fieldsCreateOnly: string[] = [
    "plant"
  ]
  //yesNoDataSource = ["Y", "N"]
  OneZeroDataSource = ["1", "0"]

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

  companyCodeDataSource: any[]
  companyCodeDropDown: string[]

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
  }


  async ngOnInit() {
    this.historyIconClick = this.historyIconClick.bind(this)

    await this.populateCompanyCode()
    this.setCompanyCodeValue = this.setCompanyCodeValue.bind(this)

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
        if (column.dataField === "company") {
          column.editCellTemplate = "companyCodeEditor"
          column.setCellValue = this.setCompanyCodeValue
          //*dxi-validation-rule required validation in html
        }
        if (column.dataField === "activeFlag") {
          column.lookup = { dataSource: this.OneZeroDataSource }
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
    e.data.activeFlag = "1"
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  async populateCompanyCode() {
    const url: string = `${environment.ServiceURL_Main}CfgPlants/GetCompanyCode`
    try {
      const data = await firstValueFrom(this.send.sendRequest(url, "GET"))
      this.companyCodeDataSource = data
      this.companyCodeDropDown = Array.from(new Set(this.companyCodeDataSource.map(item => item.companyCode)))
    } catch (error) {
      this.resetPlantsData()
      if (error?.status === 404) {
        this.toastr.error(`Company DropDown Error`, null, errorToastOptions)
      }
    }
  }

  resetPlantsData() {
    this.companyCodeDataSource = null
    this.companyCodeDropDown = null
  }

  setCompanyCodeValue(newData, value) {
    const filtered = this.companyCodeDataSource.filter(item =>
      item.companyCode === value
    )
    newData.company = filtered[0].companyCode
    newData.company = value
  }
}



