using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class SystemLanguageController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public SystemLanguageController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }
        
        [Authorize]
        [Route("api/SystemLanguage")]
        [HttpGet]
        public List<CfgSystemLanguage> Get()
        {
            CfgSystemLanguageDAL dal = new CfgSystemLanguageDAL(_config, _httpContext);
            return dal.GetCfgSystemLanguage();
        }

        // POST: api/SystemParam
        [Authorize]
        [Route("api/SystemLanguage")]
        [HttpPost]
        public ActionResult Post([FromBody] CfgSystemLanguage paramsObj)
        {
            return InsertRecord(paramsObj);
        }

        private ActionResult InsertRecord(CfgSystemLanguage paramsObj)
        {
            CfgSystemLanguageDAL dal = new CfgSystemLanguageDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            paramsObj.TokenObj = token.GetTokenObject();

            try
            {

                dal.SaveNewCfgSystemLanguage(paramsObj);

                objReturn.SuccessMsg = "Record Created Successfully";
                objReturn.Data = dal.SelectInsRowsWithData(paramsObj.LABEL_NAME);


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

        // PUT: api/SystemParam/5
        [Authorize]
        [HttpPut]
        [Route("api/SystemLanguage")]
        public ActionResult Put([FromBody] CfgSystemLanguage paramsObj)
        {
            CfgSystemLanguageDAL dal = new CfgSystemLanguageDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            paramsObj.TokenObj = token.GetTokenObject();

            try
            {

                int iUpdate = dal.UpdateCfgSystemLanguage(paramsObj);

                if (iUpdate == 0)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record updated : CfgSystemLanguage (id,key,value,category) : {0}{1}{2}{3},{4}"
                         , paramsObj.CFG_SYSTEM_LANGUAGE_ID, paramsObj.LABEL_NAME, paramsObj.EN, paramsObj.JA, paramsObj.ZH);
                    return BadRequest(errMsg); ;
                }
                else if (iUpdate > 0)
                {
                    objReturn.SuccessMsg = "Record updated successfully";
                    objReturn.Data = dal.SelectUpdRowsWithData(paramsObj.CFG_SYSTEM_LANGUAGE_ID.ToString());
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
        [HttpDelete]
        [Route("api/SystemLanguage")]
        public ActionResult Delete(int id)
        {
            CfgSystemLanguageDAL dal = new CfgSystemLanguageDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            try
            {

                int iUpdate = dal.DeleteCfgSystemLanguage(id);

                if (iUpdate == 0)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record is deleted : CfgSystemLanguage (id) : {0}", id);
                    return BadRequest(errMsg); ;
                }
                else if (iUpdate > 0)
                {
                    objReturn.SuccessMsg = "Record deleted successfully";
                    return Ok(objReturn);
                }
                return BadRequest("failed to delete selected record.");
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }


        [Authorize]
        [HttpGet]
        [Route("api/CfgSysLanguage/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {

                CfgSystemLanguageHis obj = new CfgSystemLanguageHis();
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                obj.TokenObj = token.GetTokenObject();

                CfgSystemLanguageDAL dal = new CfgSystemLanguageDAL(_config, _httpContext);
                return Ok(DataConverter.DataTableToList<CfgSystemLanguage>(dal.GetCfgHistory(id, obj)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
