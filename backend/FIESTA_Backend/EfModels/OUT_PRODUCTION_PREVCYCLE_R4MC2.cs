using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCTION_PREVCYCLE_R4MC2
{
    public decimal recordKey { get; set; }

    public string opn { get; set; } = null!;

    public decimal plmBomSortingLevel { get; set; }

    public string parentPartNumber { get; set; } = null!;

    public string parentPartNumberKey { get; set; } = null!;

    public string parentOriginalPartNumber { get; set; } = null!;

    public string parentGroupStage { get; set; } = null!;

    public string childPartNumber { get; set; } = null!;

    public string childPartNumberKey { get; set; } = null!;

    public string childOriginalPartNumber { get; set; } = null!;

    public string childGroupStage { get; set; } = null!;

    public decimal childGroupStageType { get; set; }

    public string childBaseUnitOfMeasure { get; set; } = null!;

    public string childGroupStageFlowNumber { get; set; } = null!;

    public string childGroupStageFlow { get; set; } = null!;

    public string childGroupStageFlowPlmStatus { get; set; } = null!;

    public string childGroupStageStep { get; set; } = null!;

    public decimal? childGroupStageStepSetupTime { get; set; }

    public decimal? childGroupStageStepLeadTime { get; set; }

    public decimal? childGroupStageStepLaborTime { get; set; }

    public string childGroupStageStepPlmStatus { get; set; } = null!;

    public string childCompanyCode { get; set; } = null!;

    public string childPlant { get; set; } = null!;

    public string childStorageLocation { get; set; } = null!;

    public string childLegacyLine { get; set; } = null!;

    public long childGrouping { get; set; }

    public decimal childSequenceNumber { get; set; }

    public long childQty { get; set; }

    public string operationNumber { get; set; } = null!;

    public string materialType { get; set; } = null!;

    public string marketSegment { get; set; } = null!;

    public string legacyOrganization { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string parentCompanyCode { get; set; } = null!;

    public string parentPlant { get; set; } = null!;

    public long childStructure { get; set; }

    public string childRouting { get; set; } = null!;

    public string supplyPlant { get; set; } = null!;

    public string supplyStorageLocation { get; set; } = null!;

    public string? supplyLegacyLine { get; set; }

    public string processStatus { get; set; } = null!;
}
