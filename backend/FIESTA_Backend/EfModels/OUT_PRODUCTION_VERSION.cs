using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCTION_VERSION
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string productionVersion { get; set; } = null!;

    public DateOnly validFromDate { get; set; }

    public DateOnly validToDate { get; set; }

    public string bomUsage { get; set; } = null!;

    public string bomKey { get; set; } = null!;

    public string bomAlternative { get; set; } = null!;

    public string routingGroupKey { get; set; } = null!;

    public string routingKey { get; set; } = null!;

    public string taskListDescription { get; set; } = null!;

    public long groupStageType { get; set; }

    public string? glmWF { get; set; }

    public string partNumberType { get; set; } = null!;

    public string companyCode { get; set; } = null!;

    public string? productionVersionLock { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string processStatus { get; set; } = null!;

    public string? netDieBypass { get; set; }

    public string? buyOffFlag { get; set; }
}
