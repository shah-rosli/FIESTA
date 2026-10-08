
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FIESTA_Backend.Models.Common;
using FIESTA_Backend.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgEprCategory
    {
        public CfgEprCategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region static variable
        public static string PRCategory_ApprovalOnly = "Approval Only";
        public static string PRCategory_PR_Without_PO = "PR without PO";

        #endregion
        #region TableName
        public static string TableName
        {
            get { return "CFG_EPR_CATEGORY"; }
        }
        #endregion
        #region Properties
        public decimal CFG_EPR_CATEGORY_ID { get; set; }
        public string EPR_CATEGORY_NAME { get; set; }
        public string EPR_CATEGORY_DESCRIPTION { get; set; }
        public string ACTIVE { get; set; }
        public string FIN_REVIEW_GROUP { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_EPR_CATEGORY_ID = CfgEprCategory.TableName + ".CFG_EPR_CATEGORY_ID";
            public static string EPR_CATEGORY_NAME = CfgEprCategory.TableName + ".EPR_CATEGORY_NAME";
            public static string EPR_CATEGORY_DESCRIPTION = CfgEprCategory.TableName + ".EPR_CATEGORY_DESCRIPTION";
            public static string FIN_REVIEW_GROUP = CfgEprCategory.TableName + ".FIN_REVIEW_GROUP";
            public static string ACTIVE = CfgEprCategory.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_CATEGORY_ID = "CFG_EPR_CATEGORY_ID";
            public static string EPR_CATEGORY_NAME = "EPR_CATEGORY_NAME";
            public static string EPR_CATEGORY_DESCRIPTION = "EPR_CATEGORY_DESCRIPTION";
            public static string FIN_REVIEW_GROUP = "FIN_REVIEW_GROUP";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprCategory.ColumnNames.CFG_EPR_CATEGORY_ID, "CFG_EPR_CATEGORY_ID");
            map.Add(CfgEprCategory.ColumnNames.EPR_CATEGORY_NAME, "EPR_CATEGORY_NAME");
            map.Add(CfgEprCategory.ColumnNames.FIN_REVIEW_GROUP, "FIN_REVIEW_GROUP");
            map.Add(CfgEprCategory.ColumnNames.EPR_CATEGORY_DESCRIPTION, "EPR_CATEGORY_DESCRIPTION");
            map.Add(CfgEprCategory.ColumnNames.ACTIVE, "ACTIVE");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_EPR_CATEGORY_ID = "CFG_EPR_CATEGORY_ID";
            public static string EPR_CATEGORY_NAME = "EPR_CATEGORY_NAME";
            public static string EPR_CATEGORY_DESCRIPTION = "EPR_CATEGORY_DESCRIPTION";
            public static string FIN_REVIEW_GROUP = "FIN_REVIEW_GROUP";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_EPR_CATEGORY_ID
        {
            get { return string.Format("'{0}'", CFG_EPR_CATEGORY_ID); }
        }
        public string Formatted_EPR_CATEGORY_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_CATEGORY_NAME)); }
        }
        public string Formatted_EPR_CATEGORY_DESCRIPTION
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(EPR_CATEGORY_DESCRIPTION)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }
        public string Formatted_FIN_REVIEW_GROUP
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(FIN_REVIEW_GROUP)); }
        }
        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_EPR_CATEGORY_ID; }
        }
        #endregion
    }
}
