using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OPN_LIST
{
    public string? opn { get; set; }

    public string? companyCode { get; set; }

    public string? plmStatus { get; set; }

    public string? TT { get; set; }

    public string? legacyOrganization { get; set; }

    public decimal? opnVersion { get; set; }

    public string? agileSignoff { get; set; }

    public DateTimeOffset? agileSignoffDate { get; set; }

    public string? fiestaSignoff { get; set; }

    public DateTimeOffset? fiestaSignoffDate { get; set; }

    public string? userSignoff { get; set; }

    public DateTimeOffset? lastSignoffDate { get; set; }

    public string? lastSignoffBy { get; set; }

    public string? existInProster { get; set; }

    public string? deliveredByFiesta { get; set; }

    public string? isTop95PercentRevenue { get; set; }

    public string? hasBacklog { get; set; }

    public string? hasInventory { get; set; }

    public string? hasBilling { get; set; }

    public string? failureReason { get; set; }

    public string? status { get; set; }
}
