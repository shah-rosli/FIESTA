using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string supplyPlant { get; set; } = null!;
        public string supplyStorageLocation { get; set; } = null!;
        public string? priority { get; set; }
        public decimal? ratio { get; set; }
        public string? productionVersion { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? createdBy { get; set; }
        public string? modifiedBy { get; set; }
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string deleteFlag { get; set; } = null!;
    }
}
