using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_USER_GROUP_MENU_MAP
    {
        public decimal CFG_USER_GROUP_MENU_MAP_ID { get; set; }
        public decimal CFG_USER_GROUP_ID { get; set; }
        public decimal? MENU_ID { get; set; }
        public string? ACCESS_OPERATION { get; set; }
    }
}
