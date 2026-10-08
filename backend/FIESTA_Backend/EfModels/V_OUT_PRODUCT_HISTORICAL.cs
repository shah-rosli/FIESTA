using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_PRODUCT_HISTORICAL
{
    public decimal recordKey { get; set; }

    public string? partNumberKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? partDescription { get; set; }

    public string? materialType { get; set; }

    public string? materialGroup { get; set; }

    public string? companyCode { get; set; }

    public string? companyName { get; set; }

    public string? baseUnitOfMeasure { get; set; }

    public string? plmStatus { get; set; }

    public string? legacyMPN { get; set; }

    public string? marketGroup { get; set; }

    public string? marketFamily { get; set; }

    public string? marketSegment { get; set; }

    public string? productHierarchyCode { get; set; }

    public string? profitCenter { get; set; }

    public string? businessUnit { get; set; }

    public string? businessDivision { get; set; }

    public string? gradeCode { get; set; }

    public string? priority1OPN { get; set; }

    public string? isPartAutomotive { get; set; }

    public string? isPartASIC { get; set; }

    public string? isPartITAR { get; set; }

    public string? isPartActive { get; set; }

    public string? whitePartNumber { get; set; }

    public string? basePartNumber { get; set; }

    public string? classCode { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? frequencyOrderIncrement { get; set; }

    public string? defaultSalesOrderCreationPlant { get; set; }

    public string? companyOfOrigin { get; set; }

    public string? partAxis { get; set; }

    public decimal? grossWeight { get; set; }

    public decimal? netWeight { get; set; }

    public long? standardPackingQuantity { get; set; }

    public decimal? tsFlag { get; set; }

    public decimal? expiryDatePrintingFlag { get; set; }

    public decimal? sealDateFlag { get; set; }

    public decimal? halogenFreePrintingFlag { get; set; }

    public string? moistureSensitiveLevel { get; set; }

    public string? roHSCompliant { get; set; }

    public string? roHSCompliantChina { get; set; }

    public decimal? reachPrintingFlag { get; set; }

    public decimal? ulRegistrationFlag { get; set; }

    public string? packageCode { get; set; }

    public string? packageType { get; set; }

    public string? packageGroup { get; set; }

    public string? packageCategory { get; set; }

    public long? packagePinCount { get; set; }

    public decimal? packagePitch { get; set; }

    public decimal? packageLength { get; set; }

    public decimal? packageWidth { get; set; }

    public decimal? packageBodyThickness { get; set; }

    public string? packageBodySize { get; set; }

    public string? assemblyOutPackagingType { get; set; }

    public string? singulationProcess { get; set; }

    public string? chipVersion { get; set; }

    public long? thickness { get; set; }

    public string? processTechnology { get; set; }

    public string? waferTechnology { get; set; }

    public string? waferSize { get; set; }

    public DateTime? pdnIssueDate { get; set; }

    public DateTime? pdnLastBuyDate { get; set; }

    public DateTime? pdnLastShipDate { get; set; }

    public DateTime? extendedSupportDate { get; set; }

    public DateTime? orderUntilDate { get; set; }

    public DateTimeOffset? activeDate { get; set; }

    public DateTimeOffset? obsoleteDateP6 { get; set; }

    public DateTimeOffset? deactivateDateP7 { get; set; }

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

    public string? canForecast { get; set; }

    public string? isPartNonCancelableNonReschedule { get; set; }

    public string? isPartPublish { get; set; }

    public string? eccn { get; set; }

    public string? htsus { get; set; }

    public string? customerPartNumber { get; set; }

    public string? goldenRecord { get; set; }

    public string? partNumberType { get; set; }

    public string? productGeneralType { get; set; }

    public string? productType { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
