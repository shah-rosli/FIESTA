using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class OUT_PRODUCTION_ROUTING_PREVCYCLE6_DEV
    {
        public decimal recordKey { get; set; }
        public string? partNumberKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string storageLocationType { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public string routingGroupKey { get; set; } = null!;
        public string routingKey { get; set; } = null!;
        public string taskListDescription { get; set; } = null!;
        public string operationNumber { get; set; } = null!;
        public string legacyStage { get; set; } = null!;
        public string s4OperationNumber { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public long groupStageType { get; set; }
        public string groupStageFlow { get; set; } = null!;
        public long? conversionFactor { get; set; }
        public string unitOfMeasure { get; set; } = null!;
        public string glmWF { get; set; } = null!;
        public byte glmSequence { get; set; }
        public byte glmAlternative { get; set; }
        public string glmStage { get; set; } = null!;
        public string endOfGroupStage { get; set; } = null!;
        public string mpnToOPNFlag { get; set; } = null!;
        public string? costCenter { get; set; }
        public string setupTimeUnitOfMeasure { get; set; } = null!;
        public decimal? setupTime { get; set; }
        public string leadTimeUnitOfMeasure { get; set; } = null!;
        public decimal? leadTime { get; set; }
        public string laborTimeUnitOfMeasure { get; set; } = null!;
        public decimal? laborTime { get; set; }
        public string originalPartNumber { get; set; } = null!;
        public string? supplyPlant { get; set; }
        public string? supplyStorageLocation { get; set; }
        public string? supplyLegacyLine { get; set; }
        public DateTime validFromDate { get; set; }
        public DateTime validToDate { get; set; }
        public string? hmeType { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string updateType { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string? fiestaRules { get; set; }
        public string specialOriginalPartNumber { get; set; } = null!;
    }
}
