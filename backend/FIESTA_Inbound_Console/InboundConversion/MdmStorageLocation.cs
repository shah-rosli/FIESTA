using FIESTA_Inbound_Console.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class MdmStorageLocation
    {
        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_STORAGE_LOCATION");
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("descrOfStorageLoc", typeof(string));
            dt.Columns.Add("division", typeof(string));
            dt.Columns.Add("negStocksInSLoc", typeof(string));
            dt.Columns.Add("freezeBookInvSLoc", typeof(string));
            dt.Columns.Add("sLocMRPIndicator", typeof(string));
            dt.Columns.Add("authorizationCheck", typeof(string));
            dt.Columns.Add("storageResource", typeof(string));
            dt.Columns.Add("huReqmnt", typeof(string));
            dt.Columns.Add("partnerStorLoc", typeof(string));
            dt.Columns.Add("salesOrganization", typeof(string));
            dt.Columns.Add("distributionChannel", typeof(string));
            dt.Columns.Add("shippingPointReceivingPt", typeof(string));
            dt.Columns.Add("supplier", typeof(string));
            dt.Columns.Add("customer", typeof(string));
            dt.Columns.Add("businessSystemOfMES", typeof(string));
            dt.Columns.Add("inventoryManagementType", typeof(string));
            dt.Columns.Add("validity", typeof(string));
            dt.Columns.Add("licenseNumber", typeof(string));
            dt.Columns.Add("inTransitAssignment", typeof(string));
            dt.Columns.Add("tankAssgn", typeof(string));
            dt.Columns.Add("storageLocationType", typeof(string));
            dt.Columns.Add("countryCode", typeof(string));
            dt.Columns.Add("resion", typeof(string));
            dt.Columns.Add("timeZone", typeof(string));
            dt.Columns.Add("glmPlantCode", typeof(string));
            dt.Columns.Add("activeFlag", typeof(string));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("isRecordActive", typeof(decimal));
            dt.Columns.Add("recordActiveChange", typeof(DateTime));


            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[32];

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
                if (content.storageLocation.content != null) oRowDt[1] = content.storageLocation.content.ToString();
                if (content.descrOfStorageLoc.content != null) oRowDt[2] = content.descrOfStorageLoc.content.ToString();
                if (content.division.content != null) oRowDt[3] = content.division.content.ToString();
                if (content.negStocksInSLoc.content != null) oRowDt[4] = content.negStocksInSLoc.content.ToString();
                if (content.freezeBookInvSLoc.content != null) oRowDt[5] = content.freezeBookInvSLoc.content.ToString();
                if (content.sLocMRPIndicator.content != null) oRowDt[6] = content.sLocMRPIndicator.content.ToString();
                if (content.authorizationCheck.content != null) oRowDt[7] = content.authorizationCheck.content.ToString();
                if (content.storageResource.content != null) oRowDt[8] = content.storageResource.content.ToString();
                if (content.huReqmnt.content != null) oRowDt[9] = content.huReqmnt.content.ToString();
                if (content.partnerStorLoc.content != null) oRowDt[10] = content.partnerStorLoc.content.ToString();
                if (content.salesOrganization.content != null) oRowDt[11] = content.salesOrganization.content.ToString();
                if (content.distributionChannel.content != null) oRowDt[12] = content.distributionChannel.content.ToString();
                if (content.shippingPointReceivingPt.content != null) oRowDt[13] = content.shippingPointReceivingPt.content.ToString();
                if (content.supplier.content != null) oRowDt[14] = content.supplier.content.ToString();
                if (content.customer.content != null) oRowDt[15] = content.customer.content.ToString();
                if (content.businessSystemOfMES.content != null) oRowDt[16] = content.businessSystemOfMES.content.ToString();
                if (content.inventoryManagementType.content != null) oRowDt[17] = content.inventoryManagementType.content.ToString();
                if (content.validity.content != null) oRowDt[18] = content.validity.content.ToString();
                if (content.licenseNumber.content != null) oRowDt[19] = content.licenseNumber.content.ToString();
                if (content.inTransitAssignment.content != null) oRowDt[20] = content.inTransitAssignment.content.ToString();
                if (content.tankAssgn.content != null) oRowDt[21] = content.tankAssgn.content.ToString();
                if (content.storageLocationType.content != null) oRowDt[22] = content.storageLocationType.content.ToString();
                if (content.countryCode.content != null) oRowDt[23] = content.countryCode.content.ToString();
                if (content.resion.content != null) oRowDt[24] = content.resion.content.ToString();
                if (content.timeZone.content != null) oRowDt[25] = content.timeZone.content.ToString();
                if (content.glmPlantCode.content != null) oRowDt[26] = content.glmPlantCode.content.ToString();if (content.activeFlag.content != null) oRowDt[27] = content.activeFlag.content.ToString();
                if (content.updateDateAndTime.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.updateDateAndTime.content.ToString() + "Z", out s))
                    {
                        oRowDt[28] = s.UtcDateTime;
                    }
                }

                if (content.updateType.content != null) oRowDt[29] = content.updateType.content.ToString();
                if (content.isRecordActive.content != null)
                {
                    bool s;
                    if (bool.TryParse(content.isRecordActive.content.ToString(), out s))
                    {
                        if (s) oRowDt[30] = 1;
                        else oRowDt[30] = 0;
                    }
                }
                if (content.recordActiveChange.content != null)
                {
                    DateTimeOffset s;
                    if (DateTimeOffset.TryParse(content.recordActiveChange.content.ToString() + "Z", out s))
                    {
                        oRowDt[31] = s.UtcDateTime;
                    }
                }

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"plant\",\"storageLocation\",\"descrOfStorageLoc\",\"division\",\"negStocksInSLoc\",\"freezeBookInvSLoc\",\"sLocMRPIndicator\",\"authorizationCheck\",\"storageResource\",\"huReqmnt\",\"partnerStorLoc\",\"salesOrganization\",\"distributionChannel\",\"shippingPointReceivingPt\",\"supplier\",\"customer\",\"businessSystemOfMES\",\"inventoryManagementType\",\"validity\",\"licenseNumber\",\"inTransitAssignment\",\"tankAssgn\",\"storageLocationType\",\"countryCode\",\"resion\",\"timeZone\",\"glmPlantCode\",\"activeFlag\",\"updateDateAndTime\",\"updateType\",\"isRecordActive\",\"recordActiveChange\"";
        }
    }
}
