using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_CFG_PRODUCT_RAINBOW_ISL
{
    public string ProdPN { get; set; } = null!;

    public string? PRODUCTION_PN { get; set; }

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
        return
            $"{PRODUCTION_PN}" +
            $"{(PKGQty == null ? na.ToString().PadLeft(13, '0') : PKGQty.ToString().PadLeft(13, '0'))}" +
            $"{(InnerPkgQty == null ? na.ToString().PadLeft(13, '0') : InnerPkgQty.ToString().PadLeft(13, '0'))}" +
            $"{(TP == null ? na.PadRight(3) : TP.PadRight(3))}" +
            $"{(MLQ == null ? na.ToString().PadLeft(13, '0') : MLQ.ToString().PadLeft(13, '0'))}" +
            $"{(CustomFlag == null ? '0' : CustomFlag)}" +
            $"{(WPinputTAT == null ? na.ToString().PadLeft(2, '0') : WPinputTAT.ToString().PadLeft(2, '0'))}" +
            $"{(UOCreateWeek == null ? na.ToString().PadLeft(2, '0') : UOCreateWeek.ToString().PadLeft(2, '0'))}" +
            $"{(OIQ == null ? na.ToString().PadLeft(13, '0') : OIQ.ToString().PadLeft(13, '0'))}" +
            $"{(OrderableFlag == null ? '0' : OrderableFlag)}" +
            $"{(NCNRFlag == null ? '0' : NCNRFlag)}";
    }
}
