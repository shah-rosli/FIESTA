using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_SCM_MASTER_LEADTIME_YIELD
{
    public string partNumber { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public decimal? leadTime { get; set; }

    public decimal? yield { get; set; }
}
