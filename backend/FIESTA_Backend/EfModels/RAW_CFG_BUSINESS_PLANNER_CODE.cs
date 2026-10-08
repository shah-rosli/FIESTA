using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_BUSINESS_PLANNER_CODE
{
    public string? createdBy { get; set; }

    public string? businessPlannerCode { get; set; }

    public string activeFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
