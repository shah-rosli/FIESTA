using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION
    {
        public string? productHierarchyCode { get; set; }
        public string? profitCenterCode { get; set; }
        public string? profitCenter { get; set; }
        public string? deleteFlag { get; set; }
    }
}
