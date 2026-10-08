using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgProductionVersionPatternController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgProductionVersionPatternController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.CFG_PRODUCTION_VERSION_PATTERNs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.CFG_PRODUCTION_VERSION_PATTERNs, loadOptions));
            }

        }
    }
}
