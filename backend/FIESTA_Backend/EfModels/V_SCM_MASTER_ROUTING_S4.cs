using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_SCM_MASTER_ROUTING_S4
{
    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string routingGroupKey { get; set; } = null!;

    public string routingKey { get; set; } = null!;

    public string s4OperationNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public long? conversionFactor { get; set; }

    public decimal? leadTime { get; set; }

    public string controlKey { get; set; } = null!;

    public string s4OperationShortText { get; set; } = null!;
}
