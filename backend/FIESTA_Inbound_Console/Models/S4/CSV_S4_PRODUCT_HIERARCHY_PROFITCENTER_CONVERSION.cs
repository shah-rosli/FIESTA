using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION
    {
        public string? productHierarchyCode { get; set; }
        public string? profitCenterCode { get; set; }
        public string? profitCenter { get; set; }
        public string? deleteFlag { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
