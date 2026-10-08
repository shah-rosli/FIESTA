using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProfitCenterHierarchy
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PROFIT_CENTER_HIERARCHY");
            dt.Columns.Add("setName", typeof(string));
            dt.Columns.Add("lineID", typeof(decimal));
            dt.Columns.Add("subSetName", typeof(string));
            dt.Columns.Add("description", typeof(string));
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
                    CSV_S4_PROFIT_CENTER_HIERARCHY material = (CSV_S4_PROFIT_CENTER_HIERARCHY)o;
                    oRowDt[0] = material.setName;
                    oRowDt[1] = material.lineID;
                    oRowDt[2] = material.subSetName;
                    oRowDt[3] = material.description;
                    oRowDt[4] = s.UtcDateTime;
                    oRowDt[5] = filename;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
