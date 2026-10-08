using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_COMPONENTS_PREVCYCLE_R3ITC1
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string groupStageFlowNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string factoryFlag { get; set; } = null!;

    public string componentPartNumber { get; set; } = null!;

    public string componentPartType { get; set; } = null!;

    public string componentSubType { get; set; } = null!;

    public decimal? componentStandardUsage { get; set; }

    public string componentUOM { get; set; } = null!;

    public decimal? componentLeadTime { get; set; }

    public string componentConsumption { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string processStatus { get; set; } = null!;
}
