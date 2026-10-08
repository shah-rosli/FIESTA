using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PROCESS_CONVERT_MASTER
    {
        public decimal CFG_PROCESS_CONVERT_MASTER_ID { get; set; }
        public string? detailWaferProcess { get; set; }
        public string? technology { get; set; }
        public string? roughWaferProcess { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public string? createdBy { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? modifiedBy { get; set; }
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
