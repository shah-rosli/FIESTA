using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProductHierarchy
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PRODUCT_HIERARCHY");
            dt.Columns.Add("phCode", typeof(string));
            dt.Columns.Add("level", typeof(string));
            dt.Columns.Add("phDescription", typeof(string));
            dt.Columns.Add("upperKey", typeof(string));
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
                    CSV_S4_PRODUCT_HIERARCHY material = (CSV_S4_PRODUCT_HIERARCHY)o;
                    oRowDt[0] = material.phCode;
                    oRowDt[1] = material.level;
                    oRowDt[2] = material.phDescription;
                    oRowDt[3] = material.upperKey;
                    oRowDt[4] = s.UtcDateTime;
                    oRowDt[5] = filename;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
