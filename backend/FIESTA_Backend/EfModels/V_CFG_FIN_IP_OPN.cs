using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_FIN_IP_OPN
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string ipLicenseCode { get; set; } = null!;

    public string? ipVendorName { get; set; }

    public string? techName { get; set; }

    public string? productHierarchyCode { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public string? modifiedBy { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? lastUpdateBy { get; set; }

    public string? reviewBy { get; set; }

    public DateTimeOffset? reviewDateAndTime { get; set; }

    public string? reviewStatus { get; set; }

    public string? processStatus { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;
}
