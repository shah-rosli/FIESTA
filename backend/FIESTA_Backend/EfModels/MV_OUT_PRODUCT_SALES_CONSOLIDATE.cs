using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class MV_OUT_PRODUCT_SALES_CONSOLIDATE
{
    public decimal? recordKey { get; set; }

    public string? partNumberKey { get; set; }

    public string? partNumber { get; set; }

    public string? salesOrganization { get; set; }

    public string? distributionChannel { get; set; }

    public long? minimumOrderQuantity { get; set; }

    public long? frequencyOrderIncrement { get; set; }

    public long? standardPackingQuantity { get; set; }

    public string? defaultSalesOrderCreationPlant { get; set; }

    public string? materialType { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? updateType { get; set; }

    public string? deleteFlag { get; set; }

    public DateTimeOffset? deleteDateAndTime { get; set; }

    public string? applicationCode3Default { get; set; }

    public string? goldenRecord { get; set; }

    public string? sentFromSystem { get; set; }

    public string? processStatus { get; set; }
}
