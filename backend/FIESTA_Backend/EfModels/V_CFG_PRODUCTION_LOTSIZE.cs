using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_PRODUCTION_LOTSIZE
    {
        public decimal recordKey { get; set; }

        public string partNumber { get; set; } = null!;

        public string? legacyOrganization { get; set; }

        public string? plmStatus { get; set; }

        public string plant { get; set; } = null!;

        public string storageLocation { get; set; } = null!;

        public string? legacyLine { get; set; }

        public long? minimumLotSize { get; set; }

        public long? incrementLotSize { get; set; }

        public long? maximumLotSize { get; set; }

        public string lotSizingProcedure { get; set; } = null!;

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? lastUpdateBy { get; set; }
    }
}
