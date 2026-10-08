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
    public class MdmProductionStage
    {
        public static List<MDM_PRODUCTION_STAGE> ConvertObj(CpiInboundObj obj)
        {
            List<MDM_PRODUCTION_STAGE> list = new List<MDM_PRODUCTION_STAGE>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PRODUCTION_STAGE item = new MDM_PRODUCTION_STAGE();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.stage.content != null) item.stage = content.stage.content.ToString();
                if (content.stageName.content != null) item.stageName = content.stageName.content.ToString();
                if (content.stageRecordID.content != null) item.stageRecordID = content.stageRecordID.content.ToString();
                if (content.activeFlag.content != null) item.activeFlag = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        item.updateDateAndTime = s.UtcDateTime;
                    }
                }
                if (content.updateType.content != null) item.updateType = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) item.isRecordActive = 1;
                        else item.isRecordActive = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        item.isRecordActiveChangeDateAndTime = s.UtcDateTime;
                    }
                }

                list.Add(item);
            }

            return list;
        }
        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_PRODUCTION_STAGE");
            dt.Columns.Add("stage", typeof(string));
            dt.Columns.Add("stageName", typeof(string));
            dt.Columns.Add("stageRecordID", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));


            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[8];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.stage.content != null) oRowDt[0] = content.stage.content.ToString();
                if (content.stageName.content != null) oRowDt[1] = content.stageName.content.ToString();
                if (content.stageRecordID.content != null) oRowDt[2] = content.stageRecordID.content.ToString();
                if (content.activeFlag.content != null) oRowDt[3] = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[4] = s.UtcDateTime;
                    }
                }
                if (content.updateType.content != null) oRowDt[5] = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[6] = 1;
                        else oRowDt[6] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[7] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"stage\",\"stageName\",\"stageRecordID\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
