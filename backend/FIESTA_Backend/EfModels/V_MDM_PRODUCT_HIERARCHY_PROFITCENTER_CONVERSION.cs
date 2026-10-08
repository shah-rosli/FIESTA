using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION
{
    public decimal? recordKey { get; set; }

    public string productHierarchyCode { get; set; } = null!;

    public string? profitCenterCode { get; set; }

    public string? profitCenter { get; set; }

    public string? deleteFlag { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
