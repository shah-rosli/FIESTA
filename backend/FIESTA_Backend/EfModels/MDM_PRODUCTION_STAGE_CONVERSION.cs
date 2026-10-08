using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MDM_PRODUCTION_STAGE_CONVERSION
{
    public string stage { get; set; } = null!;

    public string legacyType { get; set; } = null!;

    public string legacyStage { get; set; } = null!;

    public string? stageVSLegacyStageRecordID { get; set; }

    public string? activeFlag { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public long? isRecordActive { get; set; }

    public DateTimeOffset? isRecordActiveChangeDateAndTime { get; set; }

    public DateTimeOffset? fiesta_sys_createTimeStamp { get; set; }

    public DateTimeOffset? fiesta_sys_updateTimeStamp { get; set; }

    public string? processStatus { get; set; }

    public string? buyOffFlag { get; set; }
}
