using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class OUT_CUS_SOLD_TO
{
    public decimal recordKey { get; set; }

    public string? bpRole { get; set; }

    public string customerCode { get; set; } = null!;

    public string? buGroup { get; set; }

    public string? title { get; set; }

    public string? customerName1 { get; set; }

    public string? customerName2 { get; set; }

    public string? customerName3 { get; set; }

    public string? customerName4 { get; set; }

    public string? searchName1 { get; set; }

    public string? building { get; set; }

    public string? roomNumber { get; set; }

    public string? floor { get; set; }

    public string? street { get; set; }

    public string? street2 { get; set; }

    public string? street3 { get; set; }

    public string? houseNumber { get; set; }

    public string? district { get; set; }

    public string? homeCity { get; set; }

    public string? postalCode { get; set; }

    public string? city { get; set; }

    public string? countryCode { get; set; }

    public string? regionCode { get; set; }

    public string? timeZone { get; set; }

    public string? taxJurisdiction { get; set; }

    public string? transportationZone { get; set; }

    public string? poBox { get; set; }

    public string? languageKey { get; set; }

    public string? telNumber { get; set; }

    public string? telExtension { get; set; }

    public string? telNumber2 { get; set; }

    public string? faxNumber { get; set; }

    public string? faxExtension { get; set; }

    public string? teletexNumber { get; set; }

    public string? telexNumber { get; set; }

    public string? smtpAddr { get; set; }

    public string? companyIdTradingPartner { get; set; }

    public string? cityCode { get; set; }

    public string? vatNumber { get; set; }

    public string? customerClassification { get; set; }

    public string? fiscalYearVariant { get; set; }

    public string? unloadingPoint { get; set; }

    public string? defaultUnloadingPoint { get; set; }

    public string? customersFactoryCalendar { get; set; }

    public string? goodsReceivingHoursId { get; set; }

    public string? attribute1 { get; set; }

    public string? attribute2 { get; set; }

    public string? attribute3 { get; set; }

    public string? attribute4 { get; set; }

    public string? attribute5 { get; set; }

    public string? attribute6 { get; set; }

    public string? attribute7 { get; set; }

    public string? attribute8 { get; set; }

    public string? attribute9 { get; set; }

    public string? attribute10 { get; set; }

    public string? centralDeletionFlag { get; set; }

    public string? businessPartnerCategory { get; set; }

    public string? identificationNumber15 { get; set; }

    public string? taxtypeSg1 { get; set; }

    public string? taxnumSg1 { get; set; }

    public string? taxtypeTw1 { get; set; }

    public string? taxnumTw1 { get; set; }

    public string? taxtypeTw2 { get; set; }

    public string? taxnumTw2 { get; set; }

    public string? taxtypeKr1 { get; set; }

    public string? taxnumKr1 { get; set; }

    public string? taxtypeKr2 { get; set; }

    public string? taxnumKr2 { get; set; }

    public string? characteristicName1 { get; set; }

    public string? characteristicValue1 { get; set; }

    public string? salesOrganization { get; set; }

    public string? distributionChannel { get; set; }

    public string? division { get; set; }

    public string? customerGroup { get; set; }

    public string? currency { get; set; }

    public string? pricingProcedureAssigned { get; set; }

    public byte? deliveryPriority { get; set; }

    public string? shippingConditions { get; set; }

    public string? orderCombinationIndicator { get; set; }

    public string? completeDeliveryDefined { get; set; }

    public string? partialDeliveryAtItemLevel { get; set; }

    public decimal? maximumDeliveriesAllowed { get; set; }

    public string? incotermas1 { get; set; }

    public string? incotermas2 { get; set; }

    public string? termsOfPaymentKey { get; set; }

    public string? creditControlArea { get; set; }

    public string? accountAssignmentGroup { get; set; }

    public string? partnerFunction { get; set; }

    public string? customerOrderBlock { get; set; }

    public string? customerGroup1 { get; set; }

    public string? customerGroup2 { get; set; }

    public string? customerGroup3 { get; set; }

    public string? customerGroup4 { get; set; }

    public string? customerGroup5 { get; set; }

    public string? overDeliveryTolerance { get; set; }

    public string? accountAtCustomer { get; set; }

    public string? textId1 { get; set; }

    public string? textId2 { get; set; }

    public string? textId3 { get; set; }

    public string? textId4 { get; set; }

    public string? textId5 { get; set; }

    public string? parentCustomerAccount { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string updateType { get; set; } = null!;

    public string deleteFlag { get; set; } = null!;

    public DateTimeOffset? deleteDateAndTime { get; set; }
}
