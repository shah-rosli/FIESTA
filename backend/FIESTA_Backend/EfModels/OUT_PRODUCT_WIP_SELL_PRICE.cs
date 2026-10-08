using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCT_WIP_SELL_PRICE
{
    public decimal recordKey { get; set; }

    public string sellingPlant { get; set; } = null!;

    public string partNumberKey { get; set; } = null!;

    public DateOnly validFromDate { get; set; }

    public string? partNumber { get; set; }

    public decimal? price { get; set; }

    public string? currency { get; set; }

    public DateOnly? validToDate { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
