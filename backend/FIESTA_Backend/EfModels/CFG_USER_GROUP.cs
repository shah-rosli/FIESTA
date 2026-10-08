using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_USER_GROUP
    {
        public decimal CFG_USER_GROUP_ID { get; set; }
        public string USER_GROUP_NAME { get; set; } = null!;
        public string? USER_GROUP_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; } = null!;
    }
}
