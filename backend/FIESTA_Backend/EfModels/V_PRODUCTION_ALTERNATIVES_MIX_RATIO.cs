using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_PRODUCTION_ALTERNATIVES_MIX_RATIO
{
    public string? opn { get; set; }

    public long? bomLevel { get; set; }

    public decimal? recordKey { get; set; }

    public string? partNumberKey { get; set; }

    public string? partNumber { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? legacyLine { get; set; }

    public string? supplyPlant { get; set; }

    public string? supplyStorageLocation { get; set; }

    public string? supplyLegacyLine { get; set; }

    public string? flowAlternative { get; set; }

    public decimal? ratio { get; set; }

    public string? priority { get; set; }

    public string? productionVersion { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string? processStatus { get; set; }
}
