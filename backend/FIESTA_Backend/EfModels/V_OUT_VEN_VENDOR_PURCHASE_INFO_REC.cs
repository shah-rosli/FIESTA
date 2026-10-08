using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels;

public partial class V_OUT_VEN_VENDOR_PURCHASE_INFO_REC
{
    public decimal recordKey { get; set; }

    public string number { get; set; } = null!;

    public string purchasingOrganization { get; set; } = null!;

    public string plant { get; set; } = null!;

    public string category { get; set; } = null!;

    public string partNumberKey { get; set; } = null!;

    public string vendorAccountNumber { get; set; } = null!;

    public DateTime validFromDate { get; set; }

    public string? partNumber { get; set; }

    public DateTime? validToDate { get; set; }

    public string? materialGroup { get; set; }

    public string? materialGroupDescription { get; set; }

    public DateTime? recordRegisteredDate { get; set; }

    public string? returnAgreement { get; set; }

    public string? purchasingGroupCode { get; set; }

    public string? purchasingGroup { get; set; }

    public string? priceDetermination { get; set; }

    public short? priceUnit { get; set; }

    public byte? overdeliveryToleranceLimit { get; set; }

    public string? baseUnitOfMeasure { get; set; }

    public string? indicatorForGRBasedInvoiceVerification { get; set; }

    public string? shortText { get; set; }

    public long? minimumPurchaseOrderQuantity { get; set; }

    public string? materialNumberUsedByVendor { get; set; }

    public string? shippingInstructions { get; set; }

    public string? vatCode { get; set; }

    public string? priorVendor { get; set; }

    public string? purchaseOrderUnitOfMeasure { get; set; }

    public short? numeratorForConvOfOrderPriceUnitIntoOrderUnit { get; set; }

    public short? denominatorForConvOfOrderPriceUnitIntoOrderUnit { get; set; }

    public byte? underdeliveryToleranceLimit { get; set; }

    public byte? plannedDeliveryTimeInDays { get; set; }

    public DateTime? availableDeliverableFrom { get; set; }

    public DateTime? availableDeliverableUntil { get; set; }

    public decimal? netPrice { get; set; }

    public string? currencyCode { get; set; }

    public string? currency { get; set; }

    public string? indicatorForFieldSequence { get; set; }

    public decimal? effectivePrice { get; set; }

    public string? materialPOTextDrawingNumber { get; set; }

    public string? materialPOTextSecondaryNumber { get; set; }

    public string? standardText { get; set; }

    public string? documentNumber { get; set; }

    public string? documentVersion { get; set; }

    public string? environmentallyRelevant { get; set; }

    public string? materialFreightGroup { get; set; }

    public long? baseUnitOfMeasureQuantity { get; set; }

    public string? conditionType1 { get; set; }

    public decimal? conditionType1Amount { get; set; }

    public string? conditionType2 { get; set; }

    public decimal? conditionType2Amount { get; set; }

    public string? conditionType3 { get; set; }

    public decimal? conditionType3Amount { get; set; }

    public string? conditionType4 { get; set; }

    public decimal? conditionType4Amount { get; set; }

    public string? conditionType5 { get; set; }

    public decimal? conditionType5Amount { get; set; }

    public decimal? actualUnitPriceInThePreviousPeriod { get; set; }

    public string? validityFlag { get; set; }

    public string? lineNoOfShelfLifeExpirationDate { get; set; }

    public string? countryOfOrigin { get; set; }

    public string? orderPriceUnitPurchasing { get; set; }

    public short? numeratorForConversionOfOrderPriceUnitIntoOrderUnit { get; set; }

    public short? denominatorForConversionOfOrderPriceUnitIntoOrderUnit { get; set; }

    public string? additionalPlantAndStorageLocationExtension { get; set; }

    public string? processStatus { get; set; }

    public DateTimeOffset? createDateAndTime { get; set; }

    public DateTimeOffset? updateDateAndTime { get; set; }

    public string? deleteFlag { get; set; }
}
