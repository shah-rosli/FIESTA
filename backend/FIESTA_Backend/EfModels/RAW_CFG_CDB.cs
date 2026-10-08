using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_CDB
{
    public string? createdBy { get; set; }

    public string opn { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string lineName { get; set; } = null!;

    public string activeFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public bool? haveError { get; set; }

    public string? errorMessage { get; set; }

    public bool? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
