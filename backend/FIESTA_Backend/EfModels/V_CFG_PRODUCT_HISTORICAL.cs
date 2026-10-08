using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_HISTORICAL
{
    public decimal recordKey { get; set; }

    public string? partNumberKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? materialType { get; set; }

    public string? materialTypeDetail { get; set; }

    public string? materialGroup { get; set; }

    public string? partDescription { get; set; }

    public string? legacyOrganization { get; set; }

    public string? originalPartNumber { get; set; }

    public string? groupStage { get; set; }

    public string? groupStageName { get; set; }

    public string? companyCode { get; set; }

    public string? companyName { get; set; }

    public string? baseUnitOfMeasure { get; set; }

    public string? plmStatus { get; set; }

    public string? legacyMPN { get; set; }

    public string? marketGroup { get; set; }

    public string? marketFamily { get; set; }

    public string? marketFamilyDetail { get; set; }

    public string? marketSegment { get; set; }

    public string? productHierarchyCode { get; set; }

    public string? productHierarchy1 { get; set; }

    public string? productHierarchy2 { get; set; }

    public string? productHierarchy3 { get; set; }

    public string? productHierarchy4 { get; set; }

    public string? productHierarchy5 { get; set; }

    public string? profitCenter { get; set; }

    public string? businessUnit { get; set; }

    public string? businessDivision { get; set; }

    public string? gradeCode { get; set; }

    public string? gradeCodeDescription { get; set; }

    public string? priority1OPN { get; set; }

    public string? isPartAutomotive { get; set; }

    public string? isPartASIC { get; set; }

    public string? isPartITAR { get; set; }

    public string? isPartDolbyCapable { get; set; }

    public string? isPartMultipleComponent { get; set; }

    public string? isPartActive { get; set; }

    public string? isPartNotRecommendNewDesign { get; set; }

    public string? whitePartNumber { get; set; }

    public string? basePartNumber { get; set; }

    public string? classCode { get; set; }

    public string? classCodeDescription { get; set; }

    public long? totalShelfLife { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? frequencyOrderIncrement { get; set; }

    public string? defaultSalesOrderCreationPlant { get; set; }

    public string? companyOfOrigin { get; set; }

    public string? partAxis { get; set; }

    public string? autoShipping { get; set; }

    public string? packagingPackage { get; set; }

    public decimal? grossWeight { get; set; }

    public decimal? netWeight { get; set; }

    public long? standardPackingQuantity { get; set; }

    public string? packagingCarrier { get; set; }

    public string? packagingBox { get; set; }

    public string? packagingSpec { get; set; }

    public decimal? tsFlag { get; set; }

    public decimal? expiryDatePrintingFlag { get; set; }

    public decimal? sealDateFlag { get; set; }

    public decimal? halogenFreePrintingFlag { get; set; }

    public string? moistureSensitiveLevel { get; set; }

    public string? pcbOnBoardReflowPeakTemperature { get; set; }

    public string? pcbOnBoardReflowStorageCondition { get; set; }

    public string? pcbOnBoardReflowRebakeCondition { get; set; }

    public string? roHSCompliant { get; set; }

    public string? roHSCompliantChina { get; set; }

    public decimal? roHSExemptPrintingFlag { get; set; }

    public decimal? roHSChinaExemptPrintingFlag { get; set; }

    public decimal? reachPrintingFlag { get; set; }

    public decimal? ulRegistrationFlag { get; set; }

    public long? lotSequenceCode { get; set; }

    public string? packageCode { get; set; }

    public string? packageCodeDescription { get; set; }

    public string? jedecReferenceID { get; set; }

    public string? pbFreeIndicator { get; set; }

    public string? packageType { get; set; }

    public string? packageGroup { get; set; }

    public string? packageCategory { get; set; }

    public long? packagePinCount { get; set; }

    public decimal? packagePitch { get; set; }

    public decimal? packageLength { get; set; }

    public decimal? packageWidth { get; set; }

    public decimal? packageBodyThickness { get; set; }

    public string? packageLayer { get; set; }

    public string? packageBodySize { get; set; }

    public long? numberOfDie { get; set; }

    public string? diePositionForMultiDie { get; set; }

    public string? assemblyOutPackagingType { get; set; }

    public string? singulationProcess { get; set; }

    public long? totalNumberOfAllWires { get; set; }

    public decimal? wireDiameter { get; set; }

    public string? wireType { get; set; }

    public string? chipVersion { get; set; }

    public long? thickness { get; set; }

    public string? bumpType { get; set; }

    public string? processTechnology { get; set; }

    public string? waferTechnology { get; set; }

    public string? roughWaferProcess { get; set; }

    public string? waferOrInStockClass { get; set; }

    public string? foundryPartNumber { get; set; }

    public long? grossDiePerWafer { get; set; }

    public string? waferSize { get; set; }

    public string? productDiscontinueNotification { get; set; }

    public DateTime? pdnIssueDate { get; set; }

    public DateTime? pdnLastBuyDate { get; set; }

    public DateTime? pdnLastShipDate { get; set; }

    public DateTime? extendedSupportDate { get; set; }

    public DateTime? orderUntilDate { get; set; }

    public string? businessPlannerCode { get; set; }

    public DateTimeOffset? activeDate { get; set; }

    public DateTimeOffset? productionDateP4 { get; set; }

    public DateTimeOffset? obsoleteDateP6 { get; set; }

    public DateTimeOffset? deactivateDateP7 { get; set; }

    public string? mrpType { get; set; }

    public string? specNo { get; set; }

    public string? specNoGreenOrYellow { get; set; }

    public string? retisSeqNo { get; set; }

    public string? originalSourceSystem { get; set; }

    public string? salesRootPartNumberKey { get; set; }

    public string? salesRootPartNumber { get; set; }

    public decimal? isSalesRoot { get; set; }

    public string? publishedLeadTimeInWeeks { get; set; }

    public string? isPartRegisterable { get; set; }

    public string? isPartSoleSource { get; set; }

    public string? canSample { get; set; }

    public string? canQuote { get; set; }

    public string? canContract { get; set; }

    public string? canOrder { get; set; }

    public string? canSearch { get; set; }

    public string? canDebit { get; set; }

    public string? canOpportunity { get; set; }

    public string? canRegister { get; set; }

    public string? canRotate { get; set; }

    public string? canForecast { get; set; }

    public string? canKit { get; set; }

    public string? isPartNonCancelableNonReschedule { get; set; }

    public string? isPartPublish { get; set; }

    public string? canFlagMasterComments { get; set; }

    public string? autoApprThresholdFocusSales { get; set; }

    public string? autoApprThresholdNonFocusSales { get; set; }

    public string? autoApprThresholdFocusPL { get; set; }

    public string? autoApprThresholdNonFocusPL { get; set; }

    public string? sampleAutoApprQtyThreshold { get; set; }

    public string? sampleAutoApprTotalValThreshold { get; set; }

    public string? tacticalMarketingMgr { get; set; }

    public string? marketingMgr { get; set; }

    public string? applicationCode3Default { get; set; }

    public string? eccn { get; set; }

    public string? htsus { get; set; }

    public string? customerPartNumber { get; set; }

    public string? matrixWafer { get; set; }

    public string? finalTestTestProgramRevision { get; set; }

    public string? ulRatingsText { get; set; }

    public long? unitLoadingOrientationQuadrant { get; set; }

    public long? plasticReelSize { get; set; }

    public long? carrierTapePocketPitch { get; set; }

    public long? carrierTapeWidth { get; set; }

    public string? fiestaRules { get; set; }

    public string? goldenAll { get; set; }

    public string? goldenRecord { get; set; }

    public string? partNumberType { get; set; }

    public string? productGeneralType { get; set; }

    public string? productType { get; set; }

    public long? packagingCarrierQuantity { get; set; }

    public long? reelHubSize { get; set; }

    public string? finalTerminalFinishDescription { get; set; }

    public long? assemblyOutPackagingQty { get; set; }

    public string? manufacturerPart { get; set; }

    public string? manufacturerPartDescription { get; set; }

    public string? bomItemText { get; set; }

    public string? finalTerminalFinish { get; set; }

    public string? moistureExposureTime { get; set; }

    public string? processSpecialTechnology { get; set; }

    public string? netDieBypass { get; set; }

    public string? productLine { get; set; }

    public string? referencePackageType { get; set; }

    public string? eccn_my { get; set; }

    public string? htsus_my { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? modifiedBy { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
