
using FIESTA_Backend.Models;
using System;
using System.Collections;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgInvDivDeadLine
    {
        public CfgInvDivDeadLine()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_INV_DIV_DEADLINE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_INV_DIV_DEADLINE_ID { get; set; }
        public string INV_AOP_YEAR { get; set; }
        public string GLOBAL_DIV { get; set; }
        public DateTime INV_DIV_DEADLINE { get; set; }
        public string ACTIVE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public string MODIFIED_BY_DELEGATEE { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_INV_DIV_DEADLINE_ID = CfgInvDivDeadLine.TableName + ".CFG_INV_DIV_DEADLINE_ID";
            public static string INV_AOP_YEAR = CfgInvDivDeadLine.TableName + ".INV_AOP_YEAR";
            public static string GLOBAL_DIV = CfgInvDivDeadLine.TableName + ".GLOBAL_DIV";
            public static string INV_DIV_DEADLINE = CfgInvDivDeadLine.TableName + ".INV_DIV_DEADLINE";
            public static string ACTIVE = CfgInvDivDeadLine.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvDivDeadLine.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvDivDeadLine.TableName + ".MODIFIED_DATE";
            public static string MODIFIED_BY_DELEGATEE = CfgInvDivDeadLine.TableName + ".MODIFIED_BY_DELEGATEE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
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
            map.Add(CfgInvDivDeadLine.ColumnNames.CFG_INV_DIV_DEADLINE_ID, "CFG_INV_DIV_DEADLINE_ID");
            map.Add(CfgInvDivDeadLine.ColumnNames.INV_AOP_YEAR, "INV_AOP_YEAR");
            map.Add(CfgInvDivDeadLine.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvDivDeadLine.ColumnNames.INV_DIV_DEADLINE, "INV_DIV_DEADLINE");
            map.Add(CfgInvDivDeadLine.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvDivDeadLine.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvDivDeadLine.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvDivDeadLine.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction

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
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvDivDeadLine.ColumnNames.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        public string Formatted_INV_DIV_DEADLINE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvDivDeadLine.ColumnNames.INV_DIV_DEADLINE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }

        public string Formatted_INV_DIV_DEADLINE
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("{0}", DataConverter.ConvertTimezone(INV_DIV_DEADLINE, TokenObj.DEFAULT_TIMEZONE, "UTC"));
                else return null;
            }
            //get { return string.Format("{0}", TO_DATETIME); }
        }
        #endregion
    }
}
