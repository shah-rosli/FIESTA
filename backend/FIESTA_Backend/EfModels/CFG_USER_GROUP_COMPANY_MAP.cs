using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_USER_GROUP_COMPANY_MAP
    {
        public decimal CFG_USER_GROUP_ID { get; set; }
        public string COMPANY_CODE { get; set; } = null!;
    }
}
