using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class OUT_PRODUCTION_BOM_PREVCYCLE6
    {
        public decimal recordKey { get; set; }
        public string partNumberKey { get; set; } = null!;
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string bomUsage { get; set; } = null!;
        public string bomStatus { get; set; } = null!;
        public string bomKey { get; set; } = null!;
        public string bomAlternative { get; set; } = null!;
        public string baseUnitOfMeasure { get; set; } = null!;
        public long baseQuantity { get; set; }
        public string baseGroupStage { get; set; } = null!;
        public long baseGroupStageType { get; set; }
        public DateTime validFromDate { get; set; }
        public DateTime validToDate { get; set; }
        public string componentPartNumberKey { get; set; } = null!;
        public string componentPartNumber { get; set; } = null!;
        public string bomItem { get; set; } = null!;
        public string componentUnitOfMeasure { get; set; } = null!;
        public long componentQuantity { get; set; }
        public string componentGroupStage { get; set; } = null!;
        public long componentGroupStageType { get; set; }
        public string? bomItemTextLine1 { get; set; }
        public string? bomItemTextLine2 { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string updateType { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public string? fiestaRules { get; set; }
        public string headerDeleteFlag { get; set; } = null!;
    }
}
