using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_RET_PNSTATUS
    {
        public string? BOOKING_PN { get; set; }
        public string? PN_STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
