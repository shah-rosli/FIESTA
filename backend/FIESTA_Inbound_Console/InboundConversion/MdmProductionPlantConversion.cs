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
    public class MdmProductionPlantConversion
    {
        public static List<MDM_PRODUCTION_PLANT_CONVERSION> ConvertObjNotUsed(CpiInboundObj obj)
        {
            List<MDM_PRODUCTION_PLANT_CONVERSION> list = new List<MDM_PRODUCTION_PLANT_CONVERSION>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PRODUCTION_PLANT_CONVERSION item = new MDM_PRODUCTION_PLANT_CONVERSION();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.company.content != null) item.company = content.company.content.ToString();
                if (content.plant.content != null) item.plant = content.plant.content.ToString();
                if (content.storageLocation.content != null) item.storageLocation = content.storageLocation.content.ToString();
                if (content.legacyType.content != null) item.legacyType = content.legacyType.content.ToString();
                if (content.legacyLine.content != null) item.legacyLine = content.legacyLine.content.ToString();
                if (content.groupStage.content != null) item.groupStage = content.groupStage.content.ToString();
                if (content.massProductionFlag.content != null) item.massProductionFlag = content.massProductionFlag.content.ToString();
                if (content.plantAndSlocVsLegacyLineRecordID.content != null) item.plantAndSlocVsLegacyLineRecordID = content.plantAndSlocVsLegacyLineRecordID.content.ToString();
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
            DataTable dt = new DataTable("MDM_PRODUCTION_PLANT_CONVERSION");
            dt.Columns.Add("company", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("legacyType", typeof(string));
            dt.Columns.Add("legacyLine", typeof(string));
            dt.Columns.Add("groupStage", typeof(string));
            dt.Columns.Add("massProductionFlag", typeof(string));
            dt.Columns.Add("plantAndSlocVsLegacyLineRecordID", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));


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

                if (content.company.content != null) oRowDt[0] = content.company.content.ToString();
                if (content.plant.content != null) oRowDt[1] = content.plant.content.ToString();
                if (content.storageLocation.content != null) oRowDt[2] = content.storageLocation.content.ToString();
                if (content.legacyType.content != null) oRowDt[3] = content.legacyType.content.ToString();
                if (content.legacyLine.content != null) oRowDt[4] = content.legacyLine.content.ToString();
                if (content.groupStage.content != null) oRowDt[5] = content.groupStage.content.ToString();
                if (content.massProductionFlag.content != null) oRowDt[6] = content.massProductionFlag.content.ToString();
                if (content.plantAndSlocVsLegacyLineRecordID.content != null) oRowDt[7] = content.plantAndSlocVsLegacyLineRecordID.content.ToString();
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
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
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
            return "\"company\",\"plant\",\"storageLocation\",\"legacyType\",\"legacyLine\",\"groupStage\",\"massProductionFlag\",\"plantAndSlocVsLegacyLineRecordID\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
