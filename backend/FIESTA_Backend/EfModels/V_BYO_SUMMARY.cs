using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_BYO_SUMMARY
{
    public string? type { get; set; }

    public string? partNumber { get; set; }

    public string? remarks { get; set; }

    public string? buyOffReason { get; set; }

    public long? changeOrder { get; set; }

    public string? prefixChangeOrder { get; set; }

    public string? materialType { get; set; }

    public string? materialTypeDetail { get; set; }

    public string? materialGroup { get; set; }

    public string? companyCode { get; set; }

    public string? legacyOrganization { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? TT { get; set; }
}
