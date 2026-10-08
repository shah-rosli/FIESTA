using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PLM_PRODUCTION
    {
        public decimal recordKey { get; set; }

        public string opn { get; set; } = null!;

        public decimal bomLevel { get; set; }

        public string parentPartNumber { get; set; } = null!;

        public string parentOriginalPartNumber { get; set; } = null!;

        public string parentProcessingSubType { get; set; } = null!;

        public string parentGroupStage { get; set; } = null!;

        public string partNumber { get; set; } = null!;

        public string originalPartNumber { get; set; } = null!;

        public string processingSubType { get; set; } = null!;

        public string groupStage { get; set; } = null!;

        public long groupStageType { get; set; }

        public string componentUnitOfMeasure { get; set; } = null!;

        public string flowNumber { get; set; } = null!;

        public string flowDescription { get; set; } = null!;

        public string flowPlmStatus { get; set; } = null!;

        public string operation { get; set; } = null!;

        public long operationSequenceNumber { get; set; }

        public string operationNumber { get; set; } = null!;

        public string operationPlmStatus { get; set; } = null!;

        public string companyCode { get; set; } = null!;

        public string plant { get; set; } = null!;

        public string storageLocation { get; set; } = null!;

        public string lineName { get; set; } = null!;

        public long? multiDieSet { get; set; }

        public long? multiDieOrder { get; set; }

        public long qty { get; set; }

        public decimal? componentLeadTime { get; set; }

        public string componentConsumption { get; set; } = null!;

        public string updateType { get; set; } = null!;

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }

        public string? fiestaRules { get; set; }

        public string? fiestaSource { get; set; }

        public decimal? isBlacklisted { get; set; }

        public string? reason { get; set; }
    }
}
