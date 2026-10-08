using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgPurchasingGroupHis
    {
        public CfgPurchasingGroupHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_PURCHASING_GROUP_HIS"; }
        }

        #region Properties       

        public decimal CFG_PURCHASING_GROUP_ID { get; set; }
        public string PURCHASING_GROUP_NAME { get; set; }
        public string PURCHASING_GROUP_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string PURCHASING_GROUP_HIS_USER_ID = CfgPurchasingGroupHis.TableName + ".PURCHASING_GROUP_HIS_USER_ID";
            public static string PURCHASING_GROUP_HIS_DELEGATE = CfgPurchasingGroupHis.TableName + ".PURCHASING_GROUP_HIS_DELEGATE";
            public static string PURCHASING_GROUP_HIS_DATE = CfgPurchasingGroupHis.TableName + ".PURCHASING_GROUP_HIS_DATE";            
            public static string CFG_PURCHASING_GROUP_ID = CfgPurchasingGroupHis.TableName + ".CFG_PURCHASING_GROUP_ID";
            public static string PURCHASING_GROUP_NAME = CfgPurchasingGroupHis.TableName + ".PURCHASING_GROUP_NAME";
            public static string PURCHASING_GROUP_DESCRIPTION = CfgPurchasingGroupHis.TableName + ".PURCHASING_GROUP_DESCRIPTION";
            public static string COMPANY_CODE = CfgPurchasingGroupHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgPurchasingGroupHis.TableName + ".ACTIVE";
        }
        #endregion

       

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgPurchasingGroupHis.ColumnNames.PURCHASING_GROUP_HIS_USER_ID, "PURCHASING_GROUP_HIS_USER_ID");
            map.Add(CfgPurchasingGroupHis.ColumnNames.PURCHASING_GROUP_HIS_DELEGATE, "PURCHASING_GROUP_HIS_DELEGATE");
            map.Add(CfgPurchasingGroupHis.ColumnNames.PURCHASING_GROUP_HIS_DATE, "PURCHASING_GROUP_HIS_DATE");
            map.Add(CfgPurchasingGroupHis.ColumnNames.CFG_PURCHASING_GROUP_ID, "CFG_PURCHASING_GROUP_ID");
            map.Add(CfgPurchasingGroupHis.ColumnNames.PURCHASING_GROUP_NAME, "PURCHASING_GROUP_NAME");
            map.Add(CfgPurchasingGroupHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgPurchasingGroupHis.ColumnNames.PURCHASING_GROUP_DESCRIPTION, "PURCHASING_GROUP_DESCRIPTION");
            map.Add(CfgPurchasingGroupHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion

        public string Formatted_PURCHASING_GROUP_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgPurchasingGroupHis.ColumnNames.PURCHASING_GROUP_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
    }
}
