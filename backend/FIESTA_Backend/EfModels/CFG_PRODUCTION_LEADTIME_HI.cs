using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_LEADTIME_HI
    {
        public decimal CFG_PRODUCTION_LEADTIME_HIS_ID { get; set; }
        public DateTimeOffset? CFG_PRODUCTION_LEADTIME_HIS_DATE { get; set; }
        public string? CFG_PRODUCTION_LEADTIME_HIS_USERID { get; set; }
        public string? CFG_PRODUCTION_LEADTIME_HIS_DELEGATE { get; set; }
        public decimal? recordKey { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? glmStage { get; set; }
        public decimal? leadTime { get; set; }
        public DateTime? validFromDate { get; set; }
        public string deleteFlag { get; set; } = null!;
        public string? groupStage { get; set; }
    }
}
