using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4VenVendorCompany
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("VEN_VENDOR_COMPANY");
            dt.Columns.Add("vendorNumber", typeof(string));
            dt.Columns.Add("companyCode", typeof(string));
            dt.Columns.Add("personnelNumber", typeof(string));
            dt.Columns.Add("sortKey", typeof(string));
            dt.Columns.Add("reconciliationAcct", typeof(string));
            dt.Columns.Add("authorizationGroup", typeof(string));
            dt.Columns.Add("interestIndicator", typeof(string));
            dt.Columns.Add("planningGroup", typeof(string));
            dt.Columns.Add("headOffice", typeof(string));
            dt.Columns.Add("keyDateOfLastIntCalc", typeof(DateTime));
            dt.Columns.Add("interestCalcFrequency", typeof(string));
            dt.Columns.Add("dateOfLastInterestRun", typeof(DateTime));
            dt.Columns.Add("previousAccountNo", typeof(string));
            dt.Columns.Add("paymentMethods", typeof(string));
            dt.Columns.Add("clearingWithCust", typeof(string));
            dt.Columns.Add("paymentBlock", typeof(string));
            dt.Columns.Add("termsOfPayment", typeof(string));
            dt.Columns.Add("alternativePayee", typeof(string));
            dt.Columns.Add("checkCashingTime", typeof(string));
            dt.Columns.Add("checkDoubleInvoice", typeof(string));
            dt.Columns.Add("toleranceGroup", typeof(string));
            dt.Columns.Add("houseBank", typeof(string));
            dt.Columns.Add("individualPayment", typeof(string));
            dt.Columns.Add("paymentMethSupplement", typeof(string));
            dt.Columns.Add("paymentAdviceByEdi", typeof(string));
            dt.Columns.Add("creditMemoPytTerm", typeof(string));
            dt.Columns.Add("accountWithVendor", typeof(string));
            dt.Columns.Add("clerkAtVendor", typeof(string));
            dt.Columns.Add("accountMemo", typeof(string));
            dt.Columns.Add("accountingClerk", typeof(string));
            dt.Columns.Add("groupingKey", typeof(string));
            dt.Columns.Add("accountingClerkFax", typeof(string));
            dt.Columns.Add("clerkInternetAddress", typeof(string));
            dt.Columns.Add("acctingClerkTelephone", typeof(string));
            dt.Columns.Add("postingBlock", typeof(string));
            dt.Columns.Add("deletionFlag", typeof(string));
            dt.Columns.Add("acctStatement", typeof(string));
            dt.Columns.Add("minorityIndicator", typeof(string));
            dt.Columns.Add("paymentGroupKey", typeof(string));
            dt.Columns.Add("dunningProcedure", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("name2", typeof(string));
            dt.Columns.Add("searchTerm12", typeof(string));
            dt.Columns.Add("streetHouseNumber", typeof(string));
            dt.Columns.Add("street2", typeof(string));
            dt.Columns.Add("street3", typeof(string));
            dt.Columns.Add("street4", typeof(string));
            dt.Columns.Add("street5", typeof(string));
            dt.Columns.Add("district", typeof(string));
            dt.Columns.Add("postalCode", typeof(string));
            dt.Columns.Add("city", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("region", typeof(string));
            dt.Columns.Add("poBox", typeof(string));
            dt.Columns.Add("postalCode2", typeof(string));
            dt.Columns.Add("generalTelephone", typeof(string));
            dt.Columns.Add("fax", typeof(string));
            dt.Columns.Add("purchasingOrganization", typeof(string));
            dt.Columns.Add("orderCurrency", typeof(string));
            dt.Columns.Add("incoterms", typeof(string));
            dt.Columns.Add("inco2", typeof(string));
            dt.Columns.Add("schemaGroupVendor", typeof(string));
            dt.Columns.Add("salesperson", typeof(string));
            dt.Columns.Add("purchasingTelephone", typeof(string));
            dt.Columns.Add("grBasedInvVeri", typeof(string));
            dt.Columns.Add("autoEvalGRSetmtDel", typeof(string));
            dt.Columns.Add("autoevalgrsetmtRet", typeof(string));
            dt.Columns.Add("automaticPurchaseOrder", typeof(string));
            dt.Columns.Add("confirmationControl", typeof(string));
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

                    object[] oRowDt = new object[80];
                    CSV_S4_VEN_VENDOR_COMPANY material = (CSV_S4_VEN_VENDOR_COMPANY)o;
                    oRowDt[0] = material.vendorNumber;
                    oRowDt[1] = material.companyCode;
                    oRowDt[2] = material.personnelNumber;
                    oRowDt[3] = material.sortKey;
                    oRowDt[4] = material.reconciliationAcct;
                    oRowDt[5] = material.authorizationGroup;
                    oRowDt[6] = material.interestIndicator;
                    oRowDt[7] = material.planningGroup;
                    oRowDt[8] = material.headOffice;
                    oRowDt[9] = material.keyDateOfLastIntCalc;
                    oRowDt[10] = material.interestCalcFrequency;
                    oRowDt[11] = material.dateOfLastInterestRun;
                    oRowDt[12] = material.previousAccountNo;
                    oRowDt[13] = material.paymentMethods;
                    oRowDt[14] = material.clearingWithCust;
                    oRowDt[15] = material.paymentBlock;
                    oRowDt[16] = material.termsOfPayment;
                    oRowDt[17] = material.alternativePayee;
                    oRowDt[18] = material.checkCashingTime;
                    oRowDt[19] = material.checkDoubleInvoice;
                    oRowDt[20] = material.toleranceGroup;
                    oRowDt[21] = material.houseBank;
                    oRowDt[22] = material.individualPayment;
                    oRowDt[23] = material.paymentMethSupplement;
                    oRowDt[24] = material.paymentAdviceByEdi;
                    oRowDt[25] = material.creditMemoPytTerm;
                    oRowDt[26] = material.accountWithVendor;
                    oRowDt[27] = material.clerkAtVendor;
                    oRowDt[28] = material.accountMemo;
                    oRowDt[29] = material.accountingClerk;
                    oRowDt[30] = material.groupingKey;
                    oRowDt[31] = material.accountingClerkFax;
                    oRowDt[32] = material.clerkInternetAddress;
                    oRowDt[33] = material.acctingClerkTelephone;
                    oRowDt[34] = material.postingBlock;
                    oRowDt[35] = material.deletionFlag;
                    oRowDt[36] = material.acctStatement;
                    oRowDt[37] = material.minorityIndicator;
                    oRowDt[38] = material.paymentGroupKey;
                    oRowDt[39] = material.dunningProcedure;
                    oRowDt[40] = material.name;
                    oRowDt[41] = material.name2;
                    oRowDt[42] = material.searchTerm12;
                    oRowDt[43] = material.streetHouseNumber;
                    oRowDt[44] = material.street2;
                    oRowDt[45] = material.street3;
                    oRowDt[46] = material.street4;
                    oRowDt[47] = material.street5;
                    oRowDt[48] = material.district;
                    oRowDt[49] = material.postalCode;
                    oRowDt[50] = material.city;
                    oRowDt[51] = material.country;
                    oRowDt[52] = material.region;
                    oRowDt[53] = material.poBox;
                    oRowDt[54] = material.postalCode2;
                    oRowDt[55] = material.generalTelephone;
                    oRowDt[56] = material.fax;
                    oRowDt[57] = material.purchasingOrganization;
                    oRowDt[58] = material.orderCurrency;
                    oRowDt[59] = material.incoterms;
                    oRowDt[60] = material.inco2;
                    oRowDt[61] = material.schemaGroupVendor;
                    oRowDt[62] = material.salesperson;
                    oRowDt[63] = material.purchasingTelephone;
                    oRowDt[64] = material.grBasedInvVeri;
                    oRowDt[65] = material.autoEvalGRSetmtDel;
                    oRowDt[66] = material.autoevalgrsetmtRet;
                    oRowDt[67] = material.automaticPurchaseOrder;
                    oRowDt[68] = material.confirmationControl;
                    oRowDt[69] = material.creationDate;
                    oRowDt[70] = material.deletionIndicatorCommon;
                    oRowDt[71] = material.name3;
                    oRowDt[72] = material.name4;
                    oRowDt[73] = material.searchTerm2;
                    oRowDt[74] = material.accountNumberAtVendor;
                    oRowDt[75] = material.customerNumber;
                    oRowDt[76] = material.companyIDTradingPartner;
                    oRowDt[77] = material.bankFeeCode;
                    oRowDt[78] = s.UtcDateTime;
                    oRowDt[79] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
