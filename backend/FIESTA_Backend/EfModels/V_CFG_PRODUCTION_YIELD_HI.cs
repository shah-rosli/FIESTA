using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCTION_YIELD_HI
{
    public decimal CFG_PRODUCTION_YIELD_HIS_ID { get; set; }

    public DateTimeOffset? CFG_PRODUCTION_YIELD_HIS_DATE { get; set; }

    public string? CFG_PRODUCTION_YIELD_HIS_USERID { get; set; }

    public string? CFG_PRODUCTION_YIELD_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? partNumber { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? glmStage { get; set; }

    public DateTime? validFromDate { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? yieldFlag { get; set; }

    public string? groupStage { get; set; }

    public string? pattern { get; set; }

    public long? totalStage { get; set; }

    public decimal? yield { get; set; }

    public string? lastUpdateBy { get; set; }
}
