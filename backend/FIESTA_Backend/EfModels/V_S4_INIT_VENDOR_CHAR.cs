using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_S4_INIT_VENDOR_CHAR
{
    public string storageLocation { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string groupStageStep { get; set; } = null!;

    public string characteristicsName { get; set; } = null!;

    public string? characteristicsValue { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
