using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4VenVendor
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("VEN_VENDOR");
            dt.Columns.Add("vendorNumber", typeof(string));
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("name2", typeof(string));
            dt.Columns.Add("searchTerm12", typeof(string));
            dt.Columns.Add("buildingCode", typeof(string));
            dt.Columns.Add("room", typeof(string));
            dt.Columns.Add("floor", typeof(string));
            dt.Columns.Add("coName", typeof(string));
            dt.Columns.Add("streetHouseNumber", typeof(string));
            dt.Columns.Add("street2", typeof(string));
            dt.Columns.Add("street3", typeof(string));
            dt.Columns.Add("street4", typeof(string));
            dt.Columns.Add("street5", typeof(string));
            dt.Columns.Add("houseNumber", typeof(string));
            dt.Columns.Add("houseNumberSupplement", typeof(string));
            dt.Columns.Add("district", typeof(string));
            dt.Columns.Add("differentCity", typeof(string));
            dt.Columns.Add("postalCode", typeof(string));
            dt.Columns.Add("city", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("region", typeof(string));
            dt.Columns.Add("timeZone", typeof(string));
            dt.Columns.Add("taxJurisdictn", typeof(string));
            dt.Columns.Add("transportationZone", typeof(string));
            dt.Columns.Add("poBox", typeof(string));
            dt.Columns.Add("postalCode2", typeof(string));
            dt.Columns.Add("otherCity", typeof(string));
            dt.Columns.Add("companyPostalCode", typeof(string));
            dt.Columns.Add("languageKey", typeof(string));
            dt.Columns.Add("generalTelephone", typeof(string));
            dt.Columns.Add("telephoneExtension", typeof(string));
            dt.Columns.Add("fax", typeof(string));
            dt.Columns.Add("faxExtension", typeof(string));
            dt.Columns.Add("standardCommMethod", typeof(string));
            dt.Columns.Add("dataLine", typeof(string));
            dt.Columns.Add("telebox", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("taxNumber1", typeof(string));
            dt.Columns.Add("taxNumber2", typeof(string));
            dt.Columns.Add("taxNumber3", typeof(string));
            dt.Columns.Add("taxOffice", typeof(string));
            dt.Columns.Add("taxNumber", typeof(string));
            dt.Columns.Add("purchasingOrganization", typeof(string));
            dt.Columns.Add("orderCurrency", typeof(string));
            dt.Columns.Add("termsOfPayment", typeof(string));
            dt.Columns.Add("incoterms", typeof(string));
            dt.Columns.Add("inco2", typeof(string));
            dt.Columns.Add("minimumOrderValue", typeof(string));
            dt.Columns.Add("schemaGroupVendor", typeof(string));
            dt.Columns.Add("pricingDateControl", typeof(string));
            dt.Columns.Add("salesperson", typeof(string));
            dt.Columns.Add("purchasingTelephone", typeof(string));
            dt.Columns.Add("grBasedInvVeri", typeof(string));
            dt.Columns.Add("autoEvalGRSetmtDel", typeof(string));
            dt.Columns.Add("autoevalgrsetmtRet", typeof(string));
            dt.Columns.Add("acknowledgementReqd", typeof(string));
            dt.Columns.Add("abcIndicator", typeof(string));
            dt.Columns.Add("modeOfTransprtBorder", typeof(string));
            dt.Columns.Add("officeOfEntry", typeof(string));
            dt.Columns.Add("sortCriterion", typeof(string));
            dt.Columns.Add("automaticPurchaseOrder", typeof(string));
            dt.Columns.Add("subsequentSettlement", typeof(string));
            dt.Columns.Add("returnsVendor", typeof(string));
            dt.Columns.Add("relevantForPriceDetVendorHierarchy", typeof(string));
            dt.Columns.Add("purchasingGroup", typeof(string));
            dt.Columns.Add("plannedDelivTime", typeof(string));
            dt.Columns.Add("confirmationControl", typeof(string));
            dt.Columns.Add("partnerFunction1", typeof(string));
            dt.Columns.Add("partnerNumber1", typeof(string));
            dt.Columns.Add("creationDate", typeof(string));
            dt.Columns.Add("deletionIndicatorCommon", typeof(string));
            dt.Columns.Add("name3", typeof(string));
            dt.Columns.Add("name4", typeof(string));
            dt.Columns.Add("searchTerm2", typeof(string));
            dt.Columns.Add("accountNumberAtVendor", typeof(string));
            dt.Columns.Add("customerNumber", typeof(string));
            dt.Columns.Add("companyIDTradingPartner", typeof(string));
            dt.Columns.Add("bankFeeCode", typeof(string));
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

                    object[] oRowDt = new object[81];
                    CSV_S4_VEN_VENDOR material = (CSV_S4_VEN_VENDOR)o;
                    oRowDt[0] = material.vendorNumber;
                    oRowDt[1] = material.title;
                    oRowDt[2] = material.name;
                    oRowDt[3] = material.name2;
                    oRowDt[4] = material.searchTerm12;
                    oRowDt[5] = material.buildingCode;
                    oRowDt[6] = material.room;
                    oRowDt[7] = material.floor;
                    oRowDt[8] = material.coName;
                    oRowDt[9] = material.streetHouseNumber;
                    oRowDt[10] = material.street2;
                    oRowDt[11] = material.street3;
                    oRowDt[12] = material.street4;
                    oRowDt[13] = material.street5;
                    oRowDt[14] = material.houseNumber;
                    oRowDt[15] = material.houseNumberSupplement;
                    oRowDt[16] = material.district;
                    oRowDt[17] = material.differentCity;
                    oRowDt[18] = material.postalCode;
                    oRowDt[19] = material.city;
                    oRowDt[20] = material.country;
                    oRowDt[21] = material.region;
                    oRowDt[22] = material.timeZone;
                    oRowDt[23] = material.taxJurisdictn;
                    oRowDt[24] = material.transportationZone;
                    oRowDt[25] = material.poBox;
                    oRowDt[26] = material.postalCode2;
                    oRowDt[27] = material.otherCity;
                    oRowDt[28] = material.companyPostalCode;
                    oRowDt[29] = material.languageKey;
                    oRowDt[30] = material.generalTelephone;
                    oRowDt[31] = material.telephoneExtension;
                    oRowDt[32] = material.fax;
                    oRowDt[33] = material.faxExtension;
                    oRowDt[34] = material.standardCommMethod;
                    oRowDt[35] = material.dataLine;
                    oRowDt[36] = material.telebox;
                    oRowDt[37] = material.email;
                    oRowDt[38] = material.taxNumber1;
                    oRowDt[39] = material.taxNumber2;
                    oRowDt[40] = material.taxNumber3;
                    oRowDt[41] = material.taxOffice;
                    oRowDt[42] = material.taxNumber;
                    oRowDt[43] = material.purchasingOrganization;
                    oRowDt[44] = material.orderCurrency;
                    oRowDt[45] = material.termsOfPayment;
                    oRowDt[46] = material.incoterms;
                    oRowDt[47] = material.inco2;
                    oRowDt[48] = material.minimumOrderValue;
                    oRowDt[49] = material.schemaGroupVendor;
                    oRowDt[50] = material.pricingDateControl;
                    oRowDt[51] = material.salesperson;
                    oRowDt[52] = material.purchasingTelephone;
                    oRowDt[53] = material.grBasedInvVeri;
                    oRowDt[54] = material.autoEvalGRSetmtDel;
                    oRowDt[55] = material.autoevalgrsetmtRet;
                    oRowDt[56] = material.acknowledgementReqd;
                    oRowDt[57] = material.abcIndicator;
                    oRowDt[58] = material.modeOfTransprtBorder;
                    oRowDt[59] = material.officeOfEntry;
                    oRowDt[60] = material.sortCriterion;
                    oRowDt[61] = material.automaticPurchaseOrder;
                    oRowDt[62] = material.subsequentSettlement;
                    oRowDt[63] = material.returnsVendor;
                    oRowDt[64] = material.relevantForPriceDetVendorHierarchy;
                    oRowDt[65] = material.purchasingGroup;
                    oRowDt[66] = material.plannedDelivTime;
                    oRowDt[67] = material.confirmationControl;
                    oRowDt[68] = material.partnerFunction1;
                    oRowDt[69] = material.partnerNumber1;
                    oRowDt[70] = material.creationDate;
                    oRowDt[71] = material.deletionIndicatorCommon;
                    oRowDt[72] = material.name3;
                    oRowDt[73] = material.name4;
                    oRowDt[74] = material.searchTerm2;
                    oRowDt[75] = material.accountNumberAtVendor;
                    oRowDt[76] = material.customerNumber;
                    oRowDt[77] = material.companyIDTradingPartner;
                    oRowDt[78] = material.bankFeeCode;
                    oRowDt[79] = s.UtcDateTime;
                    oRowDt[80] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
