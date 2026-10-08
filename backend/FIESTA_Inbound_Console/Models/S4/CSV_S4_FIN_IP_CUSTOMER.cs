using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_FIN_IP_CUSTOMER
    {
        public string? ipLicenseNumber { get; set; }
        public string? customerCode { get; set; }
        public string? customerName { get; set; }
        public DateTime? validityFromDate { get; set; }
        public DateTime? validityToDate { get; set; }
        public DateTime? createdOn { get; set; }
        public string? createdBy { get; set; }
        public DateTime? lastChangedOn { get; set; }
        public string? lastChangedBy { get; set; }
        public string? status { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }


    }
}
