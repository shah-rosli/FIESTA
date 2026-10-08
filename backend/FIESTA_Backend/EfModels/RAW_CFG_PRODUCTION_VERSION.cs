using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PRODUCTION_VERSION
    {
        public string? createdBy { get; set; }
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? productionVersion { get; set; }
        public string? productionVersionLock { get; set; }
        public string? validFromDateStr { get; set; }
        public string? validToDateStr { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        public DateTime? validFromDate { get; set; }
        public DateTime? validToDate{ get; set; }
    }
}
