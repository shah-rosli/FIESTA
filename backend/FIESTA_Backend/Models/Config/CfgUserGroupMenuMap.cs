
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUserGroupMenuMap
    {
        public CfgUserGroupMenuMap()
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
            get { return "CFG_USER_GROUP_MENU_MAP"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_GROUP_MENU_MAP_ID { get; set; }
        public decimal CFG_USER_GROUP_ID { get; set; }
        public decimal MENU_ID { get; set; }
        public string ACCESS_OPERATION { get; set; }
        public string? USER_GROUP_NAME { get; set; }
        public string? MENU_NAME { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_GROUP_MENU_MAP_ID = CfgUserGroupMenuMap.TableName + ".CFG_USER_GROUP_MENU_MAP_ID";
            public static string CFG_USER_GROUP_ID = CfgUserGroupMenuMap.TableName + ".CFG_USER_GROUP_ID";
            public static string MENU_ID = CfgUserGroupMenuMap.TableName + ".MENU_ID";
            public static string ACCESS_OPERATION = CfgUserGroupMenuMap.TableName + ".ACCESS_OPERATION";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_GROUP_MENU_MAP_ID = "CFG_USER_GROUP_MENU_MAP_ID";
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
            public static string MENU_ID = "MENU_ID";
            public static string ACCESS_OPERATION = "ACCESS_OPERATION";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_MENU_MAP_ID, "CFG_USER_GROUP_MENU_MAP_ID");
            map.Add(CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_ID");
            map.Add(CfgUserGroupMenuMap.ColumnNames.MENU_ID, "MENU_ID");
            map.Add(CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION, "ACCESS_OPERATION");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_USER_GROUP_MENU_MAP_ID = "CFG_USER_GROUP_MENU_MAP_ID";
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
            public static string MENU_ID = "MENU_ID";
            public static string ACCESS_OPERATION = "ACCESS_OPERATION";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_USER_GROUP_MENU_MAP_ID
        {
            get { return string.Format("'{0}'", CFG_USER_GROUP_MENU_MAP_ID); }
        }
        public string Formatted_CFG_USER_GROUP_ID
        {
            get { return string.Format("'{0}'", CFG_USER_GROUP_ID); }
        }
        public string Formatted_MENU_ID
        {
            get { return string.Format("'{0}'", MENU_ID); }
        }
        public string Formatted_ACCESS_OPERATION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACCESS_OPERATION)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_USER_GROUP_MENU_MAP_ID; }
        }
        #endregion
    }
}
