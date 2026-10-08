using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_EOL_STATUS
    {
        public string? BOOKING_PN { get; set; }
        public string? PN_STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public DateTime? EOL_NOTICED_DATE { get; set; }
        public DateTime? LTB_ORDER_DEADLINE_DATE { get; set; }
        public string? UPDATE_ID { get; set; }
        public string? UPDATE_TYPE { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
