using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Eventing.Reader;
using UtilityCore.Models;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.DataAccess.Config
{
	public class CfgProductionCycleTimeDAL
	{
		private string _connectionString = "";
		private string _providerType = "";
		private IDBManager dbManager;
		private log4net.ILog logger;
		private readonly IConfiguration _config;
		private readonly HttpContext _httpContext;
		private EnvironmentProperties _envProperties;
		private FiestaDbContext _context;

		public CfgProductionCycleTimeDAL(IConfiguration configuration, HttpContext httpContext, FiestaDbContext context)
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
		public JsonReturn InsertRecord(CFG_PRODUCTION_CYCLETIME cfg, TokenProperties token)
		{
			JsonReturn objReturn = new JsonReturn();

            //check if exist
            CFG_PRODUCTION_CYCLETIME? c = _context.CFG_PRODUCTION_CYCLETIMEs
                .FirstOrDefault(x =>
                x.partNumber == cfg.partNumber &&
                x.plant == cfg.plant &&
                x.storageLocation == cfg.storageLocation &&
                x.glmStage == cfg.glmStage &&
                x.validFromDate.Date == cfg.validFromDate.Date);

            objReturn.Data = c;

            try
            {
                //insert only when not exist
                if (c == null)
                {
                    cfg.createdBy = token.USER_ID;
                    cfg.modifiedBy = token.USER_ID;
                    _context.CFG_PRODUCTION_CYCLETIMEs.Add(cfg);
                    _context.SaveChanges();

                    objReturn.Data = cfg;
                }
                else
                {
                    c.modifiedBy = token.USER_ID;
                    c.unitOfTime = cfg.unitOfTime;
                    c.quantityUnitOfTime = cfg.quantityUnitOfTime;
                    c.classification = cfg.classification;
                    c.time = cfg.time;
                    c.deleteFlag = cfg.deleteFlag;

                    _context.SaveChanges();
                }
                objReturn.SuccessMsg = "Record(s) are Created/Updated Successfully";
            }
            catch (Exception e)
            {
                objReturn.ErrorMsg = "Record with PartNumber : " + cfg.partNumber + " Plant : " + cfg.plant + " StorageLocation : " +
                    cfg.storageLocation + " GLM Stage : " + cfg.glmStage + " Valid From Date : " +
					cfg.validFromDate + "not added due to : " + e.InnerException.Message;
            }

			return objReturn;
		}

		public JsonReturn UpdateRecord(CFG_PRODUCTION_CYCLETIME cfg, TokenProperties token)
		{
			JsonReturn objReturn = new JsonReturn();

            //check if exist
            CFG_PRODUCTION_CYCLETIME? c = _context.CFG_PRODUCTION_CYCLETIMEs
                .FirstOrDefault(x =>
                x.partNumber == cfg.partNumber &&
                x.plant == cfg.plant &&
                x.storageLocation == cfg.storageLocation &&
                x.glmStage == cfg.glmStage &&
                x.validFromDate.Date == cfg.validFromDate.Date);

            objReturn.Data = c;

            //update only when exist
            if (c != null)
			{
				c.modifiedBy = token.USER_ID;
				c.unitOfTime = cfg.unitOfTime;
				c.quantityUnitOfTime = cfg.quantityUnitOfTime;
				c.classification = cfg.classification;
				c.time = cfg.time;
				c.deleteFlag = cfg.deleteFlag;

				_context.SaveChanges();

				objReturn.SuccessMsg = "Record Updated Successfully";
			}
			else
			{
				objReturn.ErrorMsg = "Record with PartNumber : " + cfg.partNumber + " Plant : " + cfg.plant + " StorageLocation : " +
                    cfg.storageLocation + " GLM Stage : " + cfg.glmStage + " Valid From Date : " +
					cfg.validFromDate + "not found!";
			}

			return objReturn;
		}
	}
}
