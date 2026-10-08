using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_CUS_END_CUSTOMER
{
    public decimal recordKey { get; set; }

    public string? name { get; set; }

    public string? location { get; set; }

    public string accountNumCustomerOID { get; set; } = null!;

    public string? customerType { get; set; }

    public string? category { get; set; }

    public string? legalName { get; set; }

    public string? status { get; set; }

    public string? geography { get; set; }

    public string? btAddress1 { get; set; }

    public string? btAddress2 { get; set; }

    public string? btAddress3 { get; set; }

    public string? btAddress4 { get; set; }

    public string? btAddress5 { get; set; }

    public string? btCity { get; set; }

    public string? btState { get; set; }

    public string? btZip { get; set; }

    public string? btCountry { get; set; }

    public string? currencyName { get; set; }

    public string? customerLevel { get; set; }

    public string? parentCustomerAccount { get; set; }

    public string? parentCustomerName { get; set; }

    public string? parentCustomerLocation { get; set; }

    public string? focus { get; set; }

    public string? childId { get; set; }

    public string? isTyt { get; set; }

    public string? hiRelAllowed { get; set; }

    public string? webSite { get; set; }

    public string? soldToOrigin { get; set; }

    public string? sapChangePoint { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string deleteFlag { get; set; } = null!;
}
