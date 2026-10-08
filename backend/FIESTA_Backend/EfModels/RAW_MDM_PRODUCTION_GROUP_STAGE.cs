using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PRODUCTION_GROUP_STAGE
    {
        public string? groupStage { get; set; }
        public int? groupStageSequence { get; set; }
        public string? groupStageName { get; set; }
        public string? groupStageType { get; set; }
        public string? groupStageExplanation { get; set; }
        public string? inputUoM { get; set; }
        public string? outputUoM { get; set; }
        public string? groupStageRecordID { get; set; }
        public string? activeFlag { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
