using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class PLM_AGL_MATRIX
{
    public string referenceKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string originalPartNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string matrixBins { get; set; } = null!;

    public string matrixBin { get; set; } = null!;

    public string? bin { get; set; }

    public string finishedWaferNumber { get; set; } = null!;

    public decimal? fontDiePerWafer { get; set; }

    public DateTimeOffset? transDateAndTime { get; set; }

    public DateTimeOffset? fiestaCreateDateAndTime { get; set; }

    public string? deleteFlag { get; set; }
}
