using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PROCESS_CONVERT_MASTER_HI
    {
        public decimal CFG_PROCESS_CONVERT_MASTER_HIS_ID { get; set; }
        public DateTimeOffset? CFG_PROCESS_CONVERT_MASTER_HIS_DATE { get; set; }
        public string? CFG_PROCESS_CONVERT_MASTER_HIS_USERID { get; set; }
        public string? CFG_PROCESS_CONVERT_MASTER_HIS_DELEGATE { get; set; }
        public decimal? CFG_PROCESS_CONVERT_MASTER_ID { get; set; }
        public string? detailWaferProcess { get; set; }
        public string? technology { get; set; }
        public string? roughWaferProcess { get; set; }
        public string deleteFlag { get; set; } = null!;
    }
}
