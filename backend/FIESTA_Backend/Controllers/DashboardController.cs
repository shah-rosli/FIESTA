using FIESTA_Backend.EfModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIESTA_Backend.Controllers
{
    public class DashboardController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        private readonly MDMDbContext _mdm_context;

        public DashboardController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, MDMDbContext mdm_context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _mdm_context = mdm_context;
        }

        [Route("api/Dashboard/GetTablesMaxUpdateTime")]
        [HttpGet]
        [Authorize]
        public IActionResult GetTablesMaxUpdateTime(string group_name)
        {
            //get table list

            List<V_DASHBOARD> result = new List<V_DASHBOARD>();
            if(!string.IsNullOrEmpty(group_name))
                result = _context.V_DASHBOARDs.Where(x => x.CFG_SYS_TABLE_GROUP_NAME == group_name).ToList();
            else
                result = _context.V_DASHBOARDs.ToList();

            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }

        [Route("api/Dashboard/GetDashboardData")]
        [HttpGet]
        [Authorize]
        public IActionResult GetDashboardData()
        {
            var mv = _context.USER_MVIEWs.FirstOrDefault(x => x.MVIEW_NAME == "MV_DASHBOARD_STATS");

            var v1 = _context.MV_DASHBOARD_STATs
                .AsNoTracking()
                .ToList();

            var v2 = _mdm_context.V_DASHBOARD_STATS_V2s
                .AsNoTracking()
                .ToList();

            var statsV1 = v1.Select(x => new
            {
                x.SEQ,
                x.GROUPING,
                x.OBJECT,
                x.COUNT,
                x.LASTUPDATE
            });

            var statsV2 = v2.Select(x => new
            {
                x.SEQ,
                x.GROUPING,
                x.OBJECT,
                x.COUNT,
                x.LASTUPDATE
            });

            var stats = statsV1
                .Union(statsV2)
                .OrderBy(x => x.SEQ)
                .ToList();

            return Ok(new
            {
                //stats = _context.MV_DASHBOARD_STATs.ToList<MV_DASHBOARD_STAT>(),
                stats,
                statsLastRefreshDate = mv.LAST_REFRESH_DATE,
                blacklist = _context.MV_DASHBOARD_BLACKLISTs.ToList<MV_DASHBOARD_BLACKLIST>(),
            });
        }


    }
}
