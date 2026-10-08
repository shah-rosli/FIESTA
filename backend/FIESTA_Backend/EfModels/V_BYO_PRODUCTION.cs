using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_BYO_PRODUCTION
{
    public string opn { get; set; } = null!;

    public decimal bomLevel { get; set; }

    public string parentPartNumber { get; set; } = null!;

    public string parentProcessingSubType { get; set; } = null!;

    public string parentGroupStage { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string processingSubType { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public long groupStageType { get; set; }

    public string unitOfMeasure { get; set; } = null!;

    public string companyCode { get; set; } = null!;

    public string lineName { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public long dieSet { get; set; }

    public long dieOrder { get; set; }

    public long qty { get; set; }

    public string flowNumber { get; set; } = null!;

    public string flowDescription { get; set; } = null!;

    public string flowPlmStatus { get; set; } = null!;

    public string operation { get; set; } = null!;

    public decimal operationSequenceNumber { get; set; }

    public string operationNumber { get; set; } = null!;

    public string operationPlmStatus { get; set; } = null!;

    public string supplyLineName { get; set; } = null!;

    public string supplyPlant { get; set; } = null!;

    public string supplyStorageLocation { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public string? productionEOLFlag { get; set; }

    public string? userSignOffBy { get; set; }

    public DateTimeOffset? userSignOffDate { get; set; }

    public long productionChangeOrder { get; set; }

    public string? prefixChangeOrder { get; set; }

    public string? BYOProductPartNumber { get; set; }
}
