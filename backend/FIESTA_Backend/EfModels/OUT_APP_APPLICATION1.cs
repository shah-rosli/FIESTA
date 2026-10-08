using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_APP_APPLICATION1
{
    public decimal recordKey { get; set; }

    public string applicationLevel1Code { get; set; } = null!;

    public string applicationLevel1Name { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
