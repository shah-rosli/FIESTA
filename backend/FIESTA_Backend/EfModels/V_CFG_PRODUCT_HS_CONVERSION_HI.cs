using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_HS_CONVERSION_HI
{
    public decimal CFG_PRODUCT_HS_CONVERSION_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCT_HS_CONVERSION_HIS_DATE { get; set; }

    public string? CFG_PRODUCT_HS_CONVERSION_HIS_USERID { get; set; }

    public string? CFG_PRODUCT_HS_CONVERSION_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? hsType { get; set; }

    public string? countryCode { get; set; }

    public string? partNumberKey { get; set; }

    public string? partNumber { get; set; }

    public string? hsCode { get; set; }

    public string? hsDescription { get; set; }

    public string? hsDescriptionDE { get; set; }

    public DateTime? validFrom { get; set; }

    public DateTime? validTo { get; set; }

    public string? partNumberType { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
