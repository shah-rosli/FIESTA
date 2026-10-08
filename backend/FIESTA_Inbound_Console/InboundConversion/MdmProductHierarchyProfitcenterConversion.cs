using FIESTA_Backend.EfModels;
using FIESTA_Inbound_Console.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.InboundConversion
{
    public class MdmProductHierarchyProfitcenterConversion
    {
        public static List<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION> ConvertObj(CpiInboundObj obj)
        {
            List<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION> list = new List<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION>();

            foreach (CpiRow row in obj.rows)
            {
                MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION item = new MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION();

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.productHierarchyCode.content != null) item.productHierarchyCode = content.productHierarchyCode.content.ToString();
                if (content.profitCenterCode.content != null) item.profitCenterCode = content.profitCenterCode.content.ToString();
                if (content.profitCenter.content != null) item.profitCenter = content.profitCenter.content.ToString();
                if (content.deleteFlag.content != null) item.deleteFlag = content.deleteFlag.content.ToString();

                list.Add(item);
            }

            return list;
        }

        public static DataTable ConvertObjToDT(CpiInboundObj obj)
        {
            DataTable dt = new DataTable("MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION");
            dt.Columns.Add("productHierarchyCode", typeof(string));
            dt.Columns.Add("profitCenterCode", typeof(string));
            dt.Columns.Add("profitCenter", typeof(string));
            dt.Columns.Add("deleteFlag", typeof(string));

            foreach (CpiRow row in obj.rows)
            {
                object[] oRowDt = new object[4];

                CpiContent content;
                if (row.content != null)
                {
                    content = row.content;
                }
                else
                {
                    continue;
                }

                if (content.productHierarchyCode.content != null) oRowDt[0] = content.productHierarchyCode.content.ToString();
                if (content.profitCenterCode.content != null) oRowDt[1] = content.profitCenterCode.content.ToString();
                if (content.profitCenter.content != null) oRowDt[2] = content.profitCenter.content.ToString();
                if (content.deleteFlag.content != null) oRowDt[3] = content.deleteFlag.content.ToString();

                dt.Rows.Add(oRowDt);
            }

            return dt;
        }

        public static string GetColumnNames()
        {
            return "\"productHierarchyCode\",\"profitCenterCode\",\"profitCenter\",\"deleteFlag\"";
        }
    }
}
