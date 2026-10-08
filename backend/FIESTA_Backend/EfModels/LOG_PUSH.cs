using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class LOG_PUSH
{
    public decimal AUDIT_ID { get; set; }

    public string? TABLE_NAME { get; set; }

    public string? TABLE_KEY { get; set; }

    public string? PUSH_BY { get; set; }

    public DateTimeOffset? PUSH_TIME { get; set; }

    public decimal? TOTAL_RECORDS { get; set; }

    public string? JSON_DATA { get; set; }
}
