using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MODELN_CUS_SHIP_TO
{
    public string ACCOUNT_NUM { get; set; } = null!;

    public string? ADDR_DISPLAY { get; set; }

    public string customerCode { get; set; } = null!;

    public string? ADDRESS1 { get; set; }

    public string? ADDRESS2 { get; set; }

    public string? ADDRESS3 { get; set; }

    public string? CITY { get; set; }

    public string? STATE { get; set; }

    public string? ZIP { get; set; }

    public string? COUNTRY { get; set; }

    public string ADDR_CODE { get; set; } = null!;

    public string? STATUS { get; set; }
}
