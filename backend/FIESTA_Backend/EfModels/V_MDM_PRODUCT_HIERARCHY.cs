using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MDM_PRODUCT_HIERARCHY
{
    public decimal? recordKey { get; set; }

    public string phCode { get; set; } = null!;

    public string? level { get; set; }

    public string? phDescription { get; set; }

    public string? upperKey { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }
}
