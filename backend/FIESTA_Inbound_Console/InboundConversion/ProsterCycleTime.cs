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
    public class ProsterCycleTime
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_CYCLE_TIME");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("stage", typeof(string));
            dt.Columns.Add("validFromDate", typeof(DateTime));
            dt.Columns.Add("unitOfTime", typeof(string));
            dt.Columns.Add("quantityUnitOfTime", typeof(decimal));
            dt.Columns.Add("classification", typeof(string));
            dt.Columns.Add("cycleTime", typeof(decimal));
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
                    object[] oRowDt = new object[15];
                    CSV_PRO_CYCLE_TIME cycleTime = (CSV_PRO_CYCLE_TIME)o;
                    oRowDt[0] = cycleTime.partNumber;
                    oRowDt[1] = cycleTime.plant;
                    oRowDt[2] = cycleTime.storageLocation;
                    oRowDt[3] = cycleTime.groupStage;
                    oRowDt[4] = cycleTime.stage;
                    oRowDt[5] = cycleTime.validFromDate;
                    oRowDt[6] = cycleTime.unitOfTime;
                    oRowDt[7] = cycleTime.quantityUnitOfTime;
                    oRowDt[8] = cycleTime.classification;
                    oRowDt[9] = cycleTime.cycleTime;
                    oRowDt[10] = cycleTime.createDateAndTime;
                    oRowDt[11] = cycleTime.updateDateAndTime;
                    oRowDt[12] = cycleTime.updateType;
                    oRowDt[13] = cycleTime.deleteFlag;
                    oRowDt[14] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
