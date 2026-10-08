using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_PRODUCT_SALES_ROOT_PARTNUMBER
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string? partNumber { get; set; }

    public string? partDescription { get; set; }

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

    public string? isPartNotRecommendNewDesign { get; set; }

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

    public string? productHierarchyCode { get; set; }

    public string? productHierarchy3Code { get; set; }

    public string? productHierarchy3 { get; set; }

    public string? productHierarchy2 { get; set; }

    public string? productHierarchy1 { get; set; }

    public string? companyOfOrigin { get; set; }

    public string? materialType { get; set; }

    public decimal? isSalesRoot { get; set; }

    public string? goldenRecord { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? frequencyOrderIncrement { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? createdBy { get; set; }

    public string? modifiedBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
