using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class TRN_PRODUCTION_LOTSIZE
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public long? defaultMinimumLotSize { get; set; }

    public long? minimumLotSize { get; set; }

    public DateTime? createDateAndTime { get; set; }

    public DateTime? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTime? deleteDateAndTime { get; set; }

    public string lotSizingProcedure { get; set; } = null!;

    public long? incrementLotSize { get; set; }

    public long? maximumLotSize { get; set; }
}
