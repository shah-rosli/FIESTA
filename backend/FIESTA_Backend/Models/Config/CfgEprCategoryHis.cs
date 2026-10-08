
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
    public class CfgEprCategoryHis
    {
        public CfgEprCategoryHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       
        
        #region TableName
        public static string TableName
        {
            get { return "CFG_EPR_CATEGORY_HIS"; }
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
            public static string CFG_EPR_CATEGORY_HIS_ID = CfgEprCategoryHis.TableName + ".CFG_EPR_CATEGORY_HIS_ID";
            public static string CFG_EPR_CATEGORY_HIS_USER_ID = CfgEprCategoryHis.TableName + ".CFG_EPR_CATEGORY_HIS_USER_ID";
            public static string CFG_EPR_CATEGORY_HIS_DELEGATE = CfgEprCategoryHis.TableName + ".CFG_EPR_CATEGORY_HIS_DELEGATE"; 
            public static string CFG_EPR_CATEGORY_HIS_DATE = CfgEprCategoryHis.TableName + ".CFG_EPR_CATEGORY_HIS_DATE";
            public static string CFG_EPR_CATEGORY_ID = CfgEprCategoryHis.TableName + ".CFG_EPR_CATEGORY_ID";
            public static string EPR_CATEGORY_NAME = CfgEprCategoryHis.TableName + ".EPR_CATEGORY_NAME";
            public static string EPR_CATEGORY_DESCRIPTION = CfgEprCategoryHis.TableName + ".EPR_CATEGORY_DESCRIPTION";
            public static string FIN_REVIEW_GROUP = CfgEprCategoryHis.TableName + ".FIN_REVIEW_GROUP";
            public static string ACTIVE = CfgEprCategoryHis.TableName + ".ACTIVE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_EPR_CATEGORY_HIS_ID = "CFG_EPR_CATEGORY_HIS_ID";
            public static string CFG_EPR_CATEGORY_HIS_USER_ID = "CFG_EPR_CATEGORY_HIS_USER_ID";
            public static string CFG_EPR_CATEGORY_HIS_DELEGATE = "CFG_EPR_CATEGORY_HIS_DELEGATE";
            public static string CFG_EPR_CATEGORY_HIS_DATE = "CFG_EPR_CATEGORY_HIS_DATE";
            public static string CFG_EPR_CATEGORY_ID = "CFG_EPR_CATEGORY_ID";
            public static string EPR_CATEGORY_NAME = "EPR_CATEGORY_NAME";
            public static string EPR_CATEGORY_DESCRIPTION = "EPR_CATEGORY_DESCRIPTION";
            public static string ACTIVE = "ACTIVE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgEprCategoryHis.ColumnNames.CFG_EPR_CATEGORY_HIS_ID, "CFG_EPR_CATEGORY_HIS_ID");
            map.Add(CfgEprCategoryHis.ColumnNames.CFG_EPR_CATEGORY_HIS_USER_ID, "CFG_EPR_CATEGORY_HIS_USER_ID");
            map.Add(CfgEprCategoryHis.ColumnNames.CFG_EPR_CATEGORY_HIS_DELEGATE, "CFG_EPR_CATEGORY_HIS_DELEGATE");
            map.Add(CfgEprCategoryHis.ColumnNames.CFG_EPR_CATEGORY_HIS_DATE, "CFG_EPR_CATEGORY_HIS_DATE");            
            map.Add(CfgEprCategoryHis.ColumnNames.CFG_EPR_CATEGORY_ID, "CFG_EPR_CATEGORY_ID");
            map.Add(CfgEprCategoryHis.ColumnNames.EPR_CATEGORY_NAME, "EPR_CATEGORY_NAME");
            map.Add(CfgEprCategoryHis.ColumnNames.EPR_CATEGORY_DESCRIPTION, "EPR_CATEGORY_DESCRIPTION");
            map.Add(CfgEprCategoryHis.ColumnNames.FIN_REVIEW_GROUP, "FIN_REVIEW_GROUP");
            map.Add(CfgEprCategoryHis.ColumnNames.ACTIVE, "ACTIVE");
            return map;
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

        public string Formatted_CFG_EPR_CATEGORY_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgEprCategoryHis.ColumnNames.CFG_EPR_CATEGORY_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

    }
}
