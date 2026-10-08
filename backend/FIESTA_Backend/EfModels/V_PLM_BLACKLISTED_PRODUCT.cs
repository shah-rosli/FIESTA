using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PLM_BLACKLISTED_PRODUCT
    {
        public string partNumber { get; set; } = null!;

        public string pnType { get; set; } = null!;

        public string? legacyOrg { get; set; }

        public string? plmStatus { get; set; }

        public string blacklistReason { get; set; } = null!;

        public string? blacklistReasonDescription { get; set; }

        public string details { get; set; } = null!;

        public string? category { get; set; }

        public string? type { get; set; }

        public DateTimeOffset? createDateAndTime { get; set; }
    }
}
