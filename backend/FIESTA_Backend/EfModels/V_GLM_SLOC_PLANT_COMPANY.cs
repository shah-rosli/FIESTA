using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_GLM_SLOC_PLANT_COMPANY
{
    public decimal recordKey { get; set; }

    public string plant_sloc { get; set; } = null!;

    public string storageLocation_sloc { get; set; } = null!;

    public string? descrOfStorageLoc_sloc { get; set; }

    public string? division_sloc { get; set; }

    public string? negStocksInSLoc_sloc { get; set; }

    public string? freezeBookInvSLoc_sloc { get; set; }

    public string? sLocMRPIndicator_sloc { get; set; }

    public string? authorizationCheck_sloc { get; set; }

    public string? storageResource_sloc { get; set; }

    public string? huReqmnt_sloc { get; set; }

    public string? partnerStorLoc_sloc { get; set; }

    public string? salesOrganization_sloc { get; set; }

    public string? distributionChannel_sloc { get; set; }

    public string? shippingPointReceivingPt_sloc { get; set; }

    public string? supplier_sloc { get; set; }

    public string? customer_sloc { get; set; }

    public string? businessSystemOfMES_sloc { get; set; }

    public string? inventoryManagementType_sloc { get; set; }

    public string? validity_sloc { get; set; }

    public string? licenseNumber_sloc { get; set; }

    public string? inTransitAssignment_sloc { get; set; }

    public string? tankAssgn_sloc { get; set; }

    public string? storageLocationType_sloc { get; set; }

    public string? countryCode_sloc { get; set; }

    public string? region_sloc { get; set; }

    public string? timeZone_sloc { get; set; }

    public string? glmPlantCode_sloc { get; set; }

    public string activeFlag_sloc { get; set; } = null!;

    public DateTimeOffset? createDateAndTime_sloc { get; set; }

    public DateTimeOffset? updateDateAndTime_sloc { get; set; }

    public string updateType_sloc { get; set; } = null!;

    public string deleteFlag_sloc { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime_sloc { get; set; }

    public string processStatus_sloc { get; set; } = null!;

    public decimal? recordKey_plant { get; set; }

    public string? plant_plant { get; set; }

    public string? name1_plant { get; set; }

    public string? valuationArea_plant { get; set; }

    public string? customerNumberOfPlant_plant { get; set; }

    public string? supplierNumberOfPlant_plant { get; set; }

    public string? factoryCalendar_plant { get; set; }

    public string? name2_plant { get; set; }

    public string? streetAndHouseNumber_plant { get; set; }

    public string? poBox_plant { get; set; }

    public string? postalCode_plant { get; set; }

    public string? city_plant { get; set; }

    public string? purchOrganization_plant { get; set; }

    public string? salesOrganization_plant { get; set; }

    public string? batchStatusMgmt_plant { get; set; }

    public string? condsAtPlantLevel_plant { get; set; }

    public string? sourceList_plant { get; set; }

    public string? reqmtsPlanning_plant { get; set; }

    public string? countryRegionKey_plant { get; set; }

    public string? region_plant { get; set; }

    public string? countyCode_plant { get; set; }

    public string? cityCode_plant { get; set; }

    public string? address_plant { get; set; }

    public string? planningPlant_plant { get; set; }

    public string? taxJurisdiction_plant { get; set; }

    public string? distribchannel_plant { get; set; }

    public string? intCOBillingDiv_plant { get; set; }

    public string? languageKey_plant { get; set; }

    public string? sopPlant_plant { get; set; }

    public string? varianceKey_plant { get; set; }

    public string? batchStatusMgmtOld_plant { get; set; }

    public string? plantCat_plant { get; set; }

    public string? salesDistrict_plant { get; set; }

    public string? supplyRegion_plant { get; set; }

    public string? taxIndicatorPlant_plant { get; set; }

    public string? regularSupplier_plant { get; set; }

    public decimal? firstReminderExped_plant { get; set; }

    public decimal? secondReminderExped_plant { get; set; }

    public decimal? thirdReminderExped_plant { get; set; }

    public string? text1stDunning_plant { get; set; }

    public string? text2ndDunning_plant { get; set; }

    public string? text3rdDunning_plant { get; set; }

    public decimal? poTolerance_plant { get; set; }

    public string? businessPlace_plant { get; set; }

    public string? salesAreaDetrm_plant { get; set; }

    public string? distribProfileOfPlant_plant { get; set; }

    public string? archivingMarker_plant { get; set; }

    public string? batchRecDMSType_plant { get; set; }

    public string? nodeTypesupplyChain_plant { get; set; }

    public string? namingStructure_plant { get; set; }

    public string? costObjControlling_plant { get; set; }

    public string? mixedCosting_plant { get; set; }

    public string? actualCosting_plant { get; set; }

    public string? shippingPointReceivingPt_plant { get; set; }

    public string? actualActivitiesUpdated_plant { get; set; }

    public string? controlOfCreditOfCostCenters_plant { get; set; }

    public string? afSrceDetViaATP_plant { get; set; }

    public string? batchManagementNotActiveByDefault_plant { get; set; }

    public string? supplyAssignmentARun_plant { get; set; }

    public string? seasonActiveInInventoryManagement_plant { get; set; }

    public string? controlDataForBOM_plant { get; set; }

    public string? activateVariantGrouping_plant { get; set; }

    public string? assignBatchesInARun_plant { get; set; }

    public string? exchangeValuation_plant { get; set; }

    public string? vendorType_plant { get; set; }

    public string? credIPI_plant { get; set; }

    public string? storeCat_plant { get; set; }

    public string? superiorDeptStore_plant { get; set; }

    public string? ownership_plant { get; set; }

    public string? company_plant { get; set; }

    public string? activeFlag_plant { get; set; }

    public DateTimeOffset? createDateAndTime_plant { get; set; }

    public DateTimeOffset? updateDateAndTime_plant { get; set; }

    public string? updateType_plant { get; set; }

    public string? deleteFlag_plant { get; set; }

    public DateTimeOffset? deleteDateAndTime_plant { get; set; }

    public string? processStatus_plant { get; set; }

    public decimal? recordKey_co { get; set; }

    public string? companyCode_co { get; set; }

    public string? companyName_co { get; set; }

    public string? city_co { get; set; }

    public string? countryRegionKey_co { get; set; }

    public string? currency_co { get; set; }

    public string? languageKey_co { get; set; }

    public string? chartOfAccounts_co { get; set; }

    public decimal? maxExchangeRateDeviation_co { get; set; }

    public string? fiscalYearVariant_co { get; set; }

    public string? coArea_co { get; set; }

    public string? company_co { get; set; }

    public string? address_co { get; set; }

    public string? vatRegistrationNo_co { get; set; }

    public string? fmArea_co { get; set; }

    public string? projectCashMgmtActive_co { get; set; }

    public string? cshBdgtMgtActive_co { get; set; }

    public string? updateFM_co { get; set; }

    public string? jurisdictionCode_co { get; set; }

    public DateTime? fdsCtrActiveInHR_co { get; set; }

    public string? template_co { get; set; }

    public string? transitPlant_co { get; set; }

    public string? documentEntryScreenVariant_co { get; set; }

    public string? cashManagementCompanyCode_co { get; set; }

    public string? cashManagementActivated_co { get; set; }

    public string? defineDefaultValueDate_co { get; set; }

    public string? discountBaseIsNetValue_co { get; set; }

    public string? creditControlArea_co { get; set; }

    public string? taxBaseIsNetValue_co { get; set; }

    public string? sampleAcctRulesVar_co { get; set; }

    public string? businessAreaFinStatements_co { get; set; }

    public string? proposeFiscalYear_co { get; set; }

    public string? postTranslation_co { get; set; }

    public string? companyCodeIsProductive_co { get; set; }

    public string? purchaseAccountProcessing_co { get; set; }

    public string? jvAccountingActive_co { get; set; }

    public string? financialAssetsMgmtActive_co { get; set; }

    public string? noExchRateDiffWhenClearingInLC_co { get; set; }

    public string? updateMMInCMF_co { get; set; }

    public string? updateSDInCMF_co { get; set; }

    public string? externalCoCode_co { get; set; }

    public string? originalKey_co { get; set; }

    public string? alternativeCOA_co { get; set; }

    public string? taxesOnSlsPurc_co { get; set; }

    public string? globalCoCde_co { get; set; }

    public string? fieldStatusVariant_co { get; set; }

    public string? pstngPeriodVariant_co { get; set; }

    public string? hedgeRequestActive_co { get; set; }

    public string? taxCrcyTranslation_co { get; set; }

    public string? workflowVariant_co { get; set; }

    public string? inventoryManagement_co { get; set; }

    public string? poSchedulingAgmt_co { get; set; }

    public string? purchaseRequisition_co { get; set; }

    public string? contract_co { get; set; }

    public string? taxDetermwithDocDate_co { get; set; }

    public string? inputTaxCode_co { get; set; }

    public string? outputTaxCode_co { get; set; }

    public string? importDataInPurchaseOrder_co { get; set; }

    public string? negativePostingsPermitted_co { get; set; }

    public string? controlAreaCanBeInput_co { get; set; }

    public string? extendedWithholdingTaxActive_co { get; set; }

    public string? postingDateForParking_co { get; set; }

    public string? inflationMethod_co { get; set; }

    public string? fundsReservationFieldStatusVariant_co { get; set; }

    public string? copyingControlGoodsReceipt_co { get; set; }

    public string? importDataGoodsReceipt_co { get; set; }

    public decimal? methodOffsttngAcct_co { get; set; }

    public string? baVariant_co { get; set; }

    public string? costOfSalesAccountingActv_co { get; set; }

    public string? acctsRecblePledActive_co { get; set; }

    public string? enableAmountSplit_co { get; set; }

    public string? surchargeMethod_co { get; set; }

    public string? documentTypeForProvisionsForTaxes_co { get; set; }

    public string? documentTypeForJVAmountCorrection_co { get; set; }

    public string? documentTypeForJVTaxCode_co { get; set; }

    public string? remittanceChallanDocumentType_co { get; set; }

    public string? deferredTaxRule_co { get; set; }

    public string? taxReportingDateActive_co { get; set; }

    public string? managePostingPeriodForCoCodeLedger_co { get; set; }

    public string? shoppingCart_co { get; set; }

    public string? hideEntryInInputHelp_co { get; set; }

    public string? activateAADerivation_co { get; set; }

    public string? activeFlag_co { get; set; }

    public DateTimeOffset? createDateAndTime_co { get; set; }

    public DateTimeOffset? updateDateAndTime_co { get; set; }

    public string? updateType_co { get; set; }

    public string? deleteFlag_co { get; set; }

    public DateTimeOffset? deleteDateAndTime_co { get; set; }

    public string? processStatus_co { get; set; }

    public DateTimeOffset? updateDateAndTime_max { get; set; }
}
