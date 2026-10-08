using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_FIN_IP_CUSTOMER
{
    public decimal recordKey { get; set; }

    public string ipLicenseNumber { get; set; } = null!;

    public string customerCode { get; set; } = null!;

    public string? customerName { get; set; }

    public DateTime validityFromDate { get; set; }

    public DateTime? validityToDate { get; set; }

    public string? status { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;
}
