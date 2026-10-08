using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PKG_CONVERT_MASTER_HI
    {
        public decimal CFG_PKG_CONVERT_MASTER_HIS_ID { get; set; }
        public DateTimeOffset? CFG_PKG_CONVERT_MASTER_HIS_DATE { get; set; }
        public string? CFG_PKG_CONVERT_MASTER_HIS_USERID { get; set; }
        public string? CFG_PKG_CONVERT_MASTER_HIS_DELEGATE { get; set; }
        public decimal? CFG_PKG_CONVERT_MASTER_ID { get; set; }
        public string? detailPackage { get; set; }
        public string? packageLayer { get; set; }
        public string? roughPackage { get; set; }
        public string? packageType { get; set; }
        public string? bodySize { get; set; }
        public int? pinCount { get; set; }
        public string deleteFlag { get; set; } = null!;
    }
}
