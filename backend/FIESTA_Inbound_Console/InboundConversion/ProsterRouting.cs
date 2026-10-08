using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterRouting
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_ROUTING");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("routingKey", typeof(string));
            dt.Columns.Add("operationNumber", typeof(string));
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("conversionFactor", typeof(decimal));
            dt.Columns.Add("unitOfMeasure", typeof(string));
            dt.Columns.Add("glmWF", typeof(string));
            dt.Columns.Add("glmSequence", typeof(string));
            dt.Columns.Add("glmAlternative", typeof(string));
            dt.Columns.Add("connectFromGLMSeq", typeof(string));
            dt.Columns.Add("connectFromGLMAlternative", typeof(string));
            dt.Columns.Add("glmStage", typeof(string));
            dt.Columns.Add("endOfGroupStage", typeof(string));
            dt.Columns.Add("mpnToOPNFlag", typeof(string));
            dt.Columns.Add("costCenter", typeof(string));
            dt.Columns.Add("originalPartNumber", typeof(string));
            dt.Columns.Add("hmeType", typeof(string));
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
                    object[] oRowDt = new object[24];
                    CSV_PRO_ROUTING routing = (CSV_PRO_ROUTING)o;
                    oRowDt[0] = routing.partNumber;
                    oRowDt[1] = routing.plant;
                    oRowDt[2] = routing.storageLocation;
                    oRowDt[3] = routing.routingKey;
                    oRowDt[4] = routing.operationNumber;
                    oRowDt[5] = routing.groupStage;
                    oRowDt[6] = routing.conversionFactor;
                    oRowDt[7] = routing.unitOfMeasure;
                    oRowDt[8] = routing.glmWF;
                    oRowDt[9] = routing.glmSequence;
                    oRowDt[10] = routing.glmAlternative;

                    oRowDt[11] = routing.glmStage;
                    oRowDt[12] = routing.connectFromGLMSeq;
                    oRowDt[13] = routing.connectFromGLMAlternative;
                    
                    oRowDt[14] = routing.endOfGroupStage;
                    oRowDt[15] = routing.mpnToOPNFlag;
                    oRowDt[16] = routing.costCenter;
                    oRowDt[17] = routing.originalPartNumber;
                    oRowDt[18] = routing.hmeType;
                    oRowDt[19] = routing.createDateAndTime;
                    oRowDt[20] = routing.updateDateAndTime;
                    oRowDt[21] = routing.updateType;
                    oRowDt[22] = routing.deleteFlag;
                    oRowDt[23] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
