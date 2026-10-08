using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION
{
    public decimal recordKey { get; set; }

    public string groupStage { get; set; } = null!;

    public string legacyType { get; set; } = null!;

    public string legacyGroupStage { get; set; } = null!;

    public string? groupStageVSLegacyGroupStageRecordID { get; set; }

    public string activeFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
