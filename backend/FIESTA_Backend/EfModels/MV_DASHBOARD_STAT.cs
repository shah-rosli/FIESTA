using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MV_DASHBOARD_STAT
{
    public decimal? SEQ { get; set; }

    public string? GROUPING { get; set; }

    public string? OBJECT { get; set; }

    public decimal? COUNT { get; set; }

    public DateTimeOffset? LASTUPDATE { get; set; }
}
