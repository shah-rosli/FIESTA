using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MDM_PROFIT_CENTER_HIERARCHY
{
    public string setName { get; set; } = null!;

    public int lineID { get; set; }

    public string? subSetName { get; set; }

    public string? description { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
