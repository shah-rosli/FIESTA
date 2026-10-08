using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_PROFIT_CENTER
    {
        [Name("prctr")]
        public string? PRCTR { get; set; }
        [Name("datbi")]
        public DateTime? DATBI { get; set; }
        [Name("khinr")]
        public string? KHINR { get; set; }
        [Name("ktext")]
        public string? KTEXT { get; set; }
        public string? deleteFlag { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
