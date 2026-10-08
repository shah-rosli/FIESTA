using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_PRODUCT_SALES_PREVCYCLE_R3DRYRUN
{
    public decimal recordKey { get; set; }

    public string partNumberKey { get; set; } = null!;

    public string partNumber { get; set; } = null!;

    public string salesOrganization { get; set; } = null!;

    public string distributionChannel { get; set; } = null!;

    public long? minimumOrderQuantity { get; set; }

    public long? frequencyOrderIncrement { get; set; }

    public long? standardPackingQuantity { get; set; }

    public string? defaultSalesOrderCreationPlant { get; set; }

    public string materialType { get; set; } = null!;

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? fiestaRules { get; set; }

    public string processStatus { get; set; } = null!;
}
