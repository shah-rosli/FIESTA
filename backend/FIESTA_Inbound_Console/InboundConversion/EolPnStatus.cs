using FIESTA_Inbound_Console.Models.EOL;
using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class EolPnStatus
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("EOL_STATUS");
            dt.Columns.Add("BOOKING_PN", typeof(string));
            dt.Columns.Add("PN_STATUS", typeof(string));
            dt.Columns.Add("UPDATE_DATE", typeof(DateTime));
            dt.Columns.Add("EOL_NOTICED_DATE", typeof(DateTime));
            dt.Columns.Add("LTB_ORDER_DEADLINE_DATE", typeof(DateTime));
            dt.Columns.Add("UPDATE_ID", typeof(string));
            dt.Columns.Add("UPDATE_TYPE", typeof(string));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));


            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[8];
                    TXT_EOL_PNSTATUS eol = (TXT_EOL_PNSTATUS)o;
                    oRowDt[0] = eol.BOOKING_PN;
                    oRowDt[1] = eol.PN_STATUS;
                    oRowDt[2] = eol.UPDATE_DATE;
                    oRowDt[3] = eol.EOL_NOTICED_DATE;
                    oRowDt[4] = eol.LTB_ORDER_DEADLINE_DATE;
                    oRowDt[5] = eol.UPDATE_ID;
                    oRowDt[6] = eol.UPDATE_TYPE;
                    oRowDt[7] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
