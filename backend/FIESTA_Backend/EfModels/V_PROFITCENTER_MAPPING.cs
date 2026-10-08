using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PROFITCENTER_MAPPING
    {
        public string phCode { get; set; } = null!;

        public string? profitCenterCDlv4 { get; set; }

        public string? profitCenter { get; set; }

        public string companyCode { get; set; } = null!;

        public string profitCenterCDlv3 { get; set; } = null!;

        public string? businessUnitCD { get; set; }

        public string? businessDivision { get; set; }

        public string? businessDivisionCD { get; set; }

        public string? businessUnit { get; set; }

        public string phCode1 { get; set; } = null!;
    }
}
