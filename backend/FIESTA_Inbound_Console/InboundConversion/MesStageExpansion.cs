using FIESTA_Backend.EfModels;
using FIESTA_Inbound_Console.Models.EOL;
using FIESTA_Inbound_Console.Models.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class MesStageExpansion
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("MES_STAGE_EXPANSION");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("originalPartNumber", typeof(string));
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("mesLineName", typeof(string));
            dt.Columns.Add("mesRouting", typeof(string));
            dt.Columns.Add("mesStage", typeof(string));
            dt.Columns.Add("activityRateCode", typeof(string));
            dt.Columns.Add("mesRoutingSequence", typeof(string));
            dt.Columns.Add("mesStageSequence", typeof(decimal));
            dt.Columns.Add("cycleTime", typeof(decimal));
            dt.Columns.Add("yield", typeof(decimal));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));


            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[14];
                    TXT_MES_STAGE_EXPANSION mes = (TXT_MES_STAGE_EXPANSION)o;
                    oRowDt[0] = mes.S4MPN;
                    oRowDt[1] = mes.MANUFACTURING_PART_NR;
                    oRowDt[2] = mes.GROUP_STAGE_CD;
                    oRowDt[3] = "REA - Palm Bay";
                    oRowDt[4] = mes.ROUTE_CD;
                    oRowDt[5] = mes.STAGE;
                    oRowDt[6] = mes.ACTIVTY_RATE_CODE;
                    oRowDt[7] = mes.ROUTE_SEQ_NR;
                    oRowDt[8] = mes.STAGE_SEQ_NR;
                    oRowDt[9] = mes.CYCLE_TM.HasValue && mes.CYCLE_TM.Value > 0 ? (mes.CYCLE_TM.Value / 1000000000.0m) : 0;
                    oRowDt[10] = mes.PLAN_YLD_NR.HasValue && mes.PLAN_YLD_NR.Value > 0 ? (mes.PLAN_YLD_NR.Value / 1000.0m) : 0; 
                    oRowDt[11] = "N";
                    oRowDt[12] = "N";
                    oRowDt[13] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
