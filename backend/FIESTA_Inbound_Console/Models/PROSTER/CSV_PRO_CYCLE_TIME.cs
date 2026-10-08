using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.PROSTER
{
    public class CSV_PRO_CYCLE_TIME
    {
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? groupStage { get; set; }
        public string? stage { get; set; }
        public DateTime? validFromDate { get; set; }
        public string? unitOfTime { get; set; }
        public decimal? quantityUnitOfTime { get; set; }
        public string? classification { get; set; }
        public decimal? cycleTime { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
    }
}
