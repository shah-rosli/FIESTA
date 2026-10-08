using FIESTA_Inbound_Console.Models.PROSTER;
using FIESTA_Inbound_Console.Models.RETIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterYieldMinits
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_YIELD_MINITS");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("stage", typeof(string));
            dt.Columns.Add("validFromDate", typeof(DateTime));
            dt.Columns.Add("yield", typeof(decimal));
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
                    CSV_PRO_YIELD_MINITS yield = (CSV_PRO_YIELD_MINITS)o;
                    oRowDt[0] = yield.partNumber;
                    oRowDt[1] = yield.plant;
                    oRowDt[2] = yield.storageLocation;
                    oRowDt[3] = yield.groupStage;
                    oRowDt[4] = yield.stage;
                    oRowDt[5] = yield.validFromDate;
                    oRowDt[6] = yield.yield;
                    oRowDt[7] = yield.aopFlag;
                    oRowDt[8] = yield.createDateAndTime;
                    oRowDt[9] = yield.updateDateAndTime;
                    oRowDt[10] = yield.updateType;
                    oRowDt[11] = yield.deleteFlag;
                    oRowDt[12] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
