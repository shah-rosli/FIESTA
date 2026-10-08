using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class PLM_AGL_COMPONENT
{
    public string referenceKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string flowNumber { get; set; } = null!;

    public string? flowDescription { get; set; }

    public string componentPartNumber { get; set; } = null!;

    public string componentPartType { get; set; } = null!;

    public string componentSubType { get; set; } = null!;

    public long componentStandardUsage { get; set; }

    public string componentUOM { get; set; } = null!;

    public string? lineName { get; set; }

    public DateTimeOffset? transDateAndTime { get; set; }

    public DateTimeOffset? fiestaCreateDateAndTime { get; set; }

    public string? deleteFlag { get; set; }
}
