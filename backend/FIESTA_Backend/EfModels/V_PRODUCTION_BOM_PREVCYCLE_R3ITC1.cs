using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_PRODUCTION_BOM_PREVCYCLE_R3ITC1
{
    public string? opn { get; set; }

    public long? bomLevel { get; set; }

    public decimal? recordKey { get; set; }

    public string? partNumberKey { get; set; }

    public string? partNumber { get; set; }

    public string? plant { get; set; }

    public string? bomUsage { get; set; }

    public string? bomStatus { get; set; }

    public string? bomKey { get; set; }

    public string? bomAlternative { get; set; }

    public string? baseUnitOfMeasure { get; set; }

    public long? baseQuantity { get; set; }

    public string? baseGroupStage { get; set; }

    public long? baseGroupStageType { get; set; }

    public DateTime? validFromDate { get; set; }

    public DateTime? validToDate { get; set; }

    public string? componentPartNumberKey { get; set; }

    public string? componentPartNumber { get; set; }

    public string? bomItem { get; set; }

    public string? componentUnitOfMeasure { get; set; }

    public long? componentQuantity { get; set; }

    public string? componentGroupStage { get; set; }

    public long? componentGroupStageType { get; set; }

    public string? bomItemTextLine1 { get; set; }

    public string? bomItemTextLine2 { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? headerDeleteFlag { get; set; }

    public string? fiestaRules { get; set; }
}
