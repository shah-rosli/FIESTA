using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCTION_GROUP_STAGE
{
    public decimal recordKey { get; set; }

    public string groupStage { get; set; } = null!;

    public decimal? groupStageSequence { get; set; }

    public string? groupStageName { get; set; }

    public string? groupStageType { get; set; }

    public string? groupStageExplanation { get; set; }

    public string? inputUoM { get; set; }

    public string? outputUoM { get; set; }

    public string? groupStageRecordID { get; set; }

    public string activeFlag { get; set; } = null!;

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
