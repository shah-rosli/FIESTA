using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4NonProductionProductPlant
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("NONPRODUCTION_PRODUCT_PLANT");
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("storageLocation", typeof(string));
            dt.Columns.Add("legacyLine", typeof(string));
            dt.Columns.Add("inhouseProductionTime", typeof(decimal));
            dt.Columns.Add("profitCenter", typeof(string));
            dt.Columns.Add("materialType", typeof(string));
            dt.Columns.Add("planningYield", typeof(decimal));
            dt.Columns.Add("minimumLotSize", typeof(decimal));
            dt.Columns.Add("specialOriginalPartNumber", typeof(string));
            dt.Columns.Add("businessDivision", typeof(string));
            dt.Columns.Add("businessPlannerCode", typeof(string));
            dt.Columns.Add("factoryFlag", typeof(string));
            dt.Columns.Add("lotSizingProcedure", typeof(string));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("fileName", typeof(string));

            foreach (object o in records)
            {
                if (o != null)
                {
                    //2026-06-21: individual records will have current datetime stamp.
                    //fix datetime - all records in same batch will have same datetime.
                    //sample DT: 2023-01-01T00:00:00.000Z
                    string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    DateTimeOffset s = DateTimeOffset.Parse(now);

                    object[] oRowDt = new object[19];
                    CSV_S4_NONPRODUCTION_PRODUCT_PLANT material = (CSV_S4_NONPRODUCTION_PRODUCT_PLANT)o;
                    oRowDt[0] = material.partNumberKey;
                    oRowDt[1] = material.partNumber;
                    oRowDt[2] = material.plant;
                    oRowDt[3] = material.storageLocation;
                    oRowDt[4] = material.legacyLine;
                    oRowDt[5] = material.inhouseProductionTime;
                    oRowDt[6] = material.profitCenter;
                    oRowDt[7] = material.materialType;
                    oRowDt[8] = material.planningYield;
                    oRowDt[9] = material.minimumLotSize;
                    oRowDt[10] = material.specialOriginalPartNumber;
                    oRowDt[11] = material.businessDivision;
                    oRowDt[12] = material.businessPlannerCode;
                    oRowDt[13] = material.factoryFlag;
                    oRowDt[14] = material.lotSizingProcedure;
                    oRowDt[15] = material.updateType;
                    oRowDt[16] = material.updateDateAndTime;
                    oRowDt[17] = material.updateDateAndTime;
                    oRowDt[18] = filename;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
