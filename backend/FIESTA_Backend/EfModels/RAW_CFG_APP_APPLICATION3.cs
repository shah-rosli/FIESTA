using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_APP_APPLICATION3
{
    public string? createdBy { get; set; }

    public string applicationLevel3Code { get; set; } = null!;

    public string applicationLevel3Name { get; set; } = null!;

    public string applicationLevel2Code { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
