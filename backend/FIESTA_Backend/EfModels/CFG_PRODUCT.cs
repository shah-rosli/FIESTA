using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_PRODUCT
{
    public decimal recordKey { get; set; }

    public string partNumber { get; set; } = null!;

    public string? partDescription { get; set; }

    public string? plmStatus { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? standardPackingQuantity { get; set; }

    public string? businessPlannerCode { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? createdBy { get; set; }

    public string? modifiedBy { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? proposePartDesc { get; set; }

    public string? partDescApprovedBy { get; set; }

    public DateTimeOffset? partDescApprovedDateTime { get; set; }

    public string? salesRootPartNumber { get; set; }

    public string? sentFromSystem { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string processStatus { get; set; } = null!;
}
