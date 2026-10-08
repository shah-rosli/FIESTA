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
    public class CfgUserDelegateHisDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgUserDelegateHisDAL(IConfiguration configuration, HttpContext httpContext)
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
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9} ",  CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegateHis.ColumnNames.USER_ID, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, CfgUserDelegateHis.ColumnNames.START_DATETIME, CfgUserDelegateHis.ColumnNames.END_DATETIME, CfgUserDelegateHis.ColumnNames.ACTIVE, CfgUserDelegateHis.ColumnNames.INITIATE_DATE);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegateHis.TableName);
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
        public string InsertRowQuery(CfgUserDelegateHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgUserDelegateHis.TableName);
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8},{9} ",  CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegateHis.ColumnNames.USER_ID, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, CfgUserDelegateHis.ColumnNames.START_DATETIME, CfgUserDelegateHis.ColumnNames.END_DATETIME, CfgUserDelegateHis.ColumnNames.ACTIVE, CfgUserDelegateHis.ColumnNames.INITIATE_DATE,CfgUserDelegateHis.ColumnNames.DELEGATOR_REMARK);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8},{9} ) ", obj.Formatted_CFG_USER_DELEGATE_HIS_USER_ID, obj.Formatted_CFG_USER_DELEGATE_HIS_DELEGATE, obj.Formatted_CFG_USER_DELEGATE_ID, obj.Formatted_USER_ID, obj.Formatted_DELEGATEE_USER_ID, obj.Formatted_START_DATETIME, obj.Formatted_END_DATETIME, obj.Formatted_ACTIVE, DataAccessAssistant.OracleSystimestampToUTC(),obj.Formatted_DELEGATOR_REMARK);

            return sb.ToString();
        }
        public void InsertRow(CfgUserDelegateHis paramsObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = InsertRowQuery(paramsObj);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
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
        private string UpdateRowQuery(int id, CfgUserDelegateHis obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgUserDelegateHis.TableName);
            sb.AppendFormat("  {0}={1} ", CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_ID, obj.Formatted_CFG_USER_DELEGATE_HIS_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID, obj.Formatted_CFG_USER_DELEGATE_HIS_USER_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, obj.Formatted_CFG_USER_DELEGATE_HIS_DELEGATE);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID, obj.Formatted_CFG_USER_DELEGATE_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.USER_ID, obj.Formatted_USER_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, obj.Formatted_DELEGATEE_USER_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.START_DATETIME, obj.Formatted_START_DATETIME);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.END_DATETIME, obj.Formatted_END_DATETIME);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.ACTIVE, obj.Formatted_ACTIVE);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegateHis.ColumnNames.INITIATE_DATE, obj.Formatted_INITIATE_DATE);
            sb.AppendFormat(" where {0} = {1} ", CfgUserDelegateHis.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgUserDelegateHis paramsObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, paramsObj);
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
        private string DeleteRowQuery(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgUserDelegateHis.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgUserDelegateHis.PrimaryKey, id);
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
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9} ", CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegateHis.ColumnNames.USER_ID, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, CfgUserDelegateHis.ColumnNames.START_DATETIME, CfgUserDelegateHis.ColumnNames.END_DATETIME, CfgUserDelegateHis.ColumnNames.ACTIVE, CfgUserDelegateHis.ColumnNames.INITIATE_DATE);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegateHis.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgUserDelegateHis.PrimaryKey, id);
            return sb.ToString();
        }
        public CfgUserDelegateHis SelectRowById(int id)
        {
            CfgUserDelegateHis obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgUserDelegateHis().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserDelegateHis)arr[0];
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

        private string SelectDelegationHistByDelegateeQuery(CfgUserDelegateHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6} START_DATETIME, {7} END_DATETIME, {8}, {9} INITIATE_DATE, delegatee.{10} delegatee_name, delegatee.{11} delegatee_email,{12} ",
                CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID,
                CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID,
                CfgUserDelegateHis.ColumnNames.USER_ID, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID,
                obj.Formatted_START_DATETIME_FOR_DISPLAY,obj.Formatted_END_DATETIME_FOR_DISPLAY,
                CfgUserDelegateHis.ColumnNames.ACTIVE,obj.Formatted_INITIATE_DATE_FOR_DISPLAY,
                CfgUser.ColumnNamesOnly.USER_FULL_NAME, CfgUser.ColumnNamesOnly.USER_EMAIL,CfgUserDelegateHis.ColumnNames.DELEGATOR_REMARK);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegateHis.TableName);
            sb.AppendFormat(" inner join {0} delegatee on {1}=delegatee.{2}", CfgUser.TableName, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" where {0}={1}", CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, obj.Formatted_DELEGATEE_USER_ID);
            sb.AppendFormat(" order by {0}", CfgUserDelegateHis.ColumnNames.INITIATE_DATE);
            return sb.ToString();
        }
        public DataTable SelectDelegationHistByDelegatee(CfgUserDelegateHis obj)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectDelegationHistByDelegateeQuery(obj));
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


        private string SelectDelegationHistByUserIdQuery(CfgUserDelegateHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6} START_DATETIME, {7} END_DATETIME, {8}, {9} INITIATE_DATE, delegatee.{10} delegatee_name, delegatee.{11} delegatee_email,{12} ",
                CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_ID, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_USER_ID,
                CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_HIS_DELEGATE, CfgUserDelegateHis.ColumnNames.CFG_USER_DELEGATE_ID,
                CfgUserDelegateHis.ColumnNames.USER_ID, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID,
                obj.Formatted_START_DATETIME_FOR_DISPLAY, obj.Formatted_END_DATETIME_FOR_DISPLAY,
                CfgUserDelegateHis.ColumnNames.ACTIVE, obj.Formatted_INITIATE_DATE_FOR_DISPLAY,
                CfgUser.ColumnNamesOnly.USER_FULL_NAME, CfgUser.ColumnNamesOnly.USER_EMAIL,CfgUserDelegateHis.ColumnNames.DELEGATOR_REMARK);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegateHis.TableName);
            sb.AppendFormat(" inner join {0} delegatee on {1}=delegatee.{2}", CfgUser.TableName, CfgUserDelegateHis.ColumnNames.DELEGATEE_USER_ID, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" where {0}='{1}'", CfgUserDelegateHis.ColumnNames.USER_ID, obj.USER_ID);
            sb.AppendFormat(" order by {0}", CfgUserDelegateHis.ColumnNames.INITIATE_DATE);
            return sb.ToString();
        }
        public DataTable SelectDelegationHistByUserId(CfgUserDelegateHis obj)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectDelegationHistByUserIdQuery(obj));
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

    }
}
