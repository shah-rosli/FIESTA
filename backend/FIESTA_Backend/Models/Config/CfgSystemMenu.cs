
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgSystemMenu
    {
        public CfgSystemMenu()
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
            get { return "CFG_SYSTEM_MENU"; }
        }
        #endregion
        #region Properties
        public decimal CFG_SYSTEM_MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public decimal MENU_PARENT_ID { get; set; }
        public decimal MENU_SEQUENCE { get; set; }
        public string MENU_ICON { get; set; }
        public string MENU_LINK { get; set; }
        public string ACTIVE { get; set; }
        public string[] saOperationMap { get; set; }
        public TokenProperties? TokenObj { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SYSTEM_MENU_ID = CfgSystemMenu.TableName + ".CFG_SYSTEM_MENU_ID";
            public static string MENU_NAME = CfgSystemMenu.TableName + ".MENU_NAME";
            public static string MENU_PARENT_ID = CfgSystemMenu.TableName + ".MENU_PARENT_ID";
            public static string MENU_SEQUENCE = CfgSystemMenu.TableName + ".MENU_SEQUENCE";
            public static string MENU_ICON = CfgSystemMenu.TableName + ".MENU_ICON";
            public static string MENU_LINK = CfgSystemMenu.TableName + ".MENU_LINK";
            public static string ACTIVE = CfgSystemMenu.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_SYSTEM_MENU_ID = "CFG_SYSTEM_MENU_ID";
            public static string MENU_NAME = "MENU_NAME";
            public static string MENU_PARENT_ID = "MENU_PARENT_ID";
            public static string MENU_SEQUENCE = "MENU_SEQUENCE";
            public static string MENU_ICON = "MENU_ICON";
            public static string MENU_LINK = "MENU_LINK";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, "CFG_SYSTEM_MENU_ID");
            map.Add(CfgSystemMenu.ColumnNames.MENU_NAME, "MENU_NAME");
            map.Add(CfgSystemMenu.ColumnNames.MENU_PARENT_ID, "MENU_PARENT_ID");
            map.Add(CfgSystemMenu.ColumnNames.MENU_SEQUENCE, "MENU_SEQUENCE");
            map.Add(CfgSystemMenu.ColumnNames.MENU_ICON, "MENU_ICON");
            map.Add(CfgSystemMenu.ColumnNames.MENU_LINK, "MENU_LINK");
            map.Add(CfgSystemMenu.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_SYSTEM_MENU_ID = "CFG_SYSTEM_MENU_ID";
            public static string MENU_NAME = "MENU_NAME";
            public static string MENU_PARENT_ID = "MENU_PARENT_ID";
            public static string MENU_SEQUENCE = "MENU_SEQUENCE";
            public static string MENU_ICON = "MENU_ICON";
            public static string MENU_LINK = "MENU_LINK";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_SYSTEM_MENU_ID
        {
            get { return string.Format("'{0}'", CFG_SYSTEM_MENU_ID); }
        }
        public string Formatted_MENU_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(MENU_NAME)); }
        }
        public string Formatted_MENU_PARENT_ID
        {
            get { return string.Format("'{0}'", MENU_PARENT_ID); }
        }
        public string Formatted_MENU_SEQUENCE
        {
            get { return string.Format("'{0}'", MENU_SEQUENCE); }
        }
        public string Formatted_MENU_ICON
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(MENU_ICON)); }
        }
        public string Formatted_MENU_LINK
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(MENU_LINK)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_SYSTEM_MENU_ID; }
        }
        #endregion
    }
}
