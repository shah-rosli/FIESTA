using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.S4
{
    public class CSV_S4_VEN_VENDOR_PURCHASE_INFO_REC
    {
        public string? number { get; set; }
        public string? purchasingOrganization { get; set; }
        public string? plant { get; set; }
        public string? category { get; set; }
        public string? partNumberKey { get; set; }
        public string? vendorAccountNumber { get; set; }
        public DateTime? validFromDate { get; set; }
        public string? partNumber { get; set; }
        public DateTime? validToDate { get; set; }
        public string? materialGroup { get; set; }
        public string? materialGroupDescription { get; set; }
        public DateTime? recordRegisteredDate { get; set; }
        public string? returnAgreement { get; set; }
        public string? purchasingGroupCode { get; set; }
        public string? purchasingGroup { get; set; }
        public string? priceDetermination { get; set; }
        public decimal? priceUnit { get; set; }
        public decimal? overdeliveryToleranceLimit { get; set; }
        public string? baseUnitOfMeasure { get; set; }
        public string? indicatorForGRBasedInvoiceVerification { get; set; }
        public string? deleteFlag { get; set; }
        public string? shortText { get; set; }
        public decimal? minimumPurchaseOrderQuantity { get; set; }
        public string? materialNumberUsedByVendor { get; set; }
        public string? shippingInstructions { get; set; }
        public string? vatCode { get; set; }
        public string? priorVendor { get; set; }
        public string? purchaseOrderUnitOfMeasure { get; set; }
        public decimal? numeratorForConvOfOrderPriceUnitIntoOrderUnit { get; set; }
        public decimal? denominatorForConvOfOrderPriceUnitIntoOrderUnit { get; set; }
        public decimal? underdeliveryToleranceLimit { get; set; }
        public decimal? plannedDeliveryTimeInDays { get; set; }
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
        public decimal? baseUnitOfMeasureQuantity { get; set; }
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
        public decimal? numeratorForConversionOfOrderPriceUnitIntoOrderUnit { get; set; }
        public decimal? denominatorForConversionOfOrderPriceUnitIntoOrderUnit { get; set; }
        public string? additionalPlantAndStorageLocationExtension { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public string? fileName { get; set; }


    }
}
