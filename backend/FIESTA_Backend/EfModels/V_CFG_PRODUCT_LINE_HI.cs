using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_LINE_HI
{
    public decimal CFG_PRODUCT_LINE_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCT_LINE_HIS_DATE { get; set; }

    public string? CFG_PRODUCT_LINE_HIS_USERID { get; set; }

    public string? CFG_PRODUCT_LINE_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? productHierarchy1 { get; set; }

    public string? productHierarchy2 { get; set; }

    public string? productHierarchy3 { get; set; }

    public string? productLine { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
