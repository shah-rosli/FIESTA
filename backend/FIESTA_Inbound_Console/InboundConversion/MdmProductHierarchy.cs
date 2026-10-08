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
    public class MdmProductHierarchy
    {
        public static List<MDM_PRODUCT_HIERARCHY> ConvertObjNotUsed(CpiInboundObj obj)
        {
            List<MDM_PRODUCT_HIERARCHY> list = new List<MDM_PRODUCT_HIERARCHY>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PRODUCT_HIERARCHY item = new MDM_PRODUCT_HIERARCHY();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.phCode.content != null) item.phCode = content.phCode.content.ToString();
                if (content.level.content != null) item.level = content.level.content.ToString();
                if (content.phDescription.content != null) item.phDescription = content.phDescription.content.ToString();
                if (content.upperKey.content != null) item.upperKey = content.upperKey.content.ToString();
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
            DataTable dt = new DataTable("MDM_PRODUCT_HIERARCHY");
            dt.Columns.Add("phCode", typeof(string));
            dt.Columns.Add("level", typeof (string));
            dt.Columns.Add("phDescription", typeof(string));
            dt.Columns.Add("upperKey", typeof(string));
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

                if (content.phCode.content != null) oRowDt[0] = content.phCode.content.ToString();
                if (content.level.content != null) oRowDt[1] = content.level.content.ToString();
                if (content.phDescription.content != null) oRowDt[2] = content.phDescription.content.ToString();
                if (content.upperKey.content != null) oRowDt[3] = content.upperKey.content.ToString();
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
            return "\"phCode\",\"level\",\"phDescription\",\"upperKey\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
