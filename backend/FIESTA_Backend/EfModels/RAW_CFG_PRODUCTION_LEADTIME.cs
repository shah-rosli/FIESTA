using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCTION_LEADTIME
    {
        public string? createdBy { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? groupStage { get; set; }
        public string? glmStage { get; set; }
        public decimal? leadTime { get; set; }
        public DateTime? validFromDate { get; set; }
        public string? validFromDateStr { get; set; }
        public string? deleteFlag { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        public DateTimeOffset? createdDate { get; set; }
        public decimal recordKey { get; set; }
    }
}
