
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUserUserGroupMap
    {
        public CfgUserUserGroupMap()
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
            get { return "CFG_USER_USER_GROUP_MAP"; }
        }
        #endregion
        #region Properties
        public string USER_ID { get; set; }
        public decimal CFG_USER_GROUP_ID { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string USER_ID = CfgUserUserGroupMap.TableName + ".USER_ID";
            public static string CFG_USER_GROUP_ID = CfgUserUserGroupMap.TableName + ".CFG_USER_GROUP_ID";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string USER_ID = "USER_ID";
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserUserGroupMap.ColumnNames.USER_ID, "USER_ID");
            map.Add(CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_ID");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string USER_ID = "USER_ID";
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_USER_ID
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_ID)); }
        }
        public string Formatted_CFG_USER_GROUP_ID
        {
            get { return string.Format("'{0}'", CFG_USER_GROUP_ID); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.USER_ID; }
        }
        #endregion
    }
}
