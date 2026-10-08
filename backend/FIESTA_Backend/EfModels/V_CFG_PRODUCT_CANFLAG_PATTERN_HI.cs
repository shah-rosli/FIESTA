using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_CANFLAG_PATTERN_HI
{
    public decimal CFG_PRODUCT_CANFLAG_PATTERN_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCT_CANFLAG_PATTERN_HIS_DATE { get; set; }

    public string? CFG_PRODUCT_CANFLAG_PATTERN_HIS_USERID { get; set; }

    public string? CFG_PRODUCT_CANFLAG_PATTERN_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? partNumber { get; set; }

    public string? plmStatus { get; set; }

    public string? productHierarchy1 { get; set; }

    public string? productHierarchy2 { get; set; }

    public string? productHierarchy3 { get; set; }

    public string? productHierarchy4 { get; set; }

    public string? productHierarchy5 { get; set; }

    public string? phDescription1 { get; set; }

    public string? phDescription2 { get; set; }

    public string? phDescription3 { get; set; }

    public string? phDescription4 { get; set; }

    public string? phDescription5 { get; set; }

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

    public string? isPartNotRecommendNewDesign { get; set; }

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

    public string? remark { get; set; }

    public string? deleteFlag { get; set; }

    public string? pattern { get; set; }

    public string? lastUpdateBy { get; set; }
}
