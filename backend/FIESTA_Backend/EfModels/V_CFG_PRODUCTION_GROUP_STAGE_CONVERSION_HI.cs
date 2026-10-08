using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HI
{
    public decimal CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_DATE { get; set; }

    public string? CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_USERID { get; set; }

    public string? CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? groupStage { get; set; }

    public string? legacyType { get; set; }

    public string? legacyGroupStage { get; set; }

    public string? groupStageVSLegacyGroupStageRecordID { get; set; }

    public string activeFlag { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
