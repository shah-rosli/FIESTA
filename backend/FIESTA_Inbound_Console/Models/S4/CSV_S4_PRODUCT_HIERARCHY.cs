using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PRODUCT_HIERARCHY
    {
        public string? phCode { get; set; }
        public string? level { get; set; }
        public string? phDescription { get; set; }
        public string? upperKey { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
