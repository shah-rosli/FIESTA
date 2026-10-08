using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_COMPANY_MASTER_HI
    {
        public decimal CFG_COMPANY_MASTER_HIS_ID { get; set; }
        public decimal? CFG_COMPANY_MASTER_ID { get; set; }
        public string? COMPANY_CODE { get; set; }
        public string? COMPANY_NAME { get; set; }
        public string? COMPANY_DESCRIPTION { get; set; }
        public string? DEFAULT_CURRENCY_NAME { get; set; }
        public string? ACTIVE { get; set; }
        public string? DEFAULT_TIMEZONE { get; set; }
        public string? DEFAULT_DISP_TIME_FORMAT { get; set; }
        public string? DEFAULT_DISP_DATE_FORMAT { get; set; }
        public string? DEFAULT_DISP_DATETIME_FORMAT { get; set; }
        public string? CFG_COMPANY_MASTER_HIS_USERID { get; set; }
        public DateTimeOffset? CFG_COMPANY_MASTER_HIS_DATE { get; set; }
        public string? DEFAULT_LANGUAGE { get; set; }
    }
}
