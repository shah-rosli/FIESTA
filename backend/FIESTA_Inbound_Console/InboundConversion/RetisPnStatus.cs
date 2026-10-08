using FIESTA_Backend.EfModels;
using FIESTA_Inbound_Console.Models.RETIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class RetisPnStatus
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("RET_PNSTATUS");
            dt.Columns.Add("BOOKING_PN", typeof(string));
            dt.Columns.Add("PN_STATUS", typeof(string));
            dt.Columns.Add("UPDATE_DATE", typeof(DateTime));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));

            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if(o != null)
                {
                    object[] oRowDt = new object[4];
                    CSV_RET_PNSTATUS pnStatus = (CSV_RET_PNSTATUS)o;
                    oRowDt[0] = pnStatus.BOOKING_PN;
                    oRowDt[1] = pnStatus.PN_STATUS;
                    oRowDt[2] = pnStatus.UPDATE_DATE;
                    oRowDt[3] = s.UtcDateTime;
                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
