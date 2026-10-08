using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PRODUCTION_STAGE
    {
        public string? stage { get; set; }
        public string? stageName { get; set; }
        public string? stageRecordID { get; set; }
        public string? activeFlag { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
