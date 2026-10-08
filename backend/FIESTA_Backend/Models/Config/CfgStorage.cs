
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgStorage
    {
        public CfgStorage()
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
            get { return "CFG_STORAGE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_STORAGE_ID { get; set; }
        public decimal CFG_PLANT_ID { get; set; }
        public string CFG_STORAGE_NAME { get; set; }
        public string CFG_STORAGE_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_STORAGE_ID = CfgStorage.TableName + ".CFG_STORAGE_ID";
            public static string CFG_PLANT_ID = CfgStorage.TableName + ".CFG_PLANT_ID";
            public static string CFG_STORAGE_NAME = CfgStorage.TableName + ".CFG_STORAGE_NAME";
            public static string CFG_STORAGE_DESCRIPTION = CfgStorage.TableName + ".CFG_STORAGE_DESCRIPTION";
            public static string ACTIVE = CfgStorage.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_STORAGE_ID = "CFG_STORAGE_ID";
            public static string CFG_PLANT_ID = "CFG_PLANT_ID";
            public static string CFG_STORAGE_NAME = "CFG_STORAGE_NAME";
            public static string CFG_STORAGE_DESCRIPTION = "CFG_STORAGE_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgStorage.ColumnNames.CFG_STORAGE_ID, "CFG_STORAGE_ID");
            map.Add(CfgStorage.ColumnNames.CFG_PLANT_ID, "CFG_PLANT_ID");
            map.Add(CfgStorage.ColumnNames.CFG_STORAGE_NAME, "CFG_STORAGE_NAME");
            map.Add(CfgStorage.ColumnNames.CFG_STORAGE_DESCRIPTION, "CFG_STORAGE_DESCRIPTION");
            map.Add(CfgStorage.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_STORAGE_ID = "CFG_STORAGE_ID";
            public static string CFG_PLANT_ID = "CFG_PLANT_ID";
            public static string CFG_STORAGE_NAME = "CFG_STORAGE_NAME";
            public static string CFG_STORAGE_DESCRIPTION = "CFG_STORAGE_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_STORAGE_ID
        {
            get { return string.Format("'{0}'", CFG_STORAGE_ID); }
        }
        public string Formatted_CFG_PLANT_ID
        {
            get { return string.Format("'{0}'", CFG_PLANT_ID); }
        }
        public string Formatted_CFG_STORAGE_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_STORAGE_NAME)); }
        }
        public string Formatted_CFG_STORAGE_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(CFG_STORAGE_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_STORAGE_ID; }
        }
        #endregion
    }
}
