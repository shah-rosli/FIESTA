using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_RAINBOW_IDT
{
    public string ProdPN { get; set; } = null!;

    public long? PKGQty { get; set; }

    public long? InnerPkgQty { get; set; }

    public string? TP { get; set; }

    public long? MLQ { get; set; }

    public string? CustomFlag { get; set; }

    public byte? WPinputTAT { get; set; }

    public byte? UOCreateWeek { get; set; }

    public long? OIQ { get; set; }

    public string? OrderableFlag { get; set; }

    public string? UnsawnWaferFlag { get; set; }

    public decimal? NCNRFlag { get; set; }

    public override string ToString()
    {
        string na = "";
        return $"{ProdPN.PadRight(40)}" +
            $"{PKGQty.ToString().PadLeft(13, '0')}" +
            $"{InnerPkgQty.ToString().PadLeft(13, '0')}" +
            $"{na.PadRight(3)}" +
            $"{MLQ.ToString().PadLeft(13, '0')}" +
            $"{CustomFlag}" +
            $"{WPinputTAT.ToString().PadLeft(2, '0')}" +
            $"{UOCreateWeek.ToString().PadLeft(2, '0')}" +
            $"{OIQ.ToString().PadLeft(13, '0')}" +
            $"{OrderableFlag}" +
            $"{UnsawnWaferFlag}" +
            $"{NCNRFlag}";
    }
}
