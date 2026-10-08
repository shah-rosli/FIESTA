using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCT_STANDARD_COST
{
    public decimal recordKey { get; set; }

    public string companyCode { get; set; } = null!;

    public DateOnly postingDate { get; set; }

    public string plant { get; set; } = null!;

    public string partNumberKey { get; set; } = null!;

    public string? partNumber { get; set; }

    public decimal? companyCodeCurrencyLegalValuation { get; set; }

    public string? companyCodeCurrency { get; set; }

    public short? priceUnit { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
