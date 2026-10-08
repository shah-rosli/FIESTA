using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4FinIpCustomer
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("FIN_IP_CUSTOMER");
            dt.Columns.Add("ipLicenseNumber", typeof(string));
            dt.Columns.Add("customerCode", typeof(string));
            dt.Columns.Add("customerName", typeof(string));
            dt.Columns.Add("validityFromDate", typeof(DateTime));
            dt.Columns.Add("validityToDate", typeof(DateTime));
            dt.Columns.Add("createdOn", typeof(DateTime));
            dt.Columns.Add("createdBy", typeof(string));
            dt.Columns.Add("lastChangedOn", typeof(DateTime));
            dt.Columns.Add("lastChangedBy", typeof(string));
            dt.Columns.Add("status", typeof(string));
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

                    object[] oRowDt = new object[12];
                    CSV_S4_FIN_IP_CUSTOMER material = (CSV_S4_FIN_IP_CUSTOMER)o;
                    oRowDt[0] = material.ipLicenseNumber;
                    oRowDt[1] = material.customerCode;
                    oRowDt[2] = material.customerName;
                    oRowDt[3] = material.validityFromDate;
                    oRowDt[4] = material.validityToDate;
                    oRowDt[5] = material.createdOn;
                    oRowDt[6] = material.createdBy;
                    oRowDt[7] = material.lastChangedOn;
                    oRowDt[8] = material.lastChangedBy;
                    oRowDt[9] = material.status;
                    oRowDt[10] = s.UtcDateTime;
                    oRowDt[11] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
