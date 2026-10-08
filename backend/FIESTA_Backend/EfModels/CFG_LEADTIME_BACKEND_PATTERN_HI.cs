using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_LEADTIME_BACKEND_PATTERN_HI
{
    public decimal CFG_LEADTIME_BACKEND_PATTERN_HIS_ID { get; set; }

    public DateTimeOffset? CFG_LEADTIME_BACKEND_PATTERN_HIS_DATE { get; set; }

    public string? CFG_LEADTIME_BACKEND_PATTERN_HIS_USERID { get; set; }

    public string? CFG_LEADTIME_BACKEND_PATTERN_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string? RRSite { get; set; }

    public string? plant { get; set; }

    public string? storageLocation { get; set; }

    public string? originalPartNumber { get; set; }

    public string? packageCode { get; set; }

    public string? packageGroup { get; set; }

    public string? packageType { get; set; }

    public string? packageBodySize { get; set; }

    public long? packagePinCount { get; set; }

    public string? productHierarchyCode { get; set; }

    public string? groupStage { get; set; }

    public string? legacyStage { get; set; }

    public DateTime? validFromDate { get; set; }

    public decimal? leadTime { get; set; }

    public string? remark { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? pattern { get; set; }
}
