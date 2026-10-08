using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_VEN_VENDOR
{
    public decimal recordKey { get; set; }

    public string vendorNumber { get; set; } = null!;

    public string? title { get; set; }

    public string? name { get; set; }

    public string? name2 { get; set; }

    public string? searchTerm12 { get; set; }

    public string? buildingCode { get; set; }

    public string? room { get; set; }

    public string? floor { get; set; }

    public string? coName { get; set; }

    public string? streetHouseNumber { get; set; }

    public string? street2 { get; set; }

    public string? street3 { get; set; }

    public string? street4 { get; set; }

    public string? street5 { get; set; }

    public string? houseNumber { get; set; }

    public string? houseNumberSupplement { get; set; }

    public string? district { get; set; }

    public string? differentCity { get; set; }

    public string? postalCode { get; set; }

    public string? city { get; set; }

    public string? country { get; set; }

    public string? region { get; set; }

    public string? timeZone { get; set; }

    public string? taxJurisdictn { get; set; }

    public string? transportationZone { get; set; }

    public string? poBox { get; set; }

    public string? postalCode2 { get; set; }

    public string? otherCity { get; set; }

    public string? companyPostalCode { get; set; }

    public string? languageKey { get; set; }

    public string? generalTelephone { get; set; }

    public string? telephoneExtension { get; set; }

    public string? fax { get; set; }

    public string? faxExtension { get; set; }

    public string? standardCommMethod { get; set; }

    public string? dataLine { get; set; }

    public string? telebox { get; set; }

    public string? email { get; set; }

    public string? taxNumber1 { get; set; }

    public string? taxNumber2 { get; set; }

    public string? taxNumber3 { get; set; }

    public string? taxOffice { get; set; }

    public string? taxNumber { get; set; }

    public string? purchasingOrganization { get; set; }

    public string? orderCurrency { get; set; }

    public string? termsOfPayment { get; set; }

    public string? incoterms { get; set; }

    public string? inco2 { get; set; }

    public string? minimumOrderValue { get; set; }

    public string? schemaGroupVendor { get; set; }

    public string? pricingDateControl { get; set; }

    public string? salesperson { get; set; }

    public string? purchasingTelephone { get; set; }

    public string? grBasedInvVeri { get; set; }

    public string? autoEvalGRSetmtDel { get; set; }

    public string? autoevalgrsetmtRet { get; set; }

    public string? acknowledgementReqd { get; set; }

    public string? abcIndicator { get; set; }

    public string? modeOfTransprtBorder { get; set; }

    public string? officeOfEntry { get; set; }

    public string? sortCriterion { get; set; }

    public string? automaticPurchaseOrder { get; set; }

    public string? subsequentSettlement { get; set; }

    public string? returnsVendor { get; set; }

    public string? relevantForPriceDetVendorHierarchy { get; set; }

    public string? purchasingGroup { get; set; }

    public string? plannedDelivTime { get; set; }

    public string? confirmationControl { get; set; }

    public string? partnerFunction1 { get; set; }

    public string? partnerNumber1 { get; set; }

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

    public string? updateType { get; set; }

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
