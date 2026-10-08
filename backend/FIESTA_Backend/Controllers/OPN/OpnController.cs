using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FIESTA_Backend.Controllers.PLM
{
    public class OpnController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public OpnController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/OpnList")]
        [HttpGet]
        public IActionResult OpnList([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MV_OPN_LISTs.ToList<MV_OPN_LIST>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MV_OPN_LISTs, loadOptions));
            }

        }
    }
}
