using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_BUSINESS_PLANNER_CODE_HI
{
    public decimal CFG_BUSINESS_PLANNER_CODE_HIS_ID { get; set; }

    public DateTimeOffset? CFG_BUSINESS_PLANNER_CODE_HIS_DATE { get; set; }

    public string? CFG_BUSINESS_PLANNER_CODE_HIS_USERID { get; set; }

    public string? CFG_BUSINESS_PLANNER_CODE_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? businessPlannerCode { get; set; }

    public string activeFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }
}
