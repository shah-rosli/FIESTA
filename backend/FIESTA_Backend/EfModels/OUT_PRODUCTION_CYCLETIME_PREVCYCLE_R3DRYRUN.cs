using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCTION_CYCLETIME_PREVCYCLE_R3DRYRUN
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string glmStage { get; set; } = null!;

    public string unitOfTime { get; set; } = null!;

    public long? quantityUnitOfTime { get; set; }

    public string classification { get; set; } = null!;

    public decimal? time { get; set; }

    public DateTime validFromDate { get; set; }

    public string originalPartNumber { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;

    public string factoryFlag { get; set; } = null!;
}
