using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_PRODUCT_ECCN_CONVERSION
{
    public string? createdBy { get; set; }

    public string? countryCode { get; set; }

    public string? legalRegulation { get; set; }

    public string? partNumberKey { get; set; }

    public string? foreignTradeOrganization { get; set; }

    public string? partNumber { get; set; }

    public string? eccn { get; set; }

    public string? controlGroup { get; set; }

    public string? ccat { get; set; }

    public string? indiMaintenance { get; set; }

    public string? noControl { get; set; }

    public string? partNumberType { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
