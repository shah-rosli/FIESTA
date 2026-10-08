using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_COMPONENT
{
    public decimal recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string flowNumber { get; set; } = null!;

    public string componentPartNumber { get; set; } = null!;

    public decimal? componentLeadTime { get; set; }

    public string componentConsumption { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? createdBy { get; set; }

    public string? modifiedBy { get; set; }

    public string deleteFlag { get; set; } = null!;
}
