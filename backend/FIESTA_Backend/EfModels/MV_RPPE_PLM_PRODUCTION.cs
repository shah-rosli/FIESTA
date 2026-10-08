using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class MV_RPPE_PLM_PRODUCTION
    {
        public string? tree { get; set; }
        public string? processFlow { get; set; }
        public string? opn { get; set; }
        public decimal? plmBomSortingLevel { get; set; }
        public string? partNumber { get; set; }
        public string? originalPartNumber { get; set; }
        public string? groupStage { get; set; }
        public decimal? groupStageType { get; set; }
        public string? baseUnitOfMeasure { get; set; }
        public string? groupStageFlowNumber { get; set; }
        public string? groupStageFlow { get; set; }
        public string? groupStageFlowPlmStatus { get; set; }
        public string? groupStageStep { get; set; }
        public string? groupStageStepPlmStatus { get; set; }
        public string? companyCode { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? legacyLine { get; set; }
        public decimal? structure { get; set; }
        public decimal? grouping { get; set; }
        public decimal? routing { get; set; }
        public string? sequenceNumber { get; set; }
        public long? qty { get; set; }
        public string? glmWF { get; set; }
        public string? routingKey { get; set; }
        public string? glmSequence { get; set; }
        public string? glmAlternative { get; set; }
        public string? operationNumber { get; set; }
        public long? conversionFactor { get; set; }
        public string? glmStage { get; set; }
        public string? endOfGroupStage { get; set; }
        public string? mpnToOPNFlag { get; set; }
        public string? costCenter { get; set; }
        public string? hmeType { get; set; }
    }
}
