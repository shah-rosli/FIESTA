using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Formatter;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class SystemParamController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public SystemParamController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        // GET: api/SystemParam
        //[CacheFilter(TimeDuration = 1)]
        [Route("api/SystemParam")]
        [HttpGet]
        public IEnumerable<CfgSystemParam> Get()
        {
            CfgSystemParamDAL dal = new CfgSystemParamDAL(_config, _httpContext);

            return DataTableFormatter.ConvertDataTable<CfgSystemParam>(dal.GetCfgSystemParam());
        }

        [Route("api/SystemParam/GetDistinctCategory")]
        [HttpGet]
        public IEnumerable<CfgSystemParam> GetDistinctCategory(string category)
        {
            CfgSystemParamDAL dal = new CfgSystemParamDAL(_config, _httpContext);

            return DataTableFormatter.ConvertDataTable<CfgSystemParam>(dal.GetCfgSystemParamByCategory(category)).Select(x => new CfgSystemParam() {PARAM_CATEGORY = x.PARAM_CATEGORY}).DistinctBy(x => x.PARAM_CATEGORY).OrderBy(x => x.PARAM_CATEGORY);
        }

        // POST: api/SystemParam
        [Authorize]
        [Route("api/SystemParam")]
        [HttpPost]
        public ActionResult Post([FromBody] CfgSystemParam paramsObj)
        {
            JsonReturn result = InsertRecord(paramsObj);
            if (result.ErrorMsg != null)
                return BadRequest(result);
            else
                return Ok(result);
        }

        private JsonReturn InsertRecord(CfgSystemParam paramsObj)
        {
            CfgSystemParamDAL dal = new CfgSystemParamDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            paramsObj.TokenObj = token.GetTokenObject();


            try
            {

                dal.SaveNewCfgSystemParam(paramsObj);

                objReturn.SuccessMsg = "Record Created Successfully";
                objReturn.Data = DataTableFormatter.ConvertDataTable<CfgSystemParam>(dal.SelectInsRowsWithData(paramsObj.PARAM_CATEGORY, paramsObj.PARAM_KEY));

                return objReturn;

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = string.Format("{0} {1}", ex.Message, ex.StackTrace);
                return objReturn;
            }
        }

        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/SystemParam/5
        [Authorize]
        [Route("api/SystemParam")]
        [HttpPut]
        public ActionResult Put([FromBody] CfgSystemParam paramsObj)
        {
            CfgSystemParamDAL dal = new CfgSystemParamDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            paramsObj.TokenObj = token.GetTokenObject();
            try
            {

                int iUpdate = dal.UpdateCfgSystemParam(paramsObj);

                if (iUpdate == 0)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record updated : CfgSystemParam (id,key,value,category) : {0}{1}{2}{3}"
                         , paramsObj.CFG_SYSTEM_PARAM_ID, paramsObj.PARAM_KEY, paramsObj.PARAM_VALUE, paramsObj.PARAM_CATEGORY);
                    return BadRequest(errMsg); ;
                }
                else if (iUpdate > 0)
                {
                    objReturn.SuccessMsg = "Record updated successfully";
                    objReturn.Data = DataTableFormatter.ConvertDataTable<CfgSystemParam>(dal.SelectUpdRowsWithData(paramsObj.CFG_SYSTEM_PARAM_ID.ToString()));
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
        [Route("api/SystemParam/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            CfgSystemParamDAL dal = new CfgSystemParamDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            try
            {

                int iUpdate = dal.DeleteCfgSystemParam(id);

                if (iUpdate == 0)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record is deleted : CfgSystemParam (id) : {0}", id);
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
        [Route("api/CfgSysParam/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {

                CfgSystemParamHis obj = new CfgSystemParamHis();
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                obj.TokenObj = token.GetTokenObject();

                CfgSystemParamDAL dal = new CfgSystemParamDAL(_config, _httpContext);
                return Ok(DataConverter.DataTableToList<CfgSystemParamHis>(dal.GetCfgSystemParamHistory(id, obj)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
