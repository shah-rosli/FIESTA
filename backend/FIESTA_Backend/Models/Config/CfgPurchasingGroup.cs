
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{ 
    public class CfgPurchasingGroup
    {
        //Constructor
        public CfgPurchasingGroup()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_PURCHASING_GROUP"; }
        }

        #region Properties       

        public decimal CFG_PURCHASING_GROUP_ID { get; set; }
        public string PURCHASING_GROUP_NAME { get; set; }
        public string PURCHASING_GROUP_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }
        public TokenProperties? TokenObj { get; set; }
        public string USER_ID { get; set; }

        
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_PURCHASING_GROUP_ID = CfgPurchasingGroup.TableName + ".CFG_PURCHASING_GROUP_ID";
            public static string PURCHASING_GROUP_NAME = CfgPurchasingGroup.TableName + ".PURCHASING_GROUP_NAME";
            public static string PURCHASING_GROUP_DESCRIPTION = CfgPurchasingGroup.TableName + ".PURCHASING_GROUP_DESCRIPTION";
            public static string COMPANY_CODE = CfgPurchasingGroup.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgPurchasingGroup.TableName + ".ACTIVE";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_PURCHASING_GROUP_ID = "CFG_PURCHASING_GROUP_ID";
            public static string PURCHASING_GROUP_NAME = "PURCHASING_GROUP_NAME";
            public static string PURCHASING_GROUP_DESCRIPTION = "PURCHASING_GROUP_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";

        }
        #endregion

        #region FormattedValueForSqlTransaction        
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_PURCHASING_GROUP_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PURCHASING_GROUP_NAME)); }
        }

        public string Formatted_PURCHASING_GROUP_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PURCHASING_GROUP_DESCRIPTION)); }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgPurchasingGroup.ColumnNames.CFG_PURCHASING_GROUP_ID, "CFG_PURCHASING_GROUP_ID");
            map.Add(CfgPurchasingGroup.ColumnNames.PURCHASING_GROUP_NAME, "PURCHASING_GROUP_NAME");
            map.Add(CfgPurchasingGroup.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgPurchasingGroup.ColumnNames.PURCHASING_GROUP_DESCRIPTION, "PURCHASING_GROUP_DESCRIPTION");
            map.Add(CfgPurchasingGroup.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
