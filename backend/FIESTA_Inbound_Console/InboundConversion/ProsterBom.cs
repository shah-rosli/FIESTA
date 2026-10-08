using FIESTA_Inbound_Console.Models.PROSTER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class ProsterBom
    {
        public static DataTable ConvertObjToDT(IEnumerable<object?> records)
        {
            DataTable dt = new DataTable("PRO_BOM");
            dt.Columns.Add("partNumber", typeof(string));
            dt.Columns.Add("plant", typeof(string));
            dt.Columns.Add("bomUsage", typeof(string));
            dt.Columns.Add("bomAlternative", typeof(string));
            dt.Columns.Add("baseUnitOfMeasure", typeof(string));
            dt.Columns.Add("baseQuantity", typeof(decimal));
            dt.Columns.Add("baseGroupStage", typeof(string));
            dt.Columns.Add("componentPartNumber", typeof(string));
            dt.Columns.Add("bomItem", typeof(string));
            dt.Columns.Add("componentUnitOfMeasure", typeof(string));
            dt.Columns.Add("componentQuantity", typeof(decimal));
            dt.Columns.Add("componentGroupStage", typeof(string));
            dt.Columns.Add("createDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateDateAndTime", typeof(DateTime));
            dt.Columns.Add("updateType", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));
            dt.Columns.Add("fiestaCreateDateAndTime", typeof(DateTime));

            //fix datetime - all records in same batch will have same datetime.
            //sample DT: 2023-01-01T00:00:00.000Z
            string now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            DateTimeOffset s = DateTimeOffset.Parse(now);

            foreach (object o in records)
            {
                if (o != null)
                {
                    object[] oRowDt = new object[17];
                    CSV_PRO_BOM bom = (CSV_PRO_BOM)o;
                    oRowDt[0] = bom.partNumber;
                    oRowDt[1] = bom.plant;
                    oRowDt[2] = bom.bomUsage;
                    oRowDt[3] = bom.bomAlternative;
                    oRowDt[4] = bom.baseUnitOfMeasure;
                    oRowDt[5] = bom.baseQuantity;
                    oRowDt[6] = bom.baseGroupStage;
                    oRowDt[7] = bom.componentPartNumber;
                    oRowDt[8] = bom.bomItem;
                    oRowDt[9] = bom.componentUnitOfMeasure;
                    oRowDt[10] = bom.componentQuantity;
                    oRowDt[11] = bom.componentGroupStage;
                    oRowDt[12] = bom.createDateAndTime;
                    oRowDt[13] = bom.updateDateAndTime;
                    oRowDt[14] = bom.updateType;
                    oRowDt[15] = bom.deleteFlag;
                    oRowDt[16] = s.UtcDateTime;

                    dt.Rows.Add(oRowDt);
                }
            }

            return dt;
        }
    }
}
