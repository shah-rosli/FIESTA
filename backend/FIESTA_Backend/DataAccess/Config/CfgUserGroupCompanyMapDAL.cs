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
    public class CfgUserGroupCompanyMapDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgUserGroupCompanyMapDAL(IConfiguration configuration, HttpContext httpContext)
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
            sb.AppendFormat("   {0}, {1} ", CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE);
            sb.AppendFormat("  from  {0}  ", CfgUserGroupCompanyMap.TableName);
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
        public string InsertRowQuery(CfgUserGroupCompanyMap obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgUserGroupCompanyMap.TableName);
            sb.AppendFormat("  {0}, {1} ", CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1} ) ", obj.Formatted_CFG_USER_GROUP_ID, obj.Formatted_COMPANY_CODE);

            return sb.ToString();
        }
        public void InsertRow(CfgUserGroupCompanyMap paramsObj)
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
        private string UpdateRowQuery(int id, CfgUserGroupCompanyMap obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgUserGroupCompanyMap.TableName);
            sb.AppendFormat("  {0}={1} ", CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, obj.Formatted_CFG_USER_GROUP_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE, obj.Formatted_COMPANY_CODE);
            sb.AppendFormat(" where {0} = {1} ", CfgUserGroupCompanyMap.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgUserGroupCompanyMap paramsObj)
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

            sb.AppendFormat(" Delete from  {0} where ", CfgUserGroupCompanyMap.TableName);
            sb.AppendFormat(" {0} = '{1}' ", CfgUserGroupCompanyMap.PrimaryKey, id.ToString());
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
        public string DeleteRowByUserGroupQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgUserGroupCompanyMap.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, id.ToString());
            return sb.ToString();
        }

        private string SelectRowByIdQuery(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("  {0}, {1} ", CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE);
            sb.AppendFormat("  from  {0}  ", CfgUserGroupCompanyMap.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgUserGroupCompanyMap.PrimaryKey, id);
            return sb.ToString();
        }
        public CfgUserGroupCompanyMap SelectRowById(int id)
        {
            CfgUserGroupCompanyMap obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgUserGroupCompanyMap().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserGroupCompanyMap)arr[0];
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

        public string[] SelectCompanyCodeByGroupName(string id)
        {
            CfgUserGroupCompanyMap obj = new CfgUserGroupCompanyMap();
            try
            {
                dbManager.Open();
                List<string> companyList = new List<string>();
                string[] emptyArr = new string[] { };
                if (id != null)
                {
                    ArrayList arr = dbManager.GetArrayofObjects(SelectCompanyCodeByUserGroupQuery(id), new CfgUserGroupCompanyMap().GetType());
                    if (arr != null && arr.Count > 0)
                    {
                        foreach (CfgUserGroupCompanyMap company in arr)
                        {
                            companyList.Add(company.COMPANY_CODE);
                        }
                        obj.arrCompanyCode = companyList.ToArray();
                    }
                    else
                    {
                        obj.arrCompanyCode = emptyArr;
                    }
                }
                else
                {
                    obj.arrCompanyCode = emptyArr;
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
            return obj.arrCompanyCode; 
        }

        private string SelectCompanyCodeByUserGroupQuery(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select distinct {0} from {1} where {2} ", CfgUserGroupCompanyMap.ColumnNames.COMPANY_CODE, CfgUserGroupCompanyMap.TableName,
                CfgUserGroupCompanyMap.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat(" in ( select {0} from {1}  where ( {2} = 'IT Super Admin' or {2} like '%PD%' ) ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, 
                CfgUserGroup.TableName, 
                CfgUserGroup.ColumnNames.USER_GROUP_NAME);
            sb.AppendFormat(" and {0} ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat(" in ( select {0} from {1}  where {2} = '{3}' ))", CfgUserUserGroupMap.ColumnNames.CFG_USER_GROUP_ID,CfgUserUserGroupMap.TableName, CfgUserUserGroupMap.ColumnNames.USER_ID,id);
            return sb.ToString();
        }
    }
}
