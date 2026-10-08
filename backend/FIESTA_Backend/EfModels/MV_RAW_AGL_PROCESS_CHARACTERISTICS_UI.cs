using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MV_RAW_AGL_PROCESS_CHARACTERISTICS_UI
{
    public string referenceKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string flowNumber { get; set; } = null!;

    public string flowDescription { get; set; } = null!;

    public string lineName { get; set; } = null!;

    public string operation { get; set; } = null!;

    public string characteristicsName { get; set; } = null!;

    public string? characteristicsValue { get; set; }

    public DateTimeOffset? transDateAndTime { get; set; }

    public string? deleteFlag { get; set; }
}
