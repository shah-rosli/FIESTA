using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCTION_LOTSIZE
    {
        public string? createdBy { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public long? minimumLotSize { get; set; }
        public long? incrementLotSize { get; set; }
        public long? maximumLotSize { get; set; }
        public string? lotSizingProcedure { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        public string deleteFlag { get; set; } = null!;
    }
}
