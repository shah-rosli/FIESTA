using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class CfgUserDelegationController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public CfgUserDelegationController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        [Authorize]
        [Route("api/CfgUserDelegation")]
        [HttpGet]
        public DataTable Get()
        {
            CfgUserDelegateDAL dal = new CfgUserDelegateDAL(_config, _httpContext);
            CfgUserDelegate obj = new CfgUserDelegate();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            return dal.SelectAllRows(obj);
        }

        [Authorize]
        [Route("api/CfgUserDelegation/{id}")]
        [HttpGet]
        public CfgUserDelegate Get(int id)
        {
            CfgUserDelegateDAL dal = new CfgUserDelegateDAL(_config, _httpContext);
            CfgUserDelegate obj = new CfgUserDelegate();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            obj.CFG_USER_DELEGATE_ID = id;
            return dal.SelectRowById(obj);
        }

        [Authorize]
        [Route("api/CfgUserDelegation/GetDelegationFilterByUserId")]
        [HttpGet]
        public CfgUserDelegate GetDelegationFilterByUserId(string user_id)
        {
            CfgUserDelegateDAL dal = new CfgUserDelegateDAL(_config, _httpContext);
            CfgUserDelegate obj = new CfgUserDelegate();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            obj.USER_ID = user_id;
            return dal.SelectRowByUserId(obj);
        }

        [Authorize]
        [Route("api/CfgUserDelegation/GetDelegationHistoryFilterByUserId")]
        [HttpGet]
        public string GetDelegationHistoryFilterByUserId(string user_id)
        {
            CfgUserDelegateHisDAL dal = new CfgUserDelegateHisDAL(_config, _httpContext);
            CfgUserDelegateHis obj = new CfgUserDelegateHis();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            obj.USER_ID = user_id;

            return JsonConvert.SerializeObject(dal.SelectDelegationHistByUserId(obj));
        }

        [Authorize]
        [Route("api/CfgUserDelegation/GetDelegationFilterByDelegateeId")]
        [HttpGet]
        public string GetDelegationFilterByDelegateeId(string delegatee_user_id)
        {
            CfgUserDelegateDAL dal = new CfgUserDelegateDAL(_config, _httpContext);
            CfgUserDelegate obj = new CfgUserDelegate();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            obj.DELEGATEE_USER_ID = delegatee_user_id;

            return JsonConvert.SerializeObject(dal.SelectDelegationByDelegatee(obj));
        }

        [Authorize]
        [Route("api/CfgUserDelegation/GetDelegationHistoryFilterByDelegate")]
        [HttpGet]
        public DataTable GetDelegationHistoryFilterByDelegate(string delegatee_user_id)
        {
            CfgUserDelegateHisDAL dal = new CfgUserDelegateHisDAL(_config, _httpContext);
            CfgUserDelegateHis obj = new CfgUserDelegateHis();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            obj.DELEGATEE_USER_ID = delegatee_user_id;

            return dal.SelectDelegationHistByDelegatee(obj);
        }

        // GET: api/SystemParam
        [Authorize]
        [HttpPost]
        [Route("api/CfgUserDelegation")]
        public ActionResult Post(CfgUserDelegate obj) //save new delegation
        {
            CfgUserDelegateDAL dal = new CfgUserDelegateDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            bool bUpdate = false;


            try
            {
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                obj.TokenObj = token.GetTokenObject();
                bUpdate = dal.ProcessDelegation(obj);
                if (!bUpdate)
                {
                    string errMsg = string.Format("Delegation setting failed : CfgUserDelegation (userid) : {0}, (delegate):{1}", obj.USER_ID, obj.DELEGATEE_USER_ID);
                    return BadRequest(errMsg);
                }
                else
                {
                    objReturn.SuccessMsg = "Delegation set successfully";
                    return Ok(objReturn);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
