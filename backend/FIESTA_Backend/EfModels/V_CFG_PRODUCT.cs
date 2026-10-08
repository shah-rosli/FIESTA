using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT
{
    public decimal recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string materialType { get; set; } = null!;

    public string? materialTypeDetail { get; set; }

    public string legacyOrganization { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string? partDescription { get; set; }

    public string? plmStatus { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? standardPackingQuantity { get; set; }

    public string? businessPlannerCode { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }
}
