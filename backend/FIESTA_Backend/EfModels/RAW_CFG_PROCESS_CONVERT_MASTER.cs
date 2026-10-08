using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PROCESS_CONVERT_MASTER
    {
        public string? createdBy { get; set; }
        public string? detailWaferProcess { get; set; }
        public string? technology { get; set; }
        public string? roughWaferProcess { get; set; }
        public string? deleteFlag { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        //public DateTimeOffset? createdDate { get; set; }
        //public decimal recordKey { get; set; }
    }
}
