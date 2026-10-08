using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOS_FULL
    {
        public string? createdBy { get; set; }
        public string? partNumber { get; set; }
        public string? supplyPlant { get; set; }
        public string? supplyStorageLocation { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? priority { get; set; }
        public decimal? ratio { get; set; }
        public string? productionVersion { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
    }
}
