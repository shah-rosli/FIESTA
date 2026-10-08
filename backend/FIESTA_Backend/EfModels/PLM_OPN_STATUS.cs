using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class PLM_OPN_STATUS
{
    public decimal recordKey { get; set; }

    public string opn { get; set; } = null!;

    public string? agileSignOff { get; set; }

    public DateTimeOffset? agileSignOffDate { get; set; }

    public string? fiestaSignOff { get; set; }

    public DateTimeOffset? fiestaSignOffDate { get; set; }

    public string? userSignOff { get; set; }

    public string? userSignOffBy { get; set; }

    public DateTimeOffset? userSignOffDate { get; set; }

    public string? mdmFlowFlag { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }
}
