using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_PRO_LEADTIME_PROSTER
    {
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? groupStage { get; set; }
        public string? stage { get; set; }
        public DateTime? validFromDate { get; set; }
        public decimal? leadTime { get; set; }
        public string? aopFlag { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
