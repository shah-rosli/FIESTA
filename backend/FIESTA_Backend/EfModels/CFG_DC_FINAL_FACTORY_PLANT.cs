using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_DC_FINAL_FACTORY_PLANT
{
    public string supplyPlant { get; set; } = null!;

    public string supplyStorageLocation { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string? storageLocation { get; set; }

    public string plannable { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }
}
