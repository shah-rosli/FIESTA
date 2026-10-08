using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_BOM_ALTERNATIVE
    {
        public string partNumber { get; set; } = null!;
        public string parentPlant { get; set; } = null!;
        public string childPlant { get; set; } = null!;
        public string childStorageLocation { get; set; } = null!;
        public long childStructure { get; set; }
        public long childGrouping { get; set; }
        public long childSequenceNumber { get; set; }
        public string bomAlternative { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
    }
}
