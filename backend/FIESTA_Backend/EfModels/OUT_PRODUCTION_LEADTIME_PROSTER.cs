using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class OUT_PRODUCTION_LEADTIME_PROSTER
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string stage { get; set; } = null!;
        public DateTime validFromDate { get; set; }
        public decimal? leadTime { get; set; }
        public string aopFlag { get; set; } = null!;
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }

    public partial class OUT_PRODUCTION_LEADTIME_PROSTER_EXPORT
    {
        public OUT_PRODUCTION_LEADTIME_PROSTER_EXPORT()
        {
            
        }

        public OUT_PRODUCTION_LEADTIME_PROSTER_EXPORT(OUT_PRODUCTION_LEADTIME_PROSTER x)
        {
            this.partNumber = x.partNumber;
            this.plant = x.plant;
            this.storageLocation = x.storageLocation;
            this.groupStage = x.groupStage;
            this.stage = x.stage;
            this.validFromDate = DateOnly.FromDateTime(x.validFromDate);
            this.leadTime = x.leadTime;
            this.aopFlag = x.aopFlag;
            this.createDateAndTime = x.createDateAndTime;
            this.updateDateAndTime = x.updateDateAndTime;
            this.updateType = x.updateType;
            this.deleteFlag = x.deleteFlag;
        }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string stage { get; set; } = null!;
        public DateOnly validFromDate { get; set; }
        public decimal? leadTime { get; set; }
        public string aopFlag { get; set; } = null!;
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
    }
}
