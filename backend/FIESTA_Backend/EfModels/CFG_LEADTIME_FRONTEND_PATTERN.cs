using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_LEADTIME_FRONTEND_PATTERN
{
    public decimal recordKey { get; set; }

    public string? RRSite { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? originalPartNumber { get; set; }

    public string? processTechnology { get; set; }

    public string? waferTechnology { get; set; }

    public string? roughWaferProcess { get; set; }

    public string? productHierarchyCode { get; set; }

    public string? groupStage { get; set; }

    public string? legacyStage { get; set; }

    public DateTime? validFromDate { get; set; }

    public decimal? leadTime { get; set; }

    public string? remark { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? createdBy { get; set; }

    public string? modifiedBy { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string pattern { get; set; } = null!;
}
