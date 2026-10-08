using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProfitCenter
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PROFIT_CENTER");
            dt.Columns.Add("PRCTR", typeof(string));
            dt.Columns.Add("DATBI", typeof(DateTime));
            dt.Columns.Add("KHINR", typeof(string));
            dt.Columns.Add("KTEXT", typeof(string));
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

                    object[] oRowDt = new object[7];
                    CSV_S4_PROFIT_CENTER material = (CSV_S4_PROFIT_CENTER)o;
                    oRowDt[0] = material.PRCTR;
                    oRowDt[1] = material.DATBI;
                    oRowDt[2] = material.KHINR;
                    oRowDt[3] = material.KTEXT;
                    oRowDt[4] = material.deleteFlag;
                    oRowDt[5] = s.UtcDateTime;
                    oRowDt[6] = filename;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
