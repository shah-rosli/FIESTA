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
	public class CfgProductDAL
	{
		private string _connectionString = "";
		private string _providerType = "";
		private IDBManager dbManager;
		private log4net.ILog logger;
		private readonly IConfiguration _config;
		private readonly HttpContext _httpContext;
		private EnvironmentProperties _envProperties;
		private FiestaDbContext _context;

		public CfgProductDAL(IConfiguration configuration, HttpContext httpContext, FiestaDbContext context)
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
		public JsonReturn InsertRecord(CFG_PRODUCT cfg, TokenProperties token)
		{
			JsonReturn objReturn = new JsonReturn();

            //check if exist
            CFG_PRODUCT? c = _context.CFG_PRODUCTs
            .FirstOrDefault(x => x.partNumber == cfg.partNumber);

            objReturn.Data = c;

            try
            {
                //insert only when not exist
                if (c == null)
                {
                    cfg.createdBy = token.USER_ID;
                    cfg.modifiedBy = token.USER_ID;
                    _context.SaveChanges();

                    objReturn.Data = cfg;

                }
                else
                {
                    c.modifiedBy = token.USER_ID;
                    c.partDescription = cfg.partDescription;
                    c.plmStatus = cfg.plmStatus;
                    //c.totalShelfLife = cfg.totalShelfLife; KA 20250703 dropped
                    c.minimumOrderQuantity = cfg.minimumOrderQuantity;
                    c.standardPackingQuantity = cfg.standardPackingQuantity;
                    c.businessPlannerCode = cfg.businessPlannerCode;
                    c.deleteFlag = cfg.deleteFlag;

                    _context.SaveChanges();
                }
                objReturn.SuccessMsg = "Record(s) are Created/Updated Successfully";
            }
            catch (Exception ex)
            {
                objReturn.ErrorMsg = "Record with PartNumber : " + cfg.partNumber + " is not added due to : " + ex.InnerException.Message;
            }

            return objReturn;
		}

		public JsonReturn UpdateRecord(CFG_PRODUCT cfg, TokenProperties token)
		{
			JsonReturn objReturn = new JsonReturn();

			//check if exist
			CFG_PRODUCT? c = _context.CFG_PRODUCTs
				.FirstOrDefault(x => x.partNumber == cfg.partNumber);

            objReturn.Data = c;

            //update only when exist
            if (c != null)
			{
				c.modifiedBy = token.USER_ID;
				c.partDescription = cfg.partDescription;
				c.plmStatus = cfg.plmStatus;
                //c.totalShelfLife = cfg.totalShelfLife; KA 20250703 dropped
                c.minimumOrderQuantity = cfg.minimumOrderQuantity;
				c.standardPackingQuantity = cfg.standardPackingQuantity;
				c.businessPlannerCode = cfg.businessPlannerCode;
				c.deleteFlag = cfg.deleteFlag;

				_context.SaveChanges();

				objReturn.SuccessMsg = "Record Updated Successfully";
			}
			else
			{
				objReturn.ErrorMsg = "Record with PartNumber : " + cfg.partNumber + "not found!";
			}

			return objReturn;
		}

}
}
