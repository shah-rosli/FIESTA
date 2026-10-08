using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System.Diagnostics;
using UtilityCore.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.DataAccess.Config
{
	public class CfgProductionAlternativesMixRatiosDAL
	{
		private string _connectionString = "";
		private string _providerType = "";
		private IDBManager dbManager;
		private log4net.ILog logger;
		private readonly IConfiguration _config;
		private readonly HttpContext _httpContext;
		private EnvironmentProperties _envProperties;
		private FiestaDbContext _context;

		public CfgProductionAlternativesMixRatiosDAL(IConfiguration configuration, HttpContext httpContext, FiestaDbContext context)
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
		public JsonReturn InsertRecord(CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO cfg, TokenProperties token)
		{
			JsonReturn objReturn = new JsonReturn();
            //check if exist
            CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO? c = _context.CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOs
            .FirstOrDefault(x => x.partNumber == cfg.partNumber && x.supplyPlant == cfg.supplyPlant
            && x.supplyStorageLocation == cfg.supplyStorageLocation && x.plant == cfg.plant && x.storageLocation == cfg.storageLocation);

            objReturn.Data = c;

            try
            {
                //insert only when not exist
                if (c == null)
                {
                    cfg.createdBy = token.USER_ID;
                    cfg.modifiedBy = token.USER_ID;
                    _context.CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOs.Add(cfg);
                    _context.SaveChanges();
                    objReturn.Data = cfg;
                }
                else
                {
                    c.modifiedBy = token.USER_ID;
                    c.partNumber = cfg.partNumber;
                    c.plant = cfg.plant;
                    c.storageLocation = cfg.storageLocation;
                    c.supplyPlant = cfg.supplyPlant;
                    c.supplyStorageLocation = cfg.supplyStorageLocation;
                    //c.flowAlternative = cfg.flowAlternative;
                    c.ratio = cfg.ratio;
                    c.priority = cfg.priority;
                    c.productionVersion = cfg.productionVersion;
                    c.deleteFlag = cfg.deleteFlag;

                    _context.SaveChanges();
                }
                objReturn.SuccessMsg = "Record(s) are Created/Updated Successfully";
            }
            catch (Exception ex)
            {
                objReturn.ErrorMsg = "Record with PartNumber : " + cfg.partNumber + " Supply Plant :" + cfg.supplyPlant + " Supply Storage Location :" + cfg.supplyStorageLocation
                    + " not added due to : " + ex.InnerException.Message;
            }
           
			return objReturn;
		}

        public JsonReturn UpdateRecord(CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO cfg, TokenProperties token)
        {
            JsonReturn objReturn = new JsonReturn();
            objReturn.DataList = new List<object>();
            //check if exist
            IEnumerable<CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO> cList = _context.CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOs
                .Where(x => x.partNumber == cfg.partNumber && x.supplyPlant == cfg.supplyPlant
                && x.supplyStorageLocation == cfg.supplyStorageLocation);

            foreach (CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO c in cList)
            {
                //update only when exist
                if (c != null)
                {
                    c.modifiedBy = token.USER_ID;
                    c.priority = cfg.priority;
                    c.productionVersion = cfg.productionVersion;
                    c.deleteFlag = cfg.deleteFlag;

                    objReturn.DataList.Add(c);
                }
                else
                {
                    objReturn.ErrorMsg += "Record with PartNumber : " + cfg.partNumber + " Production Version :" + cfg.productionVersion + "not found!";
                    return objReturn;
                }
            }

            _context.SaveChanges();
            objReturn.SuccessMsg = "Record Updated Successfully";

            return objReturn;
        }

        public JsonReturn UpdateFullRecord(CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO cfg, TokenProperties token)
		{
			JsonReturn objReturn = new JsonReturn();
			//check if exist
			CFG_PRODUCTION_ALTERNATIVES_MIX_RATIO? c = _context.CFG_PRODUCTION_ALTERNATIVES_MIX_RATIOs
				.FirstOrDefault(x => x.partNumber == cfg.partNumber && x.supplyPlant == cfg.supplyPlant
				&& x.supplyStorageLocation == cfg.supplyStorageLocation
                && x.plant == cfg.plant
                && x.storageLocation == cfg.storageLocation);

            objReturn.Data = c;

            //update only when exist
            if (c != null)
            {
                c.modifiedBy = token.USER_ID;
                c.ratio = cfg.ratio;
                c.priority = cfg.priority;
                c.productionVersion = cfg.productionVersion;
                c.deleteFlag = cfg.deleteFlag;

                _context.SaveChanges();

                objReturn.SuccessMsg = "Record Updated Successfully";
            }
            else
            {
                objReturn.ErrorMsg += "Record with PartNumber : " + cfg.partNumber + " Production Version :" + cfg.productionVersion + "not found!";
            }

            return objReturn;
		}
	}
}
