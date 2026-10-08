using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCTION_CYCLETIME
    {
        public string? createdBy { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string glmStage { get; set; } = null!;
        public string unitOfTime { get; set; } = null!;
        public long? quantityUnitOfTime { get; set; }
        public string classification { get; set; } = null!;
        public decimal? time { get; set; }
        public string? validFromDateStr { get; set; }
        public string originalPartNumber { get; set; } = null!;
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        public DateTimeOffset? createdDate { get; set; }
        public decimal recordKey { get; set; }
        public DateTime? validFromDate { get; set; }
    }
}
