using FIESTA_Backend.DataAccess.Common;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public UserAccessController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        [Authorize]
        [Route("api/UserAccess/GetUserList/{user_id}")]
        [HttpGet]
        public UserAccess GetUserList(string user_id)
        {
            UserAccessDAL dal = new UserAccessDAL(_config, _httpContext);
            return dal.SelectUserAccess(user_id);
        }
    }
}
