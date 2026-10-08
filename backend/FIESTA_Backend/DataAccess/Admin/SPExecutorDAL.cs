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
using FIESTA_Backend.Models.Admin;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using FIESTA_Backend.Models.Test;
using FIESTA_Backend.EfModels;
using Oracle.ManagedDataAccess.Types;

namespace FIESTA_Backend.DataAccess.Admin
{
    public class SPExecutorDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;

        public SPExecutorDAL(IConfiguration configuration, HttpContext httpContext)
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

        public SPExecutorResult ExecuteSP(string SPNAME, int i_PAGE_NO, int i_PAGE_SIZE, string i_DATEUPDATE, string i_TABLEPATH, string i_TABLENAME)
        {
            try
            {
                dbManager.Open();
                dbManager.BeginTransaction();

                dbManager.ClearParameters();
                dbManager.CreateParameters(8);

                OracleParameter PAGE_NO = new OracleParameter();
                PAGE_NO.OracleDbType = OracleDbType.Decimal;
                PAGE_NO.Direction = ParameterDirection.Input;
                PAGE_NO.ParameterName = "PAGE_NO";
                PAGE_NO.Value = i_PAGE_NO;
                PAGE_NO.Scale = 0;
                PAGE_NO.Precision = 10;
                dbManager.AddParameters(0, PAGE_NO);

                OracleParameter PAGE_SIZE = new OracleParameter();
                PAGE_SIZE.OracleDbType = OracleDbType.Decimal;
                PAGE_SIZE.Direction = ParameterDirection.Input;
                PAGE_SIZE.ParameterName = "PAGE_SIZE";
                PAGE_SIZE.Value = i_PAGE_SIZE;
                PAGE_SIZE.Scale = 0;
                PAGE_SIZE.Precision = 10;
                dbManager.AddParameters(1, PAGE_SIZE);

                OracleParameter DATEUPDATE = new OracleParameter();
                DATEUPDATE.OracleDbType = OracleDbType.Varchar2;
                DATEUPDATE.Direction = ParameterDirection.Input;
                DATEUPDATE.ParameterName = "DATEUPDATE";
                DATEUPDATE.Value = i_DATEUPDATE;
                DATEUPDATE.Size = 200;
                dbManager.AddParameters(2, DATEUPDATE);

                OracleParameter TABLEPATH = new OracleParameter();
                TABLEPATH.OracleDbType = OracleDbType.Varchar2;
                TABLEPATH.Direction = ParameterDirection.Input;
                TABLEPATH.ParameterName = "TABLEPATH";
                TABLEPATH.Value = i_TABLEPATH;
                TABLEPATH.Size = 200;
                dbManager.AddParameters(3, TABLEPATH);

                OracleParameter TABLENAME = new OracleParameter();
                TABLENAME.OracleDbType = OracleDbType.Varchar2;
                TABLENAME.Direction = ParameterDirection.Input;
                TABLENAME.ParameterName = "TABLENAME";
                TABLENAME.Value = i_TABLENAME;
                TABLENAME.Size = 200;
                dbManager.AddParameters(4, TABLENAME);

                OracleParameter OUT_DATA = new OracleParameter();
                OUT_DATA.OracleDbType = OracleDbType.Clob;
                OUT_DATA.Direction = ParameterDirection.Output;
                OUT_DATA.ParameterName = "OUT_DATA";
                //OUT_DATA.Size = (int)(Int32.MaxValue);
                dbManager.AddParameters(5, OUT_DATA);

                OracleParameter TOTAL_PAGE = new OracleParameter();
                TOTAL_PAGE.OracleDbType = OracleDbType.Decimal;
                TOTAL_PAGE.Direction = ParameterDirection.Output;
                TOTAL_PAGE.ParameterName = "TOTAL_PAGE";
                TOTAL_PAGE.Scale = 0;
                TOTAL_PAGE.Precision = 10;
                dbManager.AddParameters(6, TOTAL_PAGE);

                OracleParameter MAXDATEUPDATE = new OracleParameter();
                MAXDATEUPDATE.OracleDbType = OracleDbType.Varchar2;
                MAXDATEUPDATE.Direction = ParameterDirection.Output;
                MAXDATEUPDATE.ParameterName = "MAXDATEUPDATE";
                MAXDATEUPDATE.Size = 500;
                dbManager.AddParameters(7, MAXDATEUPDATE);

                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, SPNAME);
                dbManager.CommitTransaction();

                OracleClob oc = (OracleClob)OUT_DATA.Value;
                string val = Convert.ToString(oc.Value);
                val = val.Replace("\\\"", "\"");
                List<object> res = new List<object>();
                MdmResult result = JsonConvert.DeserializeObject<MdmResult>(val);
                string objName = "FIESTA_Backend.EfModels.OUT_" + i_TABLENAME.ToUpper();

                if (objName.EndsWith("S"))
                    objName = objName.Substring(0, objName.Length - 1);

                var t = Type.GetType(objName);
                if(t != null && result != null)
                {
                    foreach (MdmContent c in result.recordContent ?? Enumerable.Empty<MdmContent>())
                    {
                        res.Add(JsonConvert.DeserializeObject(c.content.ToString(), t));
                    }
                }
                else
                {
                    return new SPExecutorResult()
                    {
                        OUT_DATA_RAW = val,
                        OUT_DATA_GRID = null,
                        TOTAL_PAGE = Convert.ToDecimal(((OracleDecimal)TOTAL_PAGE.Value).Value),
                        MAXDATEUPDATE = "Failed to translate [" + objName + "]"
                    };
                }
                
                return new SPExecutorResult()
                {
                    OUT_DATA_RAW = val,
                    OUT_DATA_GRID = res,
                    TOTAL_PAGE = Convert.ToDecimal(((OracleDecimal)TOTAL_PAGE.Value).Value),
                    MAXDATEUPDATE = MAXDATEUPDATE.Value.ToString()
                };
            }
            catch (Exception ce)
            {
                dbManager.RollbackTransaction();
                //logger.Error(ce.StackTrace);
                return new SPExecutorResult()
                {
                    OUT_DATA_RAW = ce.Message + "\n" + ce.StackTrace,
                    OUT_DATA_GRID = null,
                    TOTAL_PAGE = 0,
                    MAXDATEUPDATE = "ERROR! Detail refer [Out Data Raw] Tab."
                };
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        public string ExecuteUpdateTime(string partNumber, string partType, string tableName)
        {
            try
            {
                dbManager.Open();

                dbManager.ClearParameters();
                dbManager.CreateParameters(4);

                OracleParameter p_pn = new OracleParameter();
                p_pn.OracleDbType = OracleDbType.Varchar2;
                p_pn.Direction = ParameterDirection.Input;
                p_pn.ParameterName = "p_pn";
                p_pn.Value = partNumber;
                p_pn.Size = 40;
                dbManager.AddParameters(0, p_pn);

                OracleParameter p_pnType = new OracleParameter();
                p_pnType.OracleDbType = OracleDbType.Varchar2;
                p_pnType.Direction = ParameterDirection.Input;
                p_pnType.ParameterName = "p_pnType";
                p_pnType.Value = partType;
                p_pnType.Size = 5;
                dbManager.AddParameters(1, p_pnType);

                OracleParameter p_tablename = new OracleParameter();
                p_tablename.OracleDbType = OracleDbType.Varchar2;
                p_tablename.Direction = ParameterDirection.Input;
                p_tablename.ParameterName = "p_tablename";
                p_tablename.Value = tableName;
                p_tablename.Size = 50;
                dbManager.AddParameters(2, p_tablename);

                OracleParameter p_out_msg = new OracleParameter();
                p_out_msg.OracleDbType = OracleDbType.Varchar2;
                p_out_msg.Direction = ParameterDirection.Output;
                p_out_msg.ParameterName = "p_out_msg";
                p_out_msg.Size = 4000;
                dbManager.AddParameters(3, p_out_msg);

                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "SP_UPDATE_PN_UPDATETIME");

                return p_out_msg.Value.ToString();
            }
            catch (Exception ce)
            {
                return ce.Message + "\n" + ce.InnerException;
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        public List<CFG_SYSTEM_PARAM> ExecuteValidateDynamicUI(string filterParamCategory)
        {
            try
            {
                dbManager.Open();

                dbManager.ClearParameters();
                dbManager.CreateParameters(2);

                OracleParameter p_pn = new OracleParameter();
                p_pn.OracleDbType = OracleDbType.Varchar2;
                p_pn.Direction = ParameterDirection.Input;
                p_pn.ParameterName = "p_filter_param_category";
                p_pn.Value = filterParamCategory;
                p_pn.Size = 200;
                dbManager.AddParameters(0, p_pn);

                OracleParameter p_out_msg = new OracleParameter();
                p_out_msg.OracleDbType = OracleDbType.Varchar2;
                p_out_msg.Direction = ParameterDirection.Output;
                p_out_msg.ParameterName = "p_out_msg";
                p_out_msg.Size = 32767;
                dbManager.AddParameters(1, p_out_msg);

                dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "SP_VLD_DYNAMIC_UI");

                return ConvertStringToList(p_out_msg.Value.ToString(), filterParamCategory);
            }
            catch (Exception ce)
            {
                return ConvertStringToList("Error Executing [" + filterParamCategory + "]|" +ce.Message + "\n" + ce.InnerException, filterParamCategory);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        private List<CFG_SYSTEM_PARAM> ConvertStringToList(string output, string filterParamCategory)
        {
            List<CFG_SYSTEM_PARAM> result = new List<CFG_SYSTEM_PARAM>();

            if (output.EndsWith(";;"))
            {
                output = output.Substring(0, output.Length - 2);
            }

            List<string> rowSplit = output.Split(";;").ToList();

            int seq = 1;
            foreach(string s in rowSplit)
            {
                string[] colSplit = s.Split('|');
                result.Add(new CFG_SYSTEM_PARAM() {
                    CFG_SYSTEM_PARAM_ID = seq++,
                    PARAM_CATEGORY = filterParamCategory,
                    PARAM_KEY = colSplit[0],
                    PARAM_VALUE = colSplit[1]
                });
            }

            return result;
        }
    }
}
