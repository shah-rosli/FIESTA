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
    public class MdmProductionGroupStage
    {
        public static List<MDM_PRODUCTION_GROUP_STAGE> ConvertObjNotUsed(CpiInboundObj obj)
        {
            List<MDM_PRODUCTION_GROUP_STAGE> list = new List<MDM_PRODUCTION_GROUP_STAGE>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PRODUCTION_GROUP_STAGE item = new MDM_PRODUCTION_GROUP_STAGE();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.groupStage.content != null) item.groupStage = content.groupStage.content.ToString();
                if (content.groupStageSequence.content != null)
                {
                    int s;
                    if(int.TryParse(content.groupStageSequence.content.ToString(),out s))
                    {
                        item.groupStageSequence = s;
                    }
                }
                if (content.groupStageName.content != null) item.groupStageName = content.groupStageName.content.ToString();
                if (content.groupStageType.content != null) item.groupStageType = content.groupStageType.content.ToString();
                if (content.groupStageExplanation.content != null) item.groupStageExplanation = content.groupStageExplanation.content.ToString();
                if (content.inputUoM.content != null) item.inputUoM = content.inputUoM.content.ToString();
                if (content.outputUoM.content != null) item.outputUoM = content.outputUoM.content.ToString();
                if (content.groupStageRecordID.content != null) item.groupStageRecordID = content.groupStageRecordID.content.ToString();
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
                        //if (s) item.isRecordActive = 1;
                        //else item.isRecordActive = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        //item.isRecordActiveChangeDateAndTime = s.UtcDateTime;
                    }
                }

                list.Add(item);
            }

            return list;
        }

        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_PRODUCTION_GROUP_STAGE");
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("groupStageSequence", typeof(decimal));
            dt.Columns.Add("groupStageName", typeof(string));
            dt.Columns.Add("groupStageType", typeof(string));
            dt.Columns.Add("groupStageExplanation", typeof(string));
            dt.Columns.Add("inputUoM", typeof(string));
            dt.Columns.Add("outputUoM", typeof(string));
            dt.Columns.Add("groupStageRecordID", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("isRecordActiveChangeDateAndTime", typeof(string));

            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[13];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.groupStage.content != null) oRowDt[0] = content.groupStage.content.ToString();
                if (content.groupStageSequence.content != null)
                {
                    int s;
                    if (int.TryParse(content.groupStageSequence.content.ToString(), out s))
                    {
                        oRowDt[1] = s;
                    }
                }
                if (content.groupStageName.content != null) oRowDt[2] = content.groupStageName.content.ToString();
                if (content.groupStageType.content != null) oRowDt[3] = content.groupStageType.content.ToString();
                if (content.groupStageExplanation.content != null) oRowDt[4] = content.groupStageExplanation.content.ToString();
                if (content.inputUoM.content != null) oRowDt[5] = content.inputUoM.content.ToString();
                if (content.outputUoM.content != null) oRowDt[6] = content.outputUoM.content.ToString();
                if (content.groupStageRecordID.content != null) oRowDt[7] = content.groupStageRecordID.content.ToString();
                if (content.activeFlag.content != null) oRowDt[8] = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[9] = s.UtcDateTime;
                    }
                }
                if (content.updateType.content != null) oRowDt[10] = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[11] = 1;
                        else oRowDt[11] = 0;
                    }
                }
                if (content.isRecordActiveChangeDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.isRecordActiveChangeDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[12] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"groupStage\",\"groupStageSequence\",\"groupStageName\",\"groupStageType\",\"groupStageExplanation\",\"inputUoM\",\"outputUoM\",\"groupStageRecordID\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"isRecordActiveChangeDateAndTime\"";
        }
    }
}
