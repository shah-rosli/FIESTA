using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_PRODUCTION_YIELD
{
    public string opn { get; set; } = null!;

    public long bomLevel { get; set; }

    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public long? totalStage { get; set; }

    public string glmStage { get; set; } = null!;

    public string yieldFlag { get; set; } = null!;

    public decimal? defaultYield { get; set; }

    public decimal? yield { get; set; }

    public DateTime validFromDate { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;

    public string factoryFlag { get; set; } = null!;

    public string? pattern { get; set; }

    public string? flowNumber { get; set; }

    public string? buyOffFlag { get; set; }
}
