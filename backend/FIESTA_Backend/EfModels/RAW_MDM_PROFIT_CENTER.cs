using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PROFIT_CENTER
    {
        public string? PRCTR { get; set; }
        public DateTimeOffset? DATBI { get; set; }
        public string? KHINR { get; set; }
        public string? KTEXT { get; set; }
        public string? deleteFlag { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
