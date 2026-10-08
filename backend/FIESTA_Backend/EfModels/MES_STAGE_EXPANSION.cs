using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MES_STAGE_EXPANSION
{
    public decimal recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string mesLineName { get; set; } = null!;

    public string mesRouting { get; set; } = null!;

    public string mesStage { get; set; } = null!;

    public string activityRateCode { get; set; } = null!;

    public string mesRoutingSequence { get; set; } = null!;

    public decimal mesStageSequence { get; set; }

    public decimal cycleTime { get; set; }

    public decimal yield { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}

