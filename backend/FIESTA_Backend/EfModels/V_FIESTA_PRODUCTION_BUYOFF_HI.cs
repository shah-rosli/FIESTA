using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_FIESTA_PRODUCTION_BUYOFF_HI
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
        public string? supplyPlant { get; set; }
        public string? supplyStorageLocation { get; set; }
        public string? supplyLegacyLine { get; set; }
        public long? structure { get; set; }
        public long? grouping { get; set; }
        public string? routing { get; set; }
        public decimal? sequenceNumber { get; set; }
        public long? qty { get; set; }
        public string? glmWF { get; set; }
        public string? routingKey { get; set; }
        public decimal? glmSequence { get; set; }
        public string? glmAlternative { get; set; }
        public string? operationNumber { get; set; }
        public long? conversionFactor { get; set; }
        public string? glmStage { get; set; }
        public string? endOfGroupStage { get; set; }
        public string? mpnToOPNFlag { get; set; }
        public string? costCenter { get; set; }
        public string? hmeType { get; set; }
        public string? buyOffComment { get; set; }
        public DateTimeOffset? buyoffDate { get; set; }
        public string? buyoffUserId { get; set; }
        public string? buyoffDelegate { get; set; }
        public decimal? opnVersion { get; set; }
    }
}
