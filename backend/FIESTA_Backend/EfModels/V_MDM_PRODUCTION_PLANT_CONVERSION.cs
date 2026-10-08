using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_MDM_PRODUCTION_PLANT_CONVERSION
{
    public decimal recordKey { get; set; }

    public string company { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string storageLocation { get; set; } = null!;

    public string legacyType { get; set; } = null!;

    public string legacyLine { get; set; } = null!;

    public string groupStage { get; set; } = null!;

    public string massProductionFlag { get; set; } = null!;

    public string? plantAndSlocVsLegacyLineRecordID { get; set; }

    public string? hmeType { get; set; }

    public string activeFlag { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string processStatus { get; set; } = null!;
}
