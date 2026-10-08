using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCT
    {
        public string? createdBy { get; set; }
        public string partNumber { get; set; } = null!;
        public string? partDescription { get; set; }
        public string? plmStatus { get; set; }
        //public long? totalShelfLife { get; set; }
        public long? minimumOrderQuantity { get; set; }
        public long? standardPackingQuantity { get; set; }
        public string? businessPlannerCode { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        public DateTimeOffset? createdDate { get; set; }
        public decimal recordKey { get; set; }
    }
}
