using FIESTA_Inbound_Console.Models.S4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class S4ProductWipSellPrice
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records, string? filename)
        {
            DataTable dt = new DataTable("PRODUCT_WIP_SELL_PRICE");
            dt.Columns.Add("sellingPlant", typeof(string));
            dt.Columns.Add("partNumberKey", typeof(string));
            dt.Columns.Add("validFromDate", typeof(DateTime));
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("currency", typeof(string));
            dt.Columns.Add("validToDate", typeof(DateTime));
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

                    object[] oRowDt = new object[9];
                    CSV_S4_PRODUCT_WIP_SELL_PRICE material = (CSV_S4_PRODUCT_WIP_SELL_PRICE)o;
                    oRowDt[0] = material.sellingPlant;
                    oRowDt[1] = material.partNumberKey;
                    oRowDt[2] = material.validFromDate;
                    oRowDt[3] = material.partNumber;
                    oRowDt[4] = material.price;
                    oRowDt[5] = material.currency;
                    oRowDt[6] = material.validToDate;
                    oRowDt[7] = s.UtcDateTime;
                    oRowDt[8] = filename + "_" + dataRowCount;
                    dataRowCount++;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
