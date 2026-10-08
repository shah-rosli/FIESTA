using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PLM_BLACKLISTED_PRODUCTION
    {
        public string? OPN { get; set; }
        public string? legacyOrg { get; set; }
        public string? blacklistReason { get; set; }
        public string? details { get; set; }
        public string? category { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
    }
}
