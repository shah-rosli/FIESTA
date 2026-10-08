using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_RET_PNSTATUS
    {
        public decimal recordKey { get; set; }
        public string BOOKING_PN { get; set; } = null!;
        public string? PN_STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }
}
