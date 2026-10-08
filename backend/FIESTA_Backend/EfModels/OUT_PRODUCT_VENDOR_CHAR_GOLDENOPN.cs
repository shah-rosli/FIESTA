using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCT_VENDOR_CHAR_GOLDENOPN
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string groupStageStep { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string characteristicsName { get; set; } = null!;

    public string? characteristicsValue { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string groupStageFlowNumber { get; set; } = null!;

    public string processStatus { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string factoryFlag { get; set; } = null!;
}
