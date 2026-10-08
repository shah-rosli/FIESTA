using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS_HI
{
    public decimal CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS_HIS_DATE { get; set; }

    public string? CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS_HIS_USERID { get; set; }

    public string? CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? legacyOrganization { get; set; }

    public string? plmStatus { get; set; }

    public string? groupStage { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string supplyPlant { get; set; } = null!;

    public string supplyStorageLocation { get; set; } = null!;

    public decimal? ratio { get; set; }

    public string? priority { get; set; }

    public string? productionVersion { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? lastUpdateBy { get; set; }
}
