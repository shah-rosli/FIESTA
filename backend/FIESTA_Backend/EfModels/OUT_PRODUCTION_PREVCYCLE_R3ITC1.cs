using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCTION_PREVCYCLE_R3ITC1
{
    public decimal recordKey { get; set; }

    public string opn { get; set; } = null!;

    public long bomLevel { get; set; }

    public string parentPartNumber { get; set; } = null!;

    public string parentPartNumberKey { get; set; } = null!;

    public string parentOriginalPartNumber { get; set; } = null!;

    public string parentProcessingSubType { get; set; } = null!;

    public string parentGroupStage { get; set; } = null!;

    public string parentPlant { get; set; } = null!;

    public string childPartNumber { get; set; } = null!;

    public string childPartNumberKey { get; set; } = null!;

    public string childOriginalPartNumber { get; set; } = null!;

    public string childProcessingSubType { get; set; } = null!;

    public string childGroupStage { get; set; } = null!;

    public long childGroupStageType { get; set; }

    public string childUnitOfMeasure { get; set; } = null!;

    public string childGroupStageFlowNumber { get; set; } = null!;

    public string childGroupStageFlowDescription { get; set; } = null!;

    public string childGroupStageFlowPlmStatus { get; set; } = null!;

    public string childGroupStageStep { get; set; } = null!;

    public string childGroupStageStepPlmStatus { get; set; } = null!;

    public string childCompanyCode { get; set; } = null!;

    public string childPlant { get; set; } = null!;

    public string childStorageLocation { get; set; } = null!;

    public string childLegacyLine { get; set; } = null!;

    public long dieSet { get; set; }

    public long dieOrder { get; set; }

    public long qty { get; set; }

    public string operationNumber { get; set; } = null!;

    public string materialType { get; set; } = null!;

    public string marketSegment { get; set; } = null!;

    public string legacyOrganization { get; set; } = null!;

    public string? supplyPlant { get; set; }

    public string? supplyStorageLocation { get; set; }

    public string? supplyLegacyLine { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string processStatus { get; set; } = null!;
}
