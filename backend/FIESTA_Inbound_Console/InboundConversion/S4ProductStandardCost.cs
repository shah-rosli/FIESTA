using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProductStandardCost
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PRODUCT_STANDARD_COST");
            dt.Columns.Add("companyCode", typeof(string));
            dt.Columns.Add("postingDate", typeof(DateTime));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("companyCodeCurrencyLegalValuation", typeof(decimal));
            dt.Columns.Add("companyCodeCurrency", typeof(string));
            dt.Columns.Add("priceUnit", typeof(decimal));
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

                    object[] oRowDt = new object[10];
                    CSV_S4_PRODUCT_STANDARD_COST material = (CSV_S4_PRODUCT_STANDARD_COST)o;
                    oRowDt[0] = material.companyCode;
                    oRowDt[1] = material.postingDate;
                    oRowDt[2] = material.plant;
                    oRowDt[3] = material.partNumberKey;
                    oRowDt[4] = material.partNumber;
                    oRowDt[5] = material.companyCodeCurrencyLegalValuation;
                    oRowDt[6] = material.companyCodeCurrency;
                    oRowDt[7] = material.priceUnit;
                    oRowDt[8] = s.UtcDateTime;
                    oRowDt[9] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
