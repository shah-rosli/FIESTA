using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_PRODUCT_LINE
{
    public string? createdBy { get; set; }

    public string? productHierarchy1 { get; set; }

    public string? productHierarchy2 { get; set; }

    public string? productHierarchy3 { get; set; }

    public string? productLine { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
