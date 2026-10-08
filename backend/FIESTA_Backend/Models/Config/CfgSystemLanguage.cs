
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
    public class CfgSystemLanguage
    {
        public CfgSystemLanguage()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_SYSTEM_LANGUAGE"; }
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
            public static string CFG_SYSTEM_LANGUAGE_ID = CfgSystemLanguage.TableName + ".CFG_SYSTEM_LANGUAGE_ID";
            public static string LABEL_NAME = CfgSystemLanguage.TableName + ".LABEL_NAME";
            public static string EN = CfgSystemLanguage.TableName + ".EN";
            public static string JA = CfgSystemLanguage.TableName + ".JA";
            public static string ZH = CfgSystemLanguage.TableName + ".ZH";

        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
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
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, "CFG_SYSTEM_LANGUAGE_ID");
            map.Add(CfgSystemLanguage.ColumnNames.LABEL_NAME, "LABEL_NAME");
            map.Add(CfgSystemLanguage.ColumnNames.EN, "EN");
            map.Add(CfgSystemLanguage.ColumnNames.JA, "JA");
            map.Add(CfgSystemLanguage.ColumnNames.ZH, "ZH");

            return map;
        }
        #endregion


       
    }
}