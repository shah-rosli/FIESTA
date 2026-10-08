using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_FIN_IP_CUSTOMER
{
    public decimal recordKey { get; set; }

    public string ipLicenseNumber { get; set; } = null!;

    public string customerCode { get; set; } = null!;

    public string? customerName { get; set; }

    public DateOnly validityFromDate { get; set; }

    public DateOnly? validityToDate { get; set; }

    public DateOnly? createdOn { get; set; }

    public string? createdBy { get; set; }

    public DateOnly? lastChangedOn { get; set; }

    public string? lastChangedBy { get; set; }

    public string? status { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
