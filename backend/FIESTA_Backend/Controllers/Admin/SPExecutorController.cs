using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.DataAccess.Admin;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models.Admin;
using FIESTA_Backend.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FIESTA_Backend.Controllers.Admin
{
    public class SPExecutorController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;

        public SPExecutorController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        [Authorize]
        [Route("api/SPExecutor")]
        [HttpGet]
        public IActionResult SPExecutor(string SPNAME, int PAGE_NO, int PAGE_SIZE, string DATEUPDATE, string TABLEPATH, string TABLENAME)
        {
            SPExecutorDAL dal = new SPExecutorDAL(_config, _httpContext);
            SPExecutorResult result = dal.ExecuteSP(SPNAME, PAGE_NO, PAGE_SIZE, DATEUPDATE, TABLEPATH, TABLENAME);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [Authorize]
        [Route("api/SPUpdateTime")]
        [HttpPost]
        public IActionResult SPUpdateTime(string partNumber, string partType, string tableName)
        {
            SPExecutorDAL dal = new SPExecutorDAL(_config, _httpContext);

            return Ok(new { status = dal.ExecuteUpdateTime(partNumber, partType, tableName) });
        }

        [Authorize]
        [Route("api/SPVldDynamicUI")]
        [HttpPost]
        public IActionResult SPVldDynamicUI(string filterParamCategory)
        {
            SPExecutorDAL dal = new SPExecutorDAL(_config, _httpContext);

            return Ok(new { status = dal.ExecuteValidateDynamicUI(filterParamCategory) });
        }
    }
}
