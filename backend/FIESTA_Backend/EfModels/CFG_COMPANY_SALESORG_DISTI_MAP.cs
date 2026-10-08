using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_COMPANY_SALESORG_DISTI_MAP
    {
        public decimal? companyCode { get; set; }
        public decimal? salesOrganization { get; set; }
        public decimal? distributionChannel { get; set; }
        public string? materialType { get; set; }
    }
}
