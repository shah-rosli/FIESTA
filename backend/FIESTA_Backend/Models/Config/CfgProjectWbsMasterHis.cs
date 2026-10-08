
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
    public class CfgProjectWbsMasterHis
    {
        public CfgProjectWbsMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_PROJECT_WBS_MASTER_HIS"; }
        }

        #region Properties       

        public decimal CFG_WBS_PROJECT_ID { get; set; }
        public string CFG_WBS_PROJECT_NAME { get; set; }
        public string CFG_WBS_PROJECT_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }

        public string USER_ID { get; set; }


        public TokenProperties? TokenObj { get; set; }


        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_PROJECT_WBS_MASTER_HIS_ID = CfgProjectWbsMasterHis.TableName + ".CFG_PROJECT_WBS_MASTER_HIS_ID";
            public static string CFG_PROJECT_WBS_HIS_USER_ID = CfgProjectWbsMasterHis.TableName + ".CFG_PROJECT_WBS_HIS_USER_ID";
            public static string CFG_PROJECT_WBS_HIS_DELEGATE = CfgProjectWbsMasterHis.TableName + ".CFG_PROJECT_WBS_HIS_DELEGATE";
            public static string CFG_PROJECT_WBS_HIS_DATE = CfgProjectWbsMasterHis.TableName + ".CFG_PROJECT_WBS_HIS_DATE";
            public static string CFG_WBS_PROJECT_ID = CfgProjectWbsMasterHis.TableName + ".CFG_WBS_PROJECT_ID";
            public static string CFG_WBS_PROJECT_NAME = CfgProjectWbsMasterHis.TableName + ".CFG_WBS_PROJECT_NAME";
            public static string CFG_WBS_PROJECT_DESCRIPTION = CfgProjectWbsMasterHis.TableName + ".CFG_WBS_PROJECT_DESCRIPTION";
            public static string COMPANY_CODE = CfgProjectWbsMasterHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgProjectWbsMasterHis.TableName + ".ACTIVE";

        }
        #endregion

      

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_WBS_PROJECT_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_WBS_PROJECT_NAME)); }
        }
        public string Formatted_CFG_WBS_PROJECT_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_WBS_PROJECT_DESCRIPTION)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_CFG_PROJECT_WBS_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgProjectWbsMasterHis.ColumnNames.CFG_PROJECT_WBS_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }

        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_PROJECT_WBS_MASTER_HIS_ID, "CFG_PROJECT_WBS_MASTER_HIS_ID");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_PROJECT_WBS_HIS_USER_ID, "CFG_PROJECT_WBS_HIS_USER_ID");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_PROJECT_WBS_HIS_DELEGATE, "CFG_PROJECT_WBS_HIS_DELEGATE");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_PROJECT_WBS_HIS_DATE, "CFG_PROJECT_WBS_HIS_DATE");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_WBS_PROJECT_ID, "CFG_WBS_PROJECT_ID");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_WBS_PROJECT_NAME, "CFG_WBS_PROJECT_NAME");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.CFG_WBS_PROJECT_DESCRIPTION, "CFG_WBS_PROJECT_DESCRIPTION");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgProjectWbsMasterHis.ColumnNames.ACTIVE, "ACTIVE");

            return map;
        }
        #endregion
    }
}
