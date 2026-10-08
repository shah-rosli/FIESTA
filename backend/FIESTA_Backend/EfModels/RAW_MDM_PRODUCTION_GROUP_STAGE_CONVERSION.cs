using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PRODUCTION_GROUP_STAGE_CONVERSION
    {
        public string? groupStage { get; set; }
        public string? legacyType { get; set; }
        public string? legacyGroupStage { get; set; }
        public string? groupStageVSLegacyGroupStageRecordID { get; set; }
        public string? activeFlag { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
