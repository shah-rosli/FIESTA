
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
    public class CfgSystemLanguageHis
    {
        public CfgSystemLanguageHis()
        {

        }

        public static string TableName
        {
            get { return "CFG_SYSTEM_LANGUAGE_HIS"; }
            
        }

        #region Properties       
        public decimal CFG_SYSTEM_LANGUAGE_ID { get; set; }
        public string LABEL_NAME { get; set; }
        public string EN { get; set; }
        public string JA { get; set; }
        public string ZH { get; set; }


        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SYSTEM_LANG_HIS_ID = CfgSystemLanguageHis.TableName + ".CFG_SYSTEM_LANG_HIS_ID";
            public static string CFG_SYSTEM_LANG_HIS_USER_ID = CfgSystemLanguageHis.TableName + ".CFG_SYSTEM_LANG_HIS_USER_ID";
            public static string CFG_SYSTEM_LANG_HIS_DELEGATE = CfgSystemLanguageHis.TableName + ".CFG_SYSTEM_LANG_HIS_DELEGATE";
            public static string CFG_SYSTEM_LANG_HIS_DATE = CfgSystemLanguageHis.TableName + ".CFG_SYSTEM_LANG_HIS_DATE";

            public static string CFG_SYSTEM_LANGUAGE_ID = CfgSystemLanguageHis.TableName + ".CFG_SYSTEM_LANGUAGE_ID";
            public static string LABEL_NAME = CfgSystemLanguageHis.TableName + ".LABEL_NAME";
            public static string EN = CfgSystemLanguageHis.TableName + ".EN";
            public static string JA = CfgSystemLanguageHis.TableName + ".JA";
            public static string ZH = CfgSystemLanguageHis.TableName + ".ZH";

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_SYSTEM_LANG_HIS_ID = "CFG_SYSTEM_LANG_HIS_ID";
            public static string CFG_SYSTEM_LANG_HIS_USER_ID = "CFG_SYSTEM_LANG_HIS_USER_ID";
            public static string CFG_SYSTEM_LANG_HIS_DELEGATE = "CFG_SYSTEM_LANG_HIS_DELEGATE";
            public static string CFG_SYSTEM_LANG_HIS_DATE = "CFG_SYSTEM_LANG_HIS_DATE";

            public static string CFG_SYSTEM_LANGUAGE_ID = "CFG_SYSTEM_LANGUAGE_ID";
            public static string LABEL_NAME = "LABEL_NAME";
            public static string EN = "EN";
            public static string JA = "JA";
            public static string ZH = "ZH";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_LABEL_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(LABEL_NAME)); }
        }
        public string Formatted_EN
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(EN)); }
        }
        public string Formatted_JA
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(JA)); }
        }
        public string Formatted_ZH
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(ZH)); }
        }

        public string Formatted_CFG_SYSTEM_LANG_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_ID, "CFG_SYSTEM_LANG_HIS_ID");
            map.Add(CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_USER_ID, "CFG_SYSTEM_LANG_HIS_USER_ID");
            map.Add(CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_DELEGATE, "CFG_SYSTEM_LANG_HIS_DELEGATE");
            map.Add(CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_DATE, "CFG_SYSTEM_LANG_HIS_DATE");
            map.Add(CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, "CFG_SYSTEM_LANGUAGE_ID");
            map.Add(CfgSystemLanguageHis.ColumnNames.LABEL_NAME, "LABEL_NAME");
            map.Add(CfgSystemLanguageHis.ColumnNames.EN, "EN");
            map.Add(CfgSystemLanguageHis.ColumnNames.JA, "JA");
            map.Add(CfgSystemLanguageHis.ColumnNames.ZH, "ZH");

            return map;
        }
        #endregion

    }
}
