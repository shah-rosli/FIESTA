using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_VERSION
    {
        public decimal recordKey { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? productionVersion { get; set; }
        public string? productionVersionLock { get; set; }
        public DateTime? validFromDate { get; set; }
        public DateTime? validToDate { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string? createdBy { get; set; }
        public string? modifiedBy { get; set; }
        public string deleteFlag { get; set; } = null!;
    }
}
