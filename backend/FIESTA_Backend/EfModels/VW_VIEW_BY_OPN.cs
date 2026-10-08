using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class VW_VIEW_BY_OPN
{
    public string OPN { get; set; } = null!;

    public string materialType { get; set; } = null!;

    public string? Status { get; set; }

    public string? Delivered { get; set; }
}
