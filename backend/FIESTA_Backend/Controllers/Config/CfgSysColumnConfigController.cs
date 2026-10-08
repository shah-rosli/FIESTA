using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.EfModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgSysColumnConfigController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        private readonly CfgSysColumnConfigDAL _dal;

        public CfgSysColumnConfigController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _dal = new CfgSysColumnConfigDAL(context);
        }

        [Route("api/[controller]/GetPatternListing")]
        [HttpGet]
        [Authorize]
        public IActionResult GetPatternListing(string tableName)
        {
            List<string> patternList = _dal.GetPatternListing(tableName);

            if (patternList.Any())
                return Ok(patternList.OrderBy(x => x));
            else
                return NotFound();
        }

        [Route("api/[controller]/GetPatternRequiredFields")]
        [HttpGet]
        [Authorize]
        public IActionResult GetPatternRequiredFields(string tableName, string pattern)
        {
            List<string> result = _dal.GetPatternRequiredFields(tableName, pattern);

            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }
    }
}
