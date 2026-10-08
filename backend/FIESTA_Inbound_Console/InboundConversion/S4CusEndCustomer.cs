using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4CusEndCustomer
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("CUS_END_CUSTOMER");
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("location", typeof(string));
            dt.Columns.Add("accountNumCustomerOID", typeof(string));
            dt.Columns.Add("customerType", typeof(string));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("legalName", typeof(string));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("geography", typeof(string));
            dt.Columns.Add("btAddress1", typeof(string));
            dt.Columns.Add("btAddress2", typeof(string));
            dt.Columns.Add("btAddress3", typeof(string));
            dt.Columns.Add("btAddress4", typeof(string));
            dt.Columns.Add("btAddress5", typeof(string));
            dt.Columns.Add("btCity", typeof(string));
            dt.Columns.Add("btState", typeof(string));
            dt.Columns.Add("btZip", typeof(string));
            dt.Columns.Add("btCountry", typeof(string));
            dt.Columns.Add("currencyName", typeof(string));
            dt.Columns.Add("customerLevel", typeof(string));
            dt.Columns.Add("parentCustomerAccount", typeof(string));
            dt.Columns.Add("parentCustomerName", typeof(string));
            dt.Columns.Add("parentCustomerLocation", typeof(string));
            dt.Columns.Add("focus", typeof(string));
            dt.Columns.Add("childId", typeof(string));
            dt.Columns.Add("isTyt", typeof(string));
            dt.Columns.Add("hiRelAllowed", typeof(string));
            dt.Columns.Add("webSite", typeof(string));
            dt.Columns.Add("soldToOrigin", typeof(string));
            dt.Columns.Add("sapChangePoint", typeof(string));
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

                    object[] oRowDt = new object[31];
                    CSV_S4_CUS_END_CUSTOMER material = (CSV_S4_CUS_END_CUSTOMER)o;
                    oRowDt[0] = material.name;
                    oRowDt[1] = material.location;
                    oRowDt[2] = material.accountNumCustomerOID;
                    oRowDt[3] = material.customerType;
                    oRowDt[4] = material.category;
                    oRowDt[5] = material.legalName;
                    oRowDt[6] = material.status;
                    oRowDt[7] = material.geography;
                    oRowDt[8] = material.btAddress1;
                    oRowDt[9] = material.btAddress2;
                    oRowDt[10] = material.btAddress3;
                    oRowDt[11] = material.btAddress4;
                    oRowDt[12] = material.btAddress5;
                    oRowDt[13] = material.btCity;
                    oRowDt[14] = material.btState;
                    oRowDt[15] = material.btZip;
                    oRowDt[16] = material.btCountry;
                    oRowDt[17] = material.currencyName;
                    oRowDt[18] = material.customerLevel;
                    oRowDt[19] = material.parentCustomerAccount;
                    oRowDt[20] = material.parentCustomerName;
                    oRowDt[21] = material.parentCustomerLocation;
                    oRowDt[22] = material.focus;
                    oRowDt[23] = material.childId;
                    oRowDt[24] = material.isTyt;
                    oRowDt[25] = material.hiRelAllowed;
                    oRowDt[26] = material.webSite;
                    oRowDt[27] = material.soldToOrigin;
                    oRowDt[28] = material.sapChangePoint;
                    oRowDt[29] = s.UtcDateTime;
                    oRowDt[30] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
