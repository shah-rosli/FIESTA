using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class CfgUserGroupController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        public CfgUserGroupController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/CfgUserGroup")]
        [HttpGet]
        public List<CfgUserGroup> Get()
        {
            CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
            return dal.ListUserGroup();
        }


        [Authorize]
        [Route("api/CfgUserGroup/GetCfgUserGroup/{id}")]
        [HttpGet]
        public CfgUserGroup Get(int id)//GetCfgUserGroup(int id)
        {
            CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
            return dal.SelectCfgUserGroupById(id);
        }

        [Authorize]
        [Route("api/CfgUserGroup/GetUserUserGroups/{userId}")]
        [HttpGet]
        public IActionResult GetUserUserGroups(string userId)
        {
            var userGroupIds = _context.CFG_USER_USER_GROUP_MAPs
                .Where(x => x.USER_ID == userId)
                .Select(x => x.CFG_USER_GROUP_ID);

            var result = _context.CFG_USER_GROUPs
                .Where(x => userGroupIds.Contains(x.CFG_USER_GROUP_ID))
                .ToList();

            return Ok(result);
        }

        //To get the CompanyCode when the usergroup is IT Superadmin or PD
        [Authorize]
        [Route("api/CfgUserGroup/GetAllowAmendPRCompany/{userId}")]
        [HttpGet]
        public string[] GetAllowAmendPRCompany(string userId)
        {
            CfgUserGroupCompanyMapDAL dal = new CfgUserGroupCompanyMapDAL(_config, _httpContext);
            return dal.SelectCompanyCodeByGroupName(userId);
        }


        [Authorize]
        [Route("api/CfgUserGroup/GetCfgUserGroupDetail")]
        [HttpGet]
        public List<CfgUserGroup> GetCfgUserGroupDetail()
        {
            CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
            return dal.GetCfgUserGroupChildDetails();
        }


        //// GET: api/SystemParam/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/SystemParam
        [Authorize]
        [Route("api/CfgUserGroup")]
        [HttpPost]
        public ActionResult Post([FromBody] CfgUserGroup obj)
        {
            return InsertRecord(obj);
        }

        private ActionResult InsertRecord(CfgUserGroup obj)
        {
            CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();

            try
            {
                dal.SaveNewCfgUserGroup(obj);
                objReturn.SuccessMsg = "Record Created Successfully";
                objReturn.Data = dal.SelectInsRowsWithData(obj.USER_GROUP_NAME);

                return Ok(objReturn);

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/CfgUserGroup")]
        [HttpPut]
        public ActionResult Put([FromBody] CfgUserGroup obj)
        {
            CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();

            try
            {

                int iUpdate = dal.UpdateCfgUserGroup(obj);// dal.UpdateRow(Convert.ToInt32((obj.CFG_USER_GROUP_ID).ToString()), obj);

                if (iUpdate == 0)
                {
                    string errMsg = string.Format("No record updated : CfgUserGroup (id,key,value,category) : {0}{1}{2}{3}"
                         , obj.CFG_USER_GROUP_ID, obj.USER_GROUP_NAME, obj.USER_GROUP_DESCRIPTION, obj.ACTIVE);
                    return BadRequest(errMsg); ;
                }
                else if (iUpdate > 0)
                {
                    objReturn.SuccessMsg = "Record updated successfully";
                    objReturn.Data = dal.SelectUpdRowsWithData(obj.CFG_USER_GROUP_ID.ToString());
                    return Ok(objReturn);
                }
                return BadRequest("Record updated failed");
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        // DELETE: api/SystemParam/5
        [Authorize]
        [Route("api/CfgUserGroup")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            try
            {

                bool bUpdate = dal.DeleteCfgUserGroup(id);
                if (!bUpdate)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record is deleted : CfgUserGroup (id) : {0}", id);
                    return BadRequest(errMsg); ;
                }
                else
                {
                    objReturn.SuccessMsg = "Record deleted successfully";
                    return Ok(objReturn);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/CfgUserGroup/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {

                CfgUserGroupHis obj = new CfgUserGroupHis();
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                obj.TokenObj = token.GetTokenObject();

                CfgUserGroupDAL dal = new CfgUserGroupDAL(_config, _httpContext);
                return Ok(DataConverter.DataTableToList<CfgUserGroupHis>(dal.GetCfgHistory(id, obj)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
