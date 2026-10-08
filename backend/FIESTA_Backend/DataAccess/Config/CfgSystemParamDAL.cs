using FIESTA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgSystemParamDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgSystemParamDAL(IConfiguration configuration, HttpContext httpContext)
        {
            this._config = configuration;
            this._httpContext = httpContext;

            _envProperties = new EnvironmentProperties(_config, _httpContext);
            _connectionString = _envProperties.CONN_STRING();
            _providerType = _config.GetSection("ProviderName").Value;
            dbManager = new DBManager(_providerType);  //new DBManager(DataProvider.Odbc);
            dbManager.ConnectionString = _connectionString;
            logger = log4net.LogManager.GetLogger("GeneralLog");
        }


        public DataTable GetCfgSystemParam()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectCfgSystemParamQuery(string.Empty));
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

        public DataTable GetCfgSystemParamByCategory(string category)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectCfgSystemParamQuery(category));
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

        public DataTable GetCfgSystemParamHistory(int id, CfgSystemParamHis obj)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetCfgSysParamHistory(id, obj));
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

        public void SaveNewCfgSystemParam(CfgSystemParam paramsObj)
        {
            string query = string.Empty;

            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                query = InsertCfgSystemParamQuery(paramsObj);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                SnapAuditTrail(dbManager, paramsObj);
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

        public int UpdateCfgSystemParam(CfgSystemParam paramsObj)
        {
            string query = string.Empty;

            try
            {
                dbManager.Open();
                int result;
                dbManager.BeginTransaction();
                query = UpdateCfgSystemParamQuery(paramsObj);
                result = dbManager.ExecuteNonQuery(CommandType.Text, query);
                SnapAuditTrail(dbManager, paramsObj);
                dbManager.CommitTransaction();
                return result;
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

        public int DeleteCfgSystemParam(int id)
        {
            string query = string.Empty;

            try
            {
                dbManager.Open();

                query = DeleteCfgSystemParamQuery(id);
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

        private void SnapAuditTrail(IDBManager dbManager, CfgSystemParam obj)
        {
            dbManager.ExecuteNonQuery(CommandType.Text, InsertSystemParamHisQuery(obj));
        }

        private string InsertSystemParamHisQuery(CfgSystemParam obj)
        {
            Object sysParamId = dbManager.ExecuteScalar(CommandType.Text, SelectMaxSytemParamHisByParamKey(obj));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert Into {0} ( ", CfgSystemParamHis.TableName);
            sb.AppendFormat(" {0},{1},{2},{3},{4},{5},{6}", CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_USER_ID,
                CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DELEGATE, CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DATE,
                CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_ID, CfgSystemParamHis.ColumnNames.PARAM_KEY,
                CfgSystemParamHis.ColumnNames.PARAM_CATEGORY, CfgSystemParamHis.ColumnNames.PARAM_VALUE);
            sb.AppendFormat(" ) ( ");
            sb.AppendFormat(" select ");
            sb.AppendFormat(" '{0}','{1}',{2},{3},{4},{5},{6} ", obj.TokenObj.USER_ID, obj.TokenObj.DELEGATE_ID,
                DataAccessAssistant.OracleSystimestampToUTC(), CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID,
                CfgSystemParam.ColumnNames.PARAM_KEY, CfgSystemParam.ColumnNames.PARAM_CATEGORY,
                CfgSystemParam.ColumnNames.PARAM_VALUE);
            sb.AppendFormat(" from {0} where {1} = {2} )", CfgSystemParam.TableName, CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID, Convert.ToDecimal(sysParamId));
            return sb.ToString();


        }

        private string GetCfgSysParamHistory(int id, CfgSystemParamHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select ");
            sb.AppendFormat(" {0},{1},{2},{3} CFG_SYSTEM_PARAM_HIS_DATE,{4},{5},{6},{7} ",
               CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_ID,
               CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_USER_ID,
               CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DELEGATE, 
               obj.Formatted_CFG_SYSTEM_PARAM_HIS_DATE_FOR_DISPLAY,
               CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_ID, CfgSystemParamHis.ColumnNames.PARAM_KEY,
               CfgSystemParamHis.ColumnNames.PARAM_CATEGORY, CfgSystemParamHis.ColumnNames.PARAM_VALUE);
            sb.AppendFormat(",usr.{0} as MODIFIED_BY_NAME,delegatee.{0} as MODIFIED_BY_DELNAME, usr.{1} as MODIFIED_BY_EMAIL"
    , CfgUser.ColumnNamesOnly.USER_FULL_NAME, CfgUser.ColumnNamesOnly.USER_EMAIL);
            sb.AppendFormat(" from {0} ", CfgSystemParamHis.TableName);
            sb.AppendFormat(" inner join {0} usr on {1}=usr.{2}", CfgUser.TableName, CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_USER_ID, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" left join {0} delegatee on {1}=delegatee.{2}", CfgUser.TableName, CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_HIS_DELEGATE, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemParamHis.ColumnNames.CFG_SYSTEM_PARAM_ID, id);
            return sb.ToString();
        }

        private string SelectMaxSytemParamHisByParamKey(CfgSystemParam obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" select max({0}) from {1} where {2} = '{3}' ", CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID, CfgSystemParam.TableName, CfgSystemParam.ColumnNames.PARAM_KEY, obj.PARAM_KEY);

            return sb.ToString();
        }
        private string UpdateCfgSystemParamQuery(CfgSystemParam paramsObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" update {0} set ", CfgSystemParam.TableName);
            sb.AppendFormat(" {0} = '{1}' ", CfgSystemParam.ColumnNames.PARAM_CATEGORY, paramsObj.Formatted_PARAM_CATEGORY);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgSystemParam.ColumnNames.PARAM_KEY, paramsObj.Formatted_PARAM_KEY);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgSystemParam.ColumnNames.PARAM_VALUE, paramsObj.Formatted_PARAM_VALUE);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID, paramsObj.CFG_SYSTEM_PARAM_ID);

            return sb.ToString();
        }

        private string DeleteCfgSystemParamQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" delete from {0}  ", CfgSystemParam.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID, id);

            return sb.ToString();
        }



        private string InsertCfgSystemParamQuery(CfgSystemParam paramsObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" insert into {0}  ({1}, {2}, {3} )", CfgSystemParam.TableName, CfgSystemParam.ColumnNames.PARAM_KEY, CfgSystemParam.ColumnNames.PARAM_VALUE, CfgSystemParam.ColumnNames.PARAM_CATEGORY);
            sb.AppendFormat(" values ('{0}','{1}','{2}' )", paramsObj.Formatted_PARAM_KEY, paramsObj.Formatted_PARAM_VALUE, paramsObj.Formatted_PARAM_CATEGORY);
            return sb.ToString();
        }

        private string SelectCfgSystemParamQuery(string category)
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendFormat(" select {0} as {1} ", CfgSystemParam.ColumnNames.CfgSysParamId , CfgSystemParam.ColumnVariable.CfgSysParamId );
            //sb.AppendFormat(" , {0} as {1} ", CfgSystemParam.ColumnNames.ParamKey, CfgSystemParam.ColumnVariable.ParamKey);
            //sb.AppendFormat(" , {0} as {1} ", CfgSystemParam.ColumnNames.ParamValue, CfgSystemParam.ColumnVariable.ParamValue);
            //sb.AppendFormat(" , {0} as {1} ", CfgSystemParam.ColumnNames.ParamCategory, CfgSystemParam.ColumnVariable.ParamCategory);
            sb.Append(" select * from ");
            sb.AppendFormat("  {0} ", CfgSystemParam.TableName);
            if (!string.IsNullOrEmpty(category))
            {
                sb.AppendFormat(" where {0} like '{1}%' ", CfgSystemParam.ColumnNames.PARAM_CATEGORY, category);
            }


            return sb.ToString();
        }

        private string GetInsRowsByUniqConst(string sysCat, string sysKey)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemParam.TableName);
            sb.AppendFormat(" where {0} = '{1}' and {2} ='{3}' ", CfgSystemParam.ColumnNames.PARAM_CATEGORY, sysCat, CfgSystemParam.ColumnNames.PARAM_KEY, sysKey);
            return sb.ToString();
        }

        private string GetUpdRowsByUniqConst(string Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemParam.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemParam.ColumnNames.CFG_SYSTEM_PARAM_ID, Id);
            return sb.ToString();
        }

        public DataTable SelectInsRowsWithData(string sysCat, string sysKey)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetInsRowsByUniqConst(sysCat, sysKey));
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

        public DataTable SelectUpdRowsWithData(string purId)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetUpdRowsByUniqConst(purId));
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

        public DataTable GetSystemParamByCategory(string category)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetSystemParamByCategoryQuery(category));
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

        private string GetSystemParamByCategoryQuery(string category)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemParam.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemParam.ColumnNames.PARAM_CATEGORY, DataConverter.FormatSQLForString(category));
            return sb.ToString();
        }
    }
}
