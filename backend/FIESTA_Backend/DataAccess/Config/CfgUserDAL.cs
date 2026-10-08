using FIESTA_Backend.Models;
using System.Collections;
using System.Data;
using System.Text;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgUserDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private readonly IConfiguration _config;
        private EnvironmentProperties _envProperties;

        public CfgUserDAL(IConfiguration configuration, HttpContext httpContext)
        {
            _config = configuration;

            _envProperties = new EnvironmentProperties(_config, httpContext);
            _connectionString = _envProperties.CONN_STRING();
            _providerType = _config.GetSection("ProviderName").Value;
            dbManager = new DBManager(_providerType);
            dbManager.ConnectionString = _connectionString;
        }

        private string SelectRowByUserEmailQuery(string email)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15} ",
                CfgUser.ColumnNames.CFG_USER_ID,
                CfgUser.ColumnNames.USER_ID,
                CfgUser.ColumnNames.USER_EMAIL,
                CfgUser.ColumnNames.USER_FULL_NAME,
                CfgUser.ColumnNames.USER_FIRST_NAME,
                CfgUser.ColumnNames.USER_LAST_NAME,
                CfgUser.ColumnNames.USER_COMPANY_CODE,
                CfgUser.ColumnNames.USER_LOCAL_TITLE,
                CfgUser.ColumnNames.USER_GLOBAL_TITLE,
                CfgUser.ColumnNames.ACTIVE,
                CfgUser.ColumnNames.DEFAULT_TIMEZONE,
                CfgUser.ColumnNames.DEFAULT_DISP_DATE_FORMAT,
                CfgUser.ColumnNames.DEFAULT_DISP_TIME_FORMAT,
                CfgUser.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT,
                CfgUser.ColumnNames.DEFAULT_LANGUAGE,
                CfgUser.ColumnNames.USER_GLOBAL_DIV);
            sb.AppendFormat("  from  {0}  ", CfgUser.TableName);
            sb.AppendFormat(" where upper({0}) = upper('{1}') ", CfgUser.ColumnNames.USER_EMAIL, email);
            sb.AppendFormat(" and Active = 'Yes' ");
            return sb.ToString();
        }

        public CfgUser SelectRowByUserEmail(string id)
        {
            CfgUser obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByUserEmailQuery(id), new CfgUser().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUser)arr[0];
                }
            }
            catch (Exception ce)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

            return obj;
        }

        private string SelectRowByUserIdQuery(string id, bool active)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}",
                CfgUser.ColumnNames.CFG_USER_ID,
                CfgUser.ColumnNames.USER_ID,
                CfgUser.ColumnNames.USER_EMAIL,
                CfgUser.ColumnNames.USER_FULL_NAME,
                CfgUser.ColumnNames.USER_FIRST_NAME,
                CfgUser.ColumnNames.USER_LAST_NAME,
                CfgUser.ColumnNames.USER_COMPANY_CODE,
                CfgUser.ColumnNames.USER_LOCAL_TITLE,
                CfgUser.ColumnNames.USER_GLOBAL_TITLE,
                CfgUser.ColumnNames.ACTIVE,
                CfgUser.ColumnNames.DEFAULT_TIMEZONE,
                CfgUser.ColumnNames.DEFAULT_DISP_DATE_FORMAT,
                CfgUser.ColumnNames.DEFAULT_DISP_TIME_FORMAT,
                CfgUser.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT,
                CfgUser.ColumnNames.DEFAULT_LANGUAGE,
                CfgUser.ColumnNames.USER_DEPT_CODE,
                CfgUser.ColumnNames.USER_DEPT_NAME,
                CfgUser.ColumnNames.USER_DEPT,
                CfgUser.ColumnNames.USER_GLOBAL_DIV,
                CfgUser.ColumnNames.GLOBAL_JOB_TITLE_CODE);
            sb.AppendFormat("  from  {0}  ", CfgUser.TableName);
            sb.AppendFormat(" where {0} = {1} ", DataConverter.FormatSQLForString(CfgUser.ColumnNames.USER_ID), id);
            if (active)
            {
                sb.AppendFormat(" and Active = 'Yes' ");
            }

            return sb.ToString();
        }

        public CfgUser SelectRowByUserId(string id, bool active = true)
        {
            CfgUser obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByUserIdQuery(id, active), new CfgUser().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUser)arr[0];
                }
            }
            catch (Exception ce)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

            return obj;
        }
    }
}