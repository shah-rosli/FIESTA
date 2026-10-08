using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_NONPRODUCTION_PRODUCT_PLANT
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string? legacyLine { get; set; }

    public decimal? inhouseProductionTime { get; set; }

    public string? profitCenter { get; set; }

    public string materialType { get; set; } = null!;

    public decimal? planningYield { get; set; }

    public long? minimumLotSize { get; set; }

    public string? specialOriginalPartNumber { get; set; }

    public string? businessDivision { get; set; }

    public string? businessPlannerCode { get; set; }

    public string? factoryFlag { get; set; }

    public string? lotSizingProcedure { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? goldenRecord { get; set; }

    public string? sentFromSystem { get; set; }

    public string processStatus { get; set; } = null!;
}
