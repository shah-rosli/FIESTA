using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PRODUCT_WIP_SELL_PRICE
    {
        public string? sellingPlant { get; set; }
        public string? partNumberKey { get; set; }
        public DateTime? validFromDate { get; set; }
        public string? partNumber { get; set; }
        public decimal? price { get; set; }
        public string? currency { get; set; }
        public DateTime? validToDate { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }


    }
}
