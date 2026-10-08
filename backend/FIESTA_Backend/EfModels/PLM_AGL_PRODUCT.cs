using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class PLM_AGL_PRODUCT
{
    public string referenceKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string partType { get; set; } = null!;

    public string subType { get; set; } = null!;

    public string partDescription { get; set; } = null!;

    public string? legacyOrganization { get; set; }

    public string originalPartNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string unitOfMeasure { get; set; } = null!;

    public string plmStatus { get; set; } = null!;

    public string? legacyMPN { get; set; }

    public string? marketSegment { get; set; }

    public string? productHierarchyCode { get; set; }

    public string? gradeCodeWithDescription { get; set; }

    public string? isPartAutomotive { get; set; }

    public string? isPartASIC { get; set; }

    public string? isPartITAR { get; set; }

    public string? isPartDolbyCapable { get; set; }

    public string? isPartMultipleComponent { get; set; }

    public string? isPartActive { get; set; }

    public string? basePartNumber { get; set; }

    public string? customerPartNumber { get; set; }

    public string? classCodeWithDescription { get; set; }

    public long? totalShelfLife { get; set; }

    public string? packagingPackage { get; set; }

    public long? packagingCarrierQuantity { get; set; }

    public string? packagingCarrier { get; set; }

    public long? standardPackingQuantity { get; set; }

    public long? unitLoadingOrientationQuadrant { get; set; }

    public long? plasticReelSize { get; set; }

    public long? carrierTapePocketPitch { get; set; }

    public long? carrierTapeWidth { get; set; }

    public string? halogenFree { get; set; }

    public string? moistureExposureTime { get; set; }

    public string? moistureSensitiveLevel { get; set; }

    public string? pcbOnBoardReflowPeakTemperature { get; set; }

    public string? pcbOnBoardReflowStorageCondition { get; set; }

    public string? pcbOnBoardReflowRebakeCondition { get; set; }

    public string? roHSCompliant { get; set; }

    public string? roHSCompliantChina { get; set; }

    public string? reach { get; set; }

    public string? ulRatings { get; set; }

    public string? finalTestTestProgramRevision { get; set; }

    public long? lotSequenceCode { get; set; }

    public string? packageCode { get; set; }

    public string? packageCodeDescription { get; set; }

    public string? jedecReferenceID { get; set; }

    public string? pbFreeIndicator { get; set; }

    public string? finalTerminalFinishWithDescription { get; set; }

    public string? packageStyle { get; set; }

    public string? packageFamily { get; set; }

    public string? packageCategory { get; set; }

    public long? packagePinCount { get; set; }

    public decimal? packagePitch { get; set; }

    public decimal? packageLength { get; set; }

    public decimal? packageWidth { get; set; }

    public decimal? packageBodyThickness { get; set; }

    public string? packageBodySize { get; set; }

    public long? numberOfDie { get; set; }

    public string? diePositionForMultiDie { get; set; }

    public string? assemblyOutPackType { get; set; }

    public long? assemblyOutPackQty { get; set; }

    public string? singulationProcess { get; set; }

    public long? totalNumberOfAllWires { get; set; }

    public decimal? wireDiameter { get; set; }

    public string? wireType { get; set; }

    public string? chipVersion { get; set; }

    public string? bomItemText { get; set; }

    public long? thickness { get; set; }

    public string? bumpType { get; set; }

    public string? processTechnology { get; set; }

    public string? waferTechnology { get; set; }

    public string? roughWaferProcess { get; set; }

    public string? foundryPartNumber { get; set; }

    public long? grossDiePerWafer { get; set; }

    public string? waferSize { get; set; }

    public string? waferType { get; set; }

    public string? productDiscontinueNotification { get; set; }

    public DateTime? pdnIssueDate { get; set; }

    public DateTime? pdnLastBuyDate { get; set; }

    public DateTime? pdnLastShipDate { get; set; }

    public DateTime? extendedSupportDate { get; set; }

    public DateTime? orderUntilDate { get; set; }

    public DateTimeOffset activeDate { get; set; }

    public DateTimeOffset? productionDateP4 { get; set; }

    public DateTimeOffset? obsoleteDateP6 { get; set; }

    public DateTimeOffset? deactivateDateP7 { get; set; }

    public string? specNo { get; set; }

    public string? manufacturerPart { get; set; }

    public string? manufacturerPartDescription { get; set; }

    public DateTimeOffset? transDateAndTime { get; set; }

    public string? deleteFlag { get; set; }

    public long? reelHubSize { get; set; }

    public decimal? packageICWeight { get; set; }

    public DateTimeOffset? fiestaCreateDateAndTime { get; set; }

    public string? processSpecialTechnology { get; set; }

    public string? netDieBypass { get; set; }

    public string? referencePackageType { get; set; }

    public long? P3QuantityLimit { get; set; }

    public string? MTSPNumber { get; set; }

    public string? MTSPRevision { get; set; }

    public string? MTSPdescription { get; set; }

    public DateTime? P3ExpirationDate { get; set; }

    public string? ResponsibleProductEngineer { get; set; }
}
