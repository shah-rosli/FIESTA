
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
    public class CfgInvAopWindowHis
    {
        public CfgInvAopWindowHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_AOP_WINDOW_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_AOP_WINDOW_ID { get; set; }
        public decimal CFG_INV_AOP_WINDOW_HIS_ID { get; set; }
        public decimal INV_AOP_YEAR { get; set; }
        public DateTime INV_AOP_DATE_FROM { get; set; }
        public DateTime INV_AOP_DATE_TO { get; set; }
        public string ACTIVE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public string MODIFIED_BY_DELEGATEE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        public string DisplayTimezone { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_AOP_WINDOW_HIS_ID = CfgInvAopWindowHis.TableName + ".CFG_INV_AOP_WINDOW_HIS_ID";
            public static string CFG_INV_AOP_WINDOW_ID = CfgInvAopWindowHis.TableName + ".CFG_INV_AOP_WINDOW_ID";
            public static string INV_AOP_YEAR = CfgInvAopWindowHis.TableName + ".INV_AOP_YEAR";
            public static string INV_AOP_DATE_FROM = CfgInvAopWindowHis.TableName + ".INV_AOP_DATE_FROM";
            public static string INV_AOP_DATE_TO = CfgInvAopWindowHis.TableName + ".INV_AOP_DATE_TO";
            public static string ACTIVE = CfgInvAopWindowHis.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvAopWindowHis.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvAopWindowHis.TableName + ".MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = CfgInvAopWindowHis.TableName + ".MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_AOP_WINDOW_HIS_ID = "CFG_INV_AOP_WINDOW_HIS_ID";
            public static string CFG_INV_AOP_WINDOW_ID = "CFG_INV_AOP_WINDOW_ID";
            public static string INV_AOP_YEAR = "INV_AOP_YEAR";
            public static string INV_AOP_DATE_FROM = "INV_AOP_DATE_FROM";
            public static string INV_AOP_DATE_TO = "INV_AOP_DATE_TO";
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
            map.Add(CfgInvAopWindowHis.ColumnNames.CFG_INV_AOP_WINDOW_HIS_ID, "CFG_INV_AOP_WINDOW_HIS_ID");
            map.Add(CfgInvAopWindowHis.ColumnNames.CFG_INV_AOP_WINDOW_ID, "CFG_INV_AOP_WINDOW_ID");
            map.Add(CfgInvAopWindowHis.ColumnNames.INV_AOP_YEAR, "INV_AOP_YEAR");
            map.Add(CfgInvAopWindowHis.ColumnNames.INV_AOP_DATE_FROM, "INV_AOP_DATE_FROM");
            map.Add(CfgInvAopWindowHis.ColumnNames.INV_AOP_DATE_TO, "INV_AOP_DATE_TO");
            map.Add(CfgInvAopWindowHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvAopWindowHis.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvAopWindowHis.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvAopWindowHis.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_MODIFIED_BY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(MODIFIED_BY)); }
        }
        public string Formatted_MODIFIED_BY_DELEGATEE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(MODIFIED_BY_DELEGATEE)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(ACTIVE)); }
        }
        public string Formatted_INV_AOP_DATE_FROM
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(INV_AOP_DATE_FROM, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }
            //get { return string.Format("{0}", TO_DATETIME); }
        }

        public string Formatted_INV_AOP_DATE_TO
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(INV_AOP_DATE_TO, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }

            //get { return string.Format("{0}", FROM_DATETIME); }
        }
        public string Formatted_INV_AOP_DATE_FROM_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvAopWindowHis.ColumnNames.INV_AOP_DATE_FROM, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        public string Formatted_INV_AOP_DATE_TO_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvAopWindowHis.ColumnNames.INV_AOP_DATE_TO, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        public string Formatted_MODIFIED_DATE_TO_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvAopWindowHis.ColumnNames.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
