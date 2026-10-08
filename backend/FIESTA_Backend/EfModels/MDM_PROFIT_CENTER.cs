using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MDM_PROFIT_CENTER
{
    public string PRCTR { get; set; } = null!;

    public DateTimeOffset DATBI { get; set; }

    public string KHINR { get; set; } = null!;

    public string? KTEXT { get; set; }

    public string? processStatus { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
