
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgEprDocumentType
    {
        public CfgEprDocumentType()
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
            get { return "CFG_EPR_DOCUMENT_TYPE"; }
        }
        #endregion
        #region Properties
        public decimal CFG_EPR_DOCUMENT_TYPE_ID { get; set; }
        public string EPR_DOCUMENT_NAME { get; set; }
        public string EPR_DOCUMENT_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_DOCUMENT_TYPE_ID = CfgEprDocumentType.TableName + ".CFG_EPR_DOCUMENT_TYPE_ID";
            public static string EPR_DOCUMENT_NAME = CfgEprDocumentType.TableName + ".EPR_DOCUMENT_NAME";
            public static string EPR_DOCUMENT_DESCRIPTION = CfgEprDocumentType.TableName + ".EPR_DOCUMENT_DESCRIPTION";
            public static string ACTIVE = CfgEprDocumentType.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_DOCUMENT_TYPE_ID = "CFG_EPR_DOCUMENT_TYPE_ID";
            public static string EPR_DOCUMENT_NAME = "EPR_DOCUMENT_NAME";
            public static string EPR_DOCUMENT_DESCRIPTION = "EPR_DOCUMENT_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprDocumentType.ColumnNames.CFG_EPR_DOCUMENT_TYPE_ID, "CFG_EPR_DOCUMENT_TYPE_ID");
            map.Add(CfgEprDocumentType.ColumnNames.EPR_DOCUMENT_NAME, "EPR_DOCUMENT_NAME");
            map.Add(CfgEprDocumentType.ColumnNames.EPR_DOCUMENT_DESCRIPTION, "EPR_DOCUMENT_DESCRIPTION");
            map.Add(CfgEprDocumentType.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_EPR_DOCUMENT_TYPE_ID = "CFG_EPR_DOCUMENT_TYPE_ID";
            public static string EPR_DOCUMENT_NAME = "EPR_DOCUMENT_NAME";
            public static string EPR_DOCUMENT_DESCRIPTION = "EPR_DOCUMENT_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_EPR_DOCUMENT_TYPE_ID
        {
            get { return string.Format("'{0}'", CFG_EPR_DOCUMENT_TYPE_ID); }
        }
        public string Formatted_EPR_DOCUMENT_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_DOCUMENT_NAME)); }
        }
        public string Formatted_EPR_DOCUMENT_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_DOCUMENT_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_EPR_DOCUMENT_TYPE_ID; }
        }
        #endregion
    }
}
