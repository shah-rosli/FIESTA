
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgPlant
    {
        public CfgPlant()
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
            get { return "CFG_PLANT"; }
        }
        #endregion
        #region Properties
        public decimal CFG_PLANT_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string CFG_PLANT_NAME { get; set; }
        public string CFG_PLANT_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        public ArrayList arStorage { get; set; }
        public System.Data.EnumerableRowCollection enStorage { get; set; }
        public TokenProperties? TokenObj { get; set; }


        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_PLANT_ID = CfgPlant.TableName + ".CFG_PLANT_ID";
            public static string COMPANY_CODE = CfgPlant.TableName + ".COMPANY_CODE";
            public static string CFG_PLANT_NAME = CfgPlant.TableName + ".CFG_PLANT_NAME";
            public static string CFG_PLANT_DESCRIPTION = CfgPlant.TableName + ".CFG_PLANT_DESCRIPTION";
            public static string ACTIVE = CfgPlant.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_PLANT_ID = "CFG_PLANT_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string CFG_PLANT_NAME = "CFG_PLANT_NAME";
            public static string CFG_PLANT_DESCRIPTION = "CFG_PLANT_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgPlant.ColumnNames.CFG_PLANT_ID, "CFG_PLANT_ID");
            map.Add(CfgPlant.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgPlant.ColumnNames.CFG_PLANT_NAME, "CFG_PLANT_NAME");
            map.Add(CfgPlant.ColumnNames.CFG_PLANT_DESCRIPTION, "CFG_PLANT_DESCRIPTION");
            map.Add(CfgPlant.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_PLANT_ID = "CFG_PLANT_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string CFG_PLANT_NAME = "CFG_PLANT_NAME";
            public static string CFG_PLANT_DESCRIPTION = "CFG_PLANT_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_PLANT_ID
        {
            get { return string.Format("'{0}'", CFG_PLANT_ID); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_CFG_PLANT_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_PLANT_NAME)); }
        }
        public string Formatted_CFG_PLANT_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_PLANT_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_PLANT_ID; }
        }
        #endregion
    }
}
