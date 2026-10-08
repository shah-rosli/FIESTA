using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_PRO_CYCLE_TIME
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string stage { get; set; } = null!;
        public DateTime validFromDate { get; set; }
        public string? unitOfTime { get; set; }
        public decimal? quantityUnitOfTime { get; set; }
        public string classification { get; set; } = null!;
        public decimal? cycleTime { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }
}
