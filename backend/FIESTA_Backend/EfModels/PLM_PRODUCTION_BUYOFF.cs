using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_PRODUCTION_BUYOFF
    {
        public decimal recordKey { get; set; }
        public string opn { get; set; } = null!;
        public decimal plmBomSortingLevel { get; set; }
        public string partNumber { get; set; } = null!;
        public string originalPartNumber { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public decimal groupStageType { get; set; }
        public string baseUnitOfMeasure { get; set; } = null!;
        public string groupStageFlowNumber { get; set; } = null!;
        public string groupStageFlow { get; set; } = null!;
        public string groupStageFlowPlmStatus { get; set; } = null!;
        public string groupStageStep { get; set; } = null!;
        public string groupStageStepPlmStatus { get; set; } = null!;
        public string companyCode { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public long grouping { get; set; }
        public decimal sequenceNumber { get; set; }
        public long qty { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string updateType { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string? fiestaRules { get; set; }
        public string fiestaBuyoff { get; set; } = null!;
        public string userBuyoff { get; set; } = null!;
        public string structure { get; set; } = null!;
        public string? routing { get; set; }
        public long groupStageStepNumber { get; set; }
        public string? buyOffComment { get; set; }
        public DateTimeOffset? buyoffDate { get; set; }
        public string? buyoffUserId { get; set; }
        public string? buyoffDelegate { get; set; }
    }
}
