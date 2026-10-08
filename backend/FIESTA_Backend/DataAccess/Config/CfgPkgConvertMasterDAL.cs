using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UtilityCore.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgPkgConvertMasterDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;
        private FiestaDbContext _context;

        public CfgPkgConvertMasterDAL(IConfiguration configuration, HttpContext httpContext, FiestaDbContext context)
        {
            this._config = configuration;
            this._httpContext = httpContext;

            _envProperties = new EnvironmentProperties(_config, _httpContext);
            _connectionString = _envProperties.CONN_STRING();
            _providerType = _config.GetSection("ProviderName").Value;
            dbManager = new DBManager(_providerType);  //new DBManager(DataProvider.Odbc);
            dbManager.ConnectionString = _connectionString;
            logger = log4net.LogManager.GetLogger("GeneralLog");
            _context = context;
        }

        public CFG_PKG_CONVERT_MASTER? GetByDetailPackage(string detailPackage)
        {
            return _context.CFG_PKG_CONVERT_MASTERs.FirstOrDefault(x => x.detailPackage == detailPackage);
        }

        public JsonReturn PerformUpload(List<CfgBulkImport> list, TokenProperties token, JsonReturn jsonReturn)
        {
            jsonReturn.Data = list;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (CfgBulkImport bulkImport in list)
                    {
                        if (bulkImport != null && !bulkImport.haveError && bulkImport.haveDifference && bulkImport.bulkImportObj != null)
                        {
                            if (bulkImport.insertOrUpdate == "Insert")
                            {
                                CFG_PKG_CONVERT_MASTER cfg = JsonConvert.DeserializeObject<CFG_PKG_CONVERT_MASTER>(bulkImport.bulkImportObj.ToString());
                                InsertRecord(cfg, token);
                            }
                            else if (bulkImport.insertOrUpdate == "Update")
                            {
                                
                                CFG_PKG_CONVERT_MASTER cfg = JsonConvert.DeserializeObject<CFG_PKG_CONVERT_MASTER>(bulkImport.bulkImportObj.ToString());
                                UpdateRecord(cfg, token);
                            }
                        }
                    }

                    dbContextTransaction.Commit();
                }
                catch(Exception ex)
                {
                    dbContextTransaction.Rollback();
                    jsonReturn.ErrorMsg = "Error: "+ex.Message + ex.StackTrace;
                    return jsonReturn;
                }
            }

            jsonReturn.SuccessMsg = "Successfully Imported!";
            return jsonReturn;
        }

        public JsonReturn InsertRecord(CFG_PKG_CONVERT_MASTER cfg, TokenProperties token)
        {
            JsonReturn objReturn = new JsonReturn();
            objReturn.Data = cfg;
            //check if exist
            CFG_PKG_CONVERT_MASTER? c = _context.CFG_PKG_CONVERT_MASTERs
                .FirstOrDefault(x => x.detailPackage == cfg.detailPackage);

            //insert only when not exist
            if (c == null)
            {
                cfg.createdBy = token.USER_ID;
                cfg.modifiedBy = token.USER_ID;
                _context.CFG_PKG_CONVERT_MASTERs.Add(cfg);
                _context.SaveChanges();

                objReturn.SuccessMsg = "Record Created Successfully";
            }
            else
            {
                objReturn.ErrorMsg = "Record with Detail Package: " + cfg.detailPackage + " exist!";
            }

            return objReturn;
        }

        public JsonReturn UpdateRecord(CFG_PKG_CONVERT_MASTER cfg, TokenProperties token)
        {
            JsonReturn objReturn = new JsonReturn();
            objReturn.Data = cfg;
            //check if exist
            CFG_PKG_CONVERT_MASTER? c = _context.CFG_PKG_CONVERT_MASTERs
                .FirstOrDefault(x => x.detailPackage == cfg.detailPackage);

            //updte only when exist
            if (c != null)
            {
                c.modifiedBy = token.USER_ID;
                c.detailPackage = cfg.detailPackage;
                c.packageLayer = cfg.packageLayer;
                c.roughPackage = cfg.roughPackage;
                c.packageType = cfg.packageType;
                c.bodySize = cfg.bodySize;
                c.pinCount = cfg.pinCount;
                c.deleteFlag = cfg.deleteFlag;

                _context.SaveChanges();

                objReturn.SuccessMsg = "Record Updated Successfully";
            }
            else
            {
                objReturn.ErrorMsg = "Record with Detail Package: " + cfg.detailPackage + " not found!";
            }

            return objReturn;
        }
    }
}
