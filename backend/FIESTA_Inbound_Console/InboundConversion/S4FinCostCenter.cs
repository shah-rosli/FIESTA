using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4FinCostCenter
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("FIN_COST_CENTER");
            dt.Columns.Add("coArea", typeof(string));
            dt.Columns.Add("costCenter", typeof(string));
            dt.Columns.Add("paymentCardsValidTo", typeof(DateTime));
            dt.Columns.Add("effectiveDate", typeof(DateTime));
            dt.Columns.Add("lockIndicatorForActualPrimaryPostings", typeof(string));
            dt.Columns.Add("lockIndicatorForPlanPrimaryCosts", typeof(string));
            dt.Columns.Add("companyCode", typeof(string));
            dt.Columns.Add("businessArea", typeof(string));
            dt.Columns.Add("costCenterCategory", typeof(string));
            dt.Columns.Add("personResponsible", typeof(string));
            dt.Columns.Add("currency", typeof(string));
            dt.Columns.Add("profitCenter", typeof(string));
            dt.Columns.Add("createOn", typeof(DateTime));
            dt.Columns.Add("userName", typeof(string));
            dt.Columns.Add("lockIndicatorForActualSecondaryCosts", typeof(string));
            dt.Columns.Add("lockIndicatorForActualRevenuePostings", typeof(string));
            dt.Columns.Add("lockIndicatorForCommitmentUpdate", typeof(string));
            dt.Columns.Add("lockIndicatorForPlanSecondaryCosts", typeof(string));
            dt.Columns.Add("lockIndicatorForPlanningRevenues", typeof(string));
            dt.Columns.Add("indicatorForAllowedAllocationMethods", typeof(string));
            dt.Columns.Add("indicatorForRecordingConsumptionQuantities", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("profitCenterArea", typeof(string));
            dt.Columns.Add("completionFlag", typeof(string));
            dt.Columns.Add("objectNumber", typeof(string));
            dt.Columns.Add("functionalArea", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("costCenterShortText", typeof(string));
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
                    CSV_S4_FIN_COST_CENTER material = (CSV_S4_FIN_COST_CENTER)o;
                    oRowDt[0] = material.coArea;
                    oRowDt[1] = material.costCenter;
                    oRowDt[2] = material.paymentCardsValidTo;
                    oRowDt[3] = material.effectiveDate;
                    oRowDt[4] = material.lockIndicatorForActualPrimaryPostings;
                    oRowDt[5] = material.lockIndicatorForPlanPrimaryCosts;
                    oRowDt[6] = material.companyCode;
                    oRowDt[7] = material.businessArea;
                    oRowDt[8] = material.costCenterCategory;
                    oRowDt[9] = material.personResponsible;
                    oRowDt[10] = material.currency;
                    oRowDt[11] = material.profitCenter;
                    oRowDt[12] = material.createOn;
                    oRowDt[13] = material.userName;
                    oRowDt[14] = material.lockIndicatorForActualSecondaryCosts;
                    oRowDt[15] = material.lockIndicatorForActualRevenuePostings;
                    oRowDt[16] = material.lockIndicatorForCommitmentUpdate;
                    oRowDt[17] = material.lockIndicatorForPlanSecondaryCosts;
                    oRowDt[18] = material.lockIndicatorForPlanningRevenues;
                    oRowDt[19] = material.indicatorForAllowedAllocationMethods;
                    oRowDt[20] = material.indicatorForRecordingConsumptionQuantities;
                    oRowDt[21] = material.country;
                    oRowDt[22] = material.profitCenterArea;
                    oRowDt[23] = material.completionFlag;
                    oRowDt[24] = material.objectNumber;
                    oRowDt[25] = material.functionalArea;
                    oRowDt[26] = material.name;
                    oRowDt[27] = material.description;
                    oRowDt[28] = material.costCenterShortText;
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
