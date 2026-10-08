using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_AGL_PRODUCTION
{
    public string referenceKey { get; set; } = null!;

    public string opn { get; set; } = null!;

    public long bomLevel { get; set; }

    public string parentPartNumber { get; set; } = null!;

    public string parentOriginalPartNumber { get; set; } = null!;

    public string parentProcessingSubType { get; set; } = null!;

    public string parentGroupStage { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string flowNumber { get; set; } = null!;

    public string flowDescription { get; set; } = null!;

    public string flowPlmStatus { get; set; } = null!;

    public string operation { get; set; } = null!;

    public long operationSequenceNumber { get; set; }

    public string operationPlmStatus { get; set; } = null!;

    public string lineName { get; set; } = null!;

    public long multiDieSet { get; set; }

    public long? multiDieOrder { get; set; }

    public long qty { get; set; }

    public DateTimeOffset? transDateAndTime { get; set; }

    public string? deleteFlag { get; set; }
}
