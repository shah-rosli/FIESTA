
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
    public class CfgInvDivisionHis
    {
        public CfgInvDivisionHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region TableName
        public static string TableName
        {
            get { return "CFG_DIVISION_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_DIVISION_ID { get; set; }
        public decimal CFG_DIVISION_HIS_ID { get; set; }
        public string GLOBAL_DIV { get; set; }
        public string GLOBAL_DIV_CODE { get; set; }
        public string GLOBAL_DIV_NAME { get; set; }
        public string ACTIVE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
        public decimal ACTIVE_COUNT { get; set; }
        public string MODIFIED_BY_DELEGATEE { get; set; }

        public string GLOBAL_UNIT { get; set; }

        public string USE_IN_INV { get; set; }

        public string[] saPurposeMap { get; set; }
        public string[] saSupervisorMap { get; set; }
        public TokenProperties? TokenObj { get; set; }
        public string DisplayTimezone { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_DIVISION_HIS_ID = CfgInvDivisionHis.TableName + ".CFG_DIVISION_HIS_ID";
            public static string CFG_DIVISION_ID = CfgInvDivisionHis.TableName + ".CFG_DIVISION_ID";
            public static string GLOBAL_DIV = CfgInvDivisionHis.TableName + ".GLOBAL_DIV";
            public static string GLOBAL_DIV_CODE = CfgInvDivisionHis.TableName + ".GLOBAL_DIV_CODE";
            public static string GLOBAL_DIV_NAME = CfgInvDivisionHis.TableName + ".GLOBAL_DIV_NAME";
            public static string ACTIVE = CfgInvDivisionHis.TableName + ".ACTIVE";
            public static string MODIFIED_BY = CfgInvDivisionHis.TableName + ".MODIFIED_BY";
            public static string MODIFIED_DATE = CfgInvDivisionHis.TableName + ".MODIFIED_DATE";
            public static string ACTIVE_COUNT = CfgInvDivisionHis.TableName + ".ACTIVE_COUNT";
            public static string MODIFIED_BY_DELEGATEE = CfgInvDivisionHis.TableName + ".MODIFIED_BY_DELEGATEE";
            public static string GLOBAL_UNIT = CfgInvDivisionHis.TableName + ".GLOBAL_UNIT";
            public static string USE_IN_INV = CfgInvDivisionHis.TableName + ".USE_IN_INV";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_DIVISION_ID = "CFG_DIVISION_ID";
            public static string CFG_DIVISION_HIS_ID = "CFG_DIVISION_HIS_ID";
            public static string GLOBAL_DIV = "GLOBAL_DIV";
            public static string GLOBAL_DIV_CODE = "GLOBAL_DIV_CODE";
            public static string GLOBAL_DIV_NAME = "GLOBAL_DIV_NAME";
            public static string ACTIVE = "ACTIVE";
            public static string MODIFIED_BY = "MODIFIED_BY";
            public static string MODIFIED_DATE = "MODIFIED_DATE";
            public static string ACTIVE_COUNT = "ACTIVE_COUNT";
            public static string MODIFIED_BY_DELEGATEE = "MODIFIED_BY_DELEGATEE";
            public static string GLOBAL_UNIT = "GLOBAL_UNIT";
            public static string USE_IN_INV = "USE_IN_INV";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgInvDivisionHis.ColumnNames.CFG_DIVISION_ID, "CFG_DIVISION_ID");
            map.Add(CfgInvDivisionHis.ColumnNames.CFG_DIVISION_HIS_ID, "CFG_DIVISION_HIS_ID");
            map.Add(CfgInvDivisionHis.ColumnNames.GLOBAL_DIV, "GLOBAL_DIV");
            map.Add(CfgInvDivisionHis.ColumnNames.GLOBAL_DIV_CODE, "GLOBAL_DIV_CODE");
            map.Add(CfgInvDivisionHis.ColumnNames.GLOBAL_DIV_NAME, "GLOBAL_DIV_NAME");
            map.Add(CfgInvDivisionHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgInvDivisionHis.ColumnNames.MODIFIED_BY, "MODIFIED_BY");
            map.Add(CfgInvDivisionHis.ColumnNames.MODIFIED_DATE, "MODIFIED_DATE");
            map.Add(CfgInvDivisionHis.ColumnNames.ACTIVE_COUNT, "ACTIVE_COUNT");
            map.Add(CfgInvDivisionHis.ColumnNames.MODIFIED_BY_DELEGATEE, "MODIFIED_BY_DELEGATEE");
            map.Add(CfgInvDivisionHis.ColumnNames.GLOBAL_UNIT, "GLOBAL_UNIT");
            map.Add(CfgInvDivisionHis.ColumnNames.USE_IN_INV, "USE_IN_INV");
            return map;
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_GLOBAL_DIV
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_DIV)); }
        }

        public string Formatted_GLOBAL_DIV_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_DIV_CODE)); }
        }

        public string Formatted_GLOBAL_DIV_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_DIV_NAME)); }
        }
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

        public string Formatted_GLOBAL_UNIT
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(GLOBAL_UNIT)); }
        }
        public string Formatted_USE_IN_INV
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(USE_IN_INV)); }
        }


        public string Formatted_MODIFIED_DATE_TO_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST(div.{0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgInvDivisionHis.ColumnNamesOnly.MODIFIED_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
    }
}
