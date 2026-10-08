
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUom
    {
        public CfgUom()
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
            get { return "CFG_UOM"; }
        }
        #endregion
        #region Properties
        public decimal CFG_UOM_ID { get; set; }
        public string UOM_NAME { get; set; }
        public string UOM_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_UOM_ID = CfgUom.TableName + ".CFG_UOM_ID";
            public static string UOM_NAME = CfgUom.TableName + ".UOM_NAME";
            public static string UOM_DESCRIPTION = CfgUom.TableName + ".UOM_DESCRIPTION";
            public static string ACTIVE = CfgUom.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_UOM_ID = "CFG_UOM_ID";
            public static string UOM_NAME = "UOM_NAME";
            public static string UOM_DESCRIPTION = "UOM_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUom.ColumnNames.CFG_UOM_ID, "CFG_UOM_ID");
            map.Add(CfgUom.ColumnNames.UOM_NAME, "UOM_NAME");
            map.Add(CfgUom.ColumnNames.UOM_DESCRIPTION, "UOM_DESCRIPTION");
            map.Add(CfgUom.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_UOM_ID = "CFG_UOM_ID";
            public static string UOM_NAME = "UOM_NAME";
            public static string UOM_DESCRIPTION = "UOM_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_UOM_ID
        {
            get { return string.Format("'{0}'", CFG_UOM_ID); }
        }
        public string Formatted_UOM_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(UOM_NAME)); }
        }
        public string Formatted_UOM_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(UOM_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_UOM_ID; }
        }
        #endregion
    }
}
