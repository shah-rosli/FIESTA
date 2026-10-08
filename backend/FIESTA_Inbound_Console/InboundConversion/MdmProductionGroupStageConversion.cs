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
    public class MdmProductionGroupStageConversion
    {
        public static List<MDM_PRODUCTION_GROUP_STAGE_CONVERSION> ConvertObjNotUsed(CpiInboundObj obj)
        {
            List<MDM_PRODUCTION_GROUP_STAGE_CONVERSION> list = new List<MDM_PRODUCTION_GROUP_STAGE_CONVERSION>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PRODUCTION_GROUP_STAGE_CONVERSION item = new MDM_PRODUCTION_GROUP_STAGE_CONVERSION();

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
                if (content.legacyType.content != null) item.legacyType = content.legacyType.content.ToString();
                if (content.legacyGroupStage.content != null) item.legacyGroupStage = content.legacyGroupStage.content.ToString();
                if (content.groupStageVSLegacyGroupStageRecordID.content != null) item.groupStageVSLegacyGroupStageRecordID = content.groupStageVSLegacyGroupStageRecordID.content.ToString();
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
                        //item.recordActiveChange = s.UtcDateTime;
                    }
                }

                list.Add(item);
            }

            return list;
        }

        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_PRODUCTION_GROUP_STAGE_CONVERSION");
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("legacyType", typeof(string));
            dt.Columns.Add("legacyGroupStage", typeof(string));
            dt.Columns.Add("groupStageVSLegacyGroupStageRecordID", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));

            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[9];

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
                if (content.legacyType.content != null) oRowDt[1] = content.legacyType.content.ToString();
                if (content.legacyGroupStage.content != null) oRowDt[2] = content.legacyGroupStage.content.ToString();
                if (content.groupStageVSLegacyGroupStageRecordID.content != null) oRowDt[3] = content.groupStageVSLegacyGroupStageRecordID.content.ToString();
                if (content.activeFlag.content != null) oRowDt[4] = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[5] = s.UtcDateTime;
                    }
                }
                if (content.updateType.content != null) oRowDt[6] = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[7] = 1;
                        else oRowDt[7] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[8] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }
        public static string GetColumnNames()
        {
            return "\"groupStage\",\"legacyType\",\"legacyGroupStage\",\"groupStageVSLegacyGroupStageRecordID\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
