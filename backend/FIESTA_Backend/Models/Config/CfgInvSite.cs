
using FIESTA_Backend.Models;
using System;
using System.Collections;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{ 
    public class CfgInvSite
    {
        public CfgInvSite()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_SITE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_SITE_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string INV_SITE_NAME { get; set; }        
        public string ACTIVE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public string MODIFIED_BY_DELEGATEE { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_SITE_ID = CfgInvSite.TableName + ".CFG_INV_SITE_ID";
            public static string COMPANY_CODE = CfgInvSite.TableName + ".COMPANY_CODE";
            public static string INV_SITE_NAME = CfgInvSite.TableName + ".INV_SITE_NAME";
            public static string ACTIVE = CfgInvSite.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvSite.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvSite.TableName + ".MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = CfgInvSite.TableName + ".MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_SITE_ID = "CFG_INV_SITE_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string INV_SITE_NAME = "INV_SITE_NAME";            
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
            map.Add(CfgInvSite.ColumnNames.CFG_INV_SITE_ID, "CFG_INV_SITE_ID");
            map.Add(CfgInvSite.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgInvSite.ColumnNames.INV_SITE_NAME, "INV_SITE_NAME");
            map.Add(CfgInvSite.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvSite.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvSite.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvSite.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction

        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_INV_SITE_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(INV_SITE_NAME)); }
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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvSite.ColumnNames.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
