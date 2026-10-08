using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Models
{
    public class CfgUser
    {
        public CfgUser()
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
            get { return "CFG_USER"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_ID { get; set; }
        public string? USER_ID { get; set; }
        public string? USER_EMAIL { get; set; }
        public string? USER_FULL_NAME { get; set; }
        public string? USER_FIRST_NAME { get; set; }
        public string? USER_LAST_NAME { get; set; }
        public string? USER_COMPANY_CODE { get; set; }
        public string? USER_LOCAL_TITLE { get; set; }
        public string? USER_GLOBAL_TITLE { get; set; }
        public string? ACTIVE { get; set; }
        public string? DEFAULT_TIMEZONE { get; set; }
        public string? DEFAULT_DISP_DATE_FORMAT { get; set; }
        public string? DEFAULT_DISP_TIME_FORMAT { get; set; }
        public string? DEFAULT_DISP_DATETIME_FORMAT { get; set; }
        public string? DEFAULT_LANGUAGE { get; set; }
        public string? USER_GLOBAL_DIV { get; set; }
        public string? USER_DEPT_CODE { get; set; }

        public string? USER_DEPT_NAME { get; set; }

        public string? USER_DEPT { get; set; }

        [NotMapped]
        public string[]? cfgUserList { get; set; }
        [NotMapped]
        public string? USER_COMPANY_NAME { get; set; }

        [NotMapped]
        public string? TZ_REGION { get; set; }
        [NotMapped]
        public string[]? saUserGroupId { get; set; }
        [NotMapped]
        public string? DELEGATE_ID { get; set; }
        public string? GLOBAL_JOB_TITLE_CODE { get; set; }
        [NotMapped]
        public TokenProperties? TokenObj { get; set; }

        public List<string>? USER_GROUPS { get; set; } //added by Keith 20260928

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_ID = CfgUser.TableName + ".CFG_USER_ID";
            public static string USER_ID = CfgUser.TableName + ".USER_ID";
            public static string USER_EMAIL = CfgUser.TableName + ".USER_EMAIL";
            public static string USER_FULL_NAME = CfgUser.TableName + ".USER_FULL_NAME";
            public static string USER_FIRST_NAME = CfgUser.TableName + ".USER_FIRST_NAME";
            public static string USER_LAST_NAME = CfgUser.TableName + ".USER_LAST_NAME";
            public static string USER_COMPANY_CODE = CfgUser.TableName + ".USER_COMPANY_CODE";
            public static string USER_LOCAL_TITLE = CfgUser.TableName + ".USER_LOCAL_TITLE";
            public static string USER_GLOBAL_TITLE = CfgUser.TableName + ".USER_GLOBAL_TITLE";
            public static string ACTIVE = CfgUser.TableName + ".ACTIVE";
            public static string DEFAULT_TIMEZONE = CfgUser.TableName + ".DEFAULT_TIMEZONE";
            public static string DEFAULT_DISP_DATE_FORMAT = CfgUser.TableName + ".DEFAULT_DISP_DATE_FORMAT";
            public static string DEFAULT_DISP_TIME_FORMAT = CfgUser.TableName + ".DEFAULT_DISP_TIME_FORMAT";
            public static string DEFAULT_DISP_DATETIME_FORMAT = CfgUser.TableName + ".DEFAULT_DISP_DATETIME_FORMAT";
            public static string DEFAULT_LANGUAGE = CfgUser.TableName + ".DEFAULT_LANGUAGE";
            public static string USER_GLOBAL_DIV = CfgUser.TableName + ".USER_GLOBAL_DIV";
            public static string USER_DEPT_CODE = CfgUser.TableName + ".USER_DEPT_CODE";
            public static string USER_DEPT_NAME = CfgUser.TableName + ".USER_DEPT_NAME";
            public static string USER_DEPT = CfgUser.TableName + ".USER_DEPT";
            public static string GLOBAL_JOB_TITLE_CODE = CfgUser.TableName + ".GLOBAL_JOB_TITLE_CODE";
        }
        #endregion
        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_ID = "CFG_USER_ID";
            public static string USER_ID = "USER_ID";
            public static string USER_EMAIL = "USER_EMAIL";
            public static string USER_FULL_NAME = "USER_FULL_NAME";
            public static string USER_FIRST_NAME = "USER_FIRST_NAME";
            public static string USER_LAST_NAME = "USER_LAST_NAME";
            public static string USER_COMPANY_CODE = "USER_COMPANY_CODE";
            public static string USER_LOCAL_TITLE = "USER_LOCAL_TITLE";
            public static string USER_GLOBAL_TITLE = "USER_GLOBAL_TITLE";
            public static string ACTIVE = "ACTIVE";
            public static string DEFAULT_TIMEZONE = "DEFAULT_TIMEZONE";
            public static string DEFAULT_DISP_DATE_FORMAT = "DEFAULT_DISP_DATE_FORMAT";
            public static string DEFAULT_DISP_TIME_FORMAT = "DEFAULT_DISP_TIME_FORMAT";
            public static string DEFAULT_DISP_DATETIME_FORMAT = "DEFAULT_DISP_DATETIME_FORMAT";
            public static string DEFAULT_LANGUAGE = "DEFAULT_LANGUAGE";
            public static string USER_GLOBAL_DIV = "USER_GLOBAL_DIV";
            public static string USER_DEPT_CODE = "USER_DEPT_CODE";
            public static string USER_DEPT_NAME = "USER_DEPT_NAME";
            public static string USER_DEPT = "USER_DEPT";
            public static string GLOBAL_JOB_TITLE_CODE = "GLOBAL_JOB_TITLE_CODE";
        }
        #endregion
        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUser.ColumnNames.CFG_USER_ID, "CFG_USER_ID");
            map.Add(CfgUser.ColumnNames.USER_ID, "USER_ID");
            map.Add(CfgUser.ColumnNames.USER_EMAIL, "USER_EMAIL");
            map.Add(CfgUser.ColumnNames.USER_FULL_NAME, "USER_FULL_NAME");
            map.Add(CfgUser.ColumnNames.USER_FIRST_NAME, "USER_FIRST_NAME");
            map.Add(CfgUser.ColumnNames.USER_LAST_NAME, "USER_LAST_NAME");
            map.Add(CfgUser.ColumnNames.USER_COMPANY_CODE, "USER_COMPANY_CODE");
            map.Add(CfgUser.ColumnNames.USER_LOCAL_TITLE, "USER_LOCAL_TITLE");
            map.Add(CfgUser.ColumnNames.USER_GLOBAL_TITLE, "USER_GLOBAL_TITLE");
            map.Add(CfgUser.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgUser.ColumnNames.DEFAULT_TIMEZONE, "DEFAULT_TIMEZONE");
            map.Add(CfgUser.ColumnNames.DEFAULT_DISP_DATE_FORMAT, "DEFAULT_DISP_DATE_FORMAT");
            map.Add(CfgUser.ColumnNames.DEFAULT_DISP_TIME_FORMAT, "DEFAULT_DISP_TIME_FORMAT");
            map.Add(CfgUser.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, "DEFAULT_DISP_DATETIME_FORMAT");
            map.Add(CfgUser.ColumnNames.DEFAULT_LANGUAGE, "DEFAULT_LANGUAGE");
            map.Add(CfgUser.ColumnNames.USER_DEPT_CODE, "USER_DEPT_CODE");
            map.Add(CfgUser.ColumnNames.USER_DEPT_NAME, "USER_DEPT_NAME");
            map.Add(CfgUser.ColumnNames.USER_DEPT, "USER_DEPT");
            map.Add(CfgUser.ColumnNames.USER_GLOBAL_DIV, "USER_GLOBAL_DIV");
            map.Add(CfgUser.ColumnNames.GLOBAL_JOB_TITLE_CODE, "GLOBAL_JOB_TITLE_CODE");


            map.Add("USER_COMPANY_NAME", "USER_COMPANY_NAME");
            return map;
        }
        #endregion
        #region DtColumnName
        public class DTColumnName
        {
            public static string CFG_USER_ID = "CFG_USER_ID";
            public static string USER_ID = "USER_ID";
            public static string USER_DS_NUMBER = "USER_DS_NUMBER";
            public static string USER_EMAIL = "USER_EMAIL";
            public static string USER_FULL_NAME = "USER_FULL_NAME";
            public static string USER_FIRST_NAME = "USER_FIRST_NAME";
            public static string USER_LAST_NAME = "USER_LAST_NAME";
            public static string DEFAULT_COST_CENTER = "DEFAULT_COST_CENTER";
            public static string USER_COMPANY_CODE = "USER_COMPANY_CODE";
            public static string USER_LOCAL_TITLE = "USER_LOCAL_TITLE";
            public static string USER_GLOBAL_TITLE = "USER_GLOBAL_TITLE";
            public static string ACTIVE = "ACTIVE";
            public static string USER_GLOBAL_DIV = "USER_GLOBAL_DIV";
            public static string USER_DEPT_CODE = "USER_DEPT_CODE";
            public static string USER_DEPT_NAME = "USER_DEPT_NAME";
            public static string USER_DEPT = "USER_DEPT";
            public static string GLOBAL_JOB_TITLE_CODE = "GLOBAL_JOB_TITLE_CODE";
        }
        #endregion
        #region FormattedValueForSqlTransaction
        public string Formatted_CFG_USER_ID
        {
            get { return string.Format("'{0}'", CFG_USER_ID); }
        }
        public string Formatted_USER_ID
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_ID)); }
        }
        public string Formatted_USER_EMAIL
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_EMAIL)); }
        }
        public string Formatted_USER_FULL_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_FULL_NAME)); }
        }
        public string Formatted_USER_FIRST_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_FIRST_NAME)); }
        }
        public string Formatted_USER_LAST_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_LAST_NAME)); }
        }
        public string Formatted_USER_COMPANY_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_COMPANY_CODE)); }
        }
        public string Formatted_USER_LOCAL_TITLE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_LOCAL_TITLE)); }
        }
        public string Formatted_USER_GLOBAL_TITLE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_GLOBAL_TITLE)); }
        }
        public string Formatted_ACTIVE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(ACTIVE)); }
        }

        public string Formatted_USER_GLOBAL_DIV
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_GLOBAL_DIV)); }
        }

        public string Formatted_USER_DEPT_CODE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_DEPT_CODE)); }
        }


        public string Formatted_USER_DEPT
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_DEPT)); }
        }


        public string Formatted_USER_DEPT_NAME
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(USER_DEPT_NAME)); }
        }

        public string Formatted_DEFAULT_DISP_DATE_FORMAT
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DEFAULT_DISP_DATE_FORMAT)); }
        }
        public string Formatted_DEFAULT_TIMEZONE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DEFAULT_TIMEZONE)); }
        }
        public string Formatted_DEFAULT_DISP_TIME_FORMAT
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DEFAULT_DISP_TIME_FORMAT)); }
        }

        public string Formatted_DEFAULT_DISP_DATETIME_FORMAT
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DEFAULT_DISP_DATETIME_FORMAT)); }
        }

        public string Formatted_DEFAULT_LANGUAGE
        {
            get { return string.Format("'{0}'", DataConverter.FormatSQL(DEFAULT_LANGUAGE)); }
        }

        public string Formatted_GLOBAL_JOB_TITLE_CODE
        {
            get { return string.Format("'{0}'", GLOBAL_JOB_TITLE_CODE); }
        }

        #endregion
        #region GetPrimaryKey 
        public static string PrimaryKey
        {
            get { return ColumnNames.CFG_USER_ID; }
        }
        #endregion
    }
}
