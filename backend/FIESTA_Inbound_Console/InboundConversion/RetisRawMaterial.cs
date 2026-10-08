using FIESTA_Inbound_Console.Models.RETIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class RetisRawMaterial
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("RET_MATERIAL");
            dt.Columns.Add("PART_KND_CD", typeof(string));
            dt.Columns.Add("MTRAL_CODE", typeof(string));
            dt.Columns.Add("PARTS_NAME", typeof(string));
            dt.Columns.Add("CONSUMER_UNIT_CD", typeof(string));
            dt.Columns.Add("RPS_NO", typeof(string));
            dt.Columns.Add("DRW_STND_NUM", typeof(string));
            dt.Columns.Add("SEQ_NO", typeof(string));
            dt.Columns.Add("REGIST_DATE", typeof(string));
            dt.Columns.Add("REGIST_TIME", typeof(string));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));


            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[10];
                    CSV_RET_MATERIAL material = (CSV_RET_MATERIAL)o;
                    oRowDt[0] = material.PART_KND_CD;
                    oRowDt[1] = material.MTRAL_CODE;
                    oRowDt[2] = material.PARTS_NAME;
                    oRowDt[3] = material.CONSUMER_UNIT_CD;
                    oRowDt[4] = material.RPS_NO;
                    oRowDt[5] = material.DRW_STND_NUM;
                    oRowDt[6] = material.SEQ_NO;
                    oRowDt[7] = material.REGIST_DATE;
                    oRowDt[8] = material.REGIST_TIME;
                    oRowDt[9] = s.UtcDateTime;
                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
