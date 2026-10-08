using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models.Common;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgProcessConvertMasterDAL
    {
        private string _connectionString = "";
        private string _providerType = "";
        private IDBManager dbManager;
        private log4net.ILog logger;
        private readonly IConfiguration _config;
        private readonly HttpContext _httpContext;
        private EnvironmentProperties _envProperties;
        private FiestaDbContext _context;

        public CfgProcessConvertMasterDAL(IConfiguration configuration, HttpContext httpContext, FiestaDbContext context)
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

        public CFG_PROCESS_CONVERT_MASTER? GetByDetailWaferProcess(string detailWaferProcess)
        {
            return _context.CFG_PROCESS_CONVERT_MASTERs.FirstOrDefault(x => x.detailWaferProcess == detailWaferProcess);
        }
    }
}
