using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MDM_PROFIT_CENTER
{
    public decimal? recordKey { get; set; }

    public string PRCTR { get; set; } = null!;

    public DateTimeOffset DATBI { get; set; }

    public string KHINR { get; set; } = null!;

    public string? KTEXT { get; set; }

    public string? processStatus { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }
}
