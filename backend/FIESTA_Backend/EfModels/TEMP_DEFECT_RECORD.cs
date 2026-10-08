using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class TEMP_DEFECT_RECORD
{
    public string? DefectNo { get; set; }

    public string? DefectDescription { get; set; }

    public string? PersonResponsible { get; set; }

    public string? S4MaterialType { get; set; }

    public string? AvailableProductInS4 { get; set; }

    public string? MissingPlant { get; set; }

    public string? MissingStorageLocation { get; set; }

    public string? UnifiedProduct { get; set; }

    public string? FIESTALegacyOrg { get; set; }

    public string? FIESTACompanyCode { get; set; }

    public string? FIESTAStatus { get; set; }

    public string? FiestaCommentMC2 { get; set; }

    public string? rootCause { get; set; }

    public string? rootCauseDetail { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }
}
