using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_COMPANYCODE_MAPPING
{
    public string? profitCenterCode { get; set; }

    public string KTEXT { get; set; } = null!;

    public string companyCode { get; set; } = null!;
}
