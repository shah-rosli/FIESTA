using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_SYSTEM_PARAM_HI
    {
        public string CFG_SYSTEM_PARAM_HIS_USER_ID { get; set; } = null!;
        public string? CFG_SYSTEM_PARAM_HIS_DELEGATE { get; set; }
        public decimal CFG_SYSTEM_PARAM_ID { get; set; }
        public string PARAM_KEY { get; set; } = null!;
        public string PARAM_VALUE { get; set; } = null!;
        public string PARAM_CATEGORY { get; set; } = null!;
        public decimal CFG_SYSTEM_PARAM_HIS_ID { get; set; }
        public DateTimeOffset CFG_SYSTEM_PARAM_HIS_DATE { get; set; }
    }
}
