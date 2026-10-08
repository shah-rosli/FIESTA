using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_EOL_STATUS
    {
        public decimal recordKey { get; set; }
        public string BOOKING_PN { get; set; } = null!;
        public string? PN_STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public DateTime? EOL_NOTICED_DATE { get; set; }
        public DateTime? LTB_ORDER_DEADLINE_DATE { get; set; }
        public string? UPDATE_ID { get; set; }
        public string? UPDATE_TYPE { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }
}
