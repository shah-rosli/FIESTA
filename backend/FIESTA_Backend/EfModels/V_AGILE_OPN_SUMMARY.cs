using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_AGILE_OPN_SUMMARY
{
    public decimal ID { get; set; }

    public string ORG { get; set; } = null!;

    public string ENTITY_ID { get; set; } = null!;

    public DateTimeOffset? CREATED_AT { get; set; }

    public DateTimeOffset? MODIFIED_AT { get; set; }

    public string? FAILURE_REASON { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;
}
