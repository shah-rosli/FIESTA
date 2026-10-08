using FIESTA_Backend.EfModels;
using FIESTA_Inbound_Console.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class MdmProfitCenter
    {
        public static List<MDM_PROFIT_CENTER> ConvertObjNotUsed(CpiInboundObj obj)
        {
            List<MDM_PROFIT_CENTER> list = new List<MDM_PROFIT_CENTER>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PROFIT_CENTER item = new MDM_PROFIT_CENTER();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.PRCTR.content != null) item.PRCTR = content.PRCTR.content.ToString();
                if (content.DATBI.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.DATBI.content.ToString() + "Z", out s))
                    {
                        item.DATBI = s.UtcDateTime;
                    }
                }
                if (content.KHINR.content != null) item.KHINR = content.KHINR.content.ToString();
                if (content.KTEXT.content != null) item.KTEXT = content.KTEXT.content.ToString();
                if (content.deleteFlag.content != null) item.deleteFlag = content.deleteFlag.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        //if (s) item.isRecordActive = 1;
                        //else item.isRecordActive = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        //item.recordActiveChange = s.UtcDateTime;
                    }
                }

                list.Add(item);
            }

            return list;
        }

        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_PROFIT_CENTER");
            dt.Columns.Add("PRCTR", typeof(string));
            dt.Columns.Add("DATBI", typeof(DateTime));
            dt.Columns.Add("KHINR", typeof(string));
            dt.Columns.Add("KTEXT", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));


            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[7];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.PRCTR.content != null) oRowDt[0] = content.PRCTR.content.ToString();
                if (content.DATBI.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.DATBI.content.ToString() + "Z", out s))
                    {
                        oRowDt[1] = s.UtcDateTime;
                    }
                }
                if (content.KHINR.content != null) oRowDt[2] = content.KHINR.content.ToString();
                if (content.KTEXT.content != null) oRowDt[3] = content.KTEXT.content.ToString();
                if (content.deleteFlag.content != null) oRowDt[4] = content.deleteFlag.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[5] = 1;
                        else oRowDt[5] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[6] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"PRCTR\",\"DATBI\",\"KHINR\",\"KTEXT\",\"deleteFlag\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
