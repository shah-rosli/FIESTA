
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;
namespace FIESTA_Backend.Models
{
    public class CfgMenuOperationMap
    {
        public CfgMenuOperationMap()
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
            get { return "CFG_MENU_OPERATION_MAP"; }
        }
        #endregion
        #region Properties
        public decimal CFG_SYSTEM_MENU_ID { get; set; }
        public string ACCESS_OPERATION { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_SYSTEM_MENU_ID = CfgMenuOperationMap.TableName + ".CFG_SYSTEM_MENU_ID";
            public static string ACCESS_OPERATION = CfgMenuOperationMap.TableName + ".ACCESS_OPERATION";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_SYSTEM_MENU_ID = "CFG_SYSTEM_MENU_ID";
            public static string ACCESS_OPERATION = "ACCESS_OPERATION";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgMenuOperationMap.ColumnNames.CFG_SYSTEM_MENU_ID, "CFG_SYSTEM_MENU_ID");
            map.Add(CfgMenuOperationMap.ColumnNames.ACCESS_OPERATION, "ACCESS_OPERATION");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_SYSTEM_MENU_ID = "CFG_SYSTEM_MENU_ID";
            public static string ACCESS_OPERATION = "ACCESS_OPERATION";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_SYSTEM_MENU_ID
        {
            get { return string.Format("'{0}'", CFG_SYSTEM_MENU_ID); }
        }
        public string Formatted_ACCESS_OPERATION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACCESS_OPERATION)); }
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
