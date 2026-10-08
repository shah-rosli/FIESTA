using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_CUS_PARTNER_FUNCTION
    {
        public string? customerNumber { get; set; }
        public string? salesOrganization { get; set; }
        public string? distributionChannel { get; set; }
        public string? division { get; set; }
        public string? partnerFunction { get; set; }
        public string? partnerCounter { get; set; }
        public string? businessPartnerNumber { get; set; }
        public string? defaultPartner { get; set; }
        public string? effectiveDate { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
