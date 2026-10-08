using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Wordprocessing;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using UtilityCore.Models;
using UtilityCore.Utility.BulkImport;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgComponentsController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgComponentsController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_CFG_COMPONENTs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_COMPONENTs, loadOptions));
            }

        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_COMPONENTS_HIs.Where(x => x.recordKey == id).ToList();
                var result_2 = from cfg in result
                               select new
                                {
                                    CFG_COMPONENTS_HIS_ID = cfg.CFG_COMPONENTS_HIS_ID,
                                    updateDateAndTime = cfg.CFG_COMPONENTS_HIS_DATE,
                                    CFG_COMPONENTS_HIS_USERID = cfg.CFG_COMPONENTS_HIS_USERID,
                                    CFG_COMPONENTS_HIS_DELEGATE = cfg.CFG_COMPONENTS_HIS_DELEGATE,
                                    recordKey = cfg.recordKey,
                                    partNumber = cfg.partNumber,
                                    legacyOrganization = cfg.legacyOrganization,
                                    groupStage = cfg.groupStage,
                                    flowNumber = cfg.flowNumber,
                                    componentPartNumber = cfg.componentPartNumber,
                                    componentLeadTime = cfg.componentLeadTime,
                                    componentConsumption = cfg.componentConsumption,
                                    deleteFlag = cfg.deleteFlag,
                                    lastUpdateBy = cfg.lastUpdateBy,
                                    componentMaterialType = cfg.componentMaterialType,
                                    flowDescription = cfg.flowDescription,
                                    lineName = cfg.lineName,
                                    componentPartType = cfg.componentPartType,
                                    componentSubType = cfg.componentSubType,
                                    componentStandardUsage = cfg.componentStandardUsage,
                                    componentUOM = cfg.componentUOM,
                               };

                return Ok(result_2.OrderByDescending(x => x.updateDateAndTime));
                //var result = _context.CFG_COMPONENTS_HIs.Where(x => x.recordKey == id).ToList();
                //var result_join = result.GroupJoin(_context.CFG_USERs,
                //                cfg => cfg.CFG_COMPONENTS_HIS_USERID,
                //                usr => usr.USER_ID,
                //                (cfg, usr) => new
                //                {
                //                    CFG_COMPONENTS_HIS_ID = cfg.CFG_COMPONENTS_HIS_ID,
                //                    updateDateAndTime = cfg.CFG_COMPONENTS_HIS_DATE,
                //                    CFG_COMPONENTS_HIS_USERID = cfg.CFG_COMPONENTS_HIS_USERID,
                //                    CFG_COMPONENTS_HIS_DELEGATE = cfg.CFG_COMPONENTS_HIS_DELEGATE,
                //                    recordKey = cfg.recordKey,
                //                    partNumber = cfg.partNumber,
                //                    groupStage = cfg.groupStage,
                //                    flowNumber = cfg.flowNumber,
                //                    componentPartNumber = cfg.componentPartNumber,
                //                    componentLeadTime = cfg.componentLeadTime,
                //                    componentConsumption = cfg.componentConsumption,
                //                    deleteFlag = cfg.deleteFlag,
                //                    lastUpdateBy = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_FULL_NAME + " <" + usr.FirstOrDefault().USER_EMAIL + ">" : "SYSTEM"
                //                }).Where(x => x.deleteFlag == "N").OrderByDescending(x => x.updateDateAndTime);

                //join with v_cfg_components
                //var result_join_2 = from t1 in result_join
                //                    join t2 in _context.V_CFG_COMPONENTs
                //                    on new { a = t1.partNumber, t1.flowNumber, t1.componentPartNumber } equals new { a = t2.partNumber, t2.flowNumber, t2.componentPartNumber }
                //                    select new
                //                    {
                //                        CFG_COMPONENTS_HIS_ID = t1.CFG_COMPONENTS_HIS_ID,
                //                        updateDateAndTime = t1.updateDateAndTime,
                //                        CFG_COMPONENTS_HIS_USERID = t1.CFG_COMPONENTS_HIS_USERID,
                //                        CFG_COMPONENTS_HIS_DELEGATE = t1.CFG_COMPONENTS_HIS_DELEGATE,
                //                        recordKey = t1.recordKey,
                //                        partNumber = t1.partNumber,
                //                        legacyOrganization = t2.legacyOrganization,
                //                        groupStage = t1.groupStage,
                //                        flowNumber = t1.flowNumber,
                //                        componentPartNumber = t1.componentPartNumber,
                //                        componentLeadTime = t1.componentLeadTime,
                //                        componentConsumption = t1.componentConsumption,
                //                        deleteFlag = t1.deleteFlag,
                //                        lastUpdateBy = t1.lastUpdateBy,
                //                        componentMaterialType = t2.componentMaterialType,
                //                        flowDescription = t2.flowDescription,
                //                        lineName = t2.lineName,
                //                        componentPartType = t2.componentPartType,
                //                        componentSubType = t2.componentSubType,
                //                        componentStandardUsage = t2.componentStandardUsage,
                //                        componentUOM = t2.componentUOM,
                //                    };

                //var result_join_2 = from t1 in result_join
                //                    select new
                //                    {
                //                        CFG_COMPONENTS_HIS_ID = t1.CFG_COMPONENTS_HIS_ID,
                //                        updateDateAndTime = t1.updateDateAndTime,
                //                        CFG_COMPONENTS_HIS_USERID = t1.CFG_COMPONENTS_HIS_USERID,
                //                        CFG_COMPONENTS_HIS_DELEGATE = t1.CFG_COMPONENTS_HIS_DELEGATE,
                //                        recordKey = t1.recordKey,
                //                        partNumber = t1.partNumber,
                //                        legacyOrganization = "",
                //                        groupStage = t1.groupStage,
                //                        flowNumber = t1.flowNumber,
                //                        componentPartNumber = t1.componentPartNumber,
                //                        componentLeadTime = t1.componentLeadTime,
                //                        componentConsumption = t1.componentConsumption,
                //                        deleteFlag = t1.deleteFlag,
                //                        lastUpdateBy = t1.lastUpdateBy,
                //                        componentMaterialType = "",
                //                        flowDescription = "",
                //                        lineName = "",
                //                        componentPartType = "",
                //                        componentSubType = "",
                //                        componentStandardUsage = "",
                //                        componentUOM = "",
                //                    };

                //return Ok(result_join_2);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] RAW_CFG_COMPONENT cfg)
        {
            return BadRequest("Insert not allowed!");

            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_COMPONENT>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_COMPONENT> excelList = new List<RAW_CFG_COMPONENT>();
                excelList.Add(cfg);
                req = Validate(excelList, token);

                //if no error validate, performUpload
                if (req != null && string.IsNullOrEmpty(req.ErrorMsg))
                {
                    //performUpload
                    req = Perform(token);

                    if (req != null && string.IsNullOrEmpty(req.ErrorMsg))
                    {
                        return Ok(req);
                    }
                    else
                    {
                        return BadRequest(req);
                    }
                }
                else
                {
                    return BadRequest(req);
                }
            }
            catch (Exception ex)
            {
                req.ErrorMsg = ex.Message + "\n" + ex.InnerException;
                return BadRequest(req);
            }
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] RAW_CFG_COMPONENT cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_COMPONENT>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_COMPONENT> excelList = new List<RAW_CFG_COMPONENT>();
                excelList.Add(cfg);
                req = Validate(excelList, token);

                //move out Data information to successMsg or errorMessage
                if (req != null && req.Data != null)
                {
                    List<CfgBulkImport> data = new List<CfgBulkImport>((IEnumerable<CfgBulkImport>)req.Data);
                    CfgBulkImport? first = data.FirstOrDefault();

                    if (first.haveError)
                    {
                        req.ErrorMsg = first.errorMessage;
                        req.WarningMsg = first.errorMessage;
                        req.SuccessMsg = null;

                        req.Data = first.bulkImportObj;
                    }
                    else
                    {
                        req.SuccessMsg = "Record Updated Successfully";
                    }
                }

                //if no error validate, performUpload
                if (req != null && string.IsNullOrEmpty(req.ErrorMsg))
                {
                    //performUpload
                    req = Perform(token);

                    if (req != null && string.IsNullOrEmpty(req.ErrorMsg))
                    {
                        return Ok(req);
                    }
                    else
                    {
                        return BadRequest(req);
                    }
                }
                else
                {
                    return BadRequest(req);
                }

            }
            catch (Exception ex)
            {
                req.ErrorMsg = ex.Message + "\n" + ex.InnerException;
                return BadRequest(req);
            }
        }

        [Authorize]
        [Route("api/[controller]/ValidateUpload")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public IActionResult ValidateUpload(IFormFile upload)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();
            try
            {
                if (ModelState.IsValid && upload != null && upload.Length > 0)
                {
                    // load product requests from excel file
                    List<RAW_CFG_COMPONENT> excelList = ExcelImporter.Import<RAW_CFG_COMPONENT>(upload.OpenReadStream());

                    req = Validate(excelList, token);

                    if (req != null && string.IsNullOrEmpty(req.ErrorMsg))
                    {
                        return Ok(req);
                    }
                    else
                    {
                        return BadRequest(req);
                    }
                }
                else
                {
                    req.ErrorMsg = "Invalid file provided!";
                    return BadRequest(req);
                }
            }
            catch (Exception ex)
            {
                req.ErrorMsg = ex.Message + "\n" + ex.InnerException;
                return BadRequest(req);
            }

        }

        [Authorize]
        [Route("api/[controller]/PerformUpload")]
        [HttpPost]
        public IActionResult PerformUpload()
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = Perform(token);
            if (req != null && string.IsNullOrEmpty(req.ErrorMsg))
            {
                return Ok(req);
            }
            else
            {
                return BadRequest(req);
            }
        }

        private JsonReturn Validate(List<RAW_CFG_COMPONENT> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_COMPONENT>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "partNumber", "groupStage", "flowNumber", "componentPartNumber", "componentMaterialType", "componentLeadTime", "componentConsumption", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");
                dtForBulkInsert.TableName = "RAW_CFG_COMPONENTS";
                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_COMPONENTS", token.USER_ID);
                allowContinue = dbStatus.isSuccessful;

                //bulk import
                if (allowContinue)
                {
                    req.SuccessMsg += dbStatus.message + "\n";
                    //bulk import to raw table using data table
                    dbStatus = biOperation.BulkCopyToStagingTable(dtForBulkInsert);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }
                //validation
                if (allowContinue)
                {
                    req.SuccessMsg += dbStatus.message + "\n";
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_COMPONENTS", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_COMPONENT> raws = _context.RAW_CFG_COMPONENTs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_COMPONENT raw in raws)
                {
                    V_CFG_COMPONENT? view = _context.V_CFG_COMPONENTs.FirstOrDefault(x => x.partNumber == raw.partNumber && x.flowNumber == raw.flowNumber && x.componentPartNumber == raw.componentPartNumber);

                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            partNumber = raw.partNumber,
                            legacyOrganization = view?.legacyOrganization,
                            componentMaterialType = raw.componentMaterialType,
                            groupStage = raw.groupStage,
                            flowNumber = raw.flowNumber,
                            flowDescription = view?.flowDescription,
                            lineName = view?.lineName,
                            componentPartNumber = raw.componentPartNumber,
                            componentPartType = view?.componentPartType,
                            componentSubType = view?.componentSubType,
                            componentStandardUsage = view?.componentStandardUsage,
                            componentUOM = view?.componentUOM,
                            componentLeadTime = raw.componentLeadTime,
                            componentConsumption = raw.componentConsumption,
                            updateDateAndTime = raw.createdDate,
                            lastUpdateBy = raw.createdBy//,
                            //deleteFlag = raw.deleteFlag
                        },
                        errorMessage = raw.errorMessage,
                        haveDifference = raw.haveDifference.HasValue ? raw.haveDifference.Value : false,
                        haveError = raw.haveError.HasValue ? raw.haveError.Value : false,
                        insertOrUpdate = raw.insertOrUpdate,
                        selected = true
                    });
                }

                req.SuccessMsg = "Excel Data Validated.";
                req.Data = validateResult.OrderBy(x => x.haveError);

                return req;
            }
            catch (Exception ex)
            {
                req.ErrorMsg = ex.Message + "\n" + ex.InnerException;
                return req;
            }
        }

        private JsonReturn Perform(TokenProperties token)
        {
            List<RAW_CFG_COMPONENT> master = new List<RAW_CFG_COMPONENT>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_COMPONENT> raws = _context.RAW_CFG_COMPONENTs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_COMPONENT raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        partNumber = raw.partNumber,
                        groupStage = raw.groupStage,
                        flowNumber = raw.flowNumber,
                        componentPartNumber = raw.componentPartNumber,
                        componentLeadTime = raw.componentLeadTime,
                        componentConsumption = raw.componentConsumption,
                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy//,
                        //deleteFlag = raw.deleteFlag
                    },
                    errorMessage = raw.errorMessage,
                    haveDifference = raw.haveDifference.HasValue ? raw.haveDifference.Value : false,
                    haveError = raw.haveError.HasValue ? raw.haveError.Value : false,
                    insertOrUpdate = raw.insertOrUpdate,
                    selected = true
                });
            }

            JsonReturn req = new JsonReturn()
            {
                Data = validateResult
            };

            //if there is actually records to update, and allow error proceeed (2025-07-20)
            if (validateResult.Count > 0 && validateResult.Count(x => x.haveDifference) > 0)
            {
                bool allowContinue = false;

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_COMPONENTS", token.USER_ID);
                allowContinue = dbStatus.isSuccessful;


                if (allowContinue)
                {
                    req.SuccessMsg = "Successfully updated all records.";
                    return req;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                    return req;
                }
            }

            req.WarningMsg = "No Record valid for insert / update!";
            req.InfoMsg = "No Record valid for insert / update!";
            return req;
        }
    }
}
