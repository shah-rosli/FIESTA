using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class MV_DASHBOARD_BLACKLIST
    {
        public decimal? CNT { get; set; }
        public string? CATEGORY { get; set; }
        public string? DESCRIPTION { get; set; }
        public string? BLACKLIST_FLAG { get; set; }
    }
}
