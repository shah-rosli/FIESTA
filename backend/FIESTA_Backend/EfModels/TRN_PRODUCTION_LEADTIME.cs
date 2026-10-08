using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class TRN_PRODUCTION_LEADTIME
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public long? totalStage { get; set; }

    public string glmStage { get; set; } = null!;

    public decimal? defaultLeadTime { get; set; }

    public decimal? leadTime { get; set; }

    public DateTime? validFromDate { get; set; }

    public DateTime? createDateAndTime { get; set; }

    public DateTime? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTime? deleteDateAndTime { get; set; }

    public string factoryFlag { get; set; } = null!;
}
