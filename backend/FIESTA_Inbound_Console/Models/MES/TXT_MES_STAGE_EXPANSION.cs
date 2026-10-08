using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.MES
{
    public class TXT_MES_STAGE_EXPANSION
    {
        public string? S4MPN { get; set; }
        public string? MANUFACTURING_PART_NR { get; set; }
        public string? GROUP_STAGE_CD { get; set; }
        public string? FACILITY_NAME { get; set; }
        public string? ROUTE_CD { get; set; }
        public string? STAGE { get; set; }
        public string? ACTIVTY_RATE_CODE { get; set; }
        public string? ROUTE_SEQ_NR { get; set; }
        public decimal? STAGE_SEQ_NR { get; set; }
        public decimal? CYCLE_TM { get; set; }
        public decimal? PLAN_YLD_NR { get; set; }

    }
}
