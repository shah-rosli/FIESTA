using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PKG_CONVERT_MASTER
    {
        public decimal CFG_PKG_CONVERT_MASTER_ID { get; set; }
        public string detailPackage { get; set; } = null!;
        public string? packageLayer { get; set; }
        public string? roughPackage { get; set; }
        public string? packageType { get; set; }
        public string? bodySize { get; set; }
        public int? pinCount { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public string? createdBy { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? modifiedBy { get; set; }
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
