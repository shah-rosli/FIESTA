using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_HS_CONVERSION
{
    public decimal recordKey { get; set; }

    public string hsType { get; set; } = null!;

    public string countryCode { get; set; } = null!;

    public string? partNumberKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? hsCode { get; set; }

    public string? hsDescription { get; set; }

    public string? hsDescriptionDE { get; set; }

    public DateTime? validFrom { get; set; }

    public DateTime? validTo { get; set; }

    public string? partNumberType { get; set; }

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
