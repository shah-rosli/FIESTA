using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PRODUCTION_PLANT_CONVERSION
    {
        public string? company { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? legacyType { get; set; }
        public string? legacyLine { get; set; }
        public string? groupStage { get; set; }
        public string? massProductionFlag { get; set; }
        public string? plantAndSlocVsLegacyLineRecordID { get; set; }
        public string? activeFlag { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public long? isRecordActive { get; set; }
        public DateTimeOffset? recordActiveChange { get; set; }
    }
}
