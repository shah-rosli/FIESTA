using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_MENU_OPERATION_MAP
    {
        public decimal CFG_SYSTEM_MENU_ID { get; set; }
        public string ACCESS_OPERATION { get; set; } = null!;
    }
}
