using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProductCanFlags4
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PRODUCT_CAN_FLAGS4");
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("publishedLeadTimeInWeeks", typeof(string));
            dt.Columns.Add("isPartRegisterable", typeof(string));
            dt.Columns.Add("isPartSoleSource", typeof(string));
            dt.Columns.Add("canSample", typeof(string));
            dt.Columns.Add("canQuote", typeof(string));
            dt.Columns.Add("canContract", typeof(string));
            dt.Columns.Add("canOrder", typeof(string));
            dt.Columns.Add("canSearch", typeof(string));
            dt.Columns.Add("canDebit", typeof(string));
            dt.Columns.Add("canOpportunity", typeof(string));
            dt.Columns.Add("canRegister", typeof(string));
            dt.Columns.Add("canRotate", typeof(string));
            dt.Columns.Add("canForecast", typeof(string));
            dt.Columns.Add("canKit", typeof(string));
            dt.Columns.Add("isPartNotRecommendNewDesign", typeof(string));
            dt.Columns.Add("isPartNonCancelableNonReschedule", typeof(string));
            dt.Columns.Add("isPartPublish", typeof(string));
            dt.Columns.Add("canFlagMasterComments", typeof(string));
            dt.Columns.Add("autoApprThresholdFocusSales", typeof(string));
            dt.Columns.Add("autoApprThresholdNonFocusSales", typeof(string));
            dt.Columns.Add("autoApprThresholdFocusPL", typeof(string));
            dt.Columns.Add("autoApprThresholdNonFocusPL", typeof(string));
            dt.Columns.Add("sampleAutoApprQtyThreshold", typeof(string));
            dt.Columns.Add("sampleAutoApprTotalValThreshold", typeof(string));
            dt.Columns.Add("tacticalMarketingMgr", typeof(string));
            dt.Columns.Add("marketingMgr", typeof(string));
            dt.Columns.Add("applicationCode3Default", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));
            dt.Columns.Add("fileName", typeof(string));

            int dataRowCount = int.Parse(DateTime.UtcNow.ToString("yyyyfff"));
            foreach (object o in records)
            {
                if (o != null)
                {
                    //2026-06-21: individual records will have current datetime stamp.
                    //fix datetime - all records in same batch will have same datetime.
                    //sample DT: 2023-01-01T00:00:00.000Z
                    string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    DateTimeOffset s = DateTimeOffset.Parse(now);

                    object[] oRowDt = new object[31];
                    CSV_S4_PRODUCT_CAN_FLAGS4 material = (CSV_S4_PRODUCT_CAN_FLAGS4)o;
                    oRowDt[0] = material.partNumberKey;
                    oRowDt[1] = material.partNumber;
                    oRowDt[2] = material.publishedLeadTimeInWeeks;
                    oRowDt[3] = material.isPartRegisterable;
                    oRowDt[4] = material.isPartSoleSource;
                    oRowDt[5] = material.canSample;
                    oRowDt[6] = material.canQuote;
                    oRowDt[7] = material.canContract;
                    oRowDt[8] = material.canOrder;
                    oRowDt[9] = material.canSearch;
                    oRowDt[10] = material.canDebit;
                    oRowDt[11] = material.canOpportunity;
                    oRowDt[12] = material.canRegister;
                    oRowDt[13] = material.canRotate;
                    oRowDt[14] = material.canForecast;
                    oRowDt[15] = material.canKit;
                    oRowDt[16] = material.isPartNotRecommendNewDesign;
                    oRowDt[17] = material.isPartNonCancelableNonReschedule;
                    oRowDt[18] = material.isPartPublish;
                    oRowDt[19] = material.canFlagMasterComments;
                    oRowDt[20] = material.autoApprThresholdFocusSales;
                    oRowDt[21] = material.autoApprThresholdNonFocusSales;
                    oRowDt[22] = material.autoApprThresholdFocusPL;
                    oRowDt[23] = material.autoApprThresholdNonFocusPL;
                    oRowDt[24] = material.sampleAutoApprQtyThreshold;
                    oRowDt[25] = material.sampleAutoApprTotalValThreshold;
                    oRowDt[26] = material.tacticalMarketingMgr;
                    oRowDt[27] = material.marketingMgr;
                    oRowDt[28] = material.applicationCode3Default;
                    oRowDt[29] = s.UtcDateTime;
                    oRowDt[30] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
