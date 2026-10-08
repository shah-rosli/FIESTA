
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
    public class CfgCPXMasterHis
    {
        public CfgCPXMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_CPX_MASTER_HIS"; }
        }

        #region Properties
      
        public decimal CFG_CPX_MASTER_ID { get; set; }
        public string CPX_NUMBER { get; set; }
        public string CPX_DESCRIPTION { get; set; }
        public string CPX_YEAR { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ACTIVE { get; set; }
        public string PROLONG_CAPEX_USE { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string CFG_COST_CENTER_NAME { get; set; }
        public decimal CPX_BUDGET_AMOUNT { get; set; }
        public string CPX_EQUIP_JIGTOOL { get; set; }
        public string CPX_CATEGORY { get; set; }
        public DateTime CPX_APPROVAL_TARGET { get; set; }

        public TokenProperties? TokenObj { get; set; }



        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_CPX_MASTER_HIS_ID = CfgCPXMasterHis.TableName + ".CFG_CPX_MASTER_HIS_ID";
            public static string CFG_CPX_MASTER_HIS_USER_ID = CfgCPXMasterHis.TableName + ".CFG_CPX_MASTER_HIS_USER_ID";
            public static string CFG_CPX_MASTER_HIS_DELEGATE = CfgCPXMasterHis.TableName + ".CFG_CPX_MASTER_HIS_DELEGATE";
            public static string CFG_CPX_MASTER_HIS_DATE = CfgCPXMasterHis.TableName + ".CFG_CPX_MASTER_HIS_DATE";
            public static string CFG_CPX_MASTER_ID = CfgCPXMasterHis.TableName + ".CFG_CPX_MASTER_ID";
            public static string CPX_NUMBER = CfgCPXMasterHis.TableName + ".CPX_NUMBER";
            public static string CPX_DESCRIPTION = CfgCPXMasterHis.TableName + ".CPX_DESCRIPTION";
            public static string COMPANY_CODE = CfgCPXMasterHis.TableName + ".COMPANY_CODE";
            public static string CPX_YEAR = CfgCPXMasterHis.TableName + ".CPX_YEAR";
            public static string ACTIVE = CfgCPXMasterHis.TableName + ".ACTIVE";
            public static string CURRENCY_NAME = CfgCPXMasterHis.TableName + ".CURRENCY_NAME";
            public static string CPX_BUDGET_AMOUNT = CfgCPXMasterHis.TableName + ".CPX_BUDGET_AMOUNT";
            public static string CFG_COST_CENTER_NAME = CfgCPXMasterHis.TableName + ".CFG_COST_CENTER_NAME";
            public static string CPX_EQUIP_JIGTOOL = CfgCPXMasterHis.TableName + ".CPX_EQUIP_JIGTOOL";
            public static string CPX_APPROVAL_TARGET = CfgCPXMasterHis.TableName + ".CPX_APPROVAL_TARGET";
            public static string PROLONG_CAPEX_USE = CfgCPXMasterHis.TableName + ".PROLONG_CAPEX_USE";
            public static string CPX_CATEGORY = CfgCPXMasterHis.TableName + ".CPX_CATEGORY";



        }
        #endregion

       

        #region FormattedValueForSqlTransaction
        public string Formatted_CPX_NUMBER
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CPX_NUMBER)); }
        }
        public string Formatted_CPX_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CPX_DESCRIPTION)); }
        }
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
        }

        public string Formatted_CPX_YEAR
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CPX_YEAR)); }
        }

        public string Formatted_CURRENCY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CURRENCY_NAME)); }
        }

        public string Formatted_CFG_COST_CENTER_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CFG_COST_CENTER_NAME)); }
        }

        public string Formatted_CPX_EQUIP_JIGTOOL
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CPX_EQUIP_JIGTOOL)); }
        }


        public string Formatted_PROLONG_CAPEX_USE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(PROLONG_CAPEX_USE)); }
        }

        public string Formatted_CPX_CATEGORY
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(CPX_CATEGORY)); }
        }

        public string Formatted_CFG_CPX_MASTER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }


        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_HIS_ID, "CFG_CPX_MASTER_HIS_ID");
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_HIS_USER_ID, "CFG_CPX_MASTER_HIS_USER_ID");
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_HIS_DELEGATE, "CFG_CPX_MASTER_HIS_DELEGATE");
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_HIS_DATE, "CFG_CPX_MASTER_HIS_DATE");
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_ID, "CFG_CPX_MASTER_ID");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_DESCRIPTION, "CPX_DESCRIPTION");
            map.Add(CfgCPXMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_NUMBER, "CPX_NUMBER");
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_CPX_MASTER_ID, "CFG_CPX_MASTER_ID");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_DESCRIPTION, "CPX_DESCRIPTION");
            map.Add(CfgCPXMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_NUMBER, "CPX_NUMBER");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_YEAR, "CPX_YEAR");
            map.Add(CfgCPXMasterHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgCPXMasterHis.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_BUDGET_AMOUNT, "CPX_BUDGET_AMOUNT");
            map.Add(CfgCPXMasterHis.ColumnNames.CFG_COST_CENTER_NAME, "CFG_COST_CENTER_NAME");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_EQUIP_JIGTOOL, "CPX_EQUIP_JIGTOOL");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_APPROVAL_TARGET, "CPX_APPROVAL_TARGET");
            map.Add(CfgCPXMasterHis.ColumnNames.PROLONG_CAPEX_USE, "PROLONG_CAPEX_USE");
            map.Add(CfgCPXMasterHis.ColumnNames.CPX_CATEGORY, "CPX_CATEGORY");
            return map;
        }
        #endregion

    }
}
