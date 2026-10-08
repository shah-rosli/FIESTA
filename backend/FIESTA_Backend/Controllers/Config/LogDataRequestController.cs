using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FIESTA_Backend.Controllers.Config
{
    public class LogDataRequestController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public LogDataRequestController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/LogDataRequest/GetAll")]
        [HttpGet]
        public IActionResult LogDataRequestUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_LOGs.ToList<V_LOG>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_LOGs, loadOptions));
            }

        }
    }
}
