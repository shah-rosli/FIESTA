using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_DASHBOARD
    {
        public string CFG_SYS_TABLE_NAME { get; set; } = null!;
        public string? CFG_SYS_TABLE_GROUP_NAME { get; set; }
        public DateTime? MAX_UPDATE_DATE_AND_TIME { get; set; }
        public decimal? ROW_COUNT { get; set; }
    }
}
