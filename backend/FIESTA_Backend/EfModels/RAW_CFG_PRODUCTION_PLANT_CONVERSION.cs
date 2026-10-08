using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_PRODUCTION_PLANT_CONVERSION
{
    public string? createdBy { get; set; }

    public string? company { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? legacyType { get; set; }

    public string? legacyLine { get; set; }

    public string? groupStage { get; set; }

    public string? massProductionFlag { get; set; }

    public string? plantAndSlocVsLegacyLineRecordID { get; set; }

    public string? hmeType { get; set; }

    public string activeFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
