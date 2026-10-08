
using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUomHis
    {
        public CfgUomHis()
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
            get { return "CFG_UOM_HIS"; }
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
            public static string CFG_UOM_HIS_ID = CfgUomHis.TableName + ".CFG_UOM_HIS_ID";
            public static string CFG_UOM_HIS_USER_ID = CfgUomHis.TableName + ".CFG_UOM_HIS_USER_ID";
            public static string CFG_UOM_HIS_DELEGATE = CfgUomHis.TableName + ".CFG_UOM_HIS_DELEGATE";
            public static string CFG_UOM_HIS_DATE = CfgUomHis.TableName + ".CFG_UOM_HIS_DATE";
            public static string CFG_UOM_ID = CfgUomHis.TableName + ".CFG_UOM_ID";
            public static string UOM_NAME = CfgUomHis.TableName + ".UOM_NAME";
            public static string UOM_DESCRIPTION = CfgUomHis.TableName + ".UOM_DESCRIPTION";
            public static string ACTIVE = CfgUomHis.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_UOM_HIS_ID = "CFG_UOM_HIS_ID";
            public static string CFG_UOM_HIS_USER_ID = "CFG_UOM_HIS_USER_ID";
            public static string CFG_UOM_HIS_DELEGATE = "CFG_UOM_HIS_DELEGATE";
            public static string CFG_UOM_HIS_DATE = "CFG_UOM_HIS_DATE";
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
            map.Add(CfgUomHis.ColumnNames.CFG_UOM_HIS_ID, "CFG_UOM_HIS_ID");
            map.Add(CfgUomHis.ColumnNames.CFG_UOM_HIS_USER_ID, "CFG_UOM_HIS_USER_ID");
            map.Add(CfgUomHis.ColumnNames.CFG_UOM_HIS_DELEGATE, "CFG_UOM_HIS_DELEGATE");
            map.Add(CfgUomHis.ColumnNames.CFG_UOM_HIS_DATE, "CFG_UOM_HIS_DATE");
            map.Add(CfgUomHis.ColumnNames.CFG_UOM_ID, "CFG_UOM_ID");
            map.Add(CfgUomHis.ColumnNames.UOM_NAME, "UOM_NAME");
            map.Add(CfgUomHis.ColumnNames.UOM_DESCRIPTION, "UOM_DESCRIPTION");
            map.Add(CfgUomHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
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

        public string Formatted_CFG_UOM_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUomHis.ColumnNames.CFG_UOM_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_UOM_HIS_ID; }
        }
        #endregion
    }
}
