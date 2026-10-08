using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class CFG_SYSTEM_TRIGGERING
{
    public decimal CFG_SYSTEM_TRIGGERING_ID { get; set; }

    public string TRIGGERING_NAME { get; set; } = null!;

    public string QUERY { get; set; } = null!;

    public string MAILSUBJECT { get; set; } = null!;

    public string MAILBODY { get; set; } = null!;

    public string RECIPIENT { get; set; } = null!;

    public string ACTIVE { get; set; } = null!;

    public string FREQUENCY { get; set; } = null!;

    public DateTimeOffset? LAST_RUN_DATETIME { get; set; }

    public string? URL_LINK { get; set; }

    public string? AS_ATTACHMENT { get; set; }
}
