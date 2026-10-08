using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_DC_PLANT
    {
        public string plant { get; set; } = null!;
        public string? storageLocation { get; set; }
        public string? companyCode { get; set; }
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
    }
}
