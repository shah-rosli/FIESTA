using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_PRODUCTION_PLANNING_YIELD
    {
        public decimal recordKey { get; set; }

        public string partNumber { get; set; } = null!;

        public string? legacyOrganization { get; set; }

        public string? plmStatus { get; set; }

        public string plant { get; set; } = null!;

        public string storageLocation { get; set; } = null!;

        public string? legacyLine { get; set; }

        public string? groupStage { get; set; }

        public string glmStage { get; set; } = null!;

        public decimal? defaultYield { get; set; }

        public decimal? yield { get; set; }

        public DateTime validFromDate { get; set; }

        public string? pattern { get; set; }

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? lastUpdateBy { get; set; }
    }
}
