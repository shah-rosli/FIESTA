using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using UtilityCore.Models;
using UtilityCore.Utility.BulkImport;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgCompanyCodeMappingController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgCompanyCodeMappingController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
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
                return Ok(_context.V_CFG_COMPANYCODE_MAPPINGs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_COMPANYCODE_MAPPINGs, loadOptions));
            }

        }

    }
}
