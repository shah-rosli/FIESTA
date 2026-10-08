using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_ALT_MIX_RATIOS_FLOW_ALTERNATIVE
    {
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string supplyPlant { get; set; } = null!;
        public string supplyStorageLocation { get; set; } = null!;
        public string flowAlternative { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
    }
}
