using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgUserUserGroupMapDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgUserUserGroupMapDAL(IConfiguration configuration, HttpContext httpContext)
        {
            //
            // TODO: Add constructor logic here
            //
            this._config = configuration;
            this._httpContext = httpContext;

            _envProperties = new EnvironmentProperties(_config, _httpContext);
            _connectionString = _envProperties.CONN_STRING();
            _providerType = _config.GetSection("ProviderName").Value;
            dbManager = new DBManager(_providerType);
            dbManager.ConnectionString = _connectionString;
            logger = log4net.LogManager.GetLogger("GeneralLog");
        }
        private string SelectAllRowsQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1} ", CfgUserUserGroupMap.ColumnNames.USER_ID, CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat("  from  {0}  ", CfgUserUserGroupMap.TableName);
            return sb.ToString();
        }
        public DataTable SelectAllRows()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectAllRowsQuery());
                dt = ds.Tables[0];
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return dt;
        }
        public string InsertRowQuery(CfgUserUserGroupMap obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgUserUserGroupMap.TableName);
            sb.AppendFormat("  {0}, {1} ", CfgUserUserGroupMap.ColumnNames.USER_ID, CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1} ) ", obj.Formatted_USER_ID, obj.Formatted_CFG_USER_GROUP_ID);

            return sb.ToString();
        }
        public void InsertRow(CfgUserUserGroupMap paramsObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = InsertRowQuery(paramsObj);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                dbManager.CommitTransaction();
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                dbManager.RollbackTransaction();
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        private string UpdateRowQuery(int id, CfgUserUserGroupMap obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgUserUserGroupMap.TableName);
            sb.AppendFormat("  {0}={1} ", CfgUserUserGroupMap.ColumnNames.USER_ID, obj.Formatted_USER_ID);
            sb.AppendFormat("  , {0}={1} ", CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID, obj.Formatted_CFG_USER_GROUP_ID);
            sb.AppendFormat(" where {0} = {1} ", CfgUserUserGroupMap.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgUserUserGroupMap paramsObj)
        {
            string query = string.Empty;
            int return_int = 0;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, paramsObj);
                return_int= dbManager.ExecuteNonQuery(CommandType.Text, query);
                dbManager.CommitTransaction();
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                dbManager.RollbackTransaction();
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return return_int;
        }
        public string DeleteRowQuery(string userid)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgUserUserGroupMap.TableName);
            sb.AppendFormat(" {0} = '{1}' ", CfgUserUserGroupMap.PrimaryKey, userid);
            return sb.ToString();
        }
        public int DeleteRow(string userid)
        {
            string query = string.Empty;
            int return_int = 0;
            try
            {
                dbManager.Open();
                query = DeleteRowQuery(userid);
                return_int= dbManager.ExecuteNonQuery(CommandType.Text, query);
                dbManager.CommitTransaction();
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                dbManager.RollbackTransaction();
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return return_int;
        }
        private string SelectRowByIdQuery(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1} ", CfgUserUserGroupMap.ColumnNames.USER_ID, CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat("  from  {0}  ", CfgUserUserGroupMap.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgUserUserGroupMap.PrimaryKey, id);
            return sb.ToString();
        }
        public CfgUserUserGroupMap SelectRowById(int id)
        {
            CfgUserUserGroupMap obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgUserUserGroupMap().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserUserGroupMap)arr[0];
                }
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return obj;
        }
    }
}
