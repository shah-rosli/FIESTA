using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_PRODUCTION_CYCLETIME
    {
        public decimal recordKey { get; set; }

        public string partNumber { get; set; } = null!;

        public string? legacyOrganization { get; set; }

        public string? plmStatus { get; set; }

        public string plant { get; set; } = null!;

        public string storageLocation { get; set; } = null!;

        public string? legacyLine { get; set; }

        public string groupStage { get; set; } = null!;

        public string glmStage { get; set; } = null!;

        public string unitOfTime { get; set; } = null!;

        public long? quantityUnitOfTime { get; set; }

        public string classification { get; set; } = null!;

        public decimal? time { get; set; }

        public DateTime validFromDate { get; set; }

        public string? originalPartNumber { get; set; }

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? lastUpdateBy { get; set; }
    }
}
