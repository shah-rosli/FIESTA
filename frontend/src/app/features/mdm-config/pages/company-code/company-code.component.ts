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

@Component({
  selector: 'app-company-code',
  templateUrl: './company-code.component.html',
  styleUrl: './company-code.component.scss'
})
export class CompanyCodeComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(DeltaUploadComponent) deltaUpload: DeltaUploadComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Company Code Maintenance"
  endpoint: string = "CfgCompanyCode"
  tableName: string = "CFG_COMPANY_CODE"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "companyCode",
    "companyName",
    "city",
    "countryRegionKey",
    "currency",
    "languageKey",
    "chartOfAccounts",
    "maxExchangeRateDeviation",
    "fiscalYearVariant",
    "coArea",
    "company",
    "address",
    "vatRegistrationNo",
    "fmArea",
    "projectCashMgmtActive",
    "cshBdgtMgtActive",
    "updateFM",
    "jurisdictionCode",
    "fdsCtrActiveInHR",
    "template",
    "transitPlant",
    "documentEntryScreenVariant",
    "cashManagementCompanyCode",
    "cashManagementActivated",
    "defineDefaultValueDate",
    "discountBaseIsNetValue",
    "creditControlArea",
    "taxBaseIsNetValue",
    "sampleAcctRulesVar",
    "businessAreaFinStatements",
    "proposeFiscalYear",
    "postTranslation",
    "companyCodeIsProductive",
    "purchaseAccountProcessing",
    "jvAccountingActive",
    "financialAssetsMgmtActive",
    "noExchRateDiffWhenClearingInLC",
    "updateMMInCMF",
    "updateSDInCMF",
    "externalCoCode",
    "originalKey",
    "alternativeCOA",
    "taxesOnSlsPurc",
    "globalCoCde",
    "fieldStatusVariant",
    "pstngPeriodVariant",
    "hedgeRequestActive",
    "taxCrcyTranslation",
    "workflowVariant",
    "inventoryManagement",
    "poSchedulingAgmt",
    "purchaseRequisition",
    "contract",
    "taxDetermwithDocDate",
    "inputTaxCode",
    "outputTaxCode",
    "importDataInPurchaseOrder",
    "negativePostingsPermitted",
    "controlAreaCanBeInput",
    "extendedWithholdingTaxActive",
    "postingDateForParking",
    "inflationMethod",
    "fundsReservationFieldStatusVariant",
    "copyingControlGoodsReceipt",
    "importDataGoodsReceipt",
    "methodOffsttngAcct",
    "baVariant",
    "costOfSalesAccountingActv",
    "acctsRecblePledActive",
    "enableAmountSplit",
    "surchargeMethod",
    "documentTypeForProvisionsForTaxes",
    "documentTypeForJVAmountCorrection",
    "documentTypeForJVTaxCode",
    "remittanceChallanDocumentType",
    "deferredTaxRule",
    "taxReportingDateActive",
    "managePostingPeriodForCoCodeLedger",
    "shoppingCart",
    "hideEntryInInputHelp",
    "activateAADerivation",
    "activeFlag"
  ]
  fieldsRequired: string[] = [
    "companyCode",
    "activeFlag"
  ]
  fieldsCreateOnly: string[] = [
    "companyCode"
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
        if (!this.fieldsAllowEditing.includes(column.dataField)) {
          column.allowEditing = false
        }
        if (this.fieldsRequired.includes(column.dataField)) {
          column.validationRules = [{ type: 'required' }]
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
      //this.setLinesDropdownReadOnly(e)
    }
  }

  openDeltaUpload() {
    if (this.dataSource.isLoaded()) {
      this.deltaUpload.openUploadPopup()
    }
  }

  onInitNewRow(e) {
    e.data.activeFlag = "Y"
  }

  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}