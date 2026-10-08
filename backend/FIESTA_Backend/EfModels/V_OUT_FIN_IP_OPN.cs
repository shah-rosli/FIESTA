using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_FIN_IP_OPN
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string? partNumber { get; set; }

    public string ipLicenseCode { get; set; } = null!;

    public string? ipVendorName { get; set; }

    public string? techName { get; set; }

    public string? productHierarchyCode { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;
}
