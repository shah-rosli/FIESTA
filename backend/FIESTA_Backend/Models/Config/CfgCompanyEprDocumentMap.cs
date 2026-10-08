
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgCompanyEprDocumentMap
    {
        public CfgCompanyEprDocumentMap()
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
            get { return "CFG_COMPANY_EPR_DOCUMENT_MAP"; }
        }
        #endregion
        #region Properties
        public string COMPANY_CODE { get; set; }
        public string EPR_DOCUMENT_NAME { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string COMPANY_CODE = CfgCompanyEprDocumentMap.TableName + ".COMPANY_CODE";
            public static string EPR_DOCUMENT_NAME = CfgCompanyEprDocumentMap.TableName + ".EPR_DOCUMENT_NAME";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string EPR_DOCUMENT_NAME = "EPR_DOCUMENT_NAME";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCompanyEprDocumentMap.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCompanyEprDocumentMap.ColumnNames.EPR_DOCUMENT_NAME, "EPR_DOCUMENT_NAME");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string EPR_DOCUMENT_NAME = "EPR_DOCUMENT_NAME";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_EPR_DOCUMENT_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_DOCUMENT_NAME)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.EPR_DOCUMENT_NAME; }
        }
        #endregion
    }
}
