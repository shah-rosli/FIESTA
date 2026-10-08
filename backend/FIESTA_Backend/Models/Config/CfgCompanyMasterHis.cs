
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
    public class CfgCompanyMasterHis
    {
        public CfgCompanyMasterHis()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static string TableName
        {
            get { return "CFG_COMPANY_MASTER_HIS"; }
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
        public TokenProperties? TokenObj { get; set; }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_COMPANY_MASTER_HIS_ID = CfgCompanyMasterHis.TableName + ".CFG_COMPANY_MASTER_HIS_ID";
            public static string CFG_COMPANY_MASTER_HIS_USER_ID = CfgCompanyMasterHis.TableName + ".CFG_COMPANY_MASTER_HIS_USER_ID";
            public static string COMPANY_MASTER_HIS_DELEGATE = CfgCompanyMasterHis.TableName + ".COMPANY_MASTER_HIS_DELEGATE";
            public static string CFG_COMPANY_MASTER_HIS_DATE = CfgCompanyMasterHis.TableName + ".CFG_COMPANY_MASTER_HIS_DATE";
            public static string CFG_COMPANY_MASTER_ID = CfgCompanyMasterHis.TableName + ".CFG_COMPANY_MASTER_ID";
            public static string COMPANY_CODE = CfgCompanyMasterHis.TableName + ".COMPANY_CODE";
            public static string COMPANY_NAME = CfgCompanyMasterHis.TableName + ".COMPANY_NAME";
            public static string COMPANY_DESCRIPTION = CfgCompanyMasterHis.TableName + ".COMPANY_DESCRIPTION";
            public static string DEFAULT_PURCHASING_ORG = CfgCompanyMasterHis.TableName + ".DEFAULT_PURCHASING_ORG";
            public static string DEFAULT_CURRENCY_NAME = CfgCompanyMasterHis.TableName + ".DEFAULT_CURRENCY_NAME";
            public static string ACTIVE = CfgCompanyMasterHis.TableName + ".ACTIVE";
            public static string APR_COMPANY_GROUP = CfgCompanyMasterHis.TableName + ".APR_COMPANY_GROUP";
            public static string IF_COMPANY_CODE = CfgCompanyMasterHis.TableName + ".IF_COMPANY_CODE";
            public static string IF_DESTINATION_SYSTEM = CfgCompanyMasterHis.TableName + ".IF_DESTINATION_SYSTEM";
            public static string DEFAULT_TIMEZONE = CfgCompanyMasterHis.TableName + ".DEFAULT_TIMEZONE";
            public static string DEFAULT_DISP_DATE_FORMAT = CfgCompanyMasterHis.TableName + ".DEFAULT_DISP_DATE_FORMAT";
            public static string DEFAULT_DISP_TIME_FORMAT = CfgCompanyMasterHis.TableName + ".DEFAULT_DISP_TIME_FORMAT";
            public static string DEFAULT_DISP_DATETIME_FORMAT = CfgCompanyMasterHis.TableName + ".DEFAULT_DISP_DATETIME_FORMAT";
            public static string DEFAULT_PR_NOTIFY_EMAIL = CfgCompanyMasterHis.TableName + ".DEFAULT_PR_NOTIFY_EMAIL";
            public static string DEFAULT_LANGUAGE = CfgCompanyMasterHis.TableName + ".DEFAULT_LANGUAGE";
        }
        #endregion


        #region FormattedValueForSqlTransaction
        public string Formatted_COMPANY_CODE
        {
            get { return string.Format("{0}", DataConverter.FormatSQL(COMPANY_CODE)); }
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

        public string Formatted_CFG_COMPANY_MASTER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion

        #region Mapping
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_ID, "CFG_COMPANY_MASTER_HIS_ID");
            map.Add(CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_USER_ID, "CFG_COMPANY_MASTER_HIS_USER_ID");
            map.Add(CfgCompanyMasterHis.ColumnNames.COMPANY_MASTER_HIS_DELEGATE, "COMPANY_MASTER_HIS_DELEGATE");
            map.Add(CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_DATE, "CFG_COMPANY_MASTER_HIS_DATE");
            map.Add(CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_ID, "CFG_COMPANY_MASTER_ID");
            map.Add(CfgCompanyMasterHis.ColumnNames.COMPANY_CODE, "COMPANY_CODE");
            map.Add(CfgCompanyMasterHis.ColumnNames.COMPANY_NAME, "COMPANY_NAME");
            map.Add(CfgCompanyMasterHis.ColumnNames.COMPANY_DESCRIPTION, "COMPANY_DESCRIPTION");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_PURCHASING_ORG, "DEFAULT_PURCHASING_ORG");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_CURRENCY_NAME, "DEFAULT_CURRENCY_NAME");
            map.Add(CfgCompanyMasterHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgCompanyMasterHis.ColumnNames.IF_DESTINATION_SYSTEM, "IF_DESTINATION_SYSTEM");
            map.Add(CfgCompanyMasterHis.ColumnNames.IF_COMPANY_CODE, "IF_COMPANY_CODE");
            map.Add(CfgCompanyMasterHis.ColumnNames.APR_COMPANY_GROUP, "APR_COMPANY_GROUP");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_TIMEZONE, "DEFAULT_TIMEZONE");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_DATE_FORMAT, "DEFAULT_DISP_DATE_FORMAT");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_TIME_FORMAT, "DEFAULT_DISP_TIME_FORMAT");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, "DEFAULT_DISP_DATETIME_FORMAT");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL, "DEFAULT_PR_NOTIFY_EMAIL");
            map.Add(CfgCompanyMasterHis.ColumnNames.DEFAULT_LANGUAGE, "DEFAULT_LANGUAGE");

            return map;
        }
        #endregion


    }
}
