
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models;
namespace FIESTA_Backend.Models
{
    public class CfgLogger
    {
        public CfgLogger()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region static variable
        #endregion
        #region TableName
        public static string TableName
        {
            get { return "LOGGER"; }
        }
        #endregion
        #region Properties
        public decimal LOGGER_ID { get; set; }
        public DateTime LOGGER_DATE { get; set; }
        public string LOGGER_TYPE { get; set; }
        public string LOGGER_PLATFORM { get; set; }
        public string LOGGER_USER { get; set; }
        public string LOGGER_DESCRIPTION { get; set; }
        public string LOGGER_SHOW_USER { get; set; }
        public string LOGGER_PAGE { get; set; }
        public string token_substitute { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string LOGGER_ID = CfgLogger.TableName + ".LOGGER_ID";
            public static string LOGGER_DATE = CfgLogger.TableName + ".LOGGER_DATE";
            public static string LOGGER_TYPE = CfgLogger.TableName + ".LOGGER_TYPE";
            public static string LOGGER_PLATFORM = CfgLogger.TableName + ".LOGGER_PLATFORM";
            public static string LOGGER_USER = CfgLogger.TableName + ".LOGGER_USER";
            public static string LOGGER_DESCRIPTION = CfgLogger.TableName + ".LOGGER_DESCRIPTION";
            public static string LOGGER_SHOW_USER = CfgLogger.TableName + ".LOGGER_SHOW_USER";
            public static string LOGGER_PAGE = CfgLogger.TableName + ".LOGGER_PAGE";

        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string LOGGER_ID = "LOGGER_ID";
            public static string LOGGER_DATE = "LOGGER_DATE";
            public static string LOGGER_TYPE = "LOGGER_TYPE";
            public static string LOGGER_PLATFORM = "LOGGER_PLATFORM";
            public static string LOGGER_USER = "LOGGER_USER";
            public static string LOGGER_DESCRIPTION = "LOGGER_DESCRIPTION";          
            public static string LOGGER_SHOW_USER = "LOGGER_SHOW_USER";
            public static string LOGGER_PAGE = "LOGGER_PAGE";

        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgLogger.ColumnNames.LOGGER_ID, "LOGGER_ID");
            map.Add(CfgLogger.ColumnNames.LOGGER_DATE, "LOGGER_DATE");
            map.Add(CfgLogger.ColumnNames.LOGGER_TYPE, "LOGGER_TYPE");
            map.Add(CfgLogger.ColumnNames.LOGGER_PLATFORM, "LOGGER_PLATFORM");
            map.Add(CfgLogger.ColumnNames.LOGGER_USER, "LOGGER_USER");
            map.Add(CfgLogger.ColumnNames.LOGGER_DESCRIPTION, "LOGGER_DESCRIPTION");
            map.Add(CfgLogger.ColumnNames.LOGGER_SHOW_USER, "LOGGER_SHOW_USER");
            map.Add(CfgLogger.ColumnNames.LOGGER_PAGE, "LOGGER_PAGE");


            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string LOGGER_ID = "LOGGER_ID";
            public static string LOGGER_DATE = "LOGGER_DATE";
            public static string LOGGER_TYPE = "LOGGER_TYPE";
            public static string LOGGER_PLATFORM = "LOGGER_PLATFORM";
            public static string LOGGER_USER = "LOGGER_USER";
            public static string LOGGER_DESCRIPTION = "LOGGER_DESCRIPTION";
            public static string LOGGER_SHOW_USER = "LOGGER_SHOW_USER";
            public static string LOGGER_PAGE = "LOGGER_PAGE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_LOGGER_ID
        {
            get { return string.Format("'{0}'", LOGGER_ID); }
        }
        public string Formatted_LOGGER_DATE
        {
            get
            {   
                    return string.Format("{0}", DataAccessAssistant.OracleSystimestampToUTC());
            }
        }
        public string Formatted_LOGGER_TYPE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(LOGGER_TYPE)); }
        }
        public string Formatted_LOGGER_PLATFORM
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(LOGGER_PLATFORM)); }
        }
        public string Formatted_LOGGER_USER
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(LOGGER_USER)); }
        }
        public string Formatted_LOGGER_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(LOGGER_DESCRIPTION)); }
        }
        public string Formatted_LOGGER_SHOW_USER
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(LOGGER_SHOW_USER)); }
        }

        public string Formatted_LOGGER_PAGE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(LOGGER_PAGE)); }
        }

        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.LOGGER_ID; }
        }
        #endregion
    }
}
