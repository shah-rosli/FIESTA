using FIESTA_Inbound_Console.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class MdmPlants
    {
        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_PLANTS");
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("name1", typeof(string));
            dt.Columns.Add("valuationArea", typeof(string));
            dt.Columns.Add("customerNumberOfPlant", typeof(string));
            dt.Columns.Add("supplierNumberOfPlant", typeof(string));
            dt.Columns.Add("factoryCalendar", typeof(string));
            dt.Columns.Add("name2", typeof(string));
            dt.Columns.Add("streetAndHouseNumber", typeof(string));
            dt.Columns.Add("poBox", typeof(string));
            dt.Columns.Add("postalCode", typeof(string));
            dt.Columns.Add("city", typeof(string));
            dt.Columns.Add("purchOrganization", typeof(string));
            dt.Columns.Add("salesOrganization", typeof(string));
            dt.Columns.Add("batchStatusMgmt", typeof(string));
            dt.Columns.Add("condsAtPlantLevel", typeof(string));
            dt.Columns.Add("sourceList", typeof(string));
            dt.Columns.Add("reqmtsPlanning", typeof(string));
            dt.Columns.Add("countryRegionKey", typeof(string));
            dt.Columns.Add("region", typeof(string));
            dt.Columns.Add("countyCode", typeof(string));
            dt.Columns.Add("cityCode", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("planningPlant", typeof(string));
            dt.Columns.Add("taxJurisdiction", typeof(string));
            dt.Columns.Add("distribchannel", typeof(string));
            dt.Columns.Add("intCOBillingDiv", typeof(string));
            dt.Columns.Add("languageKey", typeof(string));
            dt.Columns.Add("sopPlant", typeof(string));
            dt.Columns.Add("varianceKey", typeof(string));
            dt.Columns.Add("batchStatusMgmtOld", typeof(string));
            dt.Columns.Add("plantCat", typeof(string));
            dt.Columns.Add("salesDistrict", typeof(string));
            dt.Columns.Add("supplyRegion", typeof(string));
            dt.Columns.Add("taxIndicatorPlant", typeof(string));
            dt.Columns.Add("regularSupplier", typeof(string));
            dt.Columns.Add("firstReminderExped", typeof(decimal));
            dt.Columns.Add("secondReminderExped", typeof(decimal));
            dt.Columns.Add("thirdReminderExped", typeof(decimal));
            dt.Columns.Add("text1stDunning", typeof(string));
            dt.Columns.Add("text2ndDunning", typeof(string));
            dt.Columns.Add("text3rdDunning", typeof(string));
            dt.Columns.Add("poTolerance", typeof(decimal));
            dt.Columns.Add("businessPlace", typeof(string));
            dt.Columns.Add("salesAreaDetrm", typeof(string));
            dt.Columns.Add("distribProfileOfPlant", typeof(string));
            dt.Columns.Add("archivingMarker", typeof(string));
            dt.Columns.Add("batchRecDMSType", typeof(string));
            dt.Columns.Add("nodeTypesupplyChain", typeof(string));
            dt.Columns.Add("namingStructure", typeof(string));
            dt.Columns.Add("costObjControlling", typeof(string));
            dt.Columns.Add("mixedCosting", typeof(string));
            dt.Columns.Add("actualCosting", typeof(string));
            dt.Columns.Add("shippingPointReceivingPt", typeof(string));
            dt.Columns.Add("actualActivitiesUpdated", typeof(string));
            dt.Columns.Add("controlOfCreditOfCostCenters", typeof(string));
            dt.Columns.Add("afSrceDetViaATP", typeof(string));
            dt.Columns.Add("batchManagementNotActiveByDefault", typeof(string));
            dt.Columns.Add("supplyAssignmentARun", typeof(string));
            dt.Columns.Add("seasonActiveInInventoryManagement", typeof(string));
            dt.Columns.Add("controlDataForBOM", typeof(string));
            dt.Columns.Add("activateVariantGrouping", typeof(string));
            dt.Columns.Add("assignBatchesInARun", typeof(string));
            dt.Columns.Add("exchangeValuation", typeof(string));
            dt.Columns.Add("vendorType", typeof(string));
            dt.Columns.Add("credIPI", typeof(string));
            dt.Columns.Add("storeCat", typeof(string));
            dt.Columns.Add("superiorDeptStore", typeof(string));
            dt.Columns.Add("ownership", typeof(string));
            dt.Columns.Add("company", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));



            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[74];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.plant.content != null) oRowDt[0] = content.plant.content.ToString();
                if (content.name1.content != null) oRowDt[1] = content.name1.content.ToString();
                if (content.valuationArea.content != null) oRowDt[2] = content.valuationArea.content.ToString();
                if (content.customerNumberOfPlant.content != null) oRowDt[3] = content.customerNumberOfPlant.content.ToString();
                if (content.supplierNumberOfPlant.content != null) oRowDt[4] = content.supplierNumberOfPlant.content.ToString();
                if (content.factoryCalendar.content != null) oRowDt[5] = content.factoryCalendar.content.ToString();
                if (content.name2.content != null) oRowDt[6] = content.name2.content.ToString();
                if (content.streetAndHouseNumber.content != null) oRowDt[7] = content.streetAndHouseNumber.content.ToString();
                if (content.poBox.content != null) oRowDt[8] = content.poBox.content.ToString();
                if (content.postalCode.content != null) oRowDt[9] = content.postalCode.content.ToString();
                if (content.city.content != null) oRowDt[10] = content.city.content.ToString();
                if (content.purchOrganization.content != null) oRowDt[11] = content.purchOrganization.content.ToString();
                if (content.salesOrganization.content != null) oRowDt[12] = content.salesOrganization.content.ToString();
                if (content.batchStatusMgmt.content != null) oRowDt[13] = content.batchStatusMgmt.content.ToString();
                if (content.condsAtPlantLevel.content != null) oRowDt[14] = content.condsAtPlantLevel.content.ToString();
                if (content.sourceList.content != null) oRowDt[15] = content.sourceList.content.ToString();
                if (content.reqmtsPlanning.content != null) oRowDt[16] = content.reqmtsPlanning.content.ToString();
                if (content.countryRegionKey.content != null) oRowDt[17] = content.countryRegionKey.content.ToString();
                if (content.region.content != null) oRowDt[18] = content.region.content.ToString();
                if (content.countyCode.content != null) oRowDt[19] = content.countyCode.content.ToString();
                if (content.cityCode.content != null) oRowDt[20] = content.cityCode.content.ToString();
                if (content.address.content != null) oRowDt[21] = content.address.content.ToString();
                if (content.planningPlant.content != null) oRowDt[22] = content.planningPlant.content.ToString();
                if (content.taxJurisdiction.content != null) oRowDt[23] = content.taxJurisdiction.content.ToString();
                if (content.distribchannel.content != null) oRowDt[24] = content.distribchannel.content.ToString();
                if (content.intCOBillingDiv.content != null) oRowDt[25] = content.intCOBillingDiv.content.ToString();
                if (content.languageKey.content != null) oRowDt[26] = content.languageKey.content.ToString();
                if (content.sopPlant.content != null) oRowDt[27] = content.sopPlant.content.ToString();
                if (content.varianceKey.content != null) oRowDt[28] = content.varianceKey.content.ToString();
                if (content.batchStatusMgmtOld.content != null) oRowDt[29] = content.batchStatusMgmtOld.content.ToString();
                if (content.plantCat.content != null) oRowDt[30] = content.plantCat.content.ToString();
                if (content.salesDistrict.content != null) oRowDt[31] = content.salesDistrict.content.ToString();
                if (content.supplyRegion.content != null) oRowDt[32] = content.supplyRegion.content.ToString();
                if (content.taxIndicatorPlant.content != null) oRowDt[33] = content.taxIndicatorPlant.content.ToString();
                if (content.regularSupplier.content != null) oRowDt[34] = content.regularSupplier.content.ToString();
                if (content.firstReminderExped.content != null)
                {
                    int s;
                    if (int.TryParse(content.firstReminderExped.content.ToString(), out s))
                    {
                        oRowDt[35] = s;
                    }
                }
                if (content.secondReminderExped.content != null)
                {
                    int s;
                    if (int.TryParse(content.secondReminderExped.content.ToString(), out s))
                    {
                        oRowDt[36] = s;
                    }
                }
                if (content.thirdReminderExped.content != null)
                {
                    int s;
                    if (int.TryParse(content.thirdReminderExped.content.ToString(), out s))
                    {
                        oRowDt[37] = s;
                    }
                }
                if (content.text1stDunning.content != null) oRowDt[38] = content.text1stDunning.content.ToString();
                if (content.text2ndDunning.content != null) oRowDt[39] = content.text2ndDunning.content.ToString();
                if (content.text3rdDunning.content != null) oRowDt[40] = content.text3rdDunning.content.ToString();
                if (content.poTolerance.content != null)
                {
                    int s;
                    if (int.TryParse(content.poTolerance.content.ToString(), out s))
                    {
                        oRowDt[41] = s;
                    }
                }
                if (content.businessPlace.content != null) oRowDt[42] = content.businessPlace.content.ToString();
                if (content.salesAreaDetrm.content != null) oRowDt[43] = content.salesAreaDetrm.content.ToString();
                if (content.distribProfileOfPlant.content != null) oRowDt[44] = content.distribProfileOfPlant.content.ToString();
                if (content.archivingMarker.content != null) oRowDt[45] = content.archivingMarker.content.ToString();
                if (content.batchRecDMSType.content != null) oRowDt[46] = content.batchRecDMSType.content.ToString();
                if (content.nodeTypesupplyChain.content != null) oRowDt[47] = content.nodeTypesupplyChain.content.ToString();
                if (content.namingStructure.content != null) oRowDt[48] = content.namingStructure.content.ToString();
                if (content.costObjControlling.content != null) oRowDt[49] = content.costObjControlling.content.ToString();
                if (content.mixedCosting.content != null) oRowDt[50] = content.mixedCosting.content.ToString();
                if (content.actualCosting.content != null) oRowDt[51] = content.actualCosting.content.ToString();
                if (content.shippingPointReceivingPt.content != null) oRowDt[52] = content.shippingPointReceivingPt.content.ToString();
                if (content.actualActivitiesUpdated.content != null) oRowDt[53] = content.actualActivitiesUpdated.content.ToString();
                if (content.controlOfCreditOfCostCenters.content != null) oRowDt[54] = content.controlOfCreditOfCostCenters.content.ToString();
                if (content.afSrceDetViaATP.content != null) oRowDt[55] = content.afSrceDetViaATP.content.ToString();
                if (content.batchManagementNotActiveByDefault.content != null) oRowDt[56] = content.batchManagementNotActiveByDefault.content.ToString();
                if (content.supplyAssignmentARun.content != null) oRowDt[57] = content.supplyAssignmentARun.content.ToString();
                if (content.seasonActiveInInventoryManagement.content != null) oRowDt[58] = content.seasonActiveInInventoryManagement.content.ToString();
                if (content.controlDataForBOM.content != null) oRowDt[59] = content.controlDataForBOM.content.ToString();
                if (content.activateVariantGrouping.content != null) oRowDt[60] = content.activateVariantGrouping.content.ToString();
                if (content.assignBatchesInARun.content != null) oRowDt[61] = content.assignBatchesInARun.content.ToString();
                if (content.exchangeValuation.content != null) oRowDt[62] = content.exchangeValuation.content.ToString();
                if (content.vendorType.content != null) oRowDt[63] = content.vendorType.content.ToString();
                if (content.credIPI.content != null) oRowDt[64] = content.credIPI.content.ToString();
                if (content.storeCat.content != null) oRowDt[65] = content.storeCat.content.ToString();
                if (content.superiorDeptStore.content != null) oRowDt[66] = content.superiorDeptStore.content.ToString();
                if (content.ownership.content != null) oRowDt[67] = content.ownership.content.ToString();
                if (content.company.content != null) oRowDt[68] = content.company.content.ToString();
                if (content.activeFlag.content != null) oRowDt[69] = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[70] = s.UtcDateTime;
                    }
                }

                if (content.updateType.content != null) oRowDt[71] = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[72] = 1;
                        else oRowDt[72] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[73] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"plant\",\"name1\",\"valuationArea\",\"customerNumberOfPlant\",\"supplierNumberOfPlant\",\"factoryCalendar\",\"name2\",\"streetAndHouseNumber\",\"poBox\",\"postalCode\",\"city\",\"purchOrganization\",\"salesOrganization\",\"batchStatusMgmt\",\"condsAtPlantLevel\",\"sourceList\",\"reqmtsPlanning\",\"countryRegionKey\",\"region\",\"countyCode\",\"cityCode\",\"address\",\"planningPlant\",\"taxJurisdiction\",\"distribchannel\",\"intCOBillingDiv\",\"languageKey\",\"sopPlant\",\"varianceKey\",\"batchStatusMgmtOld\",\"plantCat\",\"salesDistrict\",\"supplyRegion\",\"taxIndicatorPlant\",\"regularSupplier\",\"firstReminderExped\",\"secondReminderExped\",\"thirdReminderExped\",\"text1stDunning\",\"text2ndDunning\",\"text3rdDunning\",\"poTolerance\",\"businessPlace\",\"salesAreaDetrm\",\"distribProfileOfPlant\",\"archivingMarker\",\"batchRecDMSType\",\"nodeTypesupplyChain\",\"namingStructure\",\"costObjControlling\",\"mixedCosting\",\"actualCosting\",\"shippingPointReceivingPt\",\"actualActivitiesUpdated\",\"controlOfCreditOfCostCenters\",\"afSrceDetViaATP\",\"batchManagementNotActiveByDefault\",\"supplyAssignmentARun\",\"seasonActiveInInventoryManagement\",\"controlDataForBOM\",\"activateVariantGrouping\",\"assignBatchesInARun\",\"exchangeValuation\",\"vendorType\",\"credIPI\",\"storeCat\",\"superiorDeptStore\",\"ownership\",\"company\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
