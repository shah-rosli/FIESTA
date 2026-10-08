
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
    public class CfgEprDocumentTypeHis
    {

        public CfgEprDocumentTypeHis()
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
            get { return "CFG_EPR_DOCUMENT_TYPE_HIS"; }
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
            public static string CFG_DOCUMENT_TYPE_HIS_ID = CfgEprDocumentTypeHis.TableName + ".CFG_DOCUMENT_TYPE_HIS_ID";
            public static string CFG_DOCUMENT_TYPE_HIS_USER_ID = CfgEprDocumentTypeHis.TableName + ".CFG_DOCUMENT_TYPE_HIS_USER_ID";
            public static string CFG_DOCUMENT_TYPE_HIS_DELEGATE = CfgEprDocumentTypeHis.TableName + ".CFG_DOCUMENT_TYPE_HIS_DELEGATE";
            public static string CFG_DOCUMENT_TYPE_HIS_DATE = CfgEprDocumentTypeHis.TableName + ".CFG_DOCUMENT_TYPE_HIS_DATE";
            public static string CFG_EPR_DOCUMENT_TYPE_ID = CfgEprDocumentTypeHis.TableName + ".CFG_EPR_DOCUMENT_TYPE_ID";
            public static string EPR_DOCUMENT_NAME = CfgEprDocumentTypeHis.TableName + ".EPR_DOCUMENT_NAME";
            public static string EPR_DOCUMENT_DESCRIPTION = CfgEprDocumentTypeHis.TableName + ".EPR_DOCUMENT_DESCRIPTION";
            public static string ACTIVE = CfgEprDocumentTypeHis.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_DOCUMENT_TYPE_HIS_ID = "CFG_DOCUMENT_TYPE_HIS_ID";
            public static string CFG_DOCUMENT_TYPE_HIS_USER_ID = "CFG_DOCUMENT_TYPE_HIS_USER_ID";
            public static string CFG_DOCUMENT_TYPE_HIS_DELEGATE = "CFG_DOCUMENT_TYPE_HIS_DELEGATE";
            public static string CFG_DOCUMENT_TYPE_HIS_DATE = "CFG_DOCUMENT_TYPE_HIS_DATE";
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
            map.Add(CfgEprDocumentTypeHis.ColumnNames.CFG_DOCUMENT_TYPE_HIS_ID, "CFG_DOCUMENT_TYPE_HIS_ID");
            map.Add(CfgEprDocumentTypeHis.ColumnNames.CFG_DOCUMENT_TYPE_HIS_USER_ID, "CFG_DOCUMENT_TYPE_HIS_USER_ID");
            map.Add(CfgEprDocumentTypeHis.ColumnNames.CFG_DOCUMENT_TYPE_HIS_DELEGATE, "CFG_DOCUMENT_TYPE_HIS_DELEGATE");
            map.Add(CfgEprDocumentTypeHis.ColumnNames.CFG_DOCUMENT_TYPE_HIS_DATE, "CFG_DOCUMENT_TYPE_HIS_DATE");            
            map.Add(CfgEprDocumentTypeHis.ColumnNames.CFG_EPR_DOCUMENT_TYPE_ID, "CFG_EPR_DOCUMENT_TYPE_ID");
            map.Add(CfgEprDocumentTypeHis.ColumnNames.EPR_DOCUMENT_NAME, "EPR_DOCUMENT_NAME");
            map.Add(CfgEprDocumentTypeHis.ColumnNames.EPR_DOCUMENT_DESCRIPTION, "EPR_DOCUMENT_DESCRIPTION");
            map.Add(CfgEprDocumentTypeHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_DOCUMENT_TYPE_HIS_ID = "CFG_DOCUMENT_TYPE_HIS_ID";
            public static string CFG_DOCUMENT_TYPE_HIS_USER_ID = "CFG_DOCUMENT_TYPE_HIS_USER_ID";
            public static string CFG_DOCUMENT_TYPE_HIS_DELEGATE = "CFG_DOCUMENT_TYPE_HIS_DELEGATE";
            public static string CFG_DOCUMENT_TYPE_HIS_DATE = "CFG_DOCUMENT_TYPE_HIS_DATE";            
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

        public string Formatted_CFG_DOCUMENT_TYPE_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprDocumentTypeHis.ColumnNames.CFG_DOCUMENT_TYPE_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_DOCUMENT_TYPE_HIS_ID; }
        }
        #endregion
    }
}
