using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ExcelDataReader;
using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using my.com.idt.score.Model;
using Org.BouncyCastle.Asn1.Cmp;
using System.Data;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using UtilityCore.Models;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgCodeConvertMasterController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CfgCodeConvertMasterController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.CFG_CODE_CONVERT_MASTERs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.CFG_CODE_CONVERT_MASTERs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/[controller]/GetByCodeType")]
        [HttpGet]
        public IActionResult GetByCodeType([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery]string codeType)
        {
            if (loadOptions == null)
            {
                return Ok(_context.CFG_CODE_CONVERT_MASTERs.Where(x => x.codetype == codeType).Select(x => new { code = x.code }));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.CFG_CODE_CONVERT_MASTERs.Where(x => x.codetype == codeType).Select(x => new {code = x.code}), loadOptions));
            }

        }
    }
}
