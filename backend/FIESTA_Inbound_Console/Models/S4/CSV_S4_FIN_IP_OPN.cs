using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_FIN_IP_OPN
    {
        public string? partNumberKey { get; set; }
        public string? partNumber { get; set; }
        public string? ipLicenseCode { get; set; }
        public string? ipVendorName { get; set; }
        public string? techName { get; set; }
        public string? productHierarchyCode { get; set; }
        public string? deleteFlag { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }


    }
}
