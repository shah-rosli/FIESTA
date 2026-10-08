using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Claims;
using UtilityCore.Models;
using UtilityCore.Utility.BulkImport;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;
namespace FIESTA_Backend.Controllers.Config
{
    public class CfgProductionCostingYieldByGsController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgProductionCostingYieldByGsController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
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
                return Ok(_context.V_CFG_PRODUCTION_COSTING_YIELD_BY_Gs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCTION_COSTING_YIELD_BY_Gs, loadOptions));
            }

        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCTION_YIELD_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_PRODUCTION_YIELD_HIS_ID = cfg.CFG_PRODUCTION_YIELD_HIS_ID,
                                   updateDateAndTime = cfg.CFG_PRODUCTION_YIELD_HIS_DATE,
                                   CFG_PRODUCTION_YIELD_HIS_USERID = cfg.CFG_PRODUCTION_YIELD_HIS_USERID,
                                   CFG_PRODUCTION_YIELD_HIS_DELEGATE = cfg.CFG_PRODUCTION_YIELD_HIS_DELEGATE,
                                   recordKey = cfg.recordKey,
                                   partNumber = cfg.partNumber,
                                   plant = cfg.plant,
                                   storageLocation = cfg.storageLocation,
                                   glmStage = cfg.glmStage,
                                   yield = cfg.yield,
                                   validFromDate = cfg.validFromDate,
                                   deleteFlag = cfg.deleteFlag,
                                   yieldFlag = cfg.yieldFlag,
                                   groupStage = cfg.groupStage,
                                   lastUpdateBy = cfg.lastUpdateBy
                               };

                return Ok(result_2.OrderByDescending(x => x.updateDateAndTime));

                //var result_join = result.GroupJoin(_context.CFG_USERs,
                //                cfg => cfg.CFG_PRODUCTION_YIELD_HIS_USERID,
                //                usr => usr.USER_ID,
                //                (cfg, usr) => new
                //                {
                //                    CFG_PRODUCTION_YIELD_HIS_ID = cfg.CFG_PRODUCTION_YIELD_HIS_ID,
                //                    updateDateAndTime = cfg.CFG_PRODUCTION_YIELD_HIS_DATE,
                //                    CFG_PRODUCTION_YIELD_HIS_USERID = cfg.CFG_PRODUCTION_YIELD_HIS_USERID,
                //                    CFG_PRODUCTION_YIELD_HIS_DELEGATE = cfg.CFG_PRODUCTION_YIELD_HIS_DELEGATE,
                //                    recordKey = cfg.recordKey,
                //                    partNumber = cfg.partNumber,
                //                    plant = cfg.plant,
                //                    storageLocation = cfg.storageLocation,
                //                    glmStage = cfg.glmStage,
                //                    yield = cfg.yield,
                //                    validFromDate = cfg.validFromDate,
                //                    deleteFlag = cfg.deleteFlag,
                //                    yieldFlag = cfg.yieldFlag,
                //                    groupStage = cfg.groupStage,
                //                    lastUpdateBy = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_FULL_NAME + " <" + usr.FirstOrDefault().USER_EMAIL + ">" : "SYSTEM"
                //                }).OrderByDescending(x => x.updateDateAndTime);

                //return Ok(result_join);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromForm] string values)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_YIELD>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCTION_YIELD> excelList = new List<RAW_CFG_PRODUCTION_YIELD>();
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
        public IActionResult Put([FromForm] string values)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_YIELD>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCTION_YIELD> excelList = new List<RAW_CFG_PRODUCTION_YIELD>();
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
                    List<RAW_CFG_PRODUCTION_YIELD> excelList = ExcelImporter.Import<RAW_CFG_PRODUCTION_YIELD>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCTION_YIELD> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();
            List<RAW_CFG_PRODUCTION_YIELD> excelListExpanded = new List<RAW_CFG_PRODUCTION_YIELD>();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                foreach (RAW_CFG_PRODUCTION_YIELD raw in excelList)
                {
                    List<string> glmStages = raw.glmStage.Split(",").ToList<string>();

                    double val = Convert.ToDouble(raw.yield);
                    double exp = Convert.ToDouble(1 / Convert.ToDouble(glmStages.Count()));
                    double result = Math.Pow(val, exp);
                    decimal? avgYield = Math.Round(Convert.ToDecimal(result),4);

                    foreach (string stage in glmStages)
                    {
                        RAW_CFG_PRODUCTION_YIELD r = new RAW_CFG_PRODUCTION_YIELD()
                        {
                            recordKey = raw.recordKey,
                            createdBy = raw.createdBy,
                            createdDate = raw.createdDate,
                            deleteFlag = raw.deleteFlag,
                            errorMessage = raw.errorMessage,
                            groupStage = raw.groupStage,
                            haveDifference = raw.haveDifference,
                            partNumber = raw.partNumber,
                            plant = raw.plant,
                            storageLocation = raw.storageLocation,
                            yieldFlag = "C",
                            validFromDateStr = raw.validFromDate.HasValue ? raw.validFromDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                            haveError = raw.haveError,
                            insertOrUpdate = raw.insertOrUpdate
                        };
                        r.glmStage = stage;
                        r.yield = avgYield;
                        excelListExpanded.Add(r);
                    }
                }

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCTION_YIELD>(excelListExpanded, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "partNumber", "plant", "storageLocation", "groupStage", "glmStage", "yieldFlag", "yield", "validFromDateStr", "deleteFlag", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCTION_YIELD", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCTION_YIELD", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCTION_YIELD> raws = _context.RAW_CFG_PRODUCTION_YIELDs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCTION_YIELD raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            partNumber = raw.partNumber,
                            plant = raw.plant,
                            storageLocation = raw.storageLocation,
                            groupStage = raw.groupStage,
                            glmStage = raw.glmStage,
                            yieldFlag = raw.yieldFlag,
                            yield = raw.yield,
                            validFromDate = raw.validFromDateStr,
                            updateDateAndTime = raw.createdDate,
                            lastUpdateBy = raw.createdBy,
                            deleteFlag = raw.deleteFlag
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
            List<RAW_CFG_PRODUCTION_YIELD> master = new List<RAW_CFG_PRODUCTION_YIELD>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCTION_YIELD> raws = _context.RAW_CFG_PRODUCTION_YIELDs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCTION_YIELD raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        partNumber = raw.partNumber,
                        plant = raw.plant,
                        storageLocation = raw.storageLocation,
                        groupStage = raw.groupStage,
                        glmStage = raw.glmStage,
                        yieldFlag = raw.yieldFlag,
                        yield = raw.yield,
                        validFromDate = raw.validFromDateStr,
                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy,
                        deleteFlag = raw.deleteFlag
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

            //if there is actually records to update, and no error
            if (validateResult.Count > 0 && validateResult.Count(x => x.haveError) == 0 && validateResult.Count(x => x.haveDifference) > 0)
            {
                bool allowContinue = false;

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCTION_YIELD", token.USER_ID);
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
