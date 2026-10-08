using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_CUS_END_CUSTOMER
    {
        public string? name { get; set; }
        public string? location { get; set; }
        public string? accountNumCustomerOID { get; set; }
        public string? customerType { get; set; }
        public string? category { get; set; }
        public string? legalName { get; set; }
        public string? status { get; set; }
        public string? geography { get; set; }
        public string? btAddress1 { get; set; }
        public string? btAddress2 { get; set; }
        public string? btAddress3 { get; set; }
        public string? btAddress4 { get; set; }
        public string? btAddress5 { get; set; }
        public string? btCity { get; set; }
        public string? btState { get; set; }
        public string? btZip { get; set; }
        public string? btCountry { get; set; }
        public string? currencyName { get; set; }
        public string? customerLevel { get; set; }
        public string? parentCustomerAccount { get; set; }
        public string? parentCustomerName { get; set; }
        public string? parentCustomerLocation { get; set; }
        public string? focus { get; set; }
        public string? childId { get; set; }
        public string? isTyt { get; set; }
        public string? hiRelAllowed { get; set; }
        public string? webSite { get; set; }
        public string? soldToOrigin { get; set; }
        public string? sapChangePoint { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
