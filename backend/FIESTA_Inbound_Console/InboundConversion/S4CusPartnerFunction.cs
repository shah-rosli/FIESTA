using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4CusPartnerFunction
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("CUS_PARTNER_FUNCTION");
            dt.Columns.Add("customerNumber", typeof(string));
            dt.Columns.Add("salesOrganization", typeof(string));
            dt.Columns.Add("distributionChannel", typeof(string));
            dt.Columns.Add("division", typeof(string));
            dt.Columns.Add("partnerFunction", typeof(string));
            dt.Columns.Add("partnerCounter", typeof(string));
            dt.Columns.Add("businessPartnerNumber", typeof(string));
            dt.Columns.Add("defaultPartner", typeof(string));
            dt.Columns.Add("effectiveDate", typeof(string));
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

                    object[] oRowDt = new object[11];
                    CSV_S4_CUS_PARTNER_FUNCTION material = (CSV_S4_CUS_PARTNER_FUNCTION)o;
                    oRowDt[0] = material.customerNumber;
                    oRowDt[1] = material.salesOrganization;
                    oRowDt[2] = material.distributionChannel;
                    oRowDt[3] = material.division;
                    oRowDt[4] = material.partnerFunction;
                    oRowDt[5] = material.partnerCounter;
                    oRowDt[6] = material.businessPartnerNumber;
                    oRowDt[7] = material.defaultPartner;
                    oRowDt[8] = material.effectiveDate;
                    oRowDt[9] = s.UtcDateTime;
                    oRowDt[10] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
