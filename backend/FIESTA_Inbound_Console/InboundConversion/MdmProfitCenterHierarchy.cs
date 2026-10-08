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
    public class MdmProfitCenterHierarchy
    {
        public static List<MDM_PROFIT_CENTER_HIERARCHY> ConvertObjNotUsed(CpiInboundObj obj)
        {
            List<MDM_PROFIT_CENTER_HIERARCHY> list = new List<MDM_PROFIT_CENTER_HIERARCHY>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PROFIT_CENTER_HIERARCHY item = new MDM_PROFIT_CENTER_HIERARCHY();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.setName.content != null) item.setName = content.setName.content.ToString();
                if (content.lineID.content != null)
                {
                    int s;
                    if (int.TryParse(content.lineID.content.ToString(), out s))
                    {
                        item.lineID = s;
                    }
                }
                if (content.subSetName.content != null) item.subSetName = content.subSetName.content.ToString();
                if (content.description.content != null) item.description = content.description.content.ToString();
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
            DataTable dt = new DataTable("MDM_PROFIT_CENTER_HIERARCHY");
            dt.Columns.Add("setName", typeof(string));
            dt.Columns.Add("lineID", typeof(decimal));
            dt.Columns.Add("subSetName", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));

            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[6];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.setName.content != null) oRowDt[0] = content.setName.content.ToString();
                if (content.lineID.content != null)
                {
                    int s;
                    if (int.TryParse(content.lineID.content.ToString(), out s))
                    {
                        oRowDt[1] = s;
                    }
                }
                if (content.subSetName.content != null) oRowDt[2] = content.subSetName.content.ToString();
                if (content.description.content != null) oRowDt[3] = content.description.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[4] = 1;
                        else oRowDt[4] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[5] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"setName\",\"lineID\",\"subSetName\",\"description\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
