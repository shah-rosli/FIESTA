using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_SHIPPOINT_HI
{
    public decimal CFG_SHIPPOINT_HIS_ID { get; set; }

    public DateTimeOffset? CFG_SHIPPOINT_HIS_DATE { get; set; }

    public string? CFG_SHIPPOINT_HIS_USERID { get; set; }

    public string? CFG_SHIPPOINT_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string opn { get; set; } = null!;

    public string? legacyOrganization { get; set; }

    public string? plmStatus { get; set; }

    public string lineName { get; set; } = null!;

    public string defaultShipPoint { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public string? supplyLineName { get; set; }

    public string? plannable { get; set; }

    public string activeFlag { get; set; } = null!;

    public string? fiestaRules { get; set; }

    public string? lastUpdateBy { get; set; }
}
