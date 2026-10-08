using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models.Admin;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using FIESTA_Backend.Models.Test;
using FIESTA_Backend.EfModels;
using FIESTA_Inbound_Console.Models;

namespace FIESTA_Inbound_Console.DataAccess.Inbound
{
    public class MdmInboundDALNotUsed
    {
        private readonly FiestaDbContext _context;

        public MdmInboundDALNotUsed(FiestaDbContext context)
        {
            _context = context;
        }
        public CpiInboundResult InsertUpdateProductionPlantConversion(List<MDM_PRODUCTION_PLANT_CONVERSION> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCTION_PLANT_CONVERSION";
            result.Status = "Completed";

            foreach (MDM_PRODUCTION_PLANT_CONVERSION item in list)
            {
                try
                {
                    MDM_PRODUCTION_PLANT_CONVERSION? p = _context
                    .MDM_PRODUCTION_PLANT_CONVERSIONs
                    .FirstOrDefault(x =>
                        x.company == item.company &&
                        x.plant == item.plant &&
                        x.storageLocation == item.storageLocation &&
                        x.legacyLine == item.legacyLine &&
                        x.legacyType == item.legacyType &&
                        x.groupStage == item.groupStage &&
                        x.massProductionFlag == item.massProductionFlag);
                    //update
                    if (p != null)
                    {
                        p.plantAndSlocVsLegacyLineRecordID = item.plantAndSlocVsLegacyLineRecordID;
                        p.activeFlag = item.activeFlag;
                        p.updateDateAndTime = item.updateDateAndTime;
                        p.updateType = item.updateType;
                        //p.isRecordActive = item.isRecordActive;
                        //p.recordActiveChange = item.recordActiveChange;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCTION_PLANT_CONVERSIONs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on company-plant["+ item.company +"-"+ item.plant +"] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on company-plant[" + item.company + "-" + item.plant + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProductionGroupStage(List<MDM_PRODUCTION_GROUP_STAGE> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCTION_GROUP_STAGE";
            result.Status = "Completed";

            foreach (MDM_PRODUCTION_GROUP_STAGE item in list)
            {
                try
                {
                    MDM_PRODUCTION_GROUP_STAGE? p = _context
                    .MDM_PRODUCTION_GROUP_STAGEs
                    .FirstOrDefault(x =>
                        x.groupStage == item.groupStage);
                    //update
                    if (p != null)
                    {
                        p.groupStageSequence = item.groupStageSequence;
                        p.groupStageName = item.groupStageName;
                        p.groupStageType = item.groupStageType;
                        p.groupStageExplanation = item.groupStageExplanation;
                        p.inputUoM = item.inputUoM;
                        p.outputUoM = item.outputUoM;
                        p.groupStageRecordID = item.groupStageRecordID;
                        p.activeFlag = item.activeFlag;
                        p.updateDateAndTime = item.updateDateAndTime;
                        p.updateType = item.updateType;
                        //p.isRecordActive = item.isRecordActive;
                        //p.isRecordActiveChangeDateAndTime = item.isRecordActiveChangeDateAndTime;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCTION_GROUP_STAGEs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on groupStage[" + item.groupStage + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on groupStage[" + item.groupStage + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProfitCenterHierarchy(List<MDM_PROFIT_CENTER_HIERARCHY> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PROFIT_CENTER_HIERARCHY";
            result.Status = "Completed";

            foreach (MDM_PROFIT_CENTER_HIERARCHY item in list)
            {
                try
                {
                    MDM_PROFIT_CENTER_HIERARCHY? p = _context
                    .MDM_PROFIT_CENTER_HIERARCHies
                    .FirstOrDefault(x =>
                        x.setName == item.setName &&
                        x.lineID == item.lineID);
                    //update
                    if (p != null)
                    {
                        p.subSetName = item.subSetName;
                        p.description = item.description;
                        //p.isRecordActive = item.isRecordActive;
                        //p.recordActiveChange = item.recordActiveChange;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PROFIT_CENTER_HIERARCHies
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on setName & lineID [" + item.setName + " | " + item.lineID  + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on setName & lineID [" + item.setName + " | " + item.lineID + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProfitCenter(List<MDM_PROFIT_CENTER> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PROFIT_CENTER";
            result.Status = "Completed";

            foreach (MDM_PROFIT_CENTER item in list)
            {
                try
                {
                    MDM_PROFIT_CENTER? p = _context
                    .MDM_PROFIT_CENTERs
                    .FirstOrDefault(x =>
                        x.PRCTR == item.PRCTR);
                    //update
                    if (p != null)
                    {
                        p.DATBI = item.DATBI;
                        p.KHINR = item.KHINR;
                        p.KTEXT = item.KTEXT;
                        p.deleteFlag = item.deleteFlag;
                        //p.isRecordActive = item.isRecordActive;
                        //p.recordActiveChange = item.recordActiveChange;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PROFIT_CENTERs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on PRCTR [" + item.PRCTR + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on PRCTR [" + item.PRCTR + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProductHierarchy(List<MDM_PRODUCT_HIERARCHY> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCT_HIERARCHY";
            result.Status = "Completed";

            foreach (MDM_PRODUCT_HIERARCHY item in list)
            {
                try
                {
                    MDM_PRODUCT_HIERARCHY? p = _context
                    .MDM_PRODUCT_HIERARCHies
                    .FirstOrDefault(x =>
                        x.phCode == item.phCode);
                    //update
                    if (p != null)
                    {
                        p.level = item.level;
                        p.phDescription = item.phDescription;
                        p.upperKey = item.upperKey;
                        //p.isRecordActive = item.isRecordActive;
                        //p.recordActiveChange = item.recordActiveChange;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCT_HIERARCHies
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on phCode [" + item.phCode + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on phCode [" + item.phCode + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProductHierarchyProfitcenterConversion(List<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION";
            result.Status = "Completed";

            foreach (MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION item in list)
            {
                try
                {
                    MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION? p = _context
                    .MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs
                    .FirstOrDefault(x =>
                        x.productHierarchyCode == item.productHierarchyCode);
                    //update
                    if (p != null)
                    {
                        p.profitCenterCode = item.profitCenterCode;
                        p.profitCenter = item.profitCenter;
                        p.deleteFlag = item.deleteFlag;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on productHierarchyCode [" + item.productHierarchyCode + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on productHierarchyCode [" + item.productHierarchyCode + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProductionStageConversion(List<MDM_PRODUCTION_STAGE_CONVERSION> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCTION_STAGE_CONVERSION";
            result.Status = "Completed";

            foreach (MDM_PRODUCTION_STAGE_CONVERSION item in list)
            {
                try
                {
                    MDM_PRODUCTION_STAGE_CONVERSION? p = _context
                    .MDM_PRODUCTION_STAGE_CONVERSIONs
                    .FirstOrDefault(x =>
                        x.stage == item.stage &&
                        x.legacyType == item.legacyType &&
                        x.legacyStage == item.legacyStage);
                    //update
                    if (p != null)
                    {
                        p.stageVSLegacyStageRecordID = item.stageVSLegacyStageRecordID;
                        p.activeFlag = item.activeFlag;
                        p.updateDateAndTime = item.updateDateAndTime;
                        p.updateType = item.updateType;
                        p.isRecordActive = item.isRecordActive;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCTION_STAGE_CONVERSIONs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on stage|legacyType|legacyStage [" + item.stage +"|"+item.legacyType+"|"+item.legacyStage + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on stage|legacyType|legacyStage [" + item.stage + "|" + item.legacyType + "|" + item.legacyStage + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProductionStage(List<MDM_PRODUCTION_STAGE> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCTION_STAGE";
            result.Status = "Completed";

            foreach (MDM_PRODUCTION_STAGE item in list)
            {
                try
                {
                    MDM_PRODUCTION_STAGE? p = _context
                    .MDM_PRODUCTION_STAGEs
                    .FirstOrDefault(x =>
                        x.stage == item.stage);
                    //update
                    if (p != null)
                    {
                        p.stageName = item.stageName;
                        p.stageRecordID = item.stageRecordID;
                        p.activeFlag = item.activeFlag;
                        p.updateDateAndTime = item.updateDateAndTime;
                        p.updateType = item.updateType;
                        p.isRecordActive = item.isRecordActive;
                        p.isRecordActiveChangeDateAndTime = item.isRecordActiveChangeDateAndTime;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCTION_STAGEs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on stage [" + item.stage + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on stage [" + item.stage + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }

        public CpiInboundResult InsertUpdateProductionGroupStageConversion(List<MDM_PRODUCTION_GROUP_STAGE_CONVERSION> list)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.TableName = "PRODUCTION_GROUP_STAGE_CONVERSION";
            result.Status = "Completed";

            foreach (MDM_PRODUCTION_GROUP_STAGE_CONVERSION item in list)
            {
                try
                {
                    MDM_PRODUCTION_GROUP_STAGE_CONVERSION? p = _context
                    .MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs
                    .FirstOrDefault(x =>
                        x.groupStage == item.groupStage &&
                        x.legacyType == item.legacyType &&
                        x.legacyGroupStage == item.legacyGroupStage);
                    //update
                    if (p != null)
                    {
                        p.groupStageVSLegacyGroupStageRecordID = item.groupStageVSLegacyGroupStageRecordID;
                        p.activeFlag = item.activeFlag;
                        p.updateDateAndTime = item.updateDateAndTime;
                        p.updateType = item.updateType;
                        //p.isRecordActive = item.isRecordActive;
                        //p.recordActiveChange = item.recordActiveChange;

                        result.RecordUpdated++;
                    }
                    //insert
                    else
                    {
                        _context
                        .MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs
                        .Add(item);

                        result.RecordInserted++;
                    }
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    result.RecordError++;
                    result.isError = true;
                    result.Status += "Error on groupStage|legacyType|legacyGroupStage [" + item.groupStage + "|" + item.legacyType + "|" + item.legacyGroupStage + "] : " + ex.InnerException?.Message + "\n";
                    Program.AppendError("Error on groupStage|legacyType|legacyGroupStage [" + item.groupStage + "|" + item.legacyType + "|" + item.legacyGroupStage + "] : " + ex.InnerException?.Message);
                }
            }

            return result;
        }
    }
}
