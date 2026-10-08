using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_COMPONENTS_HI
{
    public decimal CFG_COMPONENTS_HIS_ID { get; set; }

    public DateTimeOffset? CFG_COMPONENTS_HIS_DATE { get; set; }

    public string? CFG_COMPONENTS_HIS_USERID { get; set; }

    public string? CFG_COMPONENTS_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string flowNumber { get; set; } = null!;

    public string componentPartNumber { get; set; } = null!;

    public decimal? componentLeadTime { get; set; }

    public string componentConsumption { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;
}
