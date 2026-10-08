using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgUserDelegateDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgUserDelegateDAL(IConfiguration configuration, HttpContext httpContext)
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
        private string SelectAllRowsQuery(CfgUserDelegate obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6},{7} ", CfgUserDelegate.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegate.ColumnNames.USER_ID, CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, obj.Formatted_START_DATETIME_FOR_DISPLAY, obj.Formatted_END_DATETIME_FOR_DISPLAY, CfgUserDelegate.ColumnNames.ACTIVE, obj.Formatted_INITIATE_DATE_FOR_DISPLAY,CfgUserDelegate.ColumnNames.DELEGATOR_REMARK);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegate.TableName);
            //            sb.AppendFormat(" where {0}='Yes'", CfgUserDelegate.ColumnNames.ACTIVE);
            return sb.ToString();
        }
        public DataTable SelectAllRows(CfgUserDelegate obj)
        {
            DataTable dt= null;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectAllRowsQuery(obj));
                if (ds != null)
                    dt = ds.Tables[0];
                else
                    dt = new DataTable();
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
        private string InsertRowQuery(CfgUserDelegate obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgUserDelegate.TableName);
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5},{6}",  CfgUserDelegate.ColumnNames.USER_ID, CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, CfgUserDelegate.ColumnNames.START_DATETIME, CfgUserDelegate.ColumnNames.END_DATETIME, CfgUserDelegate.ColumnNames.ACTIVE, CfgUserDelegate.ColumnNames.INITIATE_DATE,CfgUserDelegate.ColumnNames.DELEGATOR_REMARK);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5},{6}) ",  obj.Formatted_USER_ID, obj.Formatted_DELEGATEE_USER_ID, obj.Formatted_START_DATETIME, obj.Formatted_END_DATETIME, obj.Formatted_ACTIVE, DataAccessAssistant.OracleSystimestampToUTC(),obj.Formatted_DELEGATOR_REMARK);

            return sb.ToString();
        }
        public void InsertRow(CfgUserDelegate paramsObj)
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
        private string UpdateRowQuery(int id, CfgUserDelegate obj)
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendFormat(" Update {0} set ", CfgUserDelegate.TableName);
            sb.AppendFormat(" {0}={1} ", CfgUserDelegate.ColumnNames.USER_ID, obj.Formatted_USER_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, obj.Formatted_DELEGATEE_USER_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegate.ColumnNames.START_DATETIME, obj.Formatted_START_DATETIME);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegate.ColumnNames.END_DATETIME, obj.Formatted_END_DATETIME);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegate.ColumnNames.ACTIVE, obj.Formatted_ACTIVE);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegate.ColumnNames.DELEGATOR_REMARK, obj.Formatted_DELEGATOR_REMARK);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserDelegate.ColumnNames.INITIATE_DATE, DataAccessAssistant.OracleSystimestampToUTC());
            sb.AppendFormat(" where {0} = {1} ", CfgUserDelegate.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgUserDelegate obj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, obj);
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

            sb.AppendFormat(" Delete from  {0} where ", CfgUserDelegate.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgUserDelegate.PrimaryKey, id);
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
        private string SelectRowByIdQuery(CfgUserDelegate obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6} ,{7}", CfgUserDelegate.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegate.ColumnNames.USER_ID, CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID,obj.Formatted_START_DATETIME_FOR_DISPLAY,obj.Formatted_END_DATETIME_FOR_DISPLAY, CfgUserDelegate.ColumnNames.ACTIVE,obj.Formatted_INITIATE_DATE_FOR_DISPLAY,CfgUserDelegate.ColumnNames.DELEGATOR_REMARK);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegate.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgUserDelegate.PrimaryKey, obj.CFG_USER_DELEGATE_ID);
            return sb.ToString();
        }
        public CfgUserDelegate SelectRowById(CfgUserDelegate obj)
        {
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(obj), new CfgUserDelegate().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserDelegate)arr[0];
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

        private string SelectRowByUserIdQuery(CfgUserDelegate obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3} START_DATETIME, {4} END_DATETIME, {5}, {6} INITIATE_DATE,{7}", CfgUserDelegate.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegate.ColumnNames.USER_ID, CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID,
                obj.Formatted_START_DATETIME_FOR_DISPLAY,obj.Formatted_END_DATETIME_FOR_DISPLAY, CfgUserDelegate.ColumnNames.ACTIVE, obj.Formatted_INITIATE_DATE_FOR_DISPLAY,CfgUserDelegate.ColumnNames.DELEGATOR_REMARK);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegate.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgUserDelegate.ColumnNames.USER_ID, obj.USER_ID);
            return sb.ToString();
        }
        public CfgUserDelegate SelectRowByUserId(CfgUserDelegate obj)
        {
            CfgUserDelegate sel_obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByUserIdQuery(obj), new CfgUserDelegate().GetType());
                if (arr != null && arr.Count > 0)
                {
                    sel_obj = (CfgUserDelegate)arr[0];
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
            return sel_obj;
        }

        private string SelectDelegationByDelegateeQuery(CfgUserDelegate obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("  {0}, {1}, {2}, {3} START_DATETIME, {4} END_DATETIME, {5}, {6} INITIATE_DATE, usr.{7} user_fullname, usr.{8} user_email, delegatee.{9} delegatee_fullname, delegatee.{10} delegatee_email ,{11}", 
                CfgUserDelegate.ColumnNames.CFG_USER_DELEGATE_ID, CfgUserDelegate.ColumnNames.USER_ID, CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, 
                obj.Formatted_START_DATETIME_FOR_DISPLAY,obj.Formatted_END_DATETIME_FOR_DISPLAY, CfgUserDelegate.ColumnNames.ACTIVE,obj.Formatted_INITIATE_DATE_FOR_DISPLAY, 
                CfgUser.ColumnNamesOnly.USER_FULL_NAME,CfgUser.ColumnNamesOnly.USER_EMAIL,CfgUser.ColumnNamesOnly.USER_FULL_NAME,CfgUser.ColumnNamesOnly.USER_EMAIL,CfgUserDelegate.ColumnNames.DELEGATOR_REMARK);
            sb.AppendFormat("  from  {0}  ", CfgUserDelegate.TableName);
            sb.AppendFormat(" inner join {0} usr on {1}=usr.{2}", CfgUser.TableName, CfgUserDelegate.ColumnNames.USER_ID, CfgUser.ColumnNamesOnly.USER_ID) ;
            sb.AppendFormat(" inner join {0} delegatee on {1}=delegatee.{2}", CfgUser.TableName, CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat("  where {0}='{1}'", CfgUserDelegate.ColumnNames.DELEGATEE_USER_ID, obj.DELEGATEE_USER_ID);
            sb.AppendFormat(" and {0}='Yes'", CfgUserDelegate.ColumnNames.ACTIVE);
            //sb.AppendFormat(" and trunc({0}) between TO_DATE({1}, 'DD/MM/YYYY') AND TO_DATE({2}, 'DD/MM/YYYY');", DataAccessAssistant.OracleSystimestampToUTC(),CfgUserDelegate.ColumnNames.START_DATETIME,CfgUserDelegate.ColumnNames.END_DATETIME);
            //sb.AppendFormat(" and trunc({0}) >= trunc({1})", DataAccessAssistant.OracleSystimestampToUTC(), CfgUserDelegate.ColumnNames.START_DATETIME);
            //sb.AppendFormat(" and trunc({0}) <= trunc({1})", DataAccessAssistant.OracleSystimestampToUTC(), CfgUserDelegate.ColumnNames.END_DATETIME);
            sb.AppendFormat(" and {0} >= {1}", DataAccessAssistant.OracleSystimestampToUTC(), CfgUserDelegate.ColumnNames.START_DATETIME);
            sb.AppendFormat(" and {0} <= {1}", DataAccessAssistant.OracleSystimestampToUTC(), CfgUserDelegate.ColumnNames.END_DATETIME);
            sb.AppendFormat(" order by {0}", CfgUserDelegate.ColumnNames.USER_ID);

            return sb.ToString();
        }
        public DataTable SelectDelegationByDelegatee(CfgUserDelegate obj)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectDelegationByDelegateeQuery(obj));
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

        public bool ProcessDelegation(CfgUserDelegate obj)
        {
            bool update_flag = false;
            CfgUserDelegate ori_obj = SelectRowByUserId(obj);
            CfgUserDelegate new_obj= null;
            CfgUserDelegateHis his_obj = null;
            CfgUserDelegateHisDAL hist_dal = new CfgUserDelegateHisDAL(_config, _httpContext);
            MapToCurrentTime(obj);
            string query = string.Empty;
            bool return_flag = false;
            if (ori_obj != null)
            {
                update_flag = true;
            }
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                if (update_flag)
                {
                    query = UpdateRowQuery(Convert.ToInt32((ori_obj.CFG_USER_DELEGATE_ID).ToString()), obj);
                }
                else
                {
                    query = InsertRowQuery(obj);
                }
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByUserIdQuery(obj), new CfgUserDelegate().GetType());
                new_obj = (CfgUserDelegate)arr[0];
                his_obj = new CfgUserDelegateHis();
                his_obj.CFG_USER_DELEGATE_HIS_USER_ID = obj.USER_ID;
                his_obj.CFG_USER_DELEGATE_HIS_DELEGATE = obj.DELEGATEE_USER_ID;
                his_obj.CFG_USER_DELEGATE_ID = new_obj.CFG_USER_DELEGATE_ID;
                his_obj.USER_ID = new_obj.USER_ID;
                his_obj.DELEGATEE_USER_ID = new_obj.DELEGATEE_USER_ID;
                his_obj.START_DATETIME = obj.START_DATETIME;
                his_obj.END_DATETIME = obj.END_DATETIME;
                his_obj.ACTIVE = new_obj.ACTIVE;
                his_obj.INITIATE_DATE = obj.INITIATE_DATE;
                his_obj.TokenObj = obj.TokenObj;
                his_obj.DELEGATOR_REMARK = obj.DELEGATOR_REMARK;
                query = hist_dal.InsertRowQuery(his_obj);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                dbManager.CommitTransaction();
                return_flag = true;
            }
            catch (Exception ce)
            {
                logger.Error(ce.Message);
                dbManager.RollbackTransaction();
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
            return return_flag;
        }

        public void MapToCurrentTime(CfgUserDelegate obj)
        {
            DateTimeOffset startDate = obj.START_DATETIME;
            DateTimeOffset endDate = obj.END_DATETIME;
            obj.START_DATETIME = new DateTimeOffset(startDate.Date.Year, startDate.Date.Month, startDate.Date.Day, 00, 00, 00, TimeSpan.Zero);
            obj.END_DATETIME = new DateTimeOffset(endDate.Date.Year, endDate.Date.Month, endDate.Date.Day, 23, 59, 59, TimeSpan.Zero);
        }

    }
}
