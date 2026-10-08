using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class TRN_PRODUCT_PLANT
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public decimal? inhouseProductionTime { get; set; }

    public string profitCenter { get; set; } = null!;

    public string materialType { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public decimal? planningYield { get; set; }

    public long? minimumLotSize { get; set; }

    public string? fiestaRules { get; set; }

    public string? specialOriginalPartNumber { get; set; }

    public string businessDivision { get; set; } = null!;

    public string businessPlannerCode { get; set; } = null!;

    public string factoryFlag { get; set; } = null!;

    public string lotSizingProcedure { get; set; } = null!;
}
