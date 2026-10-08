using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public LoggerController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }
        // GET: api/SystemParam
        [Authorize]
        [Route("api/Logger")]
        [HttpGet]
        public DataTable Get()
        {
            CfgLoggerDAL dal = new CfgLoggerDAL(_config, _httpContext);
            return dal.SelectAllRows();
        }


        [Authorize]
        [Route("api/Logger/{id}")]
        [HttpGet]
        public CfgLogger Get(int id)
        {
            CfgLoggerDAL dal = new CfgLoggerDAL(_config, _httpContext);
            return dal.SelectRowById(id);
        }

        // POST: api/SystemParam
        [Authorize]
        [Route("api/Logger")]
        [HttpPost]
        public ActionResult Post([FromBody] CfgLogger paramsObj)
        {
            return InsertRecord(paramsObj);
        }

        private ActionResult InsertRecord(CfgLogger paramsObj)
        {
            CfgLoggerDAL dal = new CfgLoggerDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            try
            {
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                paramsObj.TokenObj = token.GetTokenObject();

                dal.InsertRow(paramsObj);

                objReturn.SuccessMsg = "Record Created Successfully";

                return Ok(objReturn);

            }
            catch (Exception ex)

            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        //public void Post([FromBody]string value)
        //{
        //}



    }
}
