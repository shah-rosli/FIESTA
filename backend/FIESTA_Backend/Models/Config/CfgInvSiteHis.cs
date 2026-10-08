
using FIESTA_Backend.Models;
using System;
using System.Collections;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgInvSiteHis
    {
        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_SITE_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_SITE_ID { get; set; }

        public decimal CFG_INV_SITE_HIS_ID { get; set; }
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
            public static string CFG_INV_SITE_HIS_ID = CfgInvSiteHis.TableName + ".CFG_INV_SITE_HIS_ID";
            public static string CFG_INV_SITE_ID = CfgInvSiteHis.TableName + ".CFG_INV_SITE_ID";
            public static string COMPANY_CODE = CfgInvSiteHis.TableName + ".COMPANY_CODE";
            public static string INV_SITE_NAME = CfgInvSiteHis.TableName + ".INV_SITE_NAME";
            public static string ACTIVE = CfgInvSiteHis.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvSiteHis.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvSiteHis.TableName + ".MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = CfgInvSiteHis.TableName + ".MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_SITE_ID = "CFG_INV_SITE_ID";
            public static string CFG_INV_SITE_HIS_ID = "CFG_INV_SITE_HIS_ID";
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
            map.Add(CfgInvSiteHis.ColumnNames.CFG_INV_SITE_HIS_ID, "CFG_INV_SITE_HIS_ID");
            map.Add(CfgInvSiteHis.ColumnNames.CFG_INV_SITE_ID, "CFG_INV_SITE_ID");
            map.Add(CfgInvSiteHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgInvSiteHis.ColumnNames.INV_SITE_NAME, "INV_SITE_NAME");
            map.Add(CfgInvSiteHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvSiteHis.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvSiteHis.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvSiteHis.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvSiteHis.ColumnNames.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
