using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_RET_MATERIAL
    {
        public decimal recordKey { get; set; }
        public string? PART_KND_CD { get; set; }
        public string MTRAL_CODE { get; set; } = null!;
        public string? PARTS_NAME { get; set; }
        public string? CONSUMER_UNIT_CD { get; set; }
        public string? RPS_NO { get; set; }
        public string? DRW_STND_NUM { get; set; }
        public string? SEQ_NO { get; set; }
        public string? REGIST_DATE { get; set; }
        public string? REGIST_TIME { get; set; }
        public DateTimeOffset? REGIST_DATE_TIME { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }
}
