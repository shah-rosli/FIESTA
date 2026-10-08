using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_R4_OPN_PARTDESC
{
    public decimal recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? partDescription { get; set; }

    public string? needPartDescription { get; set; }

    public string? REG_USER { get; set; }

    public DateTime? REG_DATE { get; set; }

    public string? productHierarchyCode { get; set; }

    public string productHierarchy1 { get; set; } = null!;

    public string productHierarchy2 { get; set; } = null!;

    public string productHierarchy3 { get; set; } = null!;

    public string productHierarchy4 { get; set; } = null!;

    public string productHierarchy5 { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }

    public string deleteFlag { get; set; } = null!;
}
