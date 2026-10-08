using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_AGL_PRODUCT_FULL
    {
        public decimal recordKey { get; set; }
        public string? originalPartNumber { get; set; }
        public string? groupStage { get; set; }
        public string? partDescription { get; set; }
        public string? legacyOrganization { get; set; }
        public string? plmStatus { get; set; }
        public string? legacyMPN { get; set; }
        public string? marketGroup { get; set; }
        public string? marketFamily { get; set; }
        public string? marketFamilyDetail { get; set; }
        public string? marketSegment { get; set; }
        public string? gradeCode { get; set; }
        public string? gradeCodeDescription { get; set; }
        public string? isPartAutomotive { get; set; }
        public string? isPartASIC { get; set; }
        public string? isPartITAR { get; set; }
        public string? isPartDolbyCapable { get; set; }
        public string? isPartMultipleComponent { get; set; }
        public string? isPartActive { get; set; }
        public string? isPartNotRecommendNewDesign { get; set; }
        public string? basePartNumber { get; set; }
        public string? customerPartNumber { get; set; }
        public string? classCode { get; set; }
        public string? classCodeDescription { get; set; }
        public string? packagingPackage { get; set; }
        public decimal? netWeight { get; set; }
        public long? standardPackingQuantity { get; set; }
        public string? packagingCarrier { get; set; }
        public string? halogenFreePrintingFlag { get; set; }
        public string? moistureSensitiveLevel { get; set; }
        public long? pcbOnBoardReflowPeakTemperature { get; set; }
        public string? pcbOnBoardReflowStorageCondition { get; set; }
        public string? pcbOnBoardReflowRebakeCondition { get; set; }
        public string? roHSCompliant { get; set; }
        public string? roHSCompliantChina { get; set; }
        public string? reachPrintingFlag { get; set; }
        public long? ulRatingsControlCode { get; set; }
        public string? packagingBodySize { get; set; }
        public string? finalTestTestProgram { get; set; }
        public long? lotSequenceCode { get; set; }
        public string? packageCode { get; set; }
        public string? packageCodeDescription { get; set; }
        public string? jedecReferenceID { get; set; }
        public string? referencePackageType { get; set; }
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
        public string? foundryPartNumber { get; set; }
        public long? grossDiePerWafer { get; set; }
        public long? planningDiePerWafer { get; set; }
        public long? waferSize { get; set; }
        public string? matrixWafer { get; set; }
        public string? productDiscontinueNotification { get; set; }
        public DateTime? pdnIssueDate { get; set; }
        public DateTime? pdnLastBuyDate { get; set; }
        public DateTime? pdnLastShipDate { get; set; }
        public DateTime? extendedSupportDate { get; set; }
        public DateTime? orderUntilDate { get; set; }
        public DateTimeOffset? activeDate { get; set; }
        public DateTimeOffset? productionDateP4 { get; set; }
        public DateTimeOffset? obsoleteDateP6 { get; set; }
        public DateTimeOffset? deactivateDateP7 { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
