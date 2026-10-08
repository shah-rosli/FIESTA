using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO
    {
        public decimal? recordKey { get; set; }

        public string partNumber { get; set; } = null!;

        public string? legacyOrganization { get; set; }

        public string? plmStatus { get; set; }

        public string? groupStage { get; set; }

        public string supplyPlant { get; set; } = null!;

        public string supplyStorageLocation { get; set; } = null!;

        public string? supplyLegacyLine { get; set; }

        public string? priority { get; set; }

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? lastUpdateBy { get; set; }
    }
}
