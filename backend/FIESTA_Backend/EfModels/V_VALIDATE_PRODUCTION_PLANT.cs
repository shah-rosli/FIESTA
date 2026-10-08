using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_VALIDATE_PRODUCTION_PLANT
    {
        public string? COMPANY_CODE { get; set; }
        public string? PLANT { get; set; }
        public string? SLOC { get; set; }
        public string? NOT_EXIST_IN { get; set; }
    }
}
