
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
    public class CfgCostCenterMasterHis
    {
        public CfgCostCenterMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_COST_CENTER_MASTER_HIS"; }
        }

       
        #region Properties       

        public decimal CFG_COST_CENTER_ID { get; set; }
        public string CFG_COST_CENTER_NAME { get; set; }
        public string CFG_COST_CENTER_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }
        public string COST_CENTER_OWNER { get; set; }
        public string COST_CENTER_FINANCE_OWNER { get; set; }


        public TokenProperties? TokenObj { get; set; }



        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_COST_CENTER_HIS_ID = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_HIS_ID";
            public static string CFG_COST_CENTER_HIS_USER_ID = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_HIS_USER_ID";
            public static string CFG_COST_CENTER_HIS_DELEGATE = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_HIS_DELEGATE";
            public static string CFG_COST_CENTER_HIS_DATE = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_HIS_DATE";
            public static string CFG_COST_CENTER_ID = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_ID";
            public static string CFG_COST_CENTER_NAME = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_NAME";
            public static string CFG_COST_CENTER_DESCRIPTION = CfgCostCenterMasterHis.TableName + ".CFG_COST_CENTER_DESCRIPTION";
            public static string COMPANY_CODE = CfgCostCenterMasterHis.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CfgCostCenterMasterHis.TableName + ".ACTIVE";
            public static string COST_CENTER_OWNER = CfgCostCenterMasterHis.TableName + ".COST_CENTER_OWNER";
            public static string COST_CENTER_FINANCE_OWNER = CfgCostCenterMasterHis.TableName + ".COST_CENTER_FINANCE_OWNER";
            public static string CC_ACD_SENIOR_MGR = CfgCostCenterMasterHis.TableName + ".CC_ACD_SENIOR_MGR";
            public static string CC_ACD_DIRECTOR = CfgCostCenterMasterHis.TableName + ".CC_ACD_DIRECTOR";
            public static string CC_ACD_VP = CfgCostCenterMasterHis.TableName + ".CC_ACD_VP";
            public static string CC_ASSET_REVIEWER = CfgCostCenterMasterHis.TableName + ".CC_ASSET_REVIEWER";
        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_COST_CENTER_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_COST_CENTER_NAME)); }
        }
        public string Formatted_CFG_COST_CENTER_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_COST_CENTER_DESCRIPTION)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }
        public string Formatted_COST_CENTER_OWNER
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COST_CENTER_OWNER)); }
        }
        public string Formatted_COST_CENTER_FINANCE_OWNER
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COST_CENTER_FINANCE_OWNER)); }
        }
        public string Formatted_CFG_COST_CENTER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }


        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_ID, "CFG_COST_CENTER_HIS_ID");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_ID, "CFG_COST_CENTER_HIS_USER_ID");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_ID, "CFG_COST_CENTER_HIS_DELEGATE");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_ID, "CFG_COST_CENTER_HIS_DATE");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_ID, "CFG_COST_CENTER_ID");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_DESCRIPTION, "CFG_COST_CENTER_DESCRIPTION");
            map.Add(CfgCostCenterMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CFG_COST_CENTER_NAME, "CFG_COST_CENTER_NAME");
            map.Add(CfgCostCenterMasterHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgCostCenterMasterHis.ColumnNames.COST_CENTER_OWNER, "COST_CENTER_OWNER");
            map.Add(CfgCostCenterMasterHis.ColumnNames.COST_CENTER_FINANCE_OWNER, "COST_CENTER_FINANCE_OWNER");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CC_ACD_SENIOR_MGR, "CC_ACD_SENIOR_MGR");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CC_ACD_DIRECTOR, "CC_ACD_DIRECTOR");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CC_ACD_VP, "CC_ACD_VP");
            map.Add(CfgCostCenterMasterHis.ColumnNames.CC_ASSET_REVIEWER, "CC_ASSET_REVIEWER");

            return map;
        }
        #endregion
    }
}
