
using FIESTA_Backend.Models;
using System;
using System.Collections;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgInvDivDeadLineHis
    {
        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_DIV_DEADLINE_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_DIV_DEADLINE_HIS_ID { get; set; }

        public decimal CFG_INV_DIV_DEADLINE_ID { get; set; }
        public string INV_AOP_YEAR { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string INV_DIV_DEADLINE { get; set; }
        public string ACTIVE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public string MODIFIED_BY_DELEGATEE { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_DIV_DEADLINE_HIS_ID = CfgInvDivDeadLineHis.TableName + ".CFG_INV_DIV_DEADLINE_HIS_ID";
            public static string CFG_INV_DIV_DEADLINE_ID = CfgInvDivDeadLineHis.TableName + ".CFG_INV_DIV_DEADLINE_ID";
            public static string INV_AOP_YEAR = CfgInvDivDeadLineHis.TableName + ".INV_AOP_YEAR";
            public static string GLOBAL_DIV = CfgInvDivDeadLineHis.TableName + ".GLOBAL_DIV";
            public static string INV_DIV_DEADLINE = CfgInvDivDeadLineHis.TableName + ".INV_DIV_DEADLINE";
            public static string ACTIVE = CfgInvDivDeadLineHis.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvDivDeadLineHis.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvDivDeadLineHis.TableName + ".MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = CfgInvDivDeadLineHis.TableName + ".MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_INV_DIV_DEADLINE_HIS_ID = "CFG_INV_DIV_DEADLINE_HIS_ID";
            public static string CFG_INV_DIV_DEADLINE_ID = "CFG_INV_DIV_DEADLINE_ID";
            public static string INV_AOP_YEAR = "INV_AOP_YEAR";
            public static string GLOBAL_DIV = "GLOBAL_DIV";
            public static string INV_DIV_DEADLINE = "INV_DIV_DEADLINE";
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
            map.Add(CfgInvDivDeadLineHis.ColumnNames.CFG_INV_DIV_DEADLINE_HIS_ID, "CFG_INV_DIV_DEADLINE_HIS_ID");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.CFG_INV_DIV_DEADLINE_ID, "CFG_INV_DIV_DEADLINE_ID");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.INV_AOP_YEAR, "INV_AOP_YEAR");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.INV_DIV_DEADLINE, "INV_DIV_DEADLINE");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvDivDeadLineHis.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction

        public string Formatted_INV_AOP_YEAR
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(INV_AOP_YEAR)); }
        }
        public string Formatted_GLOBAL_DIV
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_DIV)); }
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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvDivDeadLineHis.ColumnNames.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        public string Formatted_INV_DIV_DEADLINE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvDivDeadLineHis.ColumnNames.INV_DIV_DEADLINE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
