
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgEprInspCode
    {
        public CfgEprInspCode()
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
            get { return "CFG_EPR_INSP_CODE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_EPR_INSP_CODE_ID { get; set; }
        public string EPR_INSP_CODE_NAME { get; set; }
        public string EPR_INSP_CODE_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_INSP_CODE_ID = CfgEprInspCode.TableName + ".CFG_EPR_INSP_CODE_ID";
            public static string EPR_INSP_CODE_NAME = CfgEprInspCode.TableName + ".EPR_INSP_CODE_NAME";
            public static string EPR_INSP_CODE_DESCRIPTION = CfgEprInspCode.TableName + ".EPR_INSP_CODE_DESCRIPTION";
            public static string ACTIVE = CfgEprInspCode.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_INSP_CODE_ID = "CFG_EPR_INSP_CODE_ID";
            public static string EPR_INSP_CODE_NAME = "EPR_INSP_CODE_NAME";
            public static string EPR_INSP_CODE_DESCRIPTION = "EPR_INSP_CODE_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprInspCode.ColumnNames.CFG_EPR_INSP_CODE_ID, "CFG_EPR_INSP_CODE_ID");
            map.Add(CfgEprInspCode.ColumnNames.EPR_INSP_CODE_NAME, "EPR_INSP_CODE_NAME");
            map.Add(CfgEprInspCode.ColumnNames.EPR_INSP_CODE_DESCRIPTION, "EPR_INSP_CODE_DESCRIPTION");
            map.Add(CfgEprInspCode.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_EPR_INSP_CODE_ID = "CFG_EPR_INSP_CODE_ID";
            public static string EPR_INSP_CODE_NAME = "EPR_INSP_CODE_NAME";
            public static string EPR_INSP_CODE_DESCRIPTION = "EPR_INSP_CODE_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_EPR_INSP_CODE_ID
        {
            get { return string.Format("'{0}'", CFG_EPR_INSP_CODE_ID); }
        }
        public string Formatted_EPR_INSP_CODE_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_INSP_CODE_NAME)); }
        }
        public string Formatted_EPR_INSP_CODE_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_INSP_CODE_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_EPR_INSP_CODE_ID; }
        }
        #endregion
    }
}