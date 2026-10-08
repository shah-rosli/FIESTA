using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_PRODUCTION_GROUP_STAGE
{
    public string? createdBy { get; set; }

    public string? groupStage { get; set; }

    public decimal? groupStageSequence { get; set; }

    public string? groupStageName { get; set; }

    public string? groupStageType { get; set; }

    public string? groupStageExplanation { get; set; }

    public string? inputUoM { get; set; }

    public string? outputUoM { get; set; }

    public string? groupStageRecordID { get; set; }

    public string activeFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
