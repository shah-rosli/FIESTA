
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgCompanyAccCategoryMap
    {
        public CfgCompanyAccCategoryMap()
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
            get { return "CFG_COMPANY_ACC_CATEGORY_MAP"; }
        }
        #endregion
        #region Properties
        public string COMPANY_CODE { get; set; }
        public string ACC_CATEGORY_NAME { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string COMPANY_CODE = CfgCompanyAccCategoryMap.TableName + ".COMPANY_CODE";
            public static string ACC_CATEGORY_NAME = CfgCompanyAccCategoryMap.TableName + ".ACC_CATEGORY_NAME";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACC_CATEGORY_NAME = "ACC_CATEGORY_NAME";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCompanyAccCategoryMap.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCompanyAccCategoryMap.ColumnNames.ACC_CATEGORY_NAME, "ACC_CATEGORY_NAME");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACC_CATEGORY_NAME = "ACC_CATEGORY_NAME";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_ACC_CATEGORY_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACC_CATEGORY_NAME)); }
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
