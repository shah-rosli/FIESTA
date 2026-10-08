using FIESTA_Inbound_Console.Models.PRIDES;
using FIESTA_Inbound_Console.Models.RETIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class PridesOpn
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRI_OPN");
            dt.Columns.Add("BOOKING_PN", typeof(string));
            dt.Columns.Add("SYS_STATUS", typeof(decimal));
            dt.Columns.Add("RENESAS_PN", typeof(string));
            dt.Columns.Add("BOOKING_PN_BASE", typeof(string));
            dt.Columns.Add("PRODUCT_KBN", typeof(string));
            dt.Columns.Add("ITEM_CD", typeof(string));
            dt.Columns.Add("TS_FLAG", typeof(string));
            dt.Columns.Add("EXPIRY_DATE_PRINTING_FLAG", typeof(string));
            dt.Columns.Add("SEAL_DATE_PRINTING_FLAG", typeof(string));
            dt.Columns.Add("HALOGEN_FREE_PRINTING_FLAG", typeof(string));
            dt.Columns.Add("PB_FREE", typeof(string));
            dt.Columns.Add("PB_FREE_DETAIL_SPEC_RANK", typeof(string));
            dt.Columns.Add("ROHS_EXEMPT_PRINTING_FLAG", typeof(string));
            dt.Columns.Add("REACH_PRINTING_FLAG", typeof(string));
            dt.Columns.Add("REFLOW_PEAK_TEMPERATURE", typeof(string));
            dt.Columns.Add("BASE_KBN", typeof(string));
            dt.Columns.Add("PROCESS_KBN", typeof(string));
            dt.Columns.Add("COMPONENT_WEIGHT", typeof(decimal));
            dt.Columns.Add("STORAGE_PERIOD_OF_STOCKS", typeof(string));
            dt.Columns.Add("IC_DISC_KBN", typeof(string));
            dt.Columns.Add("MSL", typeof(string));
            dt.Columns.Add("REL_RENESAS_PROSESS_NAME", typeof(string));
            dt.Columns.Add("R_PACKAGE_CODE", typeof(string));
            dt.Columns.Add("PACKAGE_TYPE", typeof(string));
            dt.Columns.Add("REMARKS", typeof(string));
            dt.Columns.Add("REG_USER", typeof(string));
            dt.Columns.Add("REG_DATE", typeof(DateTime));
            dt.Columns.Add("UPD_USER", typeof(string));
            dt.Columns.Add("UPD_DATE", typeof(DateTime));
            dt.Columns.Add("ORIGIN_KBN", typeof(string));
            dt.Columns.Add("MODEL_GROUP_CD", typeof(string));
            dt.Columns.Add("PRODUCT_CATEGORY_CD", typeof(string));
            dt.Columns.Add("QUALITY_LEVEL", typeof(string));
            dt.Columns.Add("PN_CODE_NAME", typeof(string));
            dt.Columns.Add("PACKING_TYPE", typeof(string));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));


            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[36];
                    DAT_PRI_OPN opn = (DAT_PRI_OPN)o;
                    oRowDt[0] = opn.BOOKING_PN;
                    oRowDt[1] = opn.SYS_STATUS;
                    oRowDt[2] = opn.RENESAS_PN;
                    oRowDt[3] = opn.BOOKING_PN_BASE;
                    oRowDt[4] = opn.PRODUCT_KBN;
                    oRowDt[5] = opn.ITEM_CD;
                    oRowDt[6] = opn.TS_FLAG;
                    oRowDt[7] = opn.EXPIRY_DATE_PRINTING_FLAG;
                    oRowDt[8] = opn.SEAL_DATE_PRINTING_FLAG;
                    oRowDt[9] = opn.HALOGEN_FREE_PRINTING_FLAG;
                    oRowDt[10] = opn.PB_FREE;
                    oRowDt[11] = opn.PB_FREE_DETAIL_SPEC_RANK;
                    oRowDt[12] = opn.ROHS_EXEMPT_PRINTING_FLAG;
                    oRowDt[13] = opn.REACH_PRINTING_FLAG;
                    oRowDt[14] = opn.REFLOW_PEAK_TEMPERATURE;
                    oRowDt[15] = opn.BASE_KBN;
                    oRowDt[16] = opn.PROCESS_KBN;
                    oRowDt[17] = opn.COMPONENT_WEIGHT;
                    oRowDt[18] = opn.STORAGE_PERIOD_OF_STOCKS;
                    oRowDt[19] = opn.IC_DISC_KBN;
                    oRowDt[20] = opn.MSL;
                    oRowDt[21] = opn.REL_RENESAS_PROSESS_NAME;
                    oRowDt[22] = opn.R_PACKAGE_CODE;
                    oRowDt[23] = opn.PACKAGE_TYPE;
                    oRowDt[24] = opn.REMARKS;
                    oRowDt[25] = opn.REG_USER;
                    oRowDt[26] = opn.REG_DATE;
                    oRowDt[27] = opn.UPD_USER;
                    oRowDt[28] = opn.UPD_DATE;
                    oRowDt[29] = opn.ORIGIN_KBN;
                    oRowDt[30] = opn.MODEL_GROUP_CD;
                    oRowDt[31] = opn.PRODUCT_CATEGORY_CD;
                    oRowDt[32] = opn.QUALITY_LEVEL;
                    oRowDt[33] = opn.PN_CODE_NAME;
                    oRowDt[34] = opn.PACKING_TYPE;
                    oRowDt[35] = s.UtcDateTime;
                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
