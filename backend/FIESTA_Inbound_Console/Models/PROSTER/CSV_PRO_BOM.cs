using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.PROSTER
{
    public class CSV_PRO_BOM
    {
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? bomUsage { get; set; }
        public string? bomAlternative { get; set; }
        public string? baseUnitOfMeasure { get; set; }
        public decimal? baseQuantity { get; set; }
        public string? baseGroupStage { get; set; }
        public string? componentPartNumber { get; set; }
        public string? bomItem { get; set; }
        public string? componentUnitOfMeasure { get; set; }
        public decimal? componentQuantity { get; set; }
        public string? componentGroupStage { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }

    }
}
