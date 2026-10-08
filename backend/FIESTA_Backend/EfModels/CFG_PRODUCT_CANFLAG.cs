using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_PRODUCT_CANFLAG
{
    public decimal recordKey { get; set; }

    public string flag { get; set; } = null!;

    public string? highPriority { get; set; }

    public string? p1 { get; set; }

    public string? p2 { get; set; }

    public string? p3 { get; set; }

    public string? p4 { get; set; }

    public string? p5 { get; set; }

    public string? p6 { get; set; }

    public string? p7 { get; set; }

    public string? b1 { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
