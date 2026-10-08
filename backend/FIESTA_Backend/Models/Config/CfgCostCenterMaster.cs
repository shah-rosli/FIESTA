
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
    public class CostCenterMaster
    {
        public CostCenterMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_COST_CENTER_MASTER"; }
        }

        public static string CC_GL_TableName
        {
            get { return "CFG_GL_COST_CENT_MASTER"; }
        }

        #region Properties       

        public decimal CFG_COST_CENTER_ID { get; set; }
        public string CFG_COST_CENTER_NAME { get; set; }
        public string CFG_COST_CENTER_DESCRIPTION { get; set; }
        public string COMPANY_CODE { get; set; }      
        public string ACTIVE { get; set; }
        public string COST_CENTER_OWNER { get; set; }
        public string COST_CENTER_FINANCE_OWNER { get; set; }
        public string CC_ACD_SENIOR_MGR { get; set; }
        public string CC_ACD_DIRECTOR { get; set; }
        public string CC_ACD_VP { get; set; }

        public string CC_ASSET_REVIEWER { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_COST_CENTER_ID = CostCenterMaster.TableName + ".CFG_COST_CENTER_ID";
            public static string CFG_COST_CENTER_NAME = CostCenterMaster.TableName + ".CFG_COST_CENTER_NAME";
            public static string CFG_COST_CENTER_DESCRIPTION = CostCenterMaster.TableName + ".CFG_COST_CENTER_DESCRIPTION";
            public static string COMPANY_CODE = CostCenterMaster.TableName + ".COMPANY_CODE";
            public static string ACTIVE = CostCenterMaster.TableName + ".ACTIVE";
            public static string COST_CENTER_OWNER = CostCenterMaster.TableName + ".COST_CENTER_OWNER";
            public static string COST_CENTER_FINANCE_OWNER = CostCenterMaster.TableName + ".COST_CENTER_FINANCE_OWNER";
            public static string CC_ACD_SENIOR_MGR = CostCenterMaster.TableName + ".CC_ACD_SENIOR_MGR";
            public static string CC_ACD_DIRECTOR = CostCenterMaster.TableName + ".CC_ACD_DIRECTOR";
            public static string CC_ACD_VP = CostCenterMaster.TableName + ".CC_ACD_VP";
            public static string CC_ASSET_REVIEWER = CostCenterMaster.TableName + ".CC_ASSET_REVIEWER";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_COST_CENTER_ID = "CFG_COST_CENTER_ID";
            public static string CFG_COST_CENTER_NAME = "CFG_COST_CENTER_NAME";
            public static string CFG_COST_CENTER_DESCRIPTION = "CFG_COST_CENTER_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string ACTIVE = "ACTIVE";
            public static string COST_CENTER_OWNER = "COST_CENTER_OWNER";
            public static string COST_CENTER_FINANCE_OWNER = "COST_CENTER_FINANCE_OWNER";
            public static string CC_ACD_SENIOR_MGR = "CC_ACD_SENIOR_MGR";
            public static string CC_ACD_DIRECTOR = "CC_ACD_DIRECTOR";
            public static string CC_ACD_VP = "CC_ACD_VP";
            public static string CC_ASSET_REVIEWER = "CC_ASSET_REVIEWER";
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

        public string Formatted_CC_ACD_SENIOR_MGR
        {
            get
            {
                return string.Format("{0}", DataConverter.FormatSQL(CC_ACD_SENIOR_MGR));
            }
        }

        public string Formatted_CC_ACD_DIRECTOR
        {
            get
            {
                return string.Format("{0}", DataConverter.FormatSQL(CC_ACD_DIRECTOR));
            }
        }

        public string Formatted_CC_ACD_VP
        {
            get
            {
                return string.Format("{0}", DataConverter.FormatSQL(CC_ACD_VP));
            }
        }

        public string Formatted_CC_ASSET_REVIEWER
        {
            get
            {
                return string.Format("{0}", DataConverter.FormatSQL(CC_ASSET_REVIEWER));
            }
        }

        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CostCenterMaster.ColumnNames.CFG_COST_CENTER_ID, "CFG_COST_CENTER_ID");
            map.Add(CostCenterMaster.ColumnNames.CFG_COST_CENTER_DESCRIPTION, "CFG_COST_CENTER_DESCRIPTION");
            map.Add(CostCenterMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CostCenterMaster.ColumnNames.CFG_COST_CENTER_NAME, "CFG_COST_CENTER_NAME");
            map.Add(CostCenterMaster.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CostCenterMaster.ColumnNames.COST_CENTER_OWNER, "COST_CENTER_OWNER");
            map.Add(CostCenterMaster.ColumnNames.COST_CENTER_FINANCE_OWNER, "COST_CENTER_FINANCE_OWNER");
            map.Add(CostCenterMaster.ColumnNames.CC_ACD_SENIOR_MGR, "CC_ACD_SENIOR_MGR");
            map.Add(CostCenterMaster.ColumnNames.CC_ACD_DIRECTOR, "CC_ACD_DIRECTOR");
            map.Add(CostCenterMaster.ColumnNames.CC_ACD_VP, "CC_ACD_VP");
            map.Add(CostCenterMaster.ColumnNames.CC_ASSET_REVIEWER, "CC_ASSET_REVIEWER");

            return map;
        }
        #endregion


       
    }
}