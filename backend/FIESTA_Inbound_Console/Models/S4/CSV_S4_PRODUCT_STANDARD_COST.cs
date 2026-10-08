using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PRODUCT_STANDARD_COST
    {
        public string? companyCode { get; set; }
        public DateTime? postingDate { get; set; }
        public string? plant { get; set; }
        public string? partNumberKey { get; set; }
        public string? partNumber { get; set; }
        public decimal? companyCodeCurrencyLegalValuation { get; set; }
        public string? companyCodeCurrency { get; set; }
        public decimal? priceUnit { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }
    }
}
