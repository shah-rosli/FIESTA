import { Component, ViewChild } from '@angular/core'
import { DxDataGridComponent } from 'devextreme-angular'
import DataSource from 'devextreme/data/data_source'
import { ToastrService } from 'ngx-toastr'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { PagePermission, PermissionService } from '../../../../service/permission.service'
import { environment } from '../../../../../environments/environment'
import { Column, ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import { confirm } from 'devextreme/ui/dialog';
import { ConfigHistoryPopupComponent } from '../../../mdm-config/components/config-history-popup/config-history-popup.component'
import { CookieService } from 'ngx-cookie-service'
@Component({
  selector: 'app-product-historical-review',
  templateUrl: './product-historical-review.component.html',
  styleUrl: './product-historical-review.component.scss'
})
export class ProductHistoricalReviewComponent {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent
  @ViewChild(ConfigHistoryPopupComponent) historyPopup: ConfigHistoryPopupComponent

  PageTitle: string = "Product Historical Review"
  endpoint: string = "CfgProductHistorical"
  tableName: string = "CFG_PRODUCT_HISTORICAL"
  dataSource: DataSource
  pagePermission: PagePermission
  dataGridKey: string = "recordKey"
  fieldsAllowEditing: string[] = [
    "partNumberKey",
    "partNumber",
    "materialType",
    "materialTypeDetail",
    "materialGroup",
    "partDescription",
    "legacyOrganization",
    "originalPartNumber",
    "groupStage",
    "groupStageName",
    "companyCode",
    "companyName",
    "baseUnitOfMeasure",
    "plmStatus",
    "legacyMPN",
    "marketGroup",
    "marketFamily",
    "marketFamilyDetail",
    "marketSegment",
    "productHierarchyCode",
    "productHierarchy1",
    "productHierarchy2",
    "productHierarchy3",
    "productHierarchy4",
    "productHierarchy5",
    "profitCenter",
    "businessUnit",
    "businessDivision",
    "gradeCode",
    "gradeCodeDescription",
    "priority1OPN",
    "isPartAutomotive",
    "isPartASIC",
    "isPartITAR",
    "isPartDolbyCapable",
    "isPartMultipleComponent",
    "isPartActive",
    "isPartNotRecommendNewDesign",
    "whitePartNumber",
    "basePartNumber",
    "classCode",
    "classCodeDescription",
    "totalShelfLife",
    "minimumOrderQuantity",
    "frequencyOrderIncrement",
    "defaultSalesOrderCreationPlant",
    "companyOfOrigin",
    "partAxis",
    "autoShipping",
    "packagingPackage",
    "grossWeight",
    "netWeight",
    "standardPackingQuantity",
    "packagingCarrier",
    "packagingBox",
    "packagingSpec",
    "tsFlag",
    "expiryDatePrintingFlag",
    "sealDateFlag",
    "halogenFreePrintingFlag",
    "moistureSensitiveLevel",
    "pcbOnBoardReflowPeakTemperature",
    "pcbOnBoardReflowStorageCondition",
    "pcbOnBoardReflowRebakeCondition",
    "roHSCompliant",
    "roHSCompliantChina",
    "roHSExemptPrintingFlag",
    "roHSChinaExemptPrintingFlag",
    "reachPrintingFlag",
    "ulRegistrationFlag",
    "lotSequenceCode",
    "packageCode",
    "packageCodeDescription",
    "jedecReferenceID",
    "pbFreeIndicator",
    "packageType",
    "packageGroup",
    "packageCategory",
    "packagePinCount",
    "packagePitch",
    "packageLength",
    "packageWidth",
    "packageBodyThickness",
    "packageLayer",
    "packageBodySize",
    "numberOfDie",
    "diePositionForMultiDie",
    "assemblyOutPackagingType",
    "singulationProcess",
    "totalNumberOfAllWires",
    "wireDiameter",
    "wireType",
    "chipVersion",
    "thickness",
    "bumpType",
    "processTechnology",
    "waferTechnology",
    "roughWaferProcess",
    "waferOrInStockClass",
    "foundryPartNumber",
    "grossDiePerWafer",
    "waferSize",
    "productDiscontinueNotification",
    "pdnIssueDate",
    "pdnLastBuyDate",
    "pdnLastShipDate",
    "extendedSupportDate",
    "orderUntilDate",
    "businessPlannerCode",
    "activeDate",
    "productionDateP4",
    "obsoleteDateP6",
    "deactivateDateP7",
    "mrpType",
    "specNo",
    "specNoGreenOrYellow",
    "retisSeqNo",
    "originalSourceSystem",
    "salesRootPartNumberKey",
    "salesRootPartNumber",
    "isSalesRoot",
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
    "eccn",
    "htsus",
    "customerPartNumber",
    "matrixWafer",
    "finalTestTestProgramRevision",
    "ulRatingsText",
    "unitLoadingOrientationQuadrant",
    "plasticReelSize",
    "carrierTapePocketPitch",
    "carrierTapeWidth",
    "fiestaRules",
    "goldenAll",
    "goldenRecord",
    "partNumberType",
    "productGeneralType",
    "productType",
    "packagingCarrierQuantity",
    "reelHubSize",
    "finalTerminalFinishDescription",
    "assemblyOutPackagingQty",
    "manufacturerPart",
    "manufacturerPartDescription",
    "bomItemText",
    "finalTerminalFinish",
    "moistureExposureTime",
    "processSpecialTechnology",
    "netDieBypass",
    "productLine",
    "referencePackageType",
    "eccn_my",
    "htsus_my",
    "deleteFlag"
  ]
  fieldsRequired: string[] = [
    "partNumber",
    "deleteFlag"
  ]
  fieldsCreateOnly: string[] = [
    "partNumber"
  ]
  yesNoDataSource = ["Y", "N"]

  columnConfig: Column[]
  historyColumnConfig: Column[]

  selectedRows: any[] = [];
  confirmMsg: string;

  userID: string;

  constructor(
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService,
    private cookieService: CookieService) {
  }

  ngOnInit() {
    this.userID = JSON.parse(this.cookieService.get('UserInfo')).USER_ID
    this.historyIconClick = this.historyIconClick.bind(this)
    this.pagePermission = this.permission.getUserPermissions()
    this.configureColumns()
  }

  configureColumns() {
    const createMainColumns = (columns: Column[]): Column[] => {
      const mainColumns = [...columns]
      mainColumns.forEach((column) => {
        if (column.dataField === 'processStatus') {
          column.visible = false;
        }
        if (!this.fieldsAllowEditing.includes(column.dataField)) {
          column.allowEditing = false
        }
        if (this.fieldsAllowEditing.includes(column.dataField)) {
          column.validationRules = [{ type: 'required' }]
        }
        if (column.dataField === "deleteFlag") {
          column.lookup = { dataSource: this.yesNoDataSource }
        }
      })
      mainColumns.push({
        type: "buttons",
        fixed: true,
        fixedPosition: "right",
        buttons: [{
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
        loadUrl: url + "/GetReview",
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

  onInitNewRow(e) {
    e.data.deleteFlag = "N"
  }


  saveButtonDisabled(): boolean {
    return !this.dataGrid?.instance.hasEditData()
  }
  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  onSelectionChanged(e: any) {
    const invalidRows = e.selectedRowsData.filter(
      row => row.modifiedBy === this.userID
    );

    if (invalidRows.length) {
      e.component.deselectRows(
        invalidRows.map(row => row.recordKey)
      );
    }
    this.selectedRows = e.component.getSelectedRowsData();
  }

  onCellPrepared(e: any) {
    if (e.rowType === 'data' && e.column.command === 'select') {

      if (e.data.modifiedBy == this.userID) {
        e.cellElement.classList.add('disabled-selection');
      }
    }
  }

  onCellClick(e: any) {
    if (e.rowType === 'header' && e.column?.command === 'select') {
      setTimeout(() => {
        const selectedRows = this.selectedRows.length;
        const totalRows = e.component.getVisibleRows().length;
        if (selectedRows === totalRows) {
          console.log("Selected all rows");
          e.component.clearSelection();
        } else if (selectedRows === 0) {
          console.log("Selected 0 rows");
        } else if (selectedRows < totalRows) {
          console.log("Selected some rows");
          e.component.clearSelection();
        } else {
          console.log("Unknown");
        }
      });
    }
  }

  onApp1Review(): void {

    if (this.selectedRows.length == 0) {
      this.toastr.error("No row is selected to proceed submission.", "Error!", errorToastOptions)
      return;
    }

    this.confirmMsg = this.selectedRows.length + " row(s) has been selected. Are you sure you want to proceed with the submission?";

    const result = confirm(
      this.confirmMsg,
      "Confirmation"
    );

    let pns = '';
    for (const row of this.selectedRows) {
      console.log(row.applicationLevel1Code);
      if (pns === '') {
        pns = 'p_partNumbers=' + encodeURIComponent(row.partNumber);
      } else {
        pns = pns + '&p_partNumbers=' + encodeURIComponent(row.partNumber);
      }
    }

    result.then((dialogResult) => {
      if (!dialogResult) {
        return;
      }

      const url = `${environment.ServiceURL_Main}REVIEW_PRODUCT_HISTORICAL?` + pns;
      this.send.sendRequest(url, 'POST', null).subscribe((res: any) => {
        this.toastr.success(res.Result)
        this.selectedRows = [];
        this.dataSource.reload();
      });
    });
  }
}



