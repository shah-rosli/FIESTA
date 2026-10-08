using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_SCM_MASTER_BOM
{
    public string? opn { get; set; }

    public string? bomKey { get; set; }

    public string? bomAlternative { get; set; }

    public string? partNumber { get; set; }

    public string? plant { get; set; }

    public long? baseQuantity { get; set; }

    public string? componentPartNumber { get; set; }

    public string? childPlant { get; set; }

    public long? componentQuantity { get; set; }
}
