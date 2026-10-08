using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_NONPRODUCTION_PRODUCT_PLANT
    {
        public string? partNumberKey { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? legacyLine { get; set; }
        public decimal? inhouseProductionTime { get; set; }
        public string? profitCenter { get; set; }
        public string? materialType { get; set; }
        public decimal? planningYield { get; set; }
        public decimal? minimumLotSize { get; set; }
        public string? specialOriginalPartNumber { get; set; }
        public string? businessDivision { get; set; }
        public string? businessPlannerCode { get; set; }
        public string? factoryFlag { get; set; }
        public string? lotSizingProcedure { get; set; }
        public string? updateType { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? fileName { get; set; }

    }
}
