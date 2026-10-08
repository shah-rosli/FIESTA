using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_DASHBOARD_STATS_V2
{
    public decimal? SEQ { get; set; }

    public string? GROUPING { get; set; }

    public string? OBJECT { get; set; }

    public decimal? COUNT { get; set; }

    public DateTimeOffset? LASTUPDATE { get; set; }
}
