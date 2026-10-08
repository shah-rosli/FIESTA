using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PLM_REFRESH_LIST
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string partNumberType { get; set; } = null!;
        public string? remarks { get; set; }
        public decimal activeFlag { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
    }
}
