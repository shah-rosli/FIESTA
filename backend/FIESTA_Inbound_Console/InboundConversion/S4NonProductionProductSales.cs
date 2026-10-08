using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4NonProductionProductSales
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("NONPRODUCTION_PRODUCT_SALES");
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("salesOrganization", typeof(string));
            dt.Columns.Add("distributionChannel", typeof(string));
            dt.Columns.Add("minimumOrderQuantity", typeof(decimal));
            dt.Columns.Add("frequencyOrderIncrement", typeof(decimal));
            dt.Columns.Add("standardPackingQuantity", typeof(decimal));
            dt.Columns.Add("defaultSalesOrderCreationPlant", typeof(string));
            dt.Columns.Add("materialType", typeof(string));
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

                    object[] oRowDt = new object[13];
                    CSV_S4_NONPRODUCTION_PRODUCT_SALES material = (CSV_S4_NONPRODUCTION_PRODUCT_SALES)o;
                    oRowDt[0] = material.partNumberKey;
                    oRowDt[1] = material.partNumber;
                    oRowDt[2] = material.salesOrganization;
                    oRowDt[3] = material.distributionChannel;
                    oRowDt[4] = material.minimumOrderQuantity;
                    oRowDt[5] = material.frequencyOrderIncrement;
                    oRowDt[6] = material.standardPackingQuantity;
                    oRowDt[7] = material.defaultSalesOrderCreationPlant;
                    oRowDt[8] = material.materialType;
                    oRowDt[9] = material.updateType;
                    oRowDt[10] = material.updateDateAndTime;
                    oRowDt[11] = material.updateDateAndTime;
                    oRowDt[12] = filename;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
