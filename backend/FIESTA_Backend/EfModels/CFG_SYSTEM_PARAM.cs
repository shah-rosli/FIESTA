using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_SYSTEM_PARAM
{
    public decimal CFG_SYSTEM_PARAM_ID { get; set; }

    public string PARAM_KEY { get; set; } = null!;

    public string PARAM_VALUE { get; set; } = null!;

    public string PARAM_CATEGORY { get; set; } = null!;
}
