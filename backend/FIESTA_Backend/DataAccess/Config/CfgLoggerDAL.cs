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
    public class CfgLoggerDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgLoggerDAL(IConfiguration configuration, HttpContext httpContext)
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
                sb.Append(" select * from ");
                sb.AppendFormat("  {0} ", CfgLogger.TableName);
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

        public string InsertRowQuery(CfgLogger obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgLogger.TableName);
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5},{6} ", CfgLogger.ColumnNames.LOGGER_DATE, CfgLogger.ColumnNames.LOGGER_TYPE, CfgLogger.ColumnNames.LOGGER_PLATFORM, CfgLogger.ColumnNames.LOGGER_USER, CfgLogger.ColumnNames.LOGGER_DESCRIPTION, CfgLogger.ColumnNames.LOGGER_SHOW_USER, CfgLogger.ColumnNames.LOGGER_PAGE);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5} ,{6}) ", obj.Formatted_LOGGER_DATE, obj.Formatted_LOGGER_TYPE, obj.Formatted_LOGGER_PLATFORM, obj.TokenObj==null?  string.Format("'{0}'",obj.token_substitute): string.Format("'{0}'", obj.TokenObj.USER_ID), obj.Formatted_LOGGER_DESCRIPTION, obj.Formatted_LOGGER_SHOW_USER,obj.Formatted_LOGGER_PAGE);
            return sb.ToString();
        }

        public void InsertRow(CfgLogger paramsObj)
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
                dbManager.RollbackTransaction();
                logger.Error(ce.StackTrace);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
       
        private string DeleteRowQuery(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Delete from  {0} where ", CfgLogger.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgLogger.PrimaryKey, id);
            return sb.ToString();
        }


        public int DeleteRow(int id)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = DeleteRowQuery(id);
                return dbManager.ExecuteNonQuery(CommandType.Text, query);
            }
            catch (Exception ce)
            {
                logger.Error(ce.StackTrace);
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        private string SelectRowByIdQuery(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6},{7} ", CfgLogger.ColumnNames.LOGGER_ID, CfgLogger.ColumnNames.LOGGER_DATE, CfgLogger.ColumnNames.LOGGER_TYPE, CfgLogger.ColumnNames.LOGGER_PLATFORM, CfgLogger.ColumnNames.LOGGER_USER, CfgLogger.ColumnNames.LOGGER_DESCRIPTION, CfgLogger.ColumnNames.LOGGER_SHOW_USER,CfgLogger.ColumnNames.LOGGER_PAGE);
            sb.AppendFormat("  from  {0}  ", CfgLogger.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgLogger.PrimaryKey, id);
            return sb.ToString();
        }
        
        public CfgLogger SelectRowById(int id)
        {
            CfgLogger obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgLogger().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgLogger)arr[0];
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
