using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_VEN_VENDOR_COMPANY
{
    public decimal recordKey { get; set; }

    public string vendorNumber { get; set; } = null!;

    public string companyCode { get; set; } = null!;

    public string? personnelNumber { get; set; }

    public string? sortKey { get; set; }

    public string? reconciliationAcct { get; set; }

    public string? authorizationGroup { get; set; }

    public string? interestIndicator { get; set; }

    public string? planningGroup { get; set; }

    public string? headOffice { get; set; }

    public DateOnly? keyDateOfLastIntCalc { get; set; }

    public string? interestCalcFrequency { get; set; }

    public DateOnly? dateOfLastInterestRun { get; set; }

    public string? previousAccountNo { get; set; }

    public string? paymentMethods { get; set; }

    public string? clearingWithCust { get; set; }

    public string? paymentBlock { get; set; }

    public string? termsOfPayment { get; set; }

    public string? alternativePayee { get; set; }

    public string? checkCashingTime { get; set; }

    public string? checkDoubleInvoice { get; set; }

    public string? toleranceGroup { get; set; }

    public string? houseBank { get; set; }

    public string? individualPayment { get; set; }

    public string? paymentMethSupplement { get; set; }

    public string? paymentAdviceByEdi { get; set; }

    public string? creditMemoPytTerm { get; set; }

    public string? accountWithVendor { get; set; }

    public string? clerkAtVendor { get; set; }

    public string? accountMemo { get; set; }

    public string? accountingClerk { get; set; }

    public string? groupingKey { get; set; }

    public string? accountingClerkFax { get; set; }

    public string? clerkInternetAddress { get; set; }

    public string? acctingClerkTelephone { get; set; }

    public string? postingBlock { get; set; }

    public string? deletionFlag { get; set; }

    public string? acctStatement { get; set; }

    public string? minorityIndicator { get; set; }

    public string? paymentGroupKey { get; set; }

    public string? dunningProcedure { get; set; }

    public string? name { get; set; }

    public string? name2 { get; set; }

    public string? searchTerm12 { get; set; }

    public string? streetHouseNumber { get; set; }

    public string? street2 { get; set; }

    public string? street3 { get; set; }

    public string? street4 { get; set; }

    public string? street5 { get; set; }

    public string? district { get; set; }

    public string? postalCode { get; set; }

    public string? city { get; set; }

    public string? country { get; set; }

    public string? region { get; set; }

    public string? poBox { get; set; }

    public string? postalCode2 { get; set; }

    public string? generalTelephone { get; set; }

    public string? fax { get; set; }

    public string? purchasingOrganization { get; set; }

    public string? orderCurrency { get; set; }

    public string? incoterms { get; set; }

    public string? inco2 { get; set; }

    public string? schemaGroupVendor { get; set; }

    public string? salesperson { get; set; }

    public string? purchasingTelephone { get; set; }

    public string? grBasedInvVeri { get; set; }

    public string? autoEvalGRSetmtDel { get; set; }

    public string? autoevalgrsetmtRet { get; set; }

    public string? automaticPurchaseOrder { get; set; }

    public string? confirmationControl { get; set; }

    public string? creationDate { get; set; }

    public string? deletionIndicatorCommon { get; set; }

    public string? name3 { get; set; }

    public string? name4 { get; set; }

    public string? searchTerm2 { get; set; }

    public string? accountNumberAtVendor { get; set; }

    public string? customerNumber { get; set; }

    public string? companyIDTradingPartner { get; set; }

    public string? bankFeeCode { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
