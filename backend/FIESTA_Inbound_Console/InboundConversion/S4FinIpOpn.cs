using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4FinIpOpn
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("FIN_IP_OPN");
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("ipLicenseCode", typeof(string));
            dt.Columns.Add("ipVendorName", typeof(string));
            dt.Columns.Add("techName", typeof(string));
            dt.Columns.Add("productHierarchyCode", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
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

                    object[] oRowDt = new object[9];
                    CSV_S4_FIN_IP_OPN material = (CSV_S4_FIN_IP_OPN)o;
                    oRowDt[0] = material.partNumberKey;
                    oRowDt[1] = material.partNumber;
                    oRowDt[2] = material.ipLicenseCode;
                    oRowDt[3] = material.ipVendorName;
                    oRowDt[4] = material.techName;
                    oRowDt[5] = material.productHierarchyCode;
                    oRowDt[6] = material.deleteFlag;
                    oRowDt[7] = s.UtcDateTime;
                    oRowDt[8] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
