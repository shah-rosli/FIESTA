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
    public class CfgUserGroupMenuMapDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgUserGroupMenuMapDAL(IConfiguration configuration, HttpContext httpContext)
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
            sb.AppendFormat("   {0}, {1}, {2}, {3} ", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_MENU_MAP_ID, CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupMenuMap.ColumnNames.MENU_ID, CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION);
            sb.AppendFormat("  from  {0}  ", CfgUserGroupMenuMap.TableName);
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

        private string SelectAllRowsWithDescriptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3} ,{4},{5}", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_MENU_MAP_ID, CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupMenuMap.ColumnNames.MENU_ID, CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION,CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgSystemMenu.ColumnNames.MENU_NAME);
            sb.AppendFormat("  from  {0}  ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat(" inner join {0} on {1}={2}", CfgUserGroup.TableName, CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat(" inner join {0} on {1}={2}", CfgSystemMenu.TableName, CfgUserGroupMenuMap.ColumnNames.MENU_ID, CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID);


            return sb.ToString();
        }
        public DataTable SelectAllRowsWithDescription()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectAllRowsWithDescriptionQuery());
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




        private string SelectAllRowsQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3} ", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_MENU_MAP_ID, CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupMenuMap.ColumnNames.MENU_ID, CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION);
            sb.AppendFormat("  from  {0}  ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat(" where {0}='{1}'", CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID, id.ToString());
            return sb.ToString();
        }
        public DataTable SelectAllRows(decimal id)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectAllRowsQuery(id));
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

        public string InsertRowQuery(CfgUserGroupMenuMap obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat("  {0}, {1}, {2} ",  CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupMenuMap.ColumnNames.MENU_ID, CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2} ) ",  obj.Formatted_CFG_USER_GROUP_ID, obj.Formatted_MENU_ID, obj.Formatted_ACCESS_OPERATION);

            return sb.ToString();
        }
        public void InsertRow(CfgUserGroupMenuMap paramsObj)
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
        private string UpdateRowQuery(int id, CfgUserGroupMenuMap obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat("  {0}={1} ", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_MENU_MAP_ID, obj.Formatted_CFG_USER_GROUP_MENU_MAP_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, obj.Formatted_CFG_USER_GROUP_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserGroupMenuMap.ColumnNames.MENU_ID, obj.Formatted_MENU_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION, obj.Formatted_ACCESS_OPERATION);
            sb.AppendFormat(" where {0} = {1} ", CfgUserGroupMenuMap.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgUserGroupMenuMap paramsObj)
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
        public string DeleteRowQuery(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat(" {0} = '{1}' ", CfgUserGroupMenuMap.PrimaryKey, id);
            return sb.ToString();
        }
        public string DeleteRowByUserGroupQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, id.ToString());
            return sb.ToString();
        }
        public int DeleteRow(int id)
        {
            string query = string.Empty;
            int return_int = 0;
            try
            {
                dbManager.Open();
                query = DeleteRowQuery(id);
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
            sb.AppendFormat("   {0}, {1}, {2}, {3} ", CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_MENU_MAP_ID, CfgUserGroupMenuMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupMenuMap.ColumnNames.MENU_ID, CfgUserGroupMenuMap.ColumnNames.ACCESS_OPERATION);
            sb.AppendFormat("  from  {0}  ", CfgUserGroupMenuMap.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgUserGroupMenuMap.PrimaryKey, id.ToString());
            return sb.ToString();
        }
        public CfgUserGroupMenuMap SelectRowById(int id)
        {
            CfgUserGroupMenuMap obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgUserGroupMenuMap().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserGroupMenuMap)arr[0];
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
