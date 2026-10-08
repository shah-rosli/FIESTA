using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_APP_APPLICATION1_HI
{
    public decimal CFG_APP_APPLICATION1_HIS_ID { get; set; }

    public DateTimeOffset? CFG_APP_APPLICATION1_HIS_DATE { get; set; }

    public string? CFG_APP_APPLICATION1_HIS_USERID { get; set; }

    public string? CFG_APP_APPLICATION1_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? applicationLevel1Code { get; set; }

    public string? applicationLevel1Name { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
