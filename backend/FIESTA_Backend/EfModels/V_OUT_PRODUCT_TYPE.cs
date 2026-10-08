using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_PRODUCT_TYPE
{
    public decimal recordKey { get; set; }

    public string productHierarchy1 { get; set; } = null!;

    public string productHierarchy2 { get; set; } = null!;

    public string productHierarchy3 { get; set; } = null!;

    public string? productType { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
