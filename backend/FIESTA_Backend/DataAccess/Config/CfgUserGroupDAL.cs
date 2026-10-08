using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgUserGroupDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgUserGroupDAL(IConfiguration configuration, HttpContext httpContext)
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

        public List<CfgUserGroup> ListUserGroup()
        {
            DataTable dt = GetCfgUserGroup();
            return DataConverter.DataTableToList<CfgUserGroup>(dt);
        }

        public DataTable GetCfgUserGroup()
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

        private string SelectAllRowsQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            sb.AppendFormat("{0},{1},{2},{3} ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, CfgUserGroup.ColumnNames.ACTIVE);
            sb.AppendFormat("from {0}", CfgUserGroup.TableName);
            return sb.ToString();
        }

        private string GetInsRowsByUniqConst(string userGrpName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3} ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, CfgUserGroup.ColumnNames.ACTIVE);
            sb.AppendFormat("  from  {0} ", CfgUserGroup.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgUserGroup.ColumnNames.USER_GROUP_NAME, userGrpName);
            return sb.ToString();
        }

        private string GetUpdRowsByUniqConst(string userGrpId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1}, {2}, {3} ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, CfgUserGroup.ColumnNames.ACTIVE);
            sb.AppendFormat("  from  {0} ", CfgUserGroup.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, userGrpId);
            return sb.ToString();
        }

        public List<CfgUserGroup> SelectInsRowsWithData(string userGrpName)
        {
            DataTable dt;
            List<CfgUserGroup> lsMaster = null;
            CfgUserGroupCompanyMap mapObj = null;
            List<CfgUserGroupMenuMap> lsmenu = null;
            CfgUserGroupCompanyMapDAL dtlDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetInsRowsByUniqConst(userGrpName));
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

            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                lsMaster = DataConverter.DataTableToList<CfgUserGroup>(dt);
                CfgUserGroupCompanyMapDAL comDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
                CfgUserGroupMenuMapDAL mnDAL = new CfgUserGroupMenuMapDAL(_config, _httpContext);
                DataTable dtCompany = comDAL.SelectAllRows();
                DataTable dtMenu = mnDAL.SelectAllRowsWithDescription();
                CfgUserGroupMenuMap menuObj = null;
                foreach (CfgUserGroup objMaster in lsMaster)
                {
                    DataRow[] drCompany = dtCompany.Select(string.Format("CFG_USER_GROUP_ID='{0}'", objMaster.CFG_USER_GROUP_ID));

                    if (drCompany.Length > 0)
                    {
                        objMaster.saCompany = DataConverter.DataRowArrayToStringArray(drCompany, CfgUserGroupCompanyMap.ColumnNamesOnly.COMPANY_CODE);
                    }

                    lsmenu = new List<CfgUserGroupMenuMap>();
                    DataRow[] drMenu = dtMenu.Select(string.Format("CFG_USER_GROUP_ID='{0}'", objMaster.CFG_USER_GROUP_ID));
                    foreach (DataRow dr in drMenu)
                    {
                        menuObj = new CfgUserGroupMenuMap();
                        menuObj.CFG_USER_GROUP_ID = Convert.ToDecimal((dr["CFG_USER_GROUP_ID"]).ToString());
                        menuObj.MENU_ID = Convert.ToInt32((dr["MENU_ID"]).ToString());
                        menuObj.ACCESS_OPERATION = (dr["ACCESS_OPERATION"]).ToString();
                        menuObj.MENU_NAME = (dr["MENU_NAME"]).ToString();
                        menuObj.USER_GROUP_NAME = (dr["USER_GROUP_NAME"]).ToString();

                        lsmenu.Add(menuObj);
                    }
                    objMaster.saMenu = lsmenu;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            finally
            {
                dbManager.Dispose();
            }



            return lsMaster;
        }

        public List<CfgUserGroup> SelectUpdRowsWithData(string userGrpId)
        {
            DataTable dt;
            List<CfgUserGroup> lsMaster = null;
            CfgUserGroupCompanyMap mapObj = null;
            List<CfgUserGroupMenuMap> lsmenu = null;
            CfgUserGroupCompanyMapDAL dtlDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetUpdRowsByUniqConst(userGrpId));
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
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                lsMaster = DataConverter.DataTableToList<CfgUserGroup>(dt);
                CfgUserGroupCompanyMapDAL comDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
                CfgUserGroupMenuMapDAL mnDAL = new CfgUserGroupMenuMapDAL(_config, _httpContext);
                DataTable dtCompany = comDAL.SelectAllRows();
                DataTable dtMenu = mnDAL.SelectAllRowsWithDescription();
                CfgUserGroupMenuMap menuObj = null;
                foreach (CfgUserGroup objMaster in lsMaster)
                {
                    DataRow[] drCompany = dtCompany.Select(string.Format("CFG_USER_GROUP_ID='{0}'", objMaster.CFG_USER_GROUP_ID));

                    if (drCompany.Length > 0)
                    {
                        objMaster.saCompany = DataConverter.DataRowArrayToStringArray(drCompany, CfgUserGroupCompanyMap.ColumnNamesOnly.COMPANY_CODE);
                    }

                    lsmenu = new List<CfgUserGroupMenuMap>();
                    DataRow[] drMenu = dtMenu.Select(string.Format("CFG_USER_GROUP_ID='{0}'", objMaster.CFG_USER_GROUP_ID));
                    foreach (DataRow dr in drMenu)
                    {
                        menuObj = new CfgUserGroupMenuMap();
                        menuObj.CFG_USER_GROUP_ID = Convert.ToDecimal((dr["CFG_USER_GROUP_ID"]).ToString());
                        menuObj.MENU_ID = Convert.ToInt32((dr["MENU_ID"]).ToString());
                        menuObj.ACCESS_OPERATION = (dr["ACCESS_OPERATION"]).ToString();
                        menuObj.MENU_NAME = (dr["MENU_NAME"]).ToString();
                        menuObj.USER_GROUP_NAME = (dr["USER_GROUP_NAME"]).ToString();

                        lsmenu.Add(menuObj);
                    }
                    objMaster.saMenu = lsmenu;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw ex;
            }

            finally
            {
                dbManager.Dispose();
            }

            return lsMaster;
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

        public List<CfgUserGroup> GetCfgUserGroupChildDetails()
        {
            CfgUserGroupCompanyMapDAL comDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            CfgUserGroupMenuMapDAL mnDAL = new CfgUserGroupMenuMapDAL(_config, _httpContext);
            DataTable dtCompany = comDAL.SelectAllRows();
            DataTable dtMenu = mnDAL.SelectAllRowsWithDescription();
            DataTable dt = SelectAllRows();
            List<CfgUserGroup> lsMaster = DataConverter.DataTableToList<CfgUserGroup>(dt);
            List<CfgUserGroupMenuMap> lsmenu = null;
            CfgUserGroupMenuMap menuObj = null;
            foreach (CfgUserGroup objMaster in lsMaster)
            {
                DataRow[] drCompany = dtCompany.Select(string.Format("CFG_USER_GROUP_ID='{0}'", objMaster.CFG_USER_GROUP_ID));

                if (drCompany.Length > 0)
                {
                    objMaster.saCompany = DataConverter.DataRowArrayToStringArray(drCompany, CfgUserGroupCompanyMap.ColumnNamesOnly.COMPANY_CODE);
                }
                lsmenu = new List<CfgUserGroupMenuMap>();
                DataRow[] drMenu = dtMenu.Select(string.Format("CFG_USER_GROUP_ID='{0}'", objMaster.CFG_USER_GROUP_ID));
                foreach (DataRow dr in drMenu)
                {
                    menuObj = new CfgUserGroupMenuMap();
                    menuObj.CFG_USER_GROUP_MENU_MAP_ID = Convert.ToDecimal((dr["CFG_USER_GROUP_MENU_MAP_ID"]).ToString());
                    menuObj.CFG_USER_GROUP_ID = Convert.ToDecimal((dr["CFG_USER_GROUP_ID"]).ToString());
                    menuObj.MENU_ID = Convert.ToInt32((dr["MENU_ID"]).ToString());
                    menuObj.ACCESS_OPERATION = (dr["ACCESS_OPERATION"]).ToString();
                    menuObj.MENU_NAME = (dr["MENU_NAME"]).ToString();
                    menuObj.USER_GROUP_NAME = (dr["USER_GROUP_NAME"]).ToString();

                    lsmenu.Add(menuObj);
                }
                objMaster.saMenu = lsmenu;
            }
            return lsMaster;
        }

        private string InsertRowQuery(CfgUserGroup obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgUserGroup.TableName);
            sb.AppendFormat("  {0}, {1}, {2} ", CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, CfgUserGroup.ColumnNames.ACTIVE);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1}, {2} ) ", obj.Formatted_USER_GROUP_NAME, obj.Formatted_USER_GROUP_DESCRIPTION, obj.Formatted_ACTIVE);

            return sb.ToString();
        }
        public void InsertRow(CfgUserGroup userObj)
        {
            string query = string.Empty;
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                query = InsertRowQuery(userObj);
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

        private void SnapAuditTrail(IDBManager dbManager, CfgUserGroup obj)
        {
            dbManager.ExecuteNonQuery(CommandType.Text, InsertHistoryQuery(obj));
        }

        private string InsertHistoryQuery(CfgUserGroup obj)
        {
            Object id = dbManager.ExecuteScalar(CommandType.Text, SelectMaxHistoryByParamKey(obj));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert Into {0} ( ", CfgUserGroupHis.TableName);
            sb.AppendFormat(" {0},{1},{2},{3},{4},{5},{6}", CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_USER_ID,
                CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_DELEGATE, CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_DATE, CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID,
                CfgUserGroupHis.ColumnNames.USER_GROUP_NAME, CfgUserGroupHis.ColumnNames.USER_GROUP_DESCRIPTION,
                CfgUserGroupHis.ColumnNames.ACTIVE);
            sb.AppendFormat(" ) ( ");
            sb.AppendFormat(" select ");
            sb.AppendFormat(" '{0}','{1}',{2},{3},{4},{5},{6} ", obj.TokenObj.USER_ID, obj.TokenObj.DELEGATE_ID,
                DataAccessAssistant.OracleSystimestampToUTC(), CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID,
                CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION,
                CfgUserGroup.ColumnNames.ACTIVE);
            sb.AppendFormat(" from {0} where {1} = {2} )", CfgUserGroup.TableName, CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, Convert.ToDecimal(id));
            return sb.ToString();


        }
        public DataTable GetCfgHistory(int id, CfgUserGroupHis obj)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetCfgHistoryQuery(id, obj));
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
        private string GetCfgHistoryQuery(int id, CfgUserGroupHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select");
            sb.AppendFormat(" {0},{1},{2},{3} CFG_USER_GROUP_HIS_DATE,{4},{5},{6},{7}",
              CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_ID,
              CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_USER_ID,
              CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_DELEGATE,
              obj.Formatted_CFG_USER_GROUP_HIS_DATE_FOR_DISPLAY,
              CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID,
              CfgUserGroupHis.ColumnNames.USER_GROUP_NAME,
              CfgUserGroupHis.ColumnNames.USER_GROUP_DESCRIPTION,
              CfgUserGroupHis.ColumnNames.ACTIVE);

            sb.AppendFormat(",usr.{0} as MODIFIED_BY_NAME,delegatee.{0} as MODIFIED_BY_DELNAME, usr.{1} as MODIFIED_BY_EMAIL"
    , CfgUser.ColumnNamesOnly.USER_FULL_NAME, CfgUser.ColumnNamesOnly.USER_EMAIL);
            sb.AppendFormat(" from {0} ", CfgUserGroupHis.TableName);
            sb.AppendFormat(" inner join {0} usr on {1}=usr.{2}", CfgUser.TableName, CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_USER_ID, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" left join {0} delegatee on {1}=delegatee.{2}", CfgUser.TableName, CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_HIS_DELEGATE, CfgUser.ColumnNamesOnly.USER_ID);
            sb.AppendFormat(" where {0} = '{1}' ", CfgUserGroupHis.ColumnNames.CFG_USER_GROUP_ID, id);
            return sb.ToString();
        }
        private string SelectMaxHistoryByParamKey(CfgUserGroup obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" select max({0}) from {1} where {2} = '{3}' and {4} = '{5}' ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.TableName,
                CfgUserGroup.ColumnNames.USER_GROUP_NAME, obj.USER_GROUP_NAME,
                CfgUserGroup.ColumnNames.ACTIVE, obj.ACTIVE);

            return sb.ToString();
        }

        private string SelectKey(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat(" {0} ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID);
            sb.AppendFormat(" from  {0}  ", CfgUserGroup.TableName);
            sb.AppendFormat(" where {0}='{1}'", CfgUserGroup.ColumnNames.USER_GROUP_NAME, name);
            return sb.ToString();
        }
        public void SaveNewCfgUserGroup(CfgUserGroup obj)
        {
            string query = string.Empty;
            CfgUserGroupCompanyMap mapObj = null;
            CfgUserGroupCompanyMapDAL dtlDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            CfgUserGroupMenuMapDAL mnDAL = new CfgUserGroupMenuMapDAL(_config, _httpContext);
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

            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                object id_key = dbManager.ExecuteScalar(CommandType.Text, SelectKey(obj.USER_GROUP_NAME));
                if (id_key != null)
                {
                    foreach (string company in obj.saCompany)
                    {
                        mapObj = new CfgUserGroupCompanyMap
                        {
                            CFG_USER_GROUP_ID = Convert.ToDecimal(id_key.ToString()),
                            COMPANY_CODE = company
                        };
                        dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.InsertRowQuery(mapObj));
                    }
                    foreach (CfgUserGroupMenuMap mnObj in obj.saMenu)
                    {
                        mnObj.CFG_USER_GROUP_ID = Convert.ToDecimal(id_key.ToString());

                        dbManager.ExecuteNonQuery(CommandType.Text, mnDAL.InsertRowQuery(mnObj));
                    }
                    dbManager.CommitTransaction();
                }
                else
                    dbManager.RollbackTransaction();
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

        private string UpdateRowQuery(int id, CfgUserGroup obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Update {0} set ", CfgUserGroup.TableName);
            sb.AppendFormat("     {0}={1} ", CfgUserGroup.ColumnNames.USER_GROUP_NAME, obj.Formatted_USER_GROUP_NAME);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, obj.Formatted_USER_GROUP_DESCRIPTION);
            sb.AppendFormat("  ,  {0}={1} ", CfgUserGroup.ColumnNames.ACTIVE, obj.Formatted_ACTIVE);
            sb.AppendFormat(" where {0} = {1} ", CfgUserGroup.PrimaryKey, id);
            return sb.ToString();
        }
        public int UpdateRow(int id, CfgUserGroup obj)
        {
            string query = string.Empty;
            int return_int = 0;
            try
            {
                dbManager.Open();
                query = UpdateRowQuery(id, obj);
                return_int = dbManager.ExecuteNonQuery(CommandType.Text, query);
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

        public int UpdateCfgUserGroup(CfgUserGroup obj)
        {
            string query = string.Empty;
            CfgUserGroupCompanyMap mapObj = null;
            CfgUserGroupCompanyMapDAL dtlDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            CfgUserGroupMenuMapDAL mnDAL = new CfgUserGroupMenuMapDAL(_config, _httpContext);
            CfgUserGroup ori = SelectRowById(Convert.ToInt32(obj.CFG_USER_GROUP_ID.ToString()));
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.DeleteRowByUserGroupQuery(ori.CFG_USER_GROUP_ID));
                dbManager.ExecuteNonQuery(CommandType.Text, mnDAL.DeleteRowByUserGroupQuery(ori.CFG_USER_GROUP_ID));
                query = UpdateRowQuery(Convert.ToInt32((obj.CFG_USER_GROUP_ID).ToString()), obj);



                if (dbManager.ExecuteNonQuery(CommandType.Text, query) > 0)
                {
                    foreach (string company in obj.saCompany)
                    {
                        mapObj = new CfgUserGroupCompanyMap
                        {
                            CFG_USER_GROUP_ID = obj.CFG_USER_GROUP_ID,
                            COMPANY_CODE = company
                        };

                        dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.InsertRowQuery(mapObj));
                    }
                    foreach (CfgUserGroupMenuMap mnObj in obj.saMenu)
                    {
                        mnObj.CFG_USER_GROUP_ID = obj.CFG_USER_GROUP_ID;
                        dbManager.ExecuteNonQuery(CommandType.Text, mnDAL.InsertRowQuery(mnObj));
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

            sb.AppendFormat(" Delete from {0} where ", CfgUserGroup.TableName);
            sb.AppendFormat(" {0} = {1} ", CfgUserGroup.PrimaryKey, id);
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
                return_int = dbManager.ExecuteNonQuery(CommandType.Text, query);
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

        public bool DeleteCfgUserGroup(int id)//pending todo : delete currency map as well
        {
            string query = string.Empty;
            CfgUserGroupCompanyMapDAL dtlDAL = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            CfgUserGroupMenuMapDAL mnDAL = new CfgUserGroupMenuMapDAL(_config, _httpContext);
            try
            {
                CfgUserGroup userobj = SelectRowById(id);
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.ExecuteNonQuery(CommandType.Text, dtlDAL.DeleteRowByUserGroupQuery(Convert.ToDecimal(id.ToString())));
                dbManager.ExecuteNonQuery(CommandType.Text, mnDAL.DeleteRowByUserGroupQuery(Convert.ToDecimal(id.ToString())));
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
            sb.AppendFormat(" {0}, {1}, {2}, {3} ", CfgUserGroup.ColumnNames.CFG_USER_GROUP_ID, CfgUserGroup.ColumnNames.USER_GROUP_NAME, CfgUserGroup.ColumnNames.USER_GROUP_DESCRIPTION, CfgUserGroup.ColumnNames.ACTIVE);
            sb.AppendFormat(" from  {0}  ", CfgUserGroup.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgUserGroup.PrimaryKey, id);
            return sb.ToString();
        }

        public CfgUserGroup SelectRowById(int id)
        {
            CfgUserGroup obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgUserGroup().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserGroup)arr[0];
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

        public CfgUserGroup SelectCfgUserGroupById(int id)
        {
            CfgUserGroup obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByIdQuery(id), new CfgUserGroup().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgUserGroup)arr[0];
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
