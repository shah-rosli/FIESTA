using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS_PREVCYCLE_R3ITC1
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string supplyPlant { get; set; } = null!;

    public string supplyStorageLocation { get; set; } = null!;

    public string supplyLegacyLine { get; set; } = null!;

    public string flowAlternative { get; set; } = null!;

    public decimal? ratio { get; set; }

    public string? priority { get; set; }

    public string? productionVersion { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string processStatus { get; set; } = null!;
}
