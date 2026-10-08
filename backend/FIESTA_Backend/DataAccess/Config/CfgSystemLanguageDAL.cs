using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgSystemLanguageDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgSystemLanguageDAL(IConfiguration configuration, HttpContext httpContext)
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


        public List<CfgSystemLanguage> GetCfgSystemLanguage()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectCfgSystemLanguageQuery());
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
            return DataConverter.DataTableToList<CfgSystemLanguage>(dt);
        }

        public void SaveNewCfgSystemLanguage(CfgSystemLanguage paramsObj)
        {
            string query = string.Empty;
            
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                query = InsertCfgSystemLanguageQuery(paramsObj);
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

        public int UpdateCfgSystemLanguage(CfgSystemLanguage paramsObj)
        {
            string query = string.Empty;
            int result;
            try
            {
                dbManager.Open();
                
                query = UpdateCfgSystemLanguageQuery(paramsObj);
                result= dbManager.ExecuteNonQuery(CommandType.Text, query);
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

        private void SnapAuditTrail(IDBManager dbManager, CfgSystemLanguage obj)
        {
            dbManager.ExecuteNonQuery(CommandType.Text, InsertHistoryQuery(obj));
        }

        private string InsertHistoryQuery(CfgSystemLanguage obj)
        {
            Object id = dbManager.ExecuteScalar(CommandType.Text, SelectMaxHistoryByParamKey(obj));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert Into {0} ( ", CfgSystemLanguageHis.TableName);
            sb.AppendFormat(" {0},{1},{2},{3},{4},{5},{6},{7}", CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_USER_ID,
                CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_DELEGATE, CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_DATE,
                CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, CfgSystemLanguageHis.ColumnNames.LABEL_NAME,
                CfgSystemLanguageHis.ColumnNames.EN, CfgSystemLanguageHis.ColumnNames.JA, CfgSystemLanguageHis.ColumnNames.ZH);
            sb.AppendFormat(" ) ( ");
            sb.AppendFormat(" select ");
            sb.AppendFormat(" '{0}','{1}',{2},{3},{4},{5},{6},{7} ", obj.TokenObj.USER_ID, obj.TokenObj.DELEGATE_ID,
                DataAccessAssistant.OracleSystimestampToUTC(), CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID,
                CfgSystemLanguage.ColumnNames.LABEL_NAME, CfgSystemLanguage.ColumnNames.EN,
                CfgSystemLanguage.ColumnNames.JA, CfgSystemLanguage.ColumnNames.ZH);
            sb.AppendFormat(" from {0} where {1} = {2} )", CfgSystemLanguage.TableName, CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, Convert.ToDecimal(id));
            return sb.ToString();


        }
        public DataTable GetCfgHistory(int id,CfgSystemLanguageHis obj)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetCfgHistoryQuery(id,obj));
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
        private string GetCfgHistoryQuery(int id, CfgSystemLanguageHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select ");
            sb.AppendFormat(" {0},{1},{2} CFG_SYSTEM_LANG_HIS_DATE,{3},{4},{5},{6},{7}", CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_USER_ID,
               CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANG_HIS_DELEGATE, obj.Formatted_CFG_SYSTEM_LANG_HIS_DATE_FOR_DISPLAY,
               CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, CfgSystemLanguageHis.ColumnNames.LABEL_NAME,
               CfgSystemLanguageHis.ColumnNames.EN, CfgSystemLanguageHis.ColumnNames.JA, CfgSystemLanguageHis.ColumnNames.ZH);
            sb.AppendFormat(" from {0} where {1} = '{2}' ", CfgSystemLanguageHis.TableName, CfgSystemLanguageHis.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, id);
            return sb.ToString();
        }


        public int DeleteCfgSystemLanguage(int id)
        {
            string query = string.Empty;

            try
            {
                dbManager.Open();

                query = DeleteCfgSystemLanguageQuery(id);
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
        private string UpdateCfgSystemLanguageQuery(CfgSystemLanguage paramsObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" update {0} set ", CfgSystemLanguage.TableName);
            sb.AppendFormat(" {0} = '{1}' ", CfgSystemLanguage.ColumnNames.LABEL_NAME, paramsObj.Formatted_LABEL_NAME);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgSystemLanguage.ColumnNames.EN, paramsObj.Formatted_EN);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgSystemLanguage.ColumnNames.JA, paramsObj.Formatted_JA);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgSystemLanguage.ColumnNames.ZH, paramsObj.Formatted_ZH);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID , paramsObj.CFG_SYSTEM_LANGUAGE_ID);

            return sb.ToString();
        }

        private string DeleteCfgSystemLanguageQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" delete from {0}  ", CfgSystemLanguage.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, id);

            return sb.ToString();
        }

        private string SelectMaxHistoryByParamKey(CfgSystemLanguage obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" select max({0}) from {1} where {2} = '{3}' ", CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, CfgSystemLanguage.TableName, CfgSystemLanguage.ColumnNames.LABEL_NAME, obj.LABEL_NAME);

            return sb.ToString();
        }

        private string InsertCfgSystemLanguageQuery(CfgSystemLanguage paramsObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" insert into {0}  ({1}, {2}, {3}, {4} )", CfgSystemLanguage.TableName, CfgSystemLanguage.ColumnNames.LABEL_NAME, CfgSystemLanguage.ColumnNames.EN, CfgSystemLanguage.ColumnNames.JA, CfgSystemLanguage.ColumnNames.ZH);
            sb.AppendFormat(" values ('{0}','{1}','{2}','{3}' )", paramsObj.Formatted_LABEL_NAME, paramsObj.Formatted_EN, paramsObj.Formatted_JA, paramsObj.Formatted_ZH);
            return sb.ToString();
        }

        private string SelectCfgSystemLanguageQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" select * from ");
            sb.AppendFormat("  {0} ", CfgSystemLanguage.TableName);


            return sb.ToString();
        }

        private string GetInsRowsByUniqConst(string lblName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemLanguage.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemLanguage.ColumnNames.LABEL_NAME, lblName);
            return sb.ToString();
        }

        private string GetUpdRowsByUniqConst(string Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemLanguage.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemLanguage.ColumnNames.CFG_SYSTEM_LANGUAGE_ID, Id);
            return sb.ToString();
        }

        public DataTable SelectInsRowsWithData(string lblName)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetInsRowsByUniqConst(lblName));
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

        public DataTable SelectUpdRowsWithData(string lanId)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetUpdRowsByUniqConst(lanId));
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
