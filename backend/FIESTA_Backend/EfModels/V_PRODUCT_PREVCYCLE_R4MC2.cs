using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_PRODUCT_PREVCYCLE_R4MC2
{
    public string opn { get; set; } = null!;
    public long bomLevel { get; set; }
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string materialType { get; set; } = null!;

    public string? materialTypeDetail { get; set; }

    public string materialGroup { get; set; } = null!;

    public string partDescription { get; set; } = null!;

    public string legacyOrganization { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string companyCode { get; set; } = null!;

    public string baseUnitOfMeasure { get; set; } = null!;

    public string plmStatus { get; set; } = null!;

    public string? legacyMPN { get; set; }

    public string marketGroup { get; set; } = null!;

    public string marketFamily { get; set; } = null!;

    public string marketFamilyDetail { get; set; } = null!;

    public string marketSegment { get; set; } = null!;

    public string productHierarchyCode { get; set; } = null!;

    public string productHierarchy1 { get; set; } = null!;

    public string productHierarchy2 { get; set; } = null!;

    public string productHierarchy3 { get; set; } = null!;

    public string productHierarchy4 { get; set; } = null!;

    public string productHierarchy5 { get; set; } = null!;

    public string profitCenter { get; set; } = null!;

    public string businessUnit { get; set; } = null!;

    public string businessDivision { get; set; } = null!;

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

    public bool? tsFlag { get; set; }

    public bool? expiryDatePrintingFlag { get; set; }

    public bool? sealDateFlag { get; set; }

    public bool? halogenFreePrintingFlag { get; set; }

    public string? moistureSensitiveLevel { get; set; }

    public long? pcbOnBoardReflowPeakTemperature { get; set; }

    public string? pcbOnBoardReflowStorageCondition { get; set; }

    public string? pcbOnBoardReflowRebakeCondition { get; set; }

    public string? roHSCompliant { get; set; }

    public string? roHSCompliantChina { get; set; }

    public bool? roHSExemptPrintingFlag { get; set; }

    public bool? roHSChinaExemptPrintingFlag { get; set; }

    public bool? reachPrintingFlag { get; set; }

    public bool? ulRegistrationFlag { get; set; }

    public string? ulRatingsControlCode { get; set; }

    public string? packagingBodySize { get; set; }

    public long? lotSequenceCode { get; set; }

    public string? packageCode { get; set; }

    public string? packageCodeDescription { get; set; }

    public string? jedecReferencePackageCode { get; set; }

    public string? pbFreeIndicator { get; set; }

    public string? terminationFinish { get; set; }

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

    public string? assemblyOutPackagingTypeDescription { get; set; }

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

    public long? planningDiePerWafer { get; set; }

    public long? waferSize { get; set; }

    public string? productDiscontinueNotification { get; set; }

    public DateTime? pdnIssueDate { get; set; }

    public DateTime? pdnLastBuyDate { get; set; }

    public DateTime? pdnLastShipDate { get; set; }

    public DateTime? extendedSupportDate { get; set; }

    public DateTime? orderUntilDate { get; set; }

    public string businessPlannerCode { get; set; } = null!;

    public DateTimeOffset activeDate { get; set; }

    public DateTimeOffset? productionDateP4 { get; set; }

    public DateTimeOffset? obsoleteDateP6 { get; set; }

    public DateTimeOffset? deactivateDateP7 { get; set; }

    public string mrpType { get; set; } = null!;

    public string? specNo { get; set; }

    public string? specNoGreenOrYellow { get; set; }

    public string? retisSeqNo { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string originalSourceSystem { get; set; } = null!;

    public string? fiestaRules { get; set; }

    public string? customerPartNumber { get; set; }

    public string? matrixWafer { get; set; }

    public string? finalTestTestProgramRevision { get; set; }

    public string? ulRatingsText { get; set; }

    public decimal? packQuantity { get; set; }

    public string? unitLoadingOrientationQuadrant { get; set; }

    public decimal? plasticReelSize { get; set; }

    public decimal? carrierTapePocketPitch { get; set; }

    public decimal? carrierTapeWidth { get; set; }

    public decimal? moistureExportTime { get; set; }

    public string? workOrderSpecNumber { get; set; }

    public string? sapRoutingShortText { get; set; }
}
