
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;


namespace FIESTA_Backend.Models
{
    public class CfgUserGroup
    {
        public CfgUserGroup()
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
            get { return "CFG_USER_GROUP"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_GROUP_ID { get; set; }
        public string USER_GROUP_NAME { get; set; }
        public string USER_GROUP_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        public string[] saCompany { get; set; }
        public List<CfgUserGroupMenuMap> saMenu { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_GROUP_ID = CfgUserGroup.TableName + ".CFG_USER_GROUP_ID";
            public static string USER_GROUP_NAME = CfgUserGroup.TableName + ".USER_GROUP_NAME";
            public static string USER_GROUP_DESCRIPTION = CfgUserGroup.TableName + ".USER_GROUP_DESCRIPTION";
            public static string ACTIVE = CfgUserGroup.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
            public static string USER_GROUP_NAME = "USER_GROUP_NAME";
            public static string USER_GROUP_DESCRIPTION = "USER_GROUP_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_ID");
            map.Add(CfgUserGroup.ColumnNames.USER_GROUP_NAME, "USER_GROUP_NAME");
            map.Add(CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, "USER_GROUP_DESCRIPTION");
            map.Add(CfgUserGroup.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
            public static string USER_GROUP_NAME = "USER_GROUP_NAME";
            public static string USER_GROUP_DESCRIPTION = "USER_GROUP_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_USER_GROUP_ID
        {
            get { return string.Format("'{0}'", CFG_USER_GROUP_ID); }
        }
        public string Formatted_USER_GROUP_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_GROUP_NAME)); }
        }
        public string Formatted_USER_GROUP_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_GROUP_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_USER_GROUP_ID; }
        }
        #endregion
    }
}
