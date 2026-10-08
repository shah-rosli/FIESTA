using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PRODUCT_PLANT_PREVCYCLE5
    {
        public string opn { get; set; } = null!;
        public decimal recordKey { get; set; }
        public string partNumberKey { get; set; } = null!;
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public decimal? inhouseProductionTime { get; set; }
        public string profitCenter { get; set; } = null!;
        public string materialType { get; set; } = null!;
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string updateType { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
        public long? minimumLotSize { get; set; }
        public decimal? planningYield { get; set; }
        public string specialOriginalPartNumber { get; set; } = null!;
        public string businessUnit { get; set; } = null!;
    }
}
