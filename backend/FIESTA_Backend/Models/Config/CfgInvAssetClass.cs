
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
    public class CfgInvAssetClass
    {
        public CfgInvAssetClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_ASSET_CLASS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_ASSET_CLASS_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string INV_ASSET_CLASS_NAME { get; set; }
        public string INV_ASSET_CATEGORY { get; set; }

        public string INV_DEPRECIATION_YEAR { get; set; }
        public string ACTIVE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public string MODIFIED_BY_DELEGATEE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_ASSET_CLASS_ID = CfgInvAssetClass.TableName + ".CFG_INV_ASSET_CLASS_ID";
            public static string COMPANY_CODE = CfgInvAssetClass.TableName + ".COMPANY_CODE";
            public static string INV_ASSET_CLASS_NAME = CfgInvAssetClass.TableName + ".INV_ASSET_CLASS_NAME";
            public static string INV_ASSET_CATEGORY = CfgInvAssetClass.TableName + ".INV_ASSET_CATEGORY";
            public static string INV_DEPRECIATION_YEAR = CfgInvAssetClass.TableName + ".INV_DEPRECIATION_YEAR";
            public static string ACTIVE = CfgInvAssetClass.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvAssetClass.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvAssetClass.TableName + ".MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = CfgInvAssetClass.TableName + ".MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_ASSET_CLASS_ID = "CFG_INV_ASSET_CLASS_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string INV_ASSET_CLASS_NAME = "INV_ASSET_CLASS_NAME";
            public static string INV_ASSET_CATEGORY = "INV_ASSET_CATEGORY";
            public static string INV_DEPRECIATION_YEAR = "INV_DEPRECIATION_YEAR";
            public static string ACTIVE = "ACTIVE";
            public static string MODIFIED_BY = "MODIFIED_BY";
            public static string MODIFIED_DATE = "MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = "MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInvAssetClass.ColumnNames.CFG_INV_ASSET_CLASS_ID, "CFG_INV_ASSET_CLASS_ID");
            map.Add(CfgInvAssetClass.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgInvAssetClass.ColumnNames.INV_ASSET_CLASS_NAME, "INV_ASSET_CLASS_NAME");
            map.Add(CfgInvAssetClass.ColumnNames.INV_ASSET_CATEGORY, "INV_ASSET_CATEGORY");
            map.Add(CfgInvAssetClass.ColumnNames.INV_DEPRECIATION_YEAR, "INV_DEPRECIATION_YEAR");
            map.Add(CfgInvAssetClass.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvAssetClass.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvAssetClass.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvAssetClass.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction

        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_INV_ASSET_CLASS_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(INV_ASSET_CLASS_NAME)); }
        }
        public string Formatted_INV_ASSET_CATEGORY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(INV_ASSET_CATEGORY)); }
        }

        public string Formatted_INV_DEPRECIATION_YEAR
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(INV_DEPRECIATION_YEAR)); }
        }
        public string Formatted_MODIFIED_BY_DELEGATEE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(MODIFIED_BY_DELEGATEE)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(ACTIVE)); }
        }
       
      
        public string Formatted_MODIFIED_DATE_TO_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvAssetClass.ColumnNames.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
