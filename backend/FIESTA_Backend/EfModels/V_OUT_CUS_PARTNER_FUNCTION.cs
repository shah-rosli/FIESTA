using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_CUS_PARTNER_FUNCTION
{
    public decimal recordKey { get; set; }

    public string customerNumber { get; set; } = null!;

    public string salesOrganization { get; set; } = null!;

    public string distributionChannel { get; set; } = null!;

    public string? division { get; set; }

    public string partnerFunction { get; set; } = null!;

    public string? partnerCounter { get; set; }

    public string businessPartnerNumber { get; set; } = null!;

    public string? defaultPartner { get; set; }

    public string? effectiveDate { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;
}
