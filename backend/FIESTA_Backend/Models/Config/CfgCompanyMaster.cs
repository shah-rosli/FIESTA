
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
    public class CfgCompanyMaster
    {
        public CfgCompanyMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_COMPANY_MASTER"; }
        }

        #region Properties       

        public decimal CFG_COMPANY_MASTER_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string COMPANY_DESCRIPTION { get; set; }
        public string DEFAULT_PURCHASING_ORG { get; set; }
        public string DEFAULT_CURRENCY_NAME { get; set; }

        public string APR_COMPANY_GROUP { get; set; }
        public string IF_COMPANY_CODE { get; set; }
        public string IF_DESTINATION_SYSTEM { get; set; }
        public string ACTIVE { get; set; }
        
        public string DEFAULT_TIMEZONE { get; set; }
        public string DEFAULT_DISP_DATE_FORMAT { get; set; }
        public string DEFAULT_DISP_TIME_FORMAT { get; set; }
        public string DEFAULT_DISP_DATETIME_FORMAT { get; set; }
        //public List<CfgCPXMaster> lsCfgCPXMaster{get; set;}
        public string DEFAULT_PR_NOTIFY_EMAIL { get; set; }
        public string DEFAULT_LANGUAGE { get; set; }
        public string[] saCurrencyMap { get; set; }
        public string[] saUOMMap { get; set; }
        public string[] saEprInspCodeMap { get; set; }
        public string[] saEprDocumentMap { get; set; }
        public string[] saAccountCategoryMap { get; set; }
        public string[] saEprCategoryMap { get; set; }

        public ArrayList arPlant { get; set; }

        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_COMPANY_MASTER_ID = CfgCompanyMaster.TableName + ".CFG_COMPANY_MASTER_ID";
            public static string COMPANY_CODE = CfgCompanyMaster.TableName + ".COMPANY_CODE";
            public static string COMPANY_NAME = CfgCompanyMaster.TableName + ".COMPANY_NAME";
            public static string COMPANY_DESCRIPTION = CfgCompanyMaster.TableName + ".COMPANY_DESCRIPTION";
            public static string DEFAULT_PURCHASING_ORG = CfgCompanyMaster.TableName + ".DEFAULT_PURCHASING_ORG";
            public static string DEFAULT_CURRENCY_NAME = CfgCompanyMaster.TableName + ".DEFAULT_CURRENCY_NAME";
            public static string ACTIVE = CfgCompanyMaster.TableName + ".ACTIVE";
            public static string APR_COMPANY_GROUP = CfgCompanyMaster.TableName + ".APR_COMPANY_GROUP";
            public static string IF_COMPANY_CODE = CfgCompanyMaster.TableName + ".IF_COMPANY_CODE";
            public static string IF_DESTINATION_SYSTEM = CfgCompanyMaster.TableName + ".IF_DESTINATION_SYSTEM";            
            public static string DEFAULT_TIMEZONE = CfgCompanyMaster.TableName + ".DEFAULT_TIMEZONE";
            public static string DEFAULT_DISP_DATE_FORMAT = CfgCompanyMaster.TableName + ".DEFAULT_DISP_DATE_FORMAT";
            public static string DEFAULT_DISP_TIME_FORMAT = CfgCompanyMaster.TableName + ".DEFAULT_DISP_TIME_FORMAT";
            public static string DEFAULT_DISP_DATETIME_FORMAT = CfgCompanyMaster.TableName + ".DEFAULT_DISP_DATETIME_FORMAT";
            public static string DEFAULT_PR_NOTIFY_EMAIL = CfgCompanyMaster.TableName + ".DEFAULT_PR_NOTIFY_EMAIL";
            public static string DEFAULT_LANGUAGE = CfgCompanyMaster.TableName + ".DEFAULT_LANGUAGE";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_COMPANY_MASTER_ID = "CFG_COMPANY_MASTER_ID";
            public static string COMPANY_CODE = "COMPANY_CODE";
            public static string COMPANY_NAME = "COMPANY_NAME";
            public static string COMPANY_DESCRIPTION = "COMPANY_DESCRIPTION";
            public static string DEFAULT_PURCHASING_ORG = "DEFAULT_PURCHASING_ORG";
            public static string DEFAULT_CURRENCY_NAME = "DEFAULT_CURRENCY_NAME";
            public static string ACTIVE = "ACTIVE";
            public static string APR_COMPANY_GROUP = "APR_COMPANY_GROUP";
            public static string IF_COMPANY_CODE = "IF_COMPANY_CODE";
            public static string IF_DESTINATION_SYSTEM = "IF_DESTINATION_SYSTEM";
            public static string DEFAULT_TIMEZONE = "DEFAULT_TIMEZONE";
            public static string DEFAULT_DISP_DATE_FORMAT = "DEFAULT_DISP_DATE_FORMAT";
            public static string DEFAULT_DISP_TIME_FORMAT = "DEFAULT_DISP_TIME_FORMAT";
            public static string DEFAULT_DISP_DATETIME_FORMAT = "DEFAULT_DISP_DATETIME_FORMAT";
            public static string DEFAULT_PR_NOTIFY_EMAIL = "DEFAULT_PR_NOTIFY_EMAIL";
            public static string DEFAULT_LANGUAGE = "DEFAULT_LANGUAGE";

        }
        #endregion

        #region FormattedValueForSqlTransaction
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL( COMPANY_CODE)); }
        }
        public string Formatted_COMPANY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_NAME)); }
        }
        public string Formatted_COMPANY_DESCRIPTION
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_DESCRIPTION)); }
        }
        public string Formatted_DEFAULT_PURCHASING_ORG
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_PURCHASING_ORG)); }
        }
        public string Formatted_DEFAULT_CURRENCY_NAME
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_CURRENCY_NAME)); }
        }
        public string Formatted_APR_COMPANY_GROUP
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(APR_COMPANY_GROUP)); }
        }
        public string Formatted_IF_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(IF_COMPANY_CODE)); }
        }
        public string Formatted_IF_DESTINATION_SYSTEM
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(IF_DESTINATION_SYSTEM)); }
        }

        

        public string Formatted_DEFAULT_DISP_DATE_FORMAT
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_DISP_DATE_FORMAT)); }
        }
        public string Formatted_DEFAULT_TIMEZONE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_TIMEZONE)); }
        }
        public string Formatted_DEFAULT_DISP_TIME_FORMAT
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_DISP_TIME_FORMAT)); }
        }

        public string Formatted_DEFAULT_DISP_DATETIME_FORMAT
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_DISP_DATETIME_FORMAT)); }
        }
        public string Formatted_DEFAULT_PR_NOTIFY_EMAIL
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_PR_NOTIFY_EMAIL)); }
        }

        public string Formatted_DEFAULT_LANGUAGE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(DEFAULT_LANGUAGE)); }
        }

        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, "CFG_COMPANY_MASTER_ID");
            map.Add(CfgCompanyMaster.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCompanyMaster.ColumnNames.COMPANY_NAME, "COMPANY_NAME");
            map.Add(CfgCompanyMaster.ColumnNames.COMPANY_DESCRIPTION, "COMPANY_DESCRIPTION");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_PURCHASING_ORG, "DEFAULT_PURCHASING_ORG");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_CURRENCY_NAME, "DEFAULT_CURRENCY_NAME");
            map.Add(CfgCompanyMaster.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgCompanyMaster.ColumnNames.IF_DESTINATION_SYSTEM, "IF_DESTINATION_SYSTEM");
            map.Add(CfgCompanyMaster.ColumnNames.IF_COMPANY_CODE, "IF_COMPANY_CODE");
            map.Add(CfgCompanyMaster.ColumnNames.APR_COMPANY_GROUP, "APR_COMPANY_GROUP");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_TIMEZONE, "DEFAULT_TIMEZONE");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATE_FORMAT, "DEFAULT_DISP_DATE_FORMAT");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_DISP_TIME_FORMAT, "DEFAULT_DISP_TIME_FORMAT");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, "DEFAULT_DISP_DATETIME_FORMAT");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL, "DEFAULT_PR_NOTIFY_EMAIL");
            map.Add(CfgCompanyMaster.ColumnNames.DEFAULT_LANGUAGE, "DEFAULT_LANGUAGE");
            return map;
        }
        #endregion


       
    }
}