using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class DC_PLANT_LIST
    {
        public decimal recordKey { get; set; }
        public string plant { get; set; } = null!;
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string updateType { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
