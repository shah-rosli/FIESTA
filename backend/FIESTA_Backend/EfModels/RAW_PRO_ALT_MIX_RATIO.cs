using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_PRO_ALT_MIX_RATIO
    {
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? supplyPlant { get; set; }
        public string? supplyStorageLocation { get; set; }
        public string? flowAlternative { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
