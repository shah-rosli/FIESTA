using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_NONPRODUCTION_PRODUCT_SALES
    {
        public string? partNumberKey { get; set; }
        public string? partNumber { get; set; }
        public string? salesOrganization { get; set; }
        public string? distributionChannel { get; set; }
        public decimal? minimumOrderQuantity { get; set; }
        public decimal? frequencyOrderIncrement { get; set; }
        public decimal? standardPackingQuantity { get; set; }
        public string? defaultSalesOrderCreationPlant { get; set; }
        public string? materialType { get; set; }
        public string? updateType { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
