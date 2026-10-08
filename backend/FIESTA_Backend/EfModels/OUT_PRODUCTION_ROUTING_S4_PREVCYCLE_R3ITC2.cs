using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCTION_ROUTING_S4_PREVCYCLE_R3ITC2
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string routingGroupKey { get; set; } = null!;

    public string routingKey { get; set; } = null!;

    public string taskListDescription { get; set; } = null!;

    public string s4OperationNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public long? conversionFactor { get; set; }

    public string unitOfMeasure { get; set; } = null!;

    public string setupTimeUnitOfMeasure { get; set; } = null!;

    public decimal? setupTime { get; set; }

    public string leadTimeUnitOfMeasure { get; set; } = null!;

    public decimal? leadTime { get; set; }

    public string laborTimeUnitOfMeasure { get; set; } = null!;

    public decimal? laborTime { get; set; }

    public DateTime validFromDate { get; set; }

    public DateTime validToDate { get; set; }

    public string controlKey { get; set; } = null!;

    public string? workCenter { get; set; }

    public string s4OperationShortText { get; set; } = null!;

    public string? s4OperationLongText { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string headerDeleteFlag { get; set; } = null!;

    public string processStatus { get; set; } = null!;
}
