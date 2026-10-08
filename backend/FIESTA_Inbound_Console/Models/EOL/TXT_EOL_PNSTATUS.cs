using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.EOL
{
    public class TXT_EOL_PNSTATUS
    {
        public string? BOOKING_PN { get; set; }
        public string? PN_STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public DateTime? EOL_NOTICED_DATE { get; set; }
        public DateTime? LTB_ORDER_DEADLINE_DATE { get; set; }
        public string? UPDATE_ID { get; set; }
        public string? UPDATE_TYPE { get; set; }

    }
}
