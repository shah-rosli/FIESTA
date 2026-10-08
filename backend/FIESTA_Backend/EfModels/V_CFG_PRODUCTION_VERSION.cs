using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCTION_VERSION
{
    public decimal recordKey { get; set; }

    public string? partNumber { get; set; }

    public string? legacyOrganization { get; set; }

    public string? plmStatus { get; set; }

    public string? groupStage { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? legacyLine { get; set; }

    public string? productionVersion { get; set; }

    public string? productionVersionLock { get; set; }

    public DateTime validFromDate { get; set; }

    public DateTime validToDate { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }
}
