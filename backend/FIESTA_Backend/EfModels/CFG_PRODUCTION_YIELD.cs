using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_YIELD
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string glmStage { get; set; } = null!;
        public decimal yield { get; set; }
        public DateTime validFromDate { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? createdBy { get; set; }
        public string? modifiedBy { get; set; }
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string? yieldFlag { get; set; }
        public string? groupStage { get; set; }
    }
}
