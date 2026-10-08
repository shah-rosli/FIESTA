using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_CODE_CONVERT_MASTER
    {
        public string code { get; set; } = null!;
        public string codetype { get; set; } = null!;
        public string? code_desc { get; set; }
        public string? S4setup { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
    }
}
