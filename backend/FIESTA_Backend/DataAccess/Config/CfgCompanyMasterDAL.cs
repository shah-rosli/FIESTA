using FIESTA_Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Utility.DataAccess;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.DataAccess.Config
{

    //public static class Helper
    //{

        
       
    //}

    public class CfgCompanyMasterDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public CfgCompanyMasterDAL(IConfiguration configuration, HttpContext httpContext)
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
      
        public  List<CfgCompanyMaster> GetCfgCompanyMasterWithChildDetails()
        {
            DataTable dt = GetCfgCompanyMaster();
            List<CfgCompanyMaster> lsMaster = DataConverter.DataTableToList<CfgCompanyMaster>(dt);

            DataTable dtCurrency = SelectCurrencyMap();
            DataTable dtDocument = SelectDocumentMap();
            DataTable dtInsp = SelectInspCode();
            DataTable dtUOM = SelectUOM();
            DataTable dtPlant = SelectPlantStorage();
            DataTable dtAcctCategory = SelectAccountCategory();
            DataTable dtEprCategory = SelectEprCategory();
            ArrayList arPlant = null;
            CfgPlant plantObj = null;

            foreach (CfgCompanyMaster objMaster in lsMaster)
            {
                DataRow[] draCurrency = dtCurrency.Select(string.Format("{0}='{1}'", CfgCompanyCurrencyMap.ColumnNamesOnly.COMPANY_CODE, objMaster.COMPANY_CODE));
                DataRow[] draDocument = dtDocument.Select(string.Format(" company_code='{0}'", objMaster.COMPANY_CODE));
                DataRow[] draInsp = dtInsp.Select(string.Format(" company_code='{0}'", objMaster.COMPANY_CODE));
                DataRow[] draUOM = dtUOM.Select(string.Format(" company_code='{0}'", objMaster.COMPANY_CODE));
                DataRow[] draAccountCat= dtAcctCategory.Select(string.Format(" company_code='{0}'", objMaster.COMPANY_CODE));
                DataRow[] draEprCategory = dtEprCategory.Select(string.Format(" company_code='{0}'", objMaster.COMPANY_CODE));
                if (draCurrency.Length > 0)
                {
                    objMaster.saCurrencyMap = DataConverter.DataRowArrayToStringArray(draCurrency, CfgCompanyCurrencyMap.ColumnNamesOnly.CURRENCY_NAME);
                }
                if (draDocument.Length > 0)
                {
                    objMaster.saEprDocumentMap = DataConverter.DataRowArrayToStringArray(draDocument, "doc_name");
                }
                if (draInsp.Length > 0)
                {
                    objMaster.saEprInspCodeMap = DataConverter.DataRowArrayToStringArray(draInsp, "insp_name");
                }
                if (draUOM.Length > 0)
                {
                    objMaster.saUOMMap = DataConverter.DataRowArrayToStringArray(draUOM, "uom");
                }
                if (draAccountCat.Length > 0)
                {
                    objMaster.saAccountCategoryMap = DataConverter.DataRowArrayToStringArray(draAccountCat, "category_name");
                }
                if (draEprCategory.Length > 0)
                {
                    objMaster.saEprCategoryMap = DataConverter.DataRowArrayToStringArray(draEprCategory, "category_name");
                }

                /*                arPlant = new ArrayList();
                var distinct_plant_list = (from drPlant in dtPlant.AsEnumerable()
                                           where drPlant.Field<string>("company_code") == objMaster.COMPANY_CODE
                                           select drPlant.Field<decimal>("plant_id")).Distinct();
                if (distinct_plant_list.Count() > 0)
                {
                    foreach (var rcd in distinct_plant_list)
                    {
                        arPlant = new ArrayList();
                        plantObj = new CfgPlant();
                        plantObj.CFG_PLANT_ID = rcd;
                        var plantProfile = (from drPlantStorage in dtPlant.AsEnumerable()
                                            where drPlantStorage.Field<string>("company_code") == objMaster.COMPANY_CODE
                                            && drPlantStorage.Field<decimal>("plant_id") == rcd
                                            select new
                                            {
                                                plnt_name = drPlantStorage.Field<string>("plant_name"),
                                                plnt_desc = drPlantStorage.Field<string>("plant_description")
                                            });
                        foreach (var plnt_profile in plantProfile)
                        {
                            plantObj.CFG_PLANT_NAME = plnt_profile.plnt_name;
                            plantObj.CFG_PLANT_DESCRIPTION = plnt_profile.plnt_desc;
                            break;
                        }
                        var plantStorage = (from drPlantStorage in dtPlant.AsEnumerable()
                                            where drPlantStorage.Field<string>("company_code") == objMaster.COMPANY_CODE
                                            && drPlantStorage.Field<decimal>("plant_id") == rcd
                                            select new
                                            {
                                                storage_id = drPlantStorage.Field<decimal>("storage_id"),
                                                storage_name = drPlantStorage.Field<string>("storage_name"),
                                                storage_description = drPlantStorage.Field<string>("storage_description")
                                            });
                        plantObj.enStorage = plantStorage;
                        arPlant.Add(plantObj);
                    }
                }
                
                objMaster.arPlant = arPlant;
                */
            }
            return lsMaster;
        }

        public DataTable SelectCurrencyMap()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectCurrencyMapQuery());
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
        private string SelectCurrencyMapQuery()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.AppendFormat("   {0}, {1} ", CfgCompanyCurrencyMap.ColumnNames.COMPANY_CODE, CfgCompanyCurrencyMap.ColumnNames.CURRENCY_NAME);
            sb.AppendFormat("  from  {0} ; ", CfgCompanyCurrencyMap.TableName);
            return sb.ToString();
        }

        public DataTable SelectDocumentMap()
        {
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.Append(" Select * from v_company_document order by company_code");
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, sb.ToString());
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

        public DataTable SelectInspCode()
        {
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.Append(" Select * from v_company_insp order by insp_name");
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text,sb.ToString());
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

        public DataTable SelectUOM()
        {
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from v_company_uom");
            sb.Append(" order by uom");
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, sb.ToString());
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

        public DataTable SelectAccountCategory()
        {
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from v_company_account_category");
            sb.Append(" order by category_name");
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, sb.ToString());
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

        public DataTable SelectEprCategory()
        {
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from v_company_epr_category");
            sb.Append(" order by category_name");
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, sb.ToString());
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


        public DataTable SelectPlantStorage()
        {
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from v_company_plant_storage");
            sb.Append(" order by plant_id");
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, sb.ToString());
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

        
             public DataTable GetCfgCompanyNameForInv()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectCfgCompanyNameForInvQuery());
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

        public DataTable GetCfgCompanyMaster()
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, SelectCfgCompanyMasterQuery());
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

        public List<CfgCompanyMaster> GetCfgCompanyMasterList()
        {
            return DataConverter.DataTableToList<CfgCompanyMaster>(GetCfgCompanyMaster()); 
        }

        public void SaveNewCfgCompanyMaster(CfgCompanyMaster paramsObj)
        {
            string query = string.Empty;
            //CfgCompanyCurrencyMap currencymap = null;
            //CfgCompanyEprDocumentMap doc_type_map_obj = null;
            //CfgCompanyEprInspMap insp_code_map_obj = null;
            //CfgCompanyUomMap uom_obj = null;
            //CfgCompanyAccCategoryMap acc_obj = null;
            //CfgCompanyEprCategoryMap epr_cat_obj = null;
   
            //CfgCompanyUomMapDAL uomDAL = new CfgCompanyUomMapDAL(_config, _httpContext);

            
            try
            {
                
                dbManager.Open();
                dbManager.BeginTransaction();
                
                query = InsertCfgCompanyMasterQuery(paramsObj);

                if (dbManager.ExecuteNonQuery(CommandType.Text, query) > 0)
                {
                    SnapAuditTrail(dbManager, paramsObj);
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

        private string InsertCurrencyMapQuery(CfgCompanyCurrencyMap obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert into {0} ( ", CfgCompanyCurrencyMap.TableName);
            sb.AppendFormat("  {0}, {1} ", CfgCompanyCurrencyMap.ColumnNames.COMPANY_CODE, CfgCompanyCurrencyMap.ColumnNames.CURRENCY_NAME);
            sb.Append("  ) values (  ");
            sb.AppendFormat("  {0}, {1} ) ", obj.Formatted_COMPANY_CODE, obj.Formatted_CURRENCY_NAME);

            return sb.ToString();
        }
        public int UpdateCfgCompanyMaster(CfgCompanyMaster paramsObj)
        {
            string query = string.Empty;
            CfgCompanyCurrencyMap currencymap = null;
            CfgCompanyEprDocumentMap doc_type_map_obj = null;
            CfgCompanyEprInspMap insp_code_map_obj = null;
            CfgCompanyUomMap uom_obj = null;
            CfgCompanyAccCategoryMap acc_obj = null;
            CfgCompanyEprCategoryMap epr_cat_obj = null;

            //CfgCompanyUomMapDAL uomDAL = new CfgCompanyUomMapDAL(_config, _httpContext);
        

            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                query = UpdateCfgCompanyMasterQuery(paramsObj);


                if (dbManager.ExecuteNonQuery(CommandType.Text, query) > 0)
                {
                    dbManager.ExecuteNonQuery(CommandType.Text, DeleteCurrencyMapQuery(Convert.ToInt32( paramsObj.CFG_COMPANY_MASTER_ID)));

                    //dbManager.ExecuteNonQuery(CommandType.Text, uomDAL.DeleteByCompanyCodeQuery(paramsObj.COMPANY_CODE));
                    
                    
                    //                    dbManager.ExecuteNonQuery(CommandType.Text, storageDAL.DeleteByCompanyCodeQuery(paramsObj.COMPANY_CODE));
                    //                    dbManager.ExecuteNonQuery(CommandType.Text, plantDAL.DeleteByCompanyCodeQuery(paramsObj.COMPANY_CODE));

                    foreach (string currency in paramsObj.saCurrencyMap)
                    {
                        currencymap = new CfgCompanyCurrencyMap
                        {
                            COMPANY_CODE = paramsObj.COMPANY_CODE,
                            CURRENCY_NAME = currency
                        };

                        dbManager.ExecuteNonQuery(CommandType.Text, InsertCurrencyMapQuery(currencymap));

                    }
                   
                   
                  

                    SnapAuditTrail(dbManager, paramsObj);
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

                throw ce;
            }
            finally
            {
                dbManager.Dispose();
            }

        }

      

        private void SnapAuditTrail(IDBManager dbManager, CfgCompanyMaster obj)
        {
            dbManager.ExecuteNonQuery(CommandType.Text, InsertHistoryQuery(obj));
        }

        private string InsertHistoryQuery(CfgCompanyMaster obj)
        {
            Object id = dbManager.ExecuteScalar(CommandType.Text, SelectMaxHistoryByParamKey(obj));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" Insert Into {0} ( ", CfgCompanyMasterHis.TableName);
            sb.AppendFormat(" {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_USER_ID,
                CfgCompanyMasterHis.ColumnNames.COMPANY_MASTER_HIS_DELEGATE, CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_DATE,
                CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_ID, CfgCompanyMasterHis.ColumnNames.COMPANY_CODE, CfgCompanyMasterHis.ColumnNames.COMPANY_NAME,
                CfgCompanyMasterHis.ColumnNames.COMPANY_DESCRIPTION, CfgCompanyMasterHis.ColumnNames.DEFAULT_PURCHASING_ORG, CfgCompanyMasterHis.ColumnNames.DEFAULT_CURRENCY_NAME,
                CfgCompanyMasterHis.ColumnNames.ACTIVE, CfgCompanyMasterHis.ColumnNames.APR_COMPANY_GROUP, CfgCompanyMasterHis.ColumnNames.IF_COMPANY_CODE,
                CfgCompanyMasterHis.ColumnNames.IF_DESTINATION_SYSTEM, CfgCompanyMasterHis.ColumnNames.DEFAULT_TIMEZONE, CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_TIME_FORMAT,
                CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_DATE_FORMAT, CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, CfgCompanyMasterHis.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL,
                CfgCompanyMasterHis.ColumnNames.DEFAULT_LANGUAGE);
            sb.AppendFormat(" ) ( ");
            sb.AppendFormat(" select ");
            sb.AppendFormat(" '{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18} ", obj.TokenObj.USER_ID, obj.TokenObj.DELEGATE_ID,
                DataAccessAssistant.OracleSystimestampToUTC(), CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, CfgCompanyMaster.ColumnNames.COMPANY_CODE,
                CfgCompanyMaster.ColumnNames.COMPANY_NAME, CfgCompanyMaster.ColumnNames.COMPANY_DESCRIPTION, CfgCompanyMaster.ColumnNames.DEFAULT_PURCHASING_ORG,
                 CfgCompanyMaster.ColumnNames.DEFAULT_CURRENCY_NAME, CfgCompanyMaster.ColumnNames.ACTIVE, CfgCompanyMaster.ColumnNames.APR_COMPANY_GROUP,
                  CfgCompanyMaster.ColumnNames.IF_COMPANY_CODE, CfgCompanyMaster.ColumnNames.IF_DESTINATION_SYSTEM, CfgCompanyMaster.ColumnNames.DEFAULT_TIMEZONE,
                   CfgCompanyMaster.ColumnNames.DEFAULT_DISP_TIME_FORMAT, CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATE_FORMAT, CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT,
                    CfgCompanyMaster.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL, CfgCompanyMaster.ColumnNames.DEFAULT_LANGUAGE);
            sb.AppendFormat(" from {0} where {1} = {2} )", CfgCompanyMaster.TableName, CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, Convert.ToDecimal(id));
            return sb.ToString();


        }
        public DataTable GetCfgHistory(int id,CfgCompanyMasterHis obj)
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
        private string GetCfgHistoryQuery(int id,CfgCompanyMasterHis obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select ", CfgCompanyMasterHis.TableName, CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_ID, id);
            sb.AppendFormat(" {0},{1},{2} CFG_COMPANY_MASTER_HIS_DATE,{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_HIS_USER_ID,
               CfgCompanyMasterHis.ColumnNames.COMPANY_MASTER_HIS_DELEGATE, obj.Formatted_CFG_COMPANY_MASTER_HIS_DATE_FOR_DISPLAY,
               CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_ID, CfgCompanyMasterHis.ColumnNames.COMPANY_CODE, CfgCompanyMasterHis.ColumnNames.COMPANY_NAME,
               CfgCompanyMasterHis.ColumnNames.COMPANY_DESCRIPTION, CfgCompanyMasterHis.ColumnNames.DEFAULT_PURCHASING_ORG, CfgCompanyMasterHis.ColumnNames.DEFAULT_CURRENCY_NAME,
               CfgCompanyMasterHis.ColumnNames.ACTIVE, CfgCompanyMasterHis.ColumnNames.APR_COMPANY_GROUP, CfgCompanyMasterHis.ColumnNames.IF_COMPANY_CODE,
               CfgCompanyMasterHis.ColumnNames.IF_DESTINATION_SYSTEM, CfgCompanyMasterHis.ColumnNames.DEFAULT_TIMEZONE, CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_TIME_FORMAT,
               CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_DATE_FORMAT, CfgCompanyMasterHis.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, CfgCompanyMasterHis.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL,
               CfgCompanyMasterHis.ColumnNames.DEFAULT_LANGUAGE);
            sb.AppendFormat(" from {0} where {1} = '{2}' ", CfgCompanyMasterHis.TableName, CfgCompanyMasterHis.ColumnNames.CFG_COMPANY_MASTER_ID, id);
            return sb.ToString();
        }
        private string SelectMaxHistoryByParamKey(CfgCompanyMaster obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" select max({0}) from {1} where {2} = '{3}' and {4} = '{5}' ", CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, CfgCompanyMaster.TableName, 
                CfgCompanyMaster.ColumnNames.COMPANY_NAME, obj.COMPANY_NAME,CfgCompanyMaster.ColumnNames.COMPANY_CODE,obj.COMPANY_CODE);

            return sb.ToString();
        }

        public bool DeleteCfgCompanyMaster(int id)//no need to code for other mapping as already got the cascade delete
        {
            string query = string.Empty;

            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();                

                dbManager.ExecuteNonQuery(CommandType.Text, DeleteCurrencyMapQuery(id));

                if (dbManager.ExecuteNonQuery(CommandType.Text, DeleteCfgCompanyMasterQuery(id)) > 0)
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

        private string DeleteCurrencyMapQuery(int id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" Delete from  {0} where ", CfgCompanyCurrencyMap.TableName);
            sb.AppendFormat(" {0} in ( select {1} from {2} where {3} = {4} ) "
                , CfgCompanyCurrencyMap.ColumnNames.COMPANY_CODE, CfgCompanyMaster.ColumnNames.COMPANY_CODE, CfgCompanyMaster.TableName
                , CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID , id);
            return sb.ToString();
        }
        private string UpdateCfgCompanyMasterQuery(CfgCompanyMaster paramsObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" update {0} set ", CfgCompanyMaster.TableName);
        //    sb.AppendFormat(" {0} = '{1}' ", CfgCompanyMaster.ColumnNames.COMPANY_CODE,  paramsObj.Formatted_COMPANY_CODE);
            sb.AppendFormat(" {0} = '{1}' ", CfgCompanyMaster.ColumnNames.COMPANY_NAME, paramsObj.Formatted_COMPANY_NAME);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.COMPANY_DESCRIPTION, paramsObj.Formatted_COMPANY_DESCRIPTION);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_PURCHASING_ORG, paramsObj.Formatted_DEFAULT_PURCHASING_ORG);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_CURRENCY_NAME, paramsObj.Formatted_DEFAULT_CURRENCY_NAME);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.ACTIVE, paramsObj.ACTIVE);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.APR_COMPANY_GROUP, paramsObj.Formatted_APR_COMPANY_GROUP);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.IF_COMPANY_CODE, paramsObj.Formatted_IF_COMPANY_CODE);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.IF_DESTINATION_SYSTEM, paramsObj.Formatted_IF_DESTINATION_SYSTEM);            
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_TIMEZONE, paramsObj.Formatted_DEFAULT_TIMEZONE);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATE_FORMAT, paramsObj.Formatted_DEFAULT_DISP_DATE_FORMAT);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_DISP_TIME_FORMAT, paramsObj.Formatted_DEFAULT_DISP_TIME_FORMAT);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, paramsObj.Formatted_DEFAULT_DISP_DATETIME_FORMAT);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL, paramsObj.Formatted_DEFAULT_PR_NOTIFY_EMAIL);
            sb.AppendFormat(" ,{0} = '{1}' ", CfgCompanyMaster.ColumnNames.DEFAULT_LANGUAGE, paramsObj.Formatted_DEFAULT_LANGUAGE);
            sb.AppendFormat(" where {0} = {1} ", CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, paramsObj.CFG_COMPANY_MASTER_ID);

            return sb.ToString();
        }
        private string DeleteCfgCompanyMasterQuery(decimal id)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" delete from {0}  ", CfgCompanyMaster.TableName);
            sb.AppendFormat(" where {0} = {1} ", CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, id);

            return sb.ToString();
        }        
        private string InsertCfgCompanyMasterQuery(CfgCompanyMaster paramsObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" insert into {0}  ({1}, {2}, {3}, {4}, {5} ,{6}, {7},{8},{9},{10}, {11},{12},{13},{14},{15}", CfgCompanyMaster.TableName, CfgCompanyMaster.ColumnNames.COMPANY_CODE, CfgCompanyMaster.ColumnNames.COMPANY_NAME, CfgCompanyMaster.ColumnNames.COMPANY_DESCRIPTION, CfgCompanyMaster.ColumnNames.DEFAULT_PURCHASING_ORG, CfgCompanyMaster.ColumnNames.ACTIVE, CfgCompanyMaster.ColumnNames.DEFAULT_CURRENCY_NAME
                , CfgCompanyMaster.ColumnNames.APR_COMPANY_GROUP, CfgCompanyMaster.ColumnNames.IF_COMPANY_CODE, CfgCompanyMaster.ColumnNames.IF_DESTINATION_SYSTEM
                , CfgCompanyMaster.ColumnNames.DEFAULT_TIMEZONE, CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATE_FORMAT, CfgCompanyMaster.ColumnNames.DEFAULT_DISP_TIME_FORMAT, CfgCompanyMaster.ColumnNames.DEFAULT_DISP_DATETIME_FORMAT, CfgCompanyMaster.ColumnNames.DEFAULT_PR_NOTIFY_EMAIL, CfgCompanyMaster.ColumnNames.DEFAULT_LANGUAGE);
            sb.AppendFormat(") values ('{0}','{1}','{2}','{3}', '{4}','{5}','{6}', '{7}','{8}', '{9}' , '{10}', '{11}', '{12}' ,'{13}','{14}')", paramsObj.Formatted_COMPANY_CODE, paramsObj.Formatted_COMPANY_NAME, paramsObj.Formatted_COMPANY_DESCRIPTION, paramsObj.Formatted_DEFAULT_PURCHASING_ORG, paramsObj.ACTIVE, paramsObj.Formatted_DEFAULT_CURRENCY_NAME
                , paramsObj.Formatted_APR_COMPANY_GROUP, paramsObj.Formatted_IF_COMPANY_CODE, paramsObj.Formatted_IF_DESTINATION_SYSTEM
                , paramsObj.Formatted_DEFAULT_TIMEZONE, paramsObj.Formatted_DEFAULT_DISP_DATE_FORMAT, paramsObj.Formatted_DEFAULT_DISP_TIME_FORMAT, paramsObj.Formatted_DEFAULT_DISP_DATETIME_FORMAT, paramsObj.Formatted_DEFAULT_PR_NOTIFY_EMAIL, paramsObj.Formatted_DEFAULT_LANGUAGE);
            return sb.ToString();
        }

        private string SelectCfgCompanyMasterQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" select * from ");
            sb.AppendFormat("  {0} ", CfgCompanyMaster.TableName);


            return sb.ToString();
        }


        private string SelectCfgCompanyNameForInvQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" select {0} from ", CfgCompanyMaster.ColumnNames.COMPANY_NAME);
            sb.AppendFormat("  {0} ", CfgCompanyMaster.TableName);
            sb.AppendFormat("  where {0} in  ", CfgCompanyMaster.ColumnNames.COMPANY_CODE);
            sb.AppendFormat("  (select {0} from {1}   ", CfgInvSite.ColumnNames.COMPANY_CODE, CfgInvSite.TableName);
            sb.AppendFormat("  where {0} = 'Yes' )  order by {1} ", CfgInvSite.ColumnNames.ACTIVE, CfgCompanyMaster.ColumnNames.COMPANY_NAME);


            return sb.ToString();
        }

        private string SelectRowByCodeQuery(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from ");
            sb.AppendFormat("  {0} ", CfgCompanyMaster.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgCompanyMaster.ColumnNames.COMPANY_CODE, id);
            return sb.ToString();
        }
        public CfgCompanyMaster SelectRowByCode(string id)
        {
            CfgCompanyMaster obj = null;
            try
            {
                dbManager.Open();
                ArrayList arr = dbManager.GetArrayofObjects(SelectRowByCodeQuery(id), new CfgCompanyMaster().GetType());
                if (arr != null && arr.Count > 0)
                {
                    obj = (CfgCompanyMaster)arr[0];
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

        private string GetInsRowsByUniqConst(string companyCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgCompanyMaster.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgCompanyMaster.ColumnNames.COMPANY_CODE, companyCode);
            return sb.ToString();
        }

        private string GetUpdRowsByUniqConst(string Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from  {0}  ", CfgCompanyMaster.TableName);
            sb.AppendFormat(" where {0} = '{1}' ", CfgCompanyMaster.ColumnNames.CFG_COMPANY_MASTER_ID, Id);
            return sb.ToString();
        }

        public DataTable SelectInsRowsWithData(string compcode)
        {
            DataTable dt;
            try
            {
                dbManager.Open();
                DataSet ds = dbManager.ExecuteDataSet(CommandType.Text, GetInsRowsByUniqConst(compcode));
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

    }
}
