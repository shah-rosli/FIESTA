using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_HIS_V2
{
    public decimal CFG_PRODUCT_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCT_HIS_DATE { get; set; }

    public string? CFG_PRODUCT_HIS_USERID { get; set; }

    public string? CFG_PRODUCT_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? partDescription { get; set; }

    public string? plmStatus { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? standardPackingQuantity { get; set; }

    public string? businessPlannerCode { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? proposePartDesc { get; set; }

    public string? partDescApprovedBy { get; set; }

    public DateTimeOffset? partDescApprovedDateTime { get; set; }

    public string? sentFromSystem { get; set; }

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;

    public string? partNumber { get; set; }

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

    public string? isPartNotRecommendNewDesign { get; set; }

    public string? salesRootPartNumber { get; set; }

    public decimal? isSalesRoot { get; set; }

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
}
