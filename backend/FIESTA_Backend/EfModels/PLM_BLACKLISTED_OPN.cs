using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_BLACKLISTED_OPN
    {
        public decimal recordKey { get; set; }
        public string? partNumber { get; set; }
        public string? blacklistReason { get; set; }
        public string? details { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public string? type { get; set; }
        public string? pnType { get; set; }
    }
}
