using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_DC_PRIORITY_MATRIX
{
    public string dcPlant { get; set; } = null!;

    public string? dcDescription { get; set; }

    public string priority { get; set; } = null!;

    public string? group { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }
}
