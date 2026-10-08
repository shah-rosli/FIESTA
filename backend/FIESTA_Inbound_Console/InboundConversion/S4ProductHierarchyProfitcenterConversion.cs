using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProductHierarchyProfitcenterConversion
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION");
            dt.Columns.Add("productHierarchyCode", typeof(string));
            dt.Columns.Add("profitCenterCode", typeof(string));
            dt.Columns.Add("profitCenter", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));
            dt.Columns.Add("fileName", typeof(string));

            foreach (object o in records)
            {
                if (o != null)
                {
                    //2026-06-21: individual records will have current datetime stamp.
                    //fix datetime - all records in same batch will have same datetime.
                    //sample DT: 2023-01-01T00:00:00.000Z
                    string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    DateTimeOffset s = DateTimeOffset.Parse(now);

                    object[] oRowDt = new object[6];
                    CSV_S4_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION material = (CSV_S4_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION)o;
                    oRowDt[0] = material.productHierarchyCode;
                    oRowDt[1] = material.profitCenterCode;
                    oRowDt[2] = material.profitCenter;
                    oRowDt[3] = material.deleteFlag;
                    oRowDt[4] = s.UtcDateTime;
                    oRowDt[5] = filename;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
