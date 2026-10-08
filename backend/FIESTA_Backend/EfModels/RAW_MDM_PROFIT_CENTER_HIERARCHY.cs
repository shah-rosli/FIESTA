using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PROFIT_CENTER_HIERARCHY
    {
        public string? setName { get; set; }
        public int? lineID { get; set; }
        public string? subSetName { get; set; }
        public string? description { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
