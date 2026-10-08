using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4VenVendorPurchaseInfoRec
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("VEN_VENDOR_PURCHASE_INFO_REC");
            dt.Columns.Add("number", typeof(string));
            dt.Columns.Add("purchasingOrganization", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("vendorAccountNumber", typeof(string));
            dt.Columns.Add("validFromDate", typeof(DateTime));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("validToDate", typeof(DateTime));
            dt.Columns.Add("materialGroup", typeof(string));
            dt.Columns.Add("materialGroupDescription", typeof(string));
            dt.Columns.Add("recordRegisteredDate", typeof(DateTime));
            dt.Columns.Add("returnAgreement", typeof(string));
            dt.Columns.Add("purchasingGroupCode", typeof(string));
            dt.Columns.Add("purchasingGroup", typeof(string));
            dt.Columns.Add("priceDetermination", typeof(string));
            dt.Columns.Add("priceUnit", typeof(decimal));
            dt.Columns.Add("overdeliveryToleranceLimit", typeof(decimal));
            dt.Columns.Add("baseUnitOfMeasure", typeof(string));
            dt.Columns.Add("indicatorForGRBasedInvoiceVerification", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
            dt.Columns.Add("shortText", typeof(string));
            dt.Columns.Add("minimumPurchaseOrderQuantity", typeof(decimal));
            dt.Columns.Add("materialNumberUsedByVendor", typeof(string));
            dt.Columns.Add("shippingInstructions", typeof(string));
            dt.Columns.Add("vatCode", typeof(string));
            dt.Columns.Add("priorVendor", typeof(string));
            dt.Columns.Add("purchaseOrderUnitOfMeasure", typeof(string));
            dt.Columns.Add("numeratorForConvOfOrderPriceUnitIntoOrderUnit", typeof(decimal));
            dt.Columns.Add("denominatorForConvOfOrderPriceUnitIntoOrderUnit", typeof(decimal));
            dt.Columns.Add("underdeliveryToleranceLimit", typeof(decimal));
            dt.Columns.Add("plannedDeliveryTimeInDays", typeof(decimal));
            dt.Columns.Add("availableDeliverableFrom", typeof(DateTime));
            dt.Columns.Add("availableDeliverableUntil", typeof(DateTime));
            dt.Columns.Add("netPrice", typeof(decimal));
            dt.Columns.Add("currencyCode", typeof(string));
            dt.Columns.Add("currency", typeof(string));
            dt.Columns.Add("indicatorForFieldSequence", typeof(string));
            dt.Columns.Add("effectivePrice", typeof(decimal));
            dt.Columns.Add("materialPOTextDrawingNumber", typeof(string));
            dt.Columns.Add("materialPOTextSecondaryNumber", typeof(string));
            dt.Columns.Add("standardText", typeof(string));
            dt.Columns.Add("documentNumber", typeof(string));
            dt.Columns.Add("documentVersion", typeof(string));
            dt.Columns.Add("environmentallyRelevant", typeof(string));
            dt.Columns.Add("materialFreightGroup", typeof(string));
            dt.Columns.Add("baseUnitOfMeasureQuantity", typeof(decimal));
            dt.Columns.Add("conditionType1", typeof(string));
            dt.Columns.Add("conditionType1Amount", typeof(decimal));
            dt.Columns.Add("conditionType2", typeof(string));
            dt.Columns.Add("conditionType2Amount", typeof(decimal));
            dt.Columns.Add("conditionType3", typeof(string));
            dt.Columns.Add("conditionType3Amount", typeof(decimal));
            dt.Columns.Add("conditionType4", typeof(string));
            dt.Columns.Add("conditionType4Amount", typeof(decimal));
            dt.Columns.Add("conditionType5", typeof(string));
            dt.Columns.Add("conditionType5Amount", typeof(decimal));
            dt.Columns.Add("actualUnitPriceInThePreviousPeriod", typeof(decimal));
            dt.Columns.Add("validityFlag", typeof(string));
            dt.Columns.Add("lineNoOfShelfLifeExpirationDate", typeof(string));
            dt.Columns.Add("countryOfOrigin", typeof(string));
            dt.Columns.Add("orderPriceUnitPurchasing", typeof(string));
            dt.Columns.Add("numeratorForConversionOfOrderPriceUnitIntoOrderUnit", typeof(decimal));
            dt.Columns.Add("denominatorForConversionOfOrderPriceUnitIntoOrderUnit", typeof(decimal));
            dt.Columns.Add("additionalPlantAndStorageLocationExtension", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));
            dt.Columns.Add("fileName", typeof(string));

            int dataRowCount = int.Parse(DateTime.UtcNow.ToString("yyyyfff"));
            foreach (object o in records)
            {
                if (o != null)
                {
                    //2026-06-21: individual records will have current datetime stamp.
                    //fix datetime - all records in same batch will have same datetime.
                    //sample DT: 2023-01-01T00:00:00.000Z
                    string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    DateTimeOffset s = DateTimeOffset.Parse(now);

                    object[] oRowDt = new object[67];
                    CSV_S4_VEN_VENDOR_PURCHASE_INFO_REC material = (CSV_S4_VEN_VENDOR_PURCHASE_INFO_REC)o;
                    oRowDt[0] = material.number;
                    oRowDt[1] = material.purchasingOrganization;
                    oRowDt[2] = material.plant;
                    oRowDt[3] = material.category;
                    oRowDt[4] = material.partNumberKey;
                    oRowDt[5] = material.vendorAccountNumber;
                    oRowDt[6] = material.validFromDate;
                    oRowDt[7] = material.partNumber;
                    oRowDt[8] = material.validToDate;
                    oRowDt[9] = material.materialGroup;
                    oRowDt[10] = material.materialGroupDescription;
                    oRowDt[11] = material.recordRegisteredDate;
                    oRowDt[12] = material.returnAgreement;
                    oRowDt[13] = material.purchasingGroupCode;
                    oRowDt[14] = material.purchasingGroup;
                    oRowDt[15] = material.priceDetermination;
                    oRowDt[16] = material.priceUnit;
                    oRowDt[17] = material.overdeliveryToleranceLimit;
                    oRowDt[18] = material.baseUnitOfMeasure;
                    oRowDt[19] = material.indicatorForGRBasedInvoiceVerification;
                    oRowDt[20] = material.deleteFlag;
                    oRowDt[21] = material.shortText;
                    oRowDt[22] = material.minimumPurchaseOrderQuantity;
                    oRowDt[23] = material.materialNumberUsedByVendor;
                    oRowDt[24] = material.shippingInstructions;
                    oRowDt[25] = material.vatCode;
                    oRowDt[26] = material.priorVendor;
                    oRowDt[27] = material.purchaseOrderUnitOfMeasure;
                    oRowDt[28] = material.numeratorForConvOfOrderPriceUnitIntoOrderUnit;
                    oRowDt[29] = material.denominatorForConvOfOrderPriceUnitIntoOrderUnit;
                    oRowDt[30] = material.underdeliveryToleranceLimit;
                    oRowDt[31] = material.plannedDeliveryTimeInDays;
                    oRowDt[32] = material.availableDeliverableFrom;
                    oRowDt[33] = material.availableDeliverableUntil;
                    oRowDt[34] = material.netPrice;
                    oRowDt[35] = material.currencyCode;
                    oRowDt[36] = material.currency;
                    oRowDt[37] = material.indicatorForFieldSequence;
                    oRowDt[38] = material.effectivePrice;
                    oRowDt[39] = material.materialPOTextDrawingNumber;
                    oRowDt[40] = material.materialPOTextSecondaryNumber;
                    oRowDt[41] = material.standardText;
                    oRowDt[42] = material.documentNumber;
                    oRowDt[43] = material.documentVersion;
                    oRowDt[44] = material.environmentallyRelevant;
                    oRowDt[45] = material.materialFreightGroup;
                    oRowDt[46] = material.baseUnitOfMeasureQuantity;
                    oRowDt[47] = material.conditionType1;
                    oRowDt[48] = material.conditionType1Amount;
                    oRowDt[49] = material.conditionType2;
                    oRowDt[50] = material.conditionType2Amount;
                    oRowDt[51] = material.conditionType3;
                    oRowDt[52] = material.conditionType3Amount;
                    oRowDt[53] = material.conditionType4;
                    oRowDt[54] = material.conditionType4Amount;
                    oRowDt[55] = material.conditionType5;
                    oRowDt[56] = material.conditionType5Amount;
                    oRowDt[57] = material.actualUnitPriceInThePreviousPeriod;
                    oRowDt[58] = material.validityFlag;
                    oRowDt[59] = material.lineNoOfShelfLifeExpirationDate;
                    oRowDt[60] = material.countryOfOrigin;
                    oRowDt[61] = material.orderPriceUnitPurchasing;
                    oRowDt[62] = material.numeratorForConversionOfOrderPriceUnitIntoOrderUnit;
                    oRowDt[63] = material.denominatorForConversionOfOrderPriceUnitIntoOrderUnit;
                    oRowDt[64] = material.additionalPlantAndStorageLocationExtension;
                    oRowDt[65] = s.UtcDateTime;
                    oRowDt[66] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
