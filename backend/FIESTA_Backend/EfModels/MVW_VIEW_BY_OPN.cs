using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MVW_VIEW_BY_OPN
{
    public string? opn { get; set; }

    public string? status { get; set; }

    public string? delivered { get; set; }

    public string? materialType { get; set; }

    public string? blacklistDetails { get; set; }
}
