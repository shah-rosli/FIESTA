using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PRODUCT_HIERARCHY
    {
        public string? phCode { get; set; }
        public string? level { get; set; }
        public string? phDescription { get; set; }
        public string? upperKey { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
