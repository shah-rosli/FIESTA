using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterVersion
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_VERSION");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("productionVersion", typeof(string));
            dt.Columns.Add("bomUsage", typeof(string));
            dt.Columns.Add("bomAlternative", typeof(string));
            dt.Columns.Add("routingKey", typeof(string));
            dt.Columns.Add("glmWF", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));

            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[13];
                    CSV_PRO_VERSION version = (CSV_PRO_VERSION)o;
                    oRowDt[0] = version.partNumber;
                    oRowDt[1] = version.plant;
                    oRowDt[2] = version.storageLocation;
                    oRowDt[3] = version.productionVersion;
                    oRowDt[4] = version.bomUsage;
                    oRowDt[5] = version.bomAlternative;
                    oRowDt[6] = version.routingKey;
                    oRowDt[7] = version.glmWF;
                    oRowDt[8] = version.createDateAndTime;
                    oRowDt[9] = version.updateDateAndTime;
                    oRowDt[10] = version.updateType;
                    oRowDt[11] = version.deleteFlag;
                    oRowDt[12] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
