using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public class CfgRRSiteController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgRRSiteController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
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
                return Ok(_context.CFG_RR_SITEs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.CFG_RR_SITEs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/[controller]/GetDropdownList")]
        [HttpGet]
        public IActionResult GetDropdownList()
        {
            try
            {
                var result = _context.CFG_RR_SITEs
                    .Where(x => !string.IsNullOrEmpty(x.plant) && 
                                !string.IsNullOrEmpty(x.storageLocation) && 
                                !string.IsNullOrEmpty(x.siteID) && 
                                !string.IsNullOrEmpty(x.siteName))
                    .Select(x =>
                        new
                        {
                            siteID = x.siteID,
                            siteName = x.siteName,
                        }
                    ).Distinct().OrderBy(x => x.siteID);
                
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
