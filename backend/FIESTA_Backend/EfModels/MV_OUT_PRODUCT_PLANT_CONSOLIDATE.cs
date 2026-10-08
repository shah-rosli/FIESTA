using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MV_OUT_PRODUCT_PLANT_CONSOLIDATE
{
    public decimal? recordKey { get; set; }

    public string? partNumberKey { get; set; }

    public string? partNumber { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? legacyLine { get; set; }

    public decimal? inhouseProductionTime { get; set; }

    public string? profitCenter { get; set; }

    public string? materialType { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public decimal? planningYield { get; set; }

    public long? minimumLotSize { get; set; }

    public string? specialOriginalPartNumber { get; set; }

    public string? businessDivision { get; set; }

    public string? businessPlannerCode { get; set; }

    public string? factoryFlag { get; set; }

    public string? lotSizingProcedure { get; set; }

    public string? goldenRecord { get; set; }

    public string? sentFromSystem { get; set; }

    public string? processStatus { get; set; }
}
