using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class MV_OPN_LIST_HI
    {
        public string? opn { get; set; }
        public decimal? opnVersion { get; set; }
        public DateTimeOffset? lastBuyoffDate { get; set; }
        public string? lastBuyoffBy { get; set; }
        public string? fiestaBuyoff { get; set; }
        public string? userBuyoff { get; set; }
    }
}
