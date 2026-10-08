using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_PLM_BLACKLIST_SUMMARY
{
    public string Blacklist_Number { get; set; } = null!;

    public decimal? Count_of_Part_Number { get; set; }

    public string? Blacklist_Details { get; set; }

    public string? nextAction { get; set; }

    public string? blacklistFlag { get; set; }

    public string? type { get; set; }
}
