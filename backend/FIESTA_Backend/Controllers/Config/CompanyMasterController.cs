using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UtilityCore.Utility.DataAccess;

namespace FIESTA_Backend.Controllers.Config
{
    [ApiController]
    public class CompanyMasterController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        public CompanyMasterController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        // GET: api/SystemParam
        [Authorize]
        [Route("api/CompanyMaster")]
        [HttpGet]
        public List<CfgCompanyMaster> Get()
        {
            CfgCompanyMasterDAL dal = new CfgCompanyMasterDAL(_config, _httpContext);
            return  dal.GetCfgCompanyMasterList();
            //return dal.GetCfgCompanyMasterWithChildDetails();
        }

        //[Authorize]
        //[Route("api/companymaster/GetAllCompanyMasterWithDetailList")]
        //public List<CfgCompanyMaster> GetAllCompanyMasterWithDetailList()
        //{
        //    CfgCompanyMasterDAL dal = new CfgCompanyMasterDAL();
        //    return dal.GetCfgCompanyMasterWithChildDetails();//convert datarowarray to lsobjects
        //    //return dal.GetCfgCompanyMasterWithChild_Old();//copy datarowarray to datatable then convert to lsobjects
        //    //return dal.GetCfgCompanyMasterListOfObjects();/* no child, only master , convert to list of objects from datareader */
        //}

        // POST: api/SystemParam
        [Authorize]
        [HttpPost]
        [Route("api/CompanyMaster")]
        public ActionResult Post([FromBody] CfgCompanyMaster paramsObj)
        {
            return InsertRecord(paramsObj);
        }

        private ActionResult InsertRecord(CfgCompanyMaster paramsObj)
        {
            CfgCompanyMasterDAL dal = new CfgCompanyMasterDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            paramsObj.TokenObj = token.GetTokenObject();

            try
            {

                dal.SaveNewCfgCompanyMaster(paramsObj);

                objReturn.SuccessMsg = "Record Created Successfully";
                objReturn.Data = dal.SelectInsRowsWithData(paramsObj.COMPANY_CODE);

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
        [Route("api/CompanyMaster")]
        public ActionResult Put([FromBody] CfgCompanyMaster paramsObj)
        {
            CfgCompanyMasterDAL dal = new CfgCompanyMasterDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            paramsObj.TokenObj = token.GetTokenObject();

            try
            {

                int iUpdate = dal.UpdateCfgCompanyMaster(paramsObj);

                if (iUpdate == 0)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record updated : CfgCompanyMaster (id,key,value,category) : {0}{1}{2}{3},{4}"
                         , paramsObj.CFG_COMPANY_MASTER_ID, paramsObj.COMPANY_CODE, paramsObj.COMPANY_NAME, paramsObj.COMPANY_DESCRIPTION, paramsObj.ACTIVE);
                    return BadRequest(errMsg); ;
                }
                else if (iUpdate > 0)
                {
                    objReturn.SuccessMsg = "Record updated successfully";
                    objReturn.Data = dal.SelectUpdRowsWithData(paramsObj.CFG_COMPANY_MASTER_ID.ToString());
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
        [Route("api/CompanyMaster")]
        public ActionResult Delete(int id)
        {
            CfgCompanyMasterDAL dal = new CfgCompanyMasterDAL(_config, _httpContext);
            JsonReturn objReturn = new JsonReturn();

            try
            {

                bool bUpdate = dal.DeleteCfgCompanyMaster(id);

                if (!bUpdate)
                {
                    //objReturn.ErrorMsg = "No record found.";
                    string errMsg = string.Format("No record is deleted : CfgCompanyMaster (id) : {0}", id);
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
        [Route("api/CfgCompanyMaster/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {

                CfgCompanyMasterHis obj = new CfgCompanyMasterHis();
                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                obj.TokenObj = token.GetTokenObject();

                CfgCompanyMasterDAL dal = new CfgCompanyMasterDAL(_config, _httpContext);
                return Ok(DataConverter.DataTableToList<CfgCompanyMaster>(dal.GetCfgHistory(id, obj)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
