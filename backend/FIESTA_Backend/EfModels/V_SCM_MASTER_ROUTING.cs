using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_SCM_MASTER_ROUTING
{
    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string storageLocationType { get; set; } = null!;

    public string routingGroupKey { get; set; } = null!;

    public string routingKey { get; set; } = null!;

    public string operationNumber { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string glmWF { get; set; } = null!;

    public long glmSequence { get; set; }

    public byte glmAlternative { get; set; }

    public string glmStage { get; set; } = null!;
}
