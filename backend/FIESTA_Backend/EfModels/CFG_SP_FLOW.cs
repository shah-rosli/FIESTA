using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_SP_FLOW
    {
        public string TABLE_NAME { get; set; } = null!;
        public decimal? FLOW_ENABLE { get; set; }
        public DateTimeOffset? DATEUPDATED { get; set; }
        public DateTimeOffset? RTN_MAXDATEUPDATE { get; set; }
        public string? RTN_EXEC_BY { get; set; }
    }
}
