using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_CDB_HI
{
    public decimal CFG_CDB_HIS_ID { get; set; }

    public DateTimeOffset? CFG_CDB_HIS_DATE { get; set; }

    public string? CFG_CDB_HIS_USERID { get; set; }

    public string? CFG_CDB_HIS_DELEGATE { get; set; }

    public decimal? recordKey { get; set; }

    public string opn { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string lineName { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public string activeFlag { get; set; } = null!;
}
