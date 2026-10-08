
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
    public class CfgCPXMaster
    {
        public CfgCPXMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_CPX_MASTER"; }
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
        public DateTime CPX_APPROVAL_TARGET { get; set; }
        public string CPX_CATEGORY { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_CPX_MASTER_ID = CfgCPXMaster.TableName + ".CFG_CPX_MASTER_ID";
            public static string CPX_NUMBER = CfgCPXMaster.TableName + ".CPX_NUMBER";
            public static string CPX_DESCRIPTION = CfgCPXMaster.TableName + ".CPX_DESCRIPTION";
            public static string COMPANY_CODE = CfgCPXMaster.TableName + ".COMPANY_CODE";
            public static string CPX_YEAR = CfgCPXMaster.TableName + ".CPX_YEAR";
            public static string ACTIVE = CfgCPXMaster.TableName + ".ACTIVE";
            public static string CURRENCY_NAME = CfgCPXMaster.TableName + ".CURRENCY_NAME";
            public static string CPX_BUDGET_AMOUNT = CfgCPXMaster.TableName + ".CPX_BUDGET_AMOUNT";
            public static string CFG_COST_CENTER_NAME = CfgCPXMaster.TableName + ".CFG_COST_CENTER_NAME";
            public static string CPX_EQUIP_JIGTOOL = CfgCPXMaster.TableName + ".CPX_EQUIP_JIGTOOL";
            public static string CPX_APPROVAL_TARGET = CfgCPXMaster.TableName + ".CPX_APPROVAL_TARGET";
            public static string PROLONG_CAPEX_USE = CfgCPXMaster.TableName + ".PROLONG_CAPEX_USE";
            public static string CPX_CATEGORY = CfgCPXMaster.TableName + ".CPX_CATEGORY";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_CPX_MASTER_ID = "CFG_CPX_MASTER_ID";
            public static string CPX_NUMBER = "CPX_NUMBER";
            public static string CPX_DESCRIPTION = "CPX_DESCRIPTION";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string CPX_YEAR = "CPX_YEAR";
            public static string ACTIVE = "ACTIVE";
            public static string CURRENCY_NAME = "CURRENCY_NAME";
            public static string CPX_BUDGET_AMOUNT = "CPX_BUDGET_AMOUNT";
            public static string CFG_COST_CENTER_NAME = "CFG_COST_CENTER_NAME";
            public static string CPX_EQUIP_JIGTOOL = "CPX_EQUIP_JIGTOOL";
            public static string CPX_APPROVAL_TARGET = "CPX_APPROVAL_TARGET";
            public static string PROLONG_CAPEX_USE = "PROLONG_CAPEX_USE";
            public static string CPX_CATEGORY = "CPX_CATEGORY";

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


        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCPXMaster.ColumnNames.CFG_CPX_MASTER_ID, "CFG_CPX_MASTER_ID");
            map.Add(CfgCPXMaster.ColumnNames.CPX_DESCRIPTION, "CPX_DESCRIPTION");
            map.Add(CfgCPXMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCPXMaster.ColumnNames.CPX_NUMBER, "CPX_NUMBER");
            map.Add(CfgCPXMaster.ColumnNames.CPX_YEAR, "CPX_YEAR");
            map.Add(CfgCPXMaster.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgCPXMaster.ColumnNames.CURRENCY_NAME, "CURRENCY_NAME");
            map.Add(CfgCPXMaster.ColumnNames.CPX_BUDGET_AMOUNT, "CPX_BUDGET_AMOUNT");
            map.Add(CfgCPXMaster.ColumnNames.CFG_COST_CENTER_NAME, "CFG_COST_CENTER_NAME");
            map.Add(CfgCPXMaster.ColumnNames.CPX_EQUIP_JIGTOOL, "CPX_EQUIP_JIGTOOL");
            map.Add(CfgCPXMaster.ColumnNames.CPX_APPROVAL_TARGET, "CPX_APPROVAL_TARGET");
            map.Add(CfgCPXMaster.ColumnNames.PROLONG_CAPEX_USE, "PROLONG_CAPEX_USE");
            map.Add(CfgCPXMaster.ColumnNames.CPX_CATEGORY, "CPX_CATEGORY");




            return map;
        }
        #endregion


       
    }
}