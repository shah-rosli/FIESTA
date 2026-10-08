 using FIESTA_Backend.Models; 
 using FIESTA_Backend.Models.Common; 
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
    public class CfgMenuOperationMapDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgMenuOperationMapDAL(IConfiguration configuration, HttpContext httpContext)
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
            sb.AppendFormat("   {0}, {1} ", CfgMenuOperationMap.ColumnNames.CFG_SYSTEM_MENU_ID, CfgMenuOperationMap.ColumnNames.ACCESS_OPERATION);
            sb.AppendFormat("  from  {0}  ", CfgMenuOperationMap.TableName);
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
        public string InsertRowQuery(CfgMenuOperationMap obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgMenuOperationMap.TableName);
            sb.AppendFormat("  {0}, {1} ", CfgMenuOperationMap.ColumnNames.CFG_SYSTEM_MENU_ID, CfgMenuOperationMap.ColumnNames.ACCESS_OPERATION);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1} ) ", obj.Formatted_CFG_SYSTEM_MENU_ID, obj.Formatted_ACCESS_OPERATION);

            return sb.ToString();
        }
        public void InsertRow(CfgMenuOperationMap paramsObj)
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

        private string UpdateRowQuery(int id, CfgMenuOperationMap obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgMenuOperationMap.TableName);
            sb.AppendFormat("  {0}={1} ", CfgMenuOperationMap.ColumnNames.CFG_SYSTEM_MENU_ID, obj.Formatted_CFG_SYSTEM_MENU_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgMenuOperationMap.ColumnNames.ACCESS_OPERATION, obj.Formatted_ACCESS_OPERATION);
            sb.AppendFormat(" where {0} = {1} ", CfgMenuOperationMap.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgMenuOperationMap paramsObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, paramsObj);
                return dbManager.ExecuteNonQuery(CommandType.Text, query);
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
        public string DeleteRowQuery(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgMenuOperationMap.TableName);
            sb.AppendFormat(" {0} = '{1}' ", CfgMenuOperationMap.PrimaryKey, id.ToString());
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
                return_int=dbManager.ExecuteNonQuery(CommandType.Text, query);
                dbManager.CommitTransaction();
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
            return return_int;
        }
        private string SelectRowByIdQuery(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1} ", CfgMenuOperationMap.ColumnNames.CFG_SYSTEM_MENU_ID, CfgMenuOperationMap.ColumnNames.ACCESS_OPERATION);
            sb.AppendFormat("  from  {0}  ", CfgMenuOperationMap.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgMenuOperationMap.PrimaryKey, id);
            return sb.ToString();
        }
        public CfgMenuOperationMap SelectRowById(int id)
        {
            CfgMenuOperationMap obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgMenuOperationMap().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgMenuOperationMap)arr[0];
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
