using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class RAW_CFG_FIN_IP_OPN
{
    public string? createdBy { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string ipLicenseCode { get; set; } = null!;

    public string? ipVendorName { get; set; }

    public string? techName { get; set; }

    public string? productHierarchyCode { get; set; }

    public string deleteFlag { get; set; } = null!;

    public string? insertOrUpdate { get; set; }

    public decimal? haveError { get; set; }

    public string? errorMessage { get; set; }

    public decimal? haveDifference { get; set; }

    public DateTimeOffset? createdDate { get; set; }

    public decimal recordKey { get; set; }
}
