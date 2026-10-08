using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCT_HI
    {
        public decimal CFG_PRODUCT_HIS_ID { get; set; }

        public DateTimeOffset? CFG_PRODUCT_HIS_DATE { get; set; }

        public string? CFG_PRODUCT_HIS_USERID { get; set; }

        public string? CFG_PRODUCT_HIS_DELEGATE { get; set; }

        public decimal? recordKey { get; set; }

        public string? partNumber { get; set; }

        public string? partDescription { get; set; }

        public string? plmStatus { get; set; }

        public long? minimumOrderQuantity { get; set; }

        public long? standardPackingQuantity { get; set; }

        public string? businessPlannerCode { get; set; }

        public string deleteFlag { get; set; } = null!;

        public string? proposePartDesc { get; set; }

        public string? partDescApprovedBy { get; set; }

        public DateTimeOffset? partDescApprovedDateTime { get; set; }
    }
}
