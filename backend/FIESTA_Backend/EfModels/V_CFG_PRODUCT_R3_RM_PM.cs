using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_PRODUCT_R3_RM_PM
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string? materialType { get; set; }
        public string? materialTypeDetail { get; set; }
        public string? legacyOrganization { get; set; }
        public string materialGroup { get; set; } = null!;
        public string deleteFlag { get; set; } = null!;
        public DateTimeOffset? updateDateAndTime { get; set; }
        public string? lastUpdateBy { get; set; }
    }
}
