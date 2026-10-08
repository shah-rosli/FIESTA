using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class OUT_PRODUCT_PIR
    {
        public decimal recordKey { get; set; }
        public string partNumberKey { get; set; } = null!;
        public string partNumber { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string groupStageStep { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string updateType { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string? fiestaRules { get; set; }
    }
}
