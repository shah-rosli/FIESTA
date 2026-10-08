using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_PRO_BOM
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string bomUsage { get; set; } = null!;
        public string bomAlternative { get; set; } = null!;
        public string? baseUnitOfMeasure { get; set; }
        public long? baseQuantity { get; set; }
        public string? baseGroupStage { get; set; }
        public string componentPartNumber { get; set; } = null!;
        public string? bomItem { get; set; }
        public string? componentUnitOfMeasure { get; set; }
        public long? componentQuantity { get; set; }
        public string? componentGroupStage { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }
}
