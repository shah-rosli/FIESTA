using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Backend.Models
{
    public class CfgUserHis
    {
        public CfgUserHis()
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
            get { return "CFG_USER_HIS"; }
        }
        #endregion
        #region Properties
        public decimal CFG_USER_HIS_ID { get; set; }
        public string? CFG_USER_HIS_USER_ID { get; set; }
        public string? CFG_USER_HIS_DELEGATE { get; set; }
        public DateTimeOffset CFG_USER_HIS_DATE { get; set; }
        public decimal CFG_USER_ID { get; set; }
        public string USER_ID { get; set; }
        public string? USER_EMAIL { get; set; }
        public string USER_FULL_NAME { get; set; }
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

        public string[] cfgUserList { get; set; }
        public string? USER_COMPANY_NAME { get; set; }
        public string? TZ_REGION { get; set; }
        public string[] saUserGroupId { get; set; }

        public string? DELEGATE_ID { get; set; }
        public string? GLOBAL_JOB_TITLE_CODE { get; set; }
        public string? MODIFIED_BY_EMAIL { get; set; }
        public string? MODIFIED_BY_NAME { get; set; }
        public string? MODIFIED_BY_DELNAME { get; set; }

        public TokenProperties? TokenObj { get; set; }

        #endregion
        #region ColumnNames
        public class ColumnNames
        {
            public static string CFG_USER_HIS_ID = CfgUserHis.TableName + ".CFG_USER_HIS_ID";
            public static string CFG_USER_HIS_USER_ID = CfgUserHis.TableName + ".CFG_USER_HIS_USER_ID";
            public static string CFG_USER_HIS_DELEGATE = CfgUserHis.TableName + ".CFG_USER_HIS_DELEGATE";
            public static string CFG_USER_HIS_DATE = CfgUserHis.TableName + ".CFG_USER_HIS_DATE";
            public static string CFG_USER_ID = CfgUserHis.TableName + ".CFG_USER_ID";
            public static string USER_ID = CfgUserHis.TableName + ".USER_ID";
            public static string USER_EMAIL = CfgUserHis.TableName + ".USER_EMAIL";
            public static string USER_FULL_NAME = CfgUserHis.TableName + ".USER_FULL_NAME";
            public static string USER_FIRST_NAME = CfgUserHis.TableName + ".USER_FIRST_NAME";
            public static string USER_LAST_NAME = CfgUserHis.TableName + ".USER_LAST_NAME";
            public static string USER_COMPANY_CODE = CfgUserHis.TableName + ".USER_COMPANY_CODE";
            public static string USER_LOCAL_TITLE = CfgUserHis.TableName + ".USER_LOCAL_TITLE";
            public static string USER_GLOBAL_TITLE = CfgUserHis.TableName + ".USER_GLOBAL_TITLE";
            public static string ACTIVE = CfgUserHis.TableName + ".ACTIVE";
            public static string DEFAULT_TIMEZONE = CfgUserHis.TableName + ".DEFAULT_TIMEZONE";
            public static string DEFAULT_DISP_DATE_FORMAT = CfgUserHis.TableName + ".DEFAULT_DISP_DATE_FORMAT";
            public static string DEFAULT_DISP_TIME_FORMAT = CfgUserHis.TableName + ".DEFAULT_DISP_TIME_FORMAT";
            public static string DEFAULT_DISP_DATETIME_FORMAT = CfgUserHis.TableName + ".DEFAULT_DISP_DATETIME_FORMAT";
            public static string DEFAULT_LANGUAGE = CfgUserHis.TableName + ".DEFAULT_LANGUAGE";
            public static string USER_GLOBAL_DIV = CfgUserHis.TableName + ".USER_GLOBAL_DIV";
            public static string USER_DEPT_CODE = CfgUserHis.TableName + ".USER_DEPT_CODE";
            public static string USER_DEPT_NAME = CfgUserHis.TableName + ".USER_DEPT_NAME";
            public static string USER_DEPT = CfgUserHis.TableName + ".USER_DEPT";
            public static string GLOBAL_JOB_TITLE_CODE = CfgUserHis.TableName + ".GLOBAL_JOB_TITLE_CODE";
        }
        #endregion

        #region ColumnNamesOnly
        public class ColumnNamesOnly
        {
            public static string CFG_USER_HIS_ID = "CFG_USER_HIS_ID";
            public static string CFG_USER_HIS_USER_ID = "CFG_USER_HIS_USER_ID";
            public static string CFG_USER_HIS_DELEGATE = "CFG_USER_HIS_DELEGATE";
            public static string CFG_USER_HIS_DATE = "CFG_USER_HIS_DATE";
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
            public static string USER_DEPT = "USER_DEPT ";
            public static string GLOBAL_JOB_TITLE_CODE = "GLOBAL_JOB_TITLE_CODE";
        }
        #endregion

        #region ColumnMappings
        public Hashtable ColumnMappings()
        {
            Hashtable map = new Hashtable();
            map.Add(CfgUserHis.ColumnNames.CFG_USER_HIS_ID, "CFG_USER_HIS_ID");
            map.Add(CfgUserHis.ColumnNames.CFG_USER_HIS_DATE, "CFG_USER_HIS_DATE");
            map.Add(CfgUserHis.ColumnNames.CFG_USER_HIS_USER_ID, "CFG_USER_HIS_USER_ID");
            map.Add(CfgUserHis.ColumnNames.CFG_USER_HIS_DELEGATE, "CFG_USER_HIS_DELEGATE");
            map.Add(CfgUserHis.ColumnNames.USER_ID, "USER_ID");
            map.Add(CfgUserHis.ColumnNames.USER_FULL_NAME, "USER_FULL_NAME");
            map.Add(CfgUserHis.ColumnNames.CFG_USER_ID, "CFG_USER_ID");
            map.Add(CfgUserHis.ColumnNames.USER_EMAIL, "USER_EMAIL");
            map.Add(CfgUserHis.ColumnNames.USER_FIRST_NAME, "USER_FIRST_NAME");
            map.Add(CfgUserHis.ColumnNames.USER_LAST_NAME, "USER_LAST_NAME");
            map.Add(CfgUserHis.ColumnNames.USER_COMPANY_CODE, "USER_COMPANY_CODE");
            map.Add(CfgUserHis.ColumnNames.USER_LOCAL_TITLE, "USER_LOCAL_TITLE");
            map.Add(CfgUserHis.ColumnNames.USER_GLOBAL_TITLE, "USER_GLOBAL_TITLE");
            map.Add(CfgUserHis.ColumnNames.ACTIVE, "ACTIVE");
            map.Add(CfgUserHis.ColumnNames.DEFAULT_TIMEZONE, "DEFAULT_TIMEZONE");
            map.Add(CfgUserHis.ColumnNames.DEFAULT_DISP_DATE_FORMAT, "DEFAULT_DISP_DATE_FORMAT");
            map.Add(CfgUserHis.ColumnNames.DEFAULT_DISP_TIME_FORMAT, "DEFAULT_DISP_TIME_FORMAT");
            map.Add(CfgUserHis.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, "DEFAULT_DISP_DATETIME_FORMAT");
            map.Add(CfgUserHis.ColumnNames.DEFAULT_LANGUAGE, "DEFAULT_LANGUAGE");
            map.Add(CfgUserHis.ColumnNames.USER_DEPT_CODE, "USER_DEPT_CODE");
            map.Add(CfgUserHis.ColumnNames.USER_DEPT_NAME, "USER_DEPT_NAME");
            map.Add(CfgUserHis.ColumnNames.USER_DEPT, "USER_DEPT");
            map.Add(CfgUserHis.ColumnNames.USER_GLOBAL_DIV, "USER_GLOBAL_DIV");
            map.Add(CfgUserHis.ColumnNames.GLOBAL_JOB_TITLE_CODE, "GLOBAL_JOB_TITLE_CODE");
            map.Add("USER_COMPANY_NAME", "USER_COMPANY_NAME");

            return map;
        }

        public string Formatted_CFG_USER_HIS_DATE_FOR_DISPLAY
        {
            get
            {
                if (TokenObj != null)
                    return string.Format("  FROM_TZ(CAST({0} AS TIMESTAMP), 'UTC') AT TIME ZONE '{1}' ", CfgUserHis.ColumnNames.CFG_USER_HIS_DATE, TokenObj.DEFAULT_TIMEZONE);
                else
                    return null;
            }
        }
        #endregion


    }
}
