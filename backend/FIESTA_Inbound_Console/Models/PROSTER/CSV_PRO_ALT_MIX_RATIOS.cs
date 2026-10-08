using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.PROSTER
{
    public class CSV_PRO_ALT_MIX_RATIOS
    {
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? supplyPlant { get; set; }
        public string? supplyStorageLocation { get; set; }
        public string? flowAlternative { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }

    }
}
