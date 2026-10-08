using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_APP_APPLICATION3
{
    public decimal recordKey { get; set; }

    public string applicationLevel3Code { get; set; } = null!;

    public string applicationLevel3Name { get; set; } = null!;

    public string applicationLevel2Code { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? modifiedBy { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
