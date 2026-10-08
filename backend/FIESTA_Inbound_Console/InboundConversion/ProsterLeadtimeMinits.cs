using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterLeadtimeMinits
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_LEADTIME_MINITS");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("stage", typeof(string));
            dt.Columns.Add("validFromDate", typeof(DateTime));
            dt.Columns.Add("leadTime", typeof(decimal));
            dt.Columns.Add("aopFlag", typeof(string));
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
                    CSV_PRO_LEADTIME_MINITS leadtime = (CSV_PRO_LEADTIME_MINITS)o;
                    oRowDt[0] = leadtime.partNumber;
                    oRowDt[1] = leadtime.plant;
                    oRowDt[2] = leadtime.storageLocation;
                    oRowDt[3] = leadtime.groupStage;
                    oRowDt[4] = leadtime.stage;
                    oRowDt[5] = leadtime.validFromDate;
                    oRowDt[6] = leadtime.leadTime;
                    oRowDt[7] = leadtime.aopFlag;
                    oRowDt[8] = leadtime.createDateAndTime;
                    oRowDt[9] = leadtime.updateDateAndTime;
                    oRowDt[10] = leadtime.updateType;
                    oRowDt[11] = leadtime.deleteFlag;
                    oRowDt[12] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
