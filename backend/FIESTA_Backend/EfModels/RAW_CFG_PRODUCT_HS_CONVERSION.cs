using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_PRODUCT_HS_CONVERSION
{
    public string? createdBy { get; set; }

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

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
