using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_FIN_COST_CENTER
{
    public decimal recordKey { get; set; }

    public string coArea { get; set; } = null!;

    public string costCenter { get; set; } = null!;

    public DateTime paymentCardsValidTo { get; set; }

    public DateTime? effectiveDate { get; set; }

    public string? lockIndicatorForActualPrimaryPostings { get; set; }

    public string? lockIndicatorForPlanPrimaryCosts { get; set; }

    public string? companyCode { get; set; }

    public string? businessArea { get; set; }

    public string? costCenterCategory { get; set; }

    public string? personResponsible { get; set; }

    public string? currency { get; set; }

    public string? profitCenter { get; set; }

    public DateTime? createOn { get; set; }

    public string? userName { get; set; }

    public string? lockIndicatorForActualSecondaryCosts { get; set; }

    public string? lockIndicatorForActualRevenuePostings { get; set; }

    public string? lockIndicatorForCommitmentUpdate { get; set; }

    public string? lockIndicatorForPlanSecondaryCosts { get; set; }

    public string? lockIndicatorForPlanningRevenues { get; set; }

    public string? indicatorForAllowedAllocationMethods { get; set; }

    public string? indicatorForRecordingConsumptionQuantities { get; set; }

    public string? country { get; set; }

    public string? profitCenterArea { get; set; }

    public string? completionFlag { get; set; }

    public string? objectNumber { get; set; }

    public string? functionalArea { get; set; }

    public string? name { get; set; }

    public string? description { get; set; }

    public string? costCenterShortText { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;
}
