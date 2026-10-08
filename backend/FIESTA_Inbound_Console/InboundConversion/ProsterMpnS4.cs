using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterMpnS4
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_MPN_S4");
            dt.Columns.Add("WIP_PN", typeof(string));
            dt.Columns.Add("BIG_COST_CODE", typeof(string));
            dt.Columns.Add("PARENT_WIP_PN", typeof(string));
            dt.Columns.Add("PRD_CATEGORY1", typeof(string));
            dt.Columns.Add("PRD_CATEGORY2", typeof(string));
            dt.Columns.Add("PRD_CATEGORY3", typeof(string));
            dt.Columns.Add("PRD_CATEGORY4", typeof(string));
            dt.Columns.Add("PRD_CATEGORY5", typeof(string));
            dt.Columns.Add("PB_FREE", typeof(string));
            dt.Columns.Add("RENESAS_PACKAGE", typeof(string));
            dt.Columns.Add("RENESAS_KBN", typeof(string));
            dt.Columns.Add("CUSTOMER1", typeof(string));
            dt.Columns.Add("CUSTOMER2", typeof(string));
            dt.Columns.Add("CUSTOMER3", typeof(string));
            dt.Columns.Add("CUSTOMER4", typeof(string));
            dt.Columns.Add("CUSTOMER5", typeof(string));
            dt.Columns.Add("CUSTOMER6", typeof(string));
            dt.Columns.Add("CUSTOMER7", typeof(string));
            dt.Columns.Add("CUSTOMER8", typeof(string));
            dt.Columns.Add("CUSTOMER9", typeof(string));
            dt.Columns.Add("CUSTOMER10", typeof(string));
            dt.Columns.Add("NICKNAME", typeof(string));
            dt.Columns.Add("KEYAS4", typeof(string));
            dt.Columns.Add("WFCLASS", typeof(string));
            dt.Columns.Add("IWHCLASS", typeof(string));
            dt.Columns.Add("MAE_KYOTEN", typeof(string));
            dt.Columns.Add("ATO_KYOTEN", typeof(string));
            dt.Columns.Add("BASE_ROM_KBN", typeof(string));
            dt.Columns.Add("UEHKEI", typeof(string));
            dt.Columns.Add("PROCESS_NAME", typeof(string));
            dt.Columns.Add("PROCESS_NAME_OP", typeof(string));
            dt.Columns.Add("BOOKING_PN", typeof(string));
            dt.Columns.Add("SHUTOKU", typeof(decimal));
            dt.Columns.Add("REG_USER", typeof(string));
            dt.Columns.Add("REG_DATE", typeof(string));
            dt.Columns.Add("REG_TIME", typeof(string));
            dt.Columns.Add("UPD_USER", typeof(string));
            dt.Columns.Add("UPD_DATE", typeof(string));
            dt.Columns.Add("UPD_TIME", typeof(string));
            dt.Columns.Add("WIRE_TYPE", typeof(string));
            dt.Columns.Add("CHIP_VERSION", typeof(string));
            dt.Columns.Add("UPDATE_TYPE", typeof(string));
            dt.Columns.Add("DELETE_FLAG", typeof(string));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));

            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[44];
                    CSV_PRO_MPN_S4 mpn = (CSV_PRO_MPN_S4)o;
                    oRowDt[0] = mpn.WIP_PN;
                    oRowDt[1] = mpn.BIG_COST_CODE;
                    oRowDt[2] = mpn.PARENT_WIP_PN;
                    oRowDt[3] = mpn.PRD_CATEGORY1;
                    oRowDt[4] = mpn.PRD_CATEGORY2;
                    oRowDt[5] = mpn.PRD_CATEGORY3;
                    oRowDt[6] = mpn.PRD_CATEGORY4;
                    oRowDt[7] = mpn.PRD_CATEGORY5;
                    oRowDt[8] = mpn.PB_FREE;
                    oRowDt[9] = mpn.RENESAS_PACKAGE;
                    oRowDt[10] = mpn.RENESAS_KBN;
                    oRowDt[11] = mpn.CUSTOMER1;
                    oRowDt[12] = mpn.CUSTOMER2;
                    oRowDt[13] = mpn.CUSTOMER3;
                    oRowDt[14] = mpn.CUSTOMER4;
                    oRowDt[15] = mpn.CUSTOMER5;
                    oRowDt[16] = mpn.CUSTOMER6;
                    oRowDt[17] = mpn.CUSTOMER7;
                    oRowDt[18] = mpn.CUSTOMER8;
                    oRowDt[19] = mpn.CUSTOMER9;
                    oRowDt[20] = mpn.CUSTOMER10;
                    oRowDt[21] = mpn.NICKNAME;
                    oRowDt[22] = mpn.KEYAS4;
                    oRowDt[23] = mpn.WFCLASS;
                    oRowDt[24] = mpn.IWHCLASS;
                    oRowDt[25] = mpn.MAE_KYOTEN;
                    oRowDt[26] = mpn.ATO_KYOTEN;
                    oRowDt[27] = mpn.BASE_ROM_KBN;
                    oRowDt[28] = mpn.UEHKEI;
                    oRowDt[29] = mpn.PROCESS_NAME;
                    oRowDt[30] = mpn.PROCESS_NAME_OP;
                    oRowDt[31] = mpn.BOOKING_PN;
                    oRowDt[32] = mpn.SHUTOKU;
                    oRowDt[33] = mpn.REG_USER;
                    oRowDt[34] = mpn.REG_DATE;
                    oRowDt[35] = mpn.REG_TIME;
                    oRowDt[36] = mpn.UPD_USER;
                    oRowDt[37] = mpn.UPD_DATE;
                    oRowDt[38] = mpn.UPD_TIME;
                    oRowDt[39] = mpn.WIRE_TYPE;
                    oRowDt[40] = mpn.CHIP_VERSION;
                    oRowDt[41] = mpn.UPDATE_TYPE;
                    oRowDt[42] = mpn.DELETE_FLAG;
                    oRowDt[43] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
