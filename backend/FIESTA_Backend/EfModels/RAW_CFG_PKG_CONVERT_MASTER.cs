using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_PKG_CONVERT_MASTER
    {
        public string? createdBy { get; set; }
        public string? detailPackage { get; set; }
        public string? packageLayer { get; set; }
        public string? roughPackage { get; set; }
        public string? packageType { get; set; }
        public string? bodySize { get; set; }
        public int? pinCount { get; set; }
        public string? deleteFlag { get; set; }
        public string? insertOrUpdate { get; set; }
        public bool? haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool? haveDifference { get; set; }
        //public DateTimeOffset? createdDate { get; set; }
        //public decimal recordKey { get; set; }
    }
}
