using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterAltMixRatios
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_ALT_MIX_RATIOS");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("supplyPlant", typeof(string));
            dt.Columns.Add("supplyStorageLocation", typeof(string));
            dt.Columns.Add("flowAlternative", typeof(string));
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
                    object[] oRowDt = new object[11];
                    CSV_PRO_ALT_MIX_RATIOS alt = (CSV_PRO_ALT_MIX_RATIOS)o;
                    oRowDt[0] = alt.partNumber;
                    oRowDt[1] = alt.plant;
                    oRowDt[2] = alt.storageLocation;
                    oRowDt[3] = alt.supplyPlant;
                    oRowDt[4] = alt.supplyStorageLocation;
                    oRowDt[5] = alt.flowAlternative;
                    oRowDt[6] = alt.createDateAndTime;
                    oRowDt[7] = alt.updateDateAndTime;
                    oRowDt[8] = alt.updateType;
                    oRowDt[9] = alt.deleteFlag;
                    oRowDt[10] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
