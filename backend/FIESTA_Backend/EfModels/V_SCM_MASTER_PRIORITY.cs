using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_SCM_MASTER_PRIORITY
{
    public string partNumber { get; set; } = null!;

    public string supplyPlant { get; set; } = null!;

    public string supplyStorageLocation { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string? priority { get; set; }
}
