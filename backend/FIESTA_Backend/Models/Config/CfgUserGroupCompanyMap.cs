
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUserGroupCompanyMap
    {
        public CfgUserGroupCompanyMap()
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
            get { return "CFG_USER_GROUP_COMPANY_MAP"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_GROUP_ID { get; set; }
        public string COMPANY_CODE { get; set; }

        public string[] arrCompanyCode { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_GROUP_ID = CfgUserGroupCompanyMap.TableName + ".CFG_USER_GROUP_ID";
            public static string COMPANY_CODE = CfgUserGroupCompanyMap.TableName + ".COMPANY_CODE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, "CFG_USER_GROUP_ID");
            map.Add(CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_USER_GROUP_ID = "CFG_USER_GROUP_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_USER_GROUP_ID
        {
            get { return string.Format("'{0}'", CFG_USER_GROUP_ID); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.COMPANY_CODE; }
        }
        #endregion
    }
}
