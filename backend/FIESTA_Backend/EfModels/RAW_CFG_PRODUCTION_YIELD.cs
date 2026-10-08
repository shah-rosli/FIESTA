using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCTION_YIELD
    {
        public string? createdBy { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? groupStage { get; set; }
        public string? glmStage { get; set; }
        public string? yieldFlag { get; set; }
        public decimal? yield { get; set; }
        public string? validFromDateStr { get; set; }
        public string? deleteFlag { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        public DateTimeOffset? createdDate { get; set; }
        public decimal recordKey { get; set; }
        public DateTime? validFromDate { get; set; }
    }
}
