using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PROFIT_CENTER_HIERARCHY
    {
        public string? setName { get; set; }
        public decimal? lineID { get; set; }
        public string? subSetName { get; set; }
        public string? description { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
