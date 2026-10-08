using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgCompanyUomMap
    {
        public CfgCompanyUomMap()
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
            get { return "CFG_COMPANY_UOM_MAP"; }
        }
        #endregion
        #region Properties
        public string COMPANY_CODE { get; set; }
        public string UOM_NAME { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string COMPANY_CODE = CfgCompanyUomMap.TableName + ".COMPANY_CODE";
            public static string UOM_NAME = CfgCompanyUomMap.TableName + ".UOM_NAME";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string UOM_NAME = "UOM_NAME";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCompanyUomMap.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCompanyUomMap.ColumnNames.UOM_NAME, "UOM_NAME");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string UOM_NAME = "UOM_NAME";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_UOM_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(UOM_NAME)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.UOM_NAME; }
        }
        #endregion
    }
}
