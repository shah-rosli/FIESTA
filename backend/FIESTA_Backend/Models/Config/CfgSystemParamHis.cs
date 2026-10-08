
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
    public class CfgSystemParamHis
    {
        public CfgSystemParamHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string TableName
        {
            get { return "CFG_SYSTEM_PARAM_HIS"; }
        }
        #region Properties       
        public decimal CFG_SYSTEM_PARAM_ID { get; set; }
        public decimal CFG_SYSTEM_PARAM_HIS_ID { get; set; }

        public string CFG_SYSTEM_PARAM_HIS_USER_ID { get; set; }
        public string CFG_SYSTEM_PARAM_HIS_DELEGATE { get; set; }
        public DateTimeOffset CFG_SYSTEM_PARAM_HIS_DATE { get; set; }

        public string PARAM_KEY { get; set; }
        public string PARAM_VALUE { get; set; }
        public string PARAM_CATEGORY { get; set; }
        public string? MODIFIED_BY_EMAIL { get; set; }
        public string? MODIFIED_BY_NAME { get; set; }
        public string? MODIFIED_BY_DELNAME { get; set; }
        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SYSTEM_PARAM_HIS_ID = CfgSystemParamHis.TableName + ".CFG_SYSTEM_PARAM_HIS_ID";
            public static string CFG_SYSTEM_PARAM_HIS_USER_ID = CfgSystemParamHis.TableName + ".CFG_SYSTEM_PARAM_HIS_USER_ID";
            public static string CFG_SYSTEM_PARAM_HIS_DELEGATE = CfgSystemParamHis.TableName + ".CFG_SYSTEM_PARAM_HIS_DELEGATE";
            public static string CFG_SYSTEM_PARAM_HIS_DATE = CfgSystemParamHis.TableName + ".CFG_SYSTEM_PARAM_HIS_DATE";
            public static string CFG_SYSTEM_PARAM_ID = CfgSystemParamHis.TableName + ".CFG_SYSTEM_PARAM_ID";
            public static string PARAM_KEY = CfgSystemParamHis.TableName + ".PARAM_KEY";
            public static string PARAM_VALUE = CfgSystemParamHis.TableName + ".PARAM_VALUE";
            public static string PARAM_CATEGORY = CfgSystemParamHis.TableName + ".PARAM_CATEGORY";
        }


        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_SYSTEM_PARAM_HIS_ID = "CFG_SYSTEM_PARAM_HIS_ID";
            public static string CFG_SYSTEM_PARAM_HIS_USER_ID = "CFG_SYSTEM_PARAM_HIS_USER_ID";
            public static string CFG_SYSTEM_PARAM_HIS_DELEGATE = "CFG_SYSTEM_PARAM_HIS_DELEGATE";
            public static string CFG_SYSTEM_PARAM_HIS_DATE = "CFG_SYSTEM_PARAM_HIS_DATE";
            public static string CFG_SYSTEM_PARAM_ID = "CFG_SYSTEM_PARAM_ID";
            public static string PARAM_KEY = "PARAM_KEY";
            public static string PARAM_VALUE = "PARAM_VALUE";
            public static string PARAM_CATEGORY = "PARAM_CATEGORY";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_PARAM_KEY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PARAM_KEY)); }
        }
        public string Formatted_PARAM_VALUE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PARAM_VALUE)); }
        }
        public string Formatted_PARAM_CATEGORY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PARAM_CATEGORY)); }
        }

        public string Formatted_CFG_SYSTEM_PARAM_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_ID, "CFG_SYSTEM_PARAM_HIS_ID");
            map.Add(CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_USER_ID, "CFG_SYSTEM_PARAM_HIS_USER_ID");
            map.Add(CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DELEGATE, "CFG_SYSTEM_PARAM_HIS_DELEGATE");
            map.Add(CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DATE, "CFG_SYSTEM_PARAM_HIS_DATE");
            map.Add(CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_ID, "CFG_SYSTEM_PARAM_ID");
            map.Add(CfgSystemParamHis.ColumnNames.PARAM_KEY, "PARAM_KEY");
            map.Add(CfgSystemParamHis.ColumnNames.PARAM_VALUE, "PARAM_VALUE");
            map.Add(CfgSystemParamHis.ColumnNames.PARAM_CATEGORY, "PARAM_CATEGORY");

            return map;
        }
        #endregion
    }
}
