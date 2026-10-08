using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MDM_PRODUCTION_STAGE
{
    public string stage { get; set; } = null!;

    public string? stageName { get; set; }

    public string? stageRecordID { get; set; }

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
