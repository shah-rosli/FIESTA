using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgSystemMenuDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgSystemMenuDAL(IConfiguration configuration, HttpContext httpContext)
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
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6} ", CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, CfgSystemMenu.ColumnNames.MENU_NAME, CfgSystemMenu.ColumnNames.MENU_PARENT_ID, CfgSystemMenu.ColumnNames.MENU_SEQUENCE, CfgSystemMenu.ColumnNames.MENU_ICON, CfgSystemMenu.ColumnNames.MENU_LINK, CfgSystemMenu.ColumnNames.ACTIVE);
            sb.AppendFormat("  from  {0}  ", CfgSystemMenu.TableName);
            sb.AppendFormat(" order by {0}", CfgSystemMenu.ColumnNames.MENU_SEQUENCE);
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

        public List<CfgSystemMenu> SelectAllRowsList()
        {
            return DataConverter.DataTableToList<CfgSystemMenu>(SelectAllRows());
        }

        private string SelectKey(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat(" {0} ", CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID);
            sb.AppendFormat(" from  {0}  ", CfgSystemMenu.TableName);
            sb.AppendFormat(" where {0}='{1}'", CfgSystemMenu.ColumnNames.MENU_NAME, name);
            return sb.ToString();
        }

        public CfgSystemMenu SelectCfgSystemMenu(int id)
        {
            CfgSystemMenu obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgSystemMenu().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgSystemMenu)arr[0];
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

        public List<CfgSystemMenu> GetCfgSystemMenuWithChildDetails()
        {
            CfgMenuOperationMapDAL operDAL = new CfgMenuOperationMapDAL(_config, _httpContext);
            DataTable dtOperation = operDAL.SelectAllRows();
            DataTable dt = SelectAllRows();
            List<CfgSystemMenu> lsMaster = DataConverter.DataTableToList<CfgSystemMenu>(dt);

            foreach (CfgSystemMenu objMaster in lsMaster)
            {
                DataRow[] draCurrency = dtOperation.Select(string.Format("CFG_SYSTEM_MENU_ID={0}", objMaster.Formatted_CFG_SYSTEM_MENU_ID));

                if (draCurrency.Length > 0)
                {
                    objMaster.saOperationMap = DataConverter.DataRowArrayToStringArray(draCurrency, CfgMenuOperationMap.ColumnNamesOnly.ACCESS_OPERATION);
                }
            }
            return lsMaster;
        }


        private string InsertRowQuery(CfgSystemMenu obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgSystemMenu.TableName);
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5} ", CfgSystemMenu.ColumnNames.MENU_NAME, CfgSystemMenu.ColumnNames.MENU_PARENT_ID, CfgSystemMenu.ColumnNames.MENU_SEQUENCE, CfgSystemMenu.ColumnNames.MENU_ICON, CfgSystemMenu.ColumnNames.MENU_LINK, CfgSystemMenu.ColumnNames.ACTIVE);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2}, {3}, {4}, {5} ) ", obj.Formatted_MENU_NAME, obj.Formatted_MENU_PARENT_ID, obj.Formatted_MENU_SEQUENCE, obj.Formatted_MENU_ICON, obj.Formatted_MENU_LINK, obj.Formatted_ACTIVE);

            return sb.ToString();
        }

        public void SaveNewCfgSystemMenu(CfgSystemMenu obj)
        {
            string query = string.Empty;
            CfgMenuOperationMap mapObj = null;
            CfgMenuOperationMapDAL dtl = new CfgMenuOperationMapDAL(_config, _httpContext);
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                query = InsertRowQuery(obj);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                SnapAuditTrail(dbManager, obj);
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
            Object id_key = null;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                id_key= dbManager.ExecuteScalar(CommandType.Text, SelectKey(obj.MENU_NAME));
                obj.CFG_SYSTEM_MENU_ID = Convert.ToDecimal(id_key.ToString());
                if (id_key != null)
                {
                    foreach (string operation in obj.saOperationMap)
                    {
                        mapObj = new CfgMenuOperationMap
                        {
                            CFG_SYSTEM_MENU_ID = obj.CFG_SYSTEM_MENU_ID,
                            ACCESS_OPERATION = operation
                        };
                        dbManager.ExecuteNonQuery(CommandType.Text, dtl.InsertRowQuery(mapObj));
                    }
                    dbManager.CommitTransaction();
                }
                else
                {
                    dbManager.RollbackTransaction();
                }
            }
            catch (Exception ce)
            {
                dbManager.ExecuteNonQuery(CommandType.Text, DeleteRowQuery(Convert.ToInt32(id_key.ToString())));
                logger.Error(ce.StackTrace);
                dbManager.RollbackTransaction();
                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        public void InsertRow(CfgSystemMenu paramsObj)
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
        private string UpdateRowQuery(int id, CfgSystemMenu obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgSystemMenu.TableName);
            //            sb.AppendFormat("  {0}={1} ", CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, obj.Formatted_CFG_SYSTEM_MENU_ID);
            sb.AppendFormat("    {0}={1} ", CfgSystemMenu.ColumnNames.MENU_NAME, obj.Formatted_MENU_NAME);
            sb.AppendFormat("  ,  {0}={1} ", CfgSystemMenu.ColumnNames.MENU_PARENT_ID, obj.Formatted_MENU_PARENT_ID);
            sb.AppendFormat("  ,  {0}={1} ", CfgSystemMenu.ColumnNames.MENU_SEQUENCE, obj.Formatted_MENU_SEQUENCE);
            sb.AppendFormat("  ,  {0}={1} ", CfgSystemMenu.ColumnNames.MENU_ICON, obj.Formatted_MENU_ICON);
            sb.AppendFormat("  ,  {0}={1} ", CfgSystemMenu.ColumnNames.MENU_LINK, obj.Formatted_MENU_LINK);
            sb.AppendFormat("  ,  {0}={1} ", CfgSystemMenu.ColumnNames.ACTIVE, obj.Formatted_ACTIVE);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemMenu.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgSystemMenu obj)
        {
            string query = string.Empty;
            int return_int = 0;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, obj);
                return_int= dbManager.ExecuteNonQuery(CommandType.Text, query);
                SnapAuditTrail(dbManager, obj);
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

        private void SnapAuditTrail(IDBManager dbManager, CfgSystemMenu obj)
        {
            dbManager.ExecuteNonQuery(CommandType.Text, InsertHistoryQuery(obj));
        }

        private string InsertHistoryQuery(CfgSystemMenu obj)
        {
            Object id;
            id = dbManager.ExecuteScalar(CommandType.Text, SelectMaxHistoryByParamKey(obj));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert Into {0} ( ", CfgSystemMenuHis.TableName);
            sb.AppendFormat(" {0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_USER_ID,
                CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DELEGATE, CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DATE,
                CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_ID, CfgSystemMenuHis.ColumnNames.MENU_NAME, CfgSystemMenuHis.ColumnNames.MENU_PARENT_ID,
                CfgSystemMenuHis.ColumnNames.MENU_SEQUENCE, CfgSystemMenuHis.ColumnNames.MENU_ICON, CfgSystemMenuHis.ColumnNames.MENU_LINK, CfgSystemMenuHis.ColumnNames.ACTIVE);
            sb.AppendFormat(" ) ( ");
            sb.AppendFormat(" select ");
            sb.AppendFormat(" '{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9}", obj.TokenObj.USER_ID, obj.TokenObj.DELEGATE_ID,
                DataAccessAssistant.OracleSystimestampToUTC(), CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID,
                CfgSystemMenu.ColumnNames.MENU_NAME, CfgSystemMenu.ColumnNames.MENU_PARENT_ID,
                CfgSystemMenu.ColumnNames.MENU_SEQUENCE, CfgSystemMenu.ColumnNames.MENU_ICON,
                CfgSystemMenu.ColumnNames.MENU_LINK, 
                CfgSystemMenu.ColumnNames.ACTIVE);
            sb.AppendFormat(" from {0} where {1} = {2} )", CfgSystemMenu.TableName, CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, Convert.ToDecimal(id));
            return sb.ToString();


        }
        public DataTable GetCfgHistory(int id,CfgSystemMenuHis obj)
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
        private string GetCfgHistoryQuery(int id,CfgSystemMenuHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select ");
            sb.AppendFormat(" {0},{1},{2},{3} CFG_SYSTEM_MENU_HIS_DATE,{4},{5},{6},{7},{8},{9},{10} ",
               CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_ID,
               CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_USER_ID,
               CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DELEGATE,obj.Formatted_CFG_SYSTEM_MENU_HIS_DATE_FOR_DISPLAY,
               CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_ID, CfgSystemMenuHis.ColumnNames.MENU_NAME, CfgSystemMenuHis.ColumnNames.MENU_PARENT_ID,
               CfgSystemMenuHis.ColumnNames.MENU_SEQUENCE, CfgSystemMenuHis.ColumnNames.MENU_ICON, CfgSystemMenuHis.ColumnNames.MENU_LINK, CfgSystemMenuHis.ColumnNames.ACTIVE);

            sb.AppendFormat(",usr.{0} as MODIFIED_BY_NAME,delegatee.{0} as MODIFIED_BY_DELNAME, usr.{1} as MODIFIED_BY_EMAIL"
    , CfgUser.ColumnNamesOnly.USER_FULL_NAME, CfgUser.ColumnNamesOnly.USER_EMAIL);
            sb.AppendFormat(" from {0} ", CfgSystemMenuHis.TableName);
            sb.AppendFormat(" inner join {0} usr on {1}=usr.{2}", CfgUser.TableName, CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_USER_ID, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" left join {0} delegatee on {1}=delegatee.{2}", CfgUser.TableName, CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_HIS_DELEGATE, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemMenuHis.ColumnNames.CFG_SYSTEM_MENU_ID, id);
            return sb.ToString();
        }
        private string SelectMaxHistoryByParamKey(CfgSystemMenu obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" select max({0}) from {1} where {2} = '{3}' ", CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, CfgSystemMenu.TableName, CfgSystemMenu.ColumnNames.MENU_NAME, obj.MENU_NAME);

            return sb.ToString();
        }

        public int UpdateCfgSystemMenu(CfgSystemMenu obj)
        {
            string query = string.Empty;
            CfgMenuOperationMap mapObj = null;
            CfgMenuOperationMapDAL dtlDAL = new CfgMenuOperationMapDAL(_config, _httpContext);
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                query = UpdateRowQuery(Convert.ToInt32((obj.CFG_SYSTEM_MENU_ID).ToString()), obj);


                if (dbManager.ExecuteNonQuery(CommandType.Text, query) > 0)
                {
                    dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.DeleteRowQuery(Convert.ToInt32(obj.CFG_SYSTEM_MENU_ID)));
                    foreach (string operation in obj.saOperationMap)
                    {
                        mapObj = new CfgMenuOperationMap
                        {
                            CFG_SYSTEM_MENU_ID = obj.CFG_SYSTEM_MENU_ID,
                            ACCESS_OPERATION = operation
                        };
                        dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.InsertRowQuery(mapObj));
                    }
                    SnapAuditTrail(dbManager, obj);
                    dbManager.CommitTransaction();
                    return 1;
                }
                else
                {
                    dbManager.RollbackTransaction();
                    return 0;
                }
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


        private string DeleteRowQuery(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgSystemMenu.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgSystemMenu.PrimaryKey, id);
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

        public bool DeleteCfgSystemMenu(int id)
        {
            string query = string.Empty;
            CfgMenuOperationMapDAL dtlDAL = new CfgMenuOperationMapDAL(_config, _httpContext);
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.DeleteRowQuery(id));

                if (dbManager.ExecuteNonQuery(CommandType.Text, DeleteRowQuery(id)) > 0)
                {
                    dbManager.CommitTransaction();
                    return true;
                }
                else
                {
                    dbManager.RollbackTransaction();
                    return false;
                }
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

        private string SelectRowByIdQuery(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3}, {4}, {5}, {6} ", CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, CfgSystemMenu.ColumnNames.MENU_NAME, CfgSystemMenu.ColumnNames.MENU_PARENT_ID, CfgSystemMenu.ColumnNames.MENU_SEQUENCE, CfgSystemMenu.ColumnNames.MENU_ICON, CfgSystemMenu.ColumnNames.MENU_LINK, CfgSystemMenu.ColumnNames.ACTIVE);
            sb.AppendFormat("  from  {0}  ", CfgSystemMenu.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgSystemMenu.PrimaryKey, id);
            return sb.ToString();
        }
        public CfgSystemMenu SelectRowById(int id)
        {
            CfgSystemMenu obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgSystemMenu().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgSystemMenu)arr[0];
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


        private string GetInsRowsByUniqConst(string menuName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemMenu.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemMenu.ColumnNames.MENU_NAME, menuName);
            return sb.ToString();
        }

        private string GetUpdRowsByUniqConst(string Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgSystemMenu.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgSystemMenu.ColumnNames.CFG_SYSTEM_MENU_ID, Id);
            return sb.ToString();
        }

        public List<CfgSystemMenu> SelectInsRowsWithData(string menuName)
        {
            DataTable dt;
            List<CfgSystemMenu> lsMaster = null;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetInsRowsByUniqConst(menuName));
                dt = ds.Tables[0];
                CfgMenuOperationMapDAL operDAL = new CfgMenuOperationMapDAL(_config, _httpContext);
                DataTable dtOperation = operDAL.SelectAllRows();
               lsMaster = DataConverter.DataTableToList<CfgSystemMenu>(dt);
                foreach (CfgSystemMenu objMaster in lsMaster)
                {
                    DataRow[] draCurrency = dtOperation.Select(string.Format("CFG_SYSTEM_MENU_ID={0}", objMaster.Formatted_CFG_SYSTEM_MENU_ID));

                    if (draCurrency.Length > 0)
                    {
                        objMaster.saOperationMap = DataConverter.DataRowArrayToStringArray(draCurrency, CfgMenuOperationMap.ColumnNamesOnly.ACCESS_OPERATION);
                    }
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
            return lsMaster;
        }

        public List<CfgSystemMenu> SelectUpdRowsWithData(string menuId)
        {
            DataTable dt;
            List<CfgSystemMenu> lsMaster = null;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetUpdRowsByUniqConst(menuId));
                dt = ds.Tables[0];
                CfgMenuOperationMapDAL operDAL = new CfgMenuOperationMapDAL(_config, _httpContext);
                DataTable dtOperation = operDAL.SelectAllRows();
                lsMaster = DataConverter.DataTableToList<CfgSystemMenu>(dt);
                foreach (CfgSystemMenu objMaster in lsMaster)
                {
                    DataRow[] draCurrency = dtOperation.Select(string.Format("CFG_SYSTEM_MENU_ID={0}", objMaster.Formatted_CFG_SYSTEM_MENU_ID));

                    if (draCurrency.Length > 0)
                    {
                        objMaster.saOperationMap = DataConverter.DataRowArrayToStringArray(draCurrency, CfgMenuOperationMap.ColumnNamesOnly.ACCESS_OPERATION);
                    }
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
            return lsMaster;
        }
    }
}
