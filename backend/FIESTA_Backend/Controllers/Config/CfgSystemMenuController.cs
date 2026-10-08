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
    public class CfgSystemMenuController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public CfgSystemMenuController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        [Authorize]
        [Route("api/CfgSystemMenu")]
        [HttpGet]
        public List<CfgSystemMenu> Get()
        {
            CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
            return dal.SelectAllRowsList();
        }


        [Authorize]
        [Route("api/CfgSystemMenu/GetCfgSystemMenu/{id}")]
        [HttpGet]
        //        [Route("api/CfgSystemMenu/GetCfgSystemMenu/{id}")]
        //    [HttpGet]
        public CfgSystemMenu Get(int id)// GetCfgSystemMenu(int id)
        {
            CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
            return dal.SelectCfgSystemMenu(id);
        }

        [Authorize]
        [Route("api/CfgSystemMenu/GetAllSystemMenuDetailList")]
        [HttpGet]
        //[Route("api/CfgSystemMenu/GetAllSystemMenuDetailList")]//pending todo : return CompanyList with currencymappinglist
        public List<CfgSystemMenu> GetWithChildDetails()// GetAllSystemMenuDetailList()
        {
            CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
            return dal.GetCfgSystemMenuWithChildDetails();
        }

        //// GET: api/SystemParam/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/SystemParam
        [Authorize]
        [Route("api/CfgSystemMenu")]
        [HttpPost]
        public ActionResult Post([FromBody] CfgSystemMenu obj)
        {
            return InsertRecord(obj);
        }

        private ActionResult InsertRecord(CfgSystemMenu obj)
        {
            CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            try
            {
                dal.SaveNewCfgSystemMenu(obj);
                objReturn.SuccessMsg = "Record Created Successfully";
                objReturn.Data = dal.SelectInsRowsWithData(obj.MENU_NAME);
                return Ok(objReturn);

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/CfgSystemMenu")]
        [HttpPut]
        public ActionResult Put([FromBody] CfgSystemMenu obj)
        {
            CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            obj.TokenObj = token.GetTokenObject();
            try
            {

                //  int iUpdate = dal.UpdateRow(Convert.ToInt32((obj.CFG_SYSTEM_MENU_ID).ToString()), obj);

                int iUpdate = dal.UpdateCfgSystemMenu(obj);

                if (iUpdate < 0)
                {
                    string errMsg = string.Format("No record updated : CfgUserGroup (id,parent id,sequence,menu_icon) : {0}{1}{2}{3}"
                         , obj.CFG_SYSTEM_MENU_ID, obj.MENU_PARENT_ID, obj.MENU_SEQUENCE, obj.MENU_ICON);

                    return BadRequest(errMsg);
                }
                else if (iUpdate > 0)
                {
                    objReturn.SuccessMsg = "Record updated successfully";
                    objReturn.Data = dal.SelectUpdRowsWithData(obj.CFG_SYSTEM_MENU_ID.ToString());
                    return Ok(objReturn);
                }
                return BadRequest("Record updated failed");
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/CfgSystemMenu")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            try
            {

                bool bUpdate = dal.DeleteCfgSystemMenu(id);
                if (!bUpdate)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record is deleted : CfgSystemMenu (id) : {0}", id);
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
        [Route("api/CfgSystemMenu/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                CfgSystemMenuHis obj = new CfgSystemMenuHis();
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                obj.TokenObj = token.GetTokenObject();

                CfgSystemMenuDAL dal = new CfgSystemMenuDAL(_config, _httpContext);
                return Ok(DataConverter.DataTableToList<CfgSystemMenuHis>(dal.GetCfgHistory(id, obj)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
