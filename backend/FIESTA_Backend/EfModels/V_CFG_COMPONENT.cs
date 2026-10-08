using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_COMPONENT
{
    public decimal recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? legacyOrganization { get; set; }

    public string? plmStatus { get; set; }

    public string groupStage { get; set; } = null!;

    public string flowNumber { get; set; } = null!;

    public string? flowDescription { get; set; }

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string lineName { get; set; } = null!;

    public string componentPartNumber { get; set; } = null!;

    public string? componentMaterialType { get; set; }

    public string? componentPartType { get; set; }

    public string? componentSubType { get; set; }

    public decimal? componentStandardUsage { get; set; }

    public string componentUOM { get; set; } = null!;

    public decimal? componentLeadTime { get; set; }

    public string componentConsumption { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }
}
