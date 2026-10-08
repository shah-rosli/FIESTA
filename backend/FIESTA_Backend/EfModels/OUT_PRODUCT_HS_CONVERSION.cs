using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCT_HS_CONVERSION
{
    public decimal recordKey { get; set; }

    public string hsType { get; set; } = null!;

    public string countryCode { get; set; } = null!;

    public string? partNumberKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? hsCode { get; set; }

    public string? hsDescription { get; set; }

    public string? hsDescriptionDE { get; set; }

    public DateOnly? validFrom { get; set; }

    public DateOnly? validTo { get; set; }

    public string? partNumberType { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
