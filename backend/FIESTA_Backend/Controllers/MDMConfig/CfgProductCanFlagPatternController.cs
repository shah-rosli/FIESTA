using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using UtilityCore.Models;
using UtilityCore.Utility.BulkImport;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;
using static NPOI.HSSF.Util.HSSFColor;

namespace FIESTA_Backend.Controllers.MDMConfig
{
    public class CfgProductCanFlagPatternController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgProductCanFlagPatternController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PRODUCT_CANFLAG_PATTERNs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_CANFLAG_PATTERNs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCT_CANFLAG_PATTERN_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_PRODUCT_CANFLAG_PATTERN_HIS_ID = cfg.CFG_PRODUCT_CANFLAG_PATTERN_HIS_ID,
                                   updateDateAndTime = cfg.CFG_PRODUCT_CANFLAG_PATTERN_HIS_DATE,
                                   CFG_PRODUCT_CANFLAG_PATTERN_HIS_USERID = cfg.CFG_PRODUCT_CANFLAG_PATTERN_HIS_USERID,
                                   CFG_PRODUCT_CANFLAG_PATTERN_HIS_DELEGATE = cfg.CFG_PRODUCT_CANFLAG_PATTERN_HIS_DELEGATE,

                                   recordKey = cfg.recordKey,
                                   partNumber = cfg.partNumber,
                                   plmStatus = cfg.plmStatus,
                                   productHierarchy1 = cfg.productHierarchy1,
                                   productHierarchy2 = cfg.productHierarchy2,
                                   productHierarchy3 = cfg.productHierarchy3,
                                   productHierarchy4 = cfg.productHierarchy4,
                                   productHierarchy5 = cfg.productHierarchy5,
                                   publishedLeadTimeInWeeks = cfg.publishedLeadTimeInWeeks,
                                   isPartRegisterable = cfg.isPartRegisterable,
                                   isPartSoleSource = cfg.isPartSoleSource,
                                   canSample = cfg.canSample,
                                   canQuote = cfg.canQuote,
                                   canContract = cfg.canContract,
                                   canOrder = cfg.canOrder,
                                   canSearch = cfg.canSearch,
                                   canDebit = cfg.canDebit,
                                   canOpportunity = cfg.canOpportunity,
                                   canRegister = cfg.canRegister,
                                   canRotate = cfg.canRotate,
                                   canForecast = cfg.canForecast,
                                   canKit = cfg.canKit,
                                   isPartNotRecommendNewDesign = cfg.isPartNotRecommendNewDesign,
                                   isPartNonCancelableNonReschedule = cfg.isPartNonCancelableNonReschedule,
                                   isPartPublish = cfg.isPartPublish,
                                   canFlagMasterComments = cfg.canFlagMasterComments,
                                   autoApprThresholdFocusSales = cfg.autoApprThresholdFocusSales,
                                   autoApprThresholdNonFocusSales = cfg.autoApprThresholdNonFocusSales,
                                   autoApprThresholdFocusPL = cfg.autoApprThresholdFocusPL,
                                   autoApprThresholdNonFocusPL = cfg.autoApprThresholdNonFocusPL,
                                   sampleAutoApprQtyThreshold = cfg.sampleAutoApprQtyThreshold,
                                   sampleAutoApprTotalValThreshold = cfg.sampleAutoApprTotalValThreshold,
                                   tacticalMarketingMgr = cfg.tacticalMarketingMgr,
                                   marketingMgr = cfg.marketingMgr,
                                   applicationCode3Default = cfg.applicationCode3Default,
                                   remark = cfg.remark,
                                   deleteFlag = cfg.deleteFlag,
                                   pattern = cfg.pattern,
                                   lastUpdateBy = cfg.lastUpdateBy


                               };

                return Ok(result_2.OrderByDescending(x => x.updateDateAndTime));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] RAW_CFG_PRODUCT_CANFLAG_PATTERN cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_GROUP_STAGE>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> excelList = new List<RAW_CFG_PRODUCT_CANFLAG_PATTERN>();
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
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] RAW_CFG_PRODUCT_CANFLAG_PATTERN cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> excelList = new List<RAW_CFG_PRODUCT_CANFLAG_PATTERN>();
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
                    List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> excelList = ExcelImporter.Import<RAW_CFG_PRODUCT_CANFLAG_PATTERN>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCT_CANFLAG_PATTERN>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "partNumber", "plmStatus", "productHierarchy1", "productHierarchy2"
                    , "productHierarchy3", "productHierarchy4", "productHierarchy5", "publishedLeadTimeInWeeks", "isPartRegisterable"
                    , "isPartSoleSource", "canSample", "canQuote", "canContract", "canOrder"
                    , "canSearch", "canDebit", "canOpportunity", "canRegister", "canRotate"
                    , "canForecast", "canKit", "isPartNotRecommendNewDesign", "isPartNonCancelableNonReschedule", "isPartPublish"
                    , "canFlagMasterComments", "autoApprThresholdFocusSales", "autoApprThresholdNonFocusSales", "autoApprThresholdFocusPL", "autoApprThresholdNonFocusPL"
                    , "sampleAutoApprQtyThreshold", "sampleAutoApprTotalValThreshold", "tacticalMarketingMgr", "marketingMgr", "applicationCode3Default"
                    , "remark", "pattern", "deleteFlag", "insertOrUpdate", "haveError"
                    , "errorMessage", "haveDifference");

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCT_CANFLAG_PATTERN", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCT_CANFLAG_PATTERN", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> raws = _context.RAW_CFG_PRODUCT_CANFLAG_PATTERNs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCT_CANFLAG_PATTERN raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            partNumber = raw.partNumber,
                            plmStatus = raw.plmStatus,
                            productHierarchy1 = raw.productHierarchy1,
                            productHierarchy2 = raw.productHierarchy2,
                            productHierarchy3 = raw.productHierarchy3,
                            productHierarchy4 = raw.productHierarchy4,
                            productHierarchy5 = raw.productHierarchy5,
                            publishedLeadTimeInWeeks = raw.publishedLeadTimeInWeeks,
                            isPartRegisterable = raw.isPartRegisterable,
                            isPartSoleSource = raw.isPartSoleSource,
                            canSample = raw.canSample,
                            canQuote = raw.canQuote,
                            canContract = raw.canContract,
                            canOrder = raw.canOrder,
                            canSearch = raw.canSearch,
                            canDebit = raw.canDebit,
                            canOpportunity = raw.canOpportunity,
                            canRegister = raw.canRegister,
                            canRotate = raw.canRotate,
                            canForecast = raw.canForecast,
                            canKit = raw.canKit,
                            isPartNotRecommendNewDesign = raw.isPartNotRecommendNewDesign,
                            isPartNonCancelableNonReschedule = raw.isPartNonCancelableNonReschedule,
                            isPartPublish = raw.isPartPublish,
                            canFlagMasterComments = raw.canFlagMasterComments,
                            autoApprThresholdFocusSales = raw.autoApprThresholdFocusSales,
                            autoApprThresholdNonFocusSales = raw.autoApprThresholdNonFocusSales,
                            autoApprThresholdFocusPL = raw.autoApprThresholdFocusPL,
                            autoApprThresholdNonFocusPL = raw.autoApprThresholdNonFocusPL,
                            sampleAutoApprQtyThreshold = raw.sampleAutoApprQtyThreshold,
                            sampleAutoApprTotalValThreshold = raw.sampleAutoApprTotalValThreshold,
                            tacticalMarketingMgr = raw.tacticalMarketingMgr,
                            marketingMgr = raw.marketingMgr,
                            applicationCode3Default = raw.applicationCode3Default,
                            remark = raw.remark,
                            pattern = raw.pattern,


                            updateDateAndTime = raw.createdDate,
                            lastUpdateBy = raw.createdBy,
                            deleteFlag = raw.deleteFlag
                        },
                        errorMessage = raw.errorMessage,
                        haveDifference = raw.haveDifference.HasValue ? raw.haveDifference.Value == 1 : false,
                        haveError = raw.haveError.HasValue ? raw.haveError.Value == 1 : false,
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
            List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> master = new List<RAW_CFG_PRODUCT_CANFLAG_PATTERN>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCT_CANFLAG_PATTERN> raws = _context.RAW_CFG_PRODUCT_CANFLAG_PATTERNs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCT_CANFLAG_PATTERN raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        partNumber = raw.partNumber,
                        plmStatus = raw.plmStatus,
                        productHierarchy1 = raw.productHierarchy1,
                        productHierarchy2 = raw.productHierarchy2,
                        productHierarchy3 = raw.productHierarchy3,
                        productHierarchy4 = raw.productHierarchy4,
                        productHierarchy5 = raw.productHierarchy5,
                        publishedLeadTimeInWeeks = raw.publishedLeadTimeInWeeks,
                        isPartRegisterable = raw.isPartRegisterable,
                        isPartSoleSource = raw.isPartSoleSource,
                        canSample = raw.canSample,
                        canQuote = raw.canQuote,
                        canContract = raw.canContract,
                        canOrder = raw.canOrder,
                        canSearch = raw.canSearch,
                        canDebit = raw.canDebit,
                        canOpportunity = raw.canOpportunity,
                        canRegister = raw.canRegister,
                        canRotate = raw.canRotate,
                        canForecast = raw.canForecast,
                        canKit = raw.canKit,
                        isPartNotRecommendNewDesign = raw.isPartNotRecommendNewDesign,
                        isPartNonCancelableNonReschedule = raw.isPartNonCancelableNonReschedule,
                        isPartPublish = raw.isPartPublish,
                        canFlagMasterComments = raw.canFlagMasterComments,
                        autoApprThresholdFocusSales = raw.autoApprThresholdFocusSales,
                        autoApprThresholdNonFocusSales = raw.autoApprThresholdNonFocusSales,
                        autoApprThresholdFocusPL = raw.autoApprThresholdFocusPL,
                        autoApprThresholdNonFocusPL = raw.autoApprThresholdNonFocusPL,
                        sampleAutoApprQtyThreshold = raw.sampleAutoApprQtyThreshold,
                        sampleAutoApprTotalValThreshold = raw.sampleAutoApprTotalValThreshold,
                        tacticalMarketingMgr = raw.tacticalMarketingMgr,
                        marketingMgr = raw.marketingMgr,
                        applicationCode3Default = raw.applicationCode3Default,
                        remark = raw.remark,
                        pattern = raw.pattern,


                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy,
                        deleteFlag = raw.deleteFlag
                    },
                    errorMessage = raw.errorMessage,
                    haveDifference = raw.haveDifference.HasValue ? raw.haveDifference.Value == 1 : false,
                    haveError = raw.haveError.HasValue ? raw.haveError.Value == 1 : false,
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCT_CANFLAG_PATTERN", token.USER_ID);
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

        [Authorize]
        [Route("api/[controller]/GetProductHierarchy123")]
        [HttpGet]
        public IActionResult GetProductHierarchy12345()
        {
            try
            {
                var levels = new[] { "1", "2", "3" };

                var phList = _context.V_MDM_PRODUCT_HIERARCHies
                .Where(x => x.deleteFlag != "Y"
                    && levels.Contains(x.level)
                )
                .Select(x => new
                {
                    x.phCode,
                    x.phDescription,
                    x.level
                })
                .AsEnumerable()
                .Select(x => new
                {
                    display = x.phCode + " : " + x.phDescription,
                    phCode = x.phCode,
                    phDescription = x.phDescription,
                    level = x.level
                })
                .Distinct()
                .OrderBy(x => x.level)
                .ThenBy(x => x.phCode)
                .ToList();


                if (phList == null || phList.Count == 0)
                    return NotFound();

                return Ok(phList);
            }
            catch (Exception ex)
            {
                string xx = ex.Message;
                string xx2 = ex.Message;
                return NotFound();
            }
        }

        [Authorize]
        [Route("api/[controller]/GetProductHierarchyLive")]
        [HttpGet]
        public IActionResult GetProductHierarchyLive(string level = "", string search = "")
        {
            try
            {
                IQueryable<V_MDM_PRODUCT_HIERARCHY> query = _context.V_MDM_PRODUCT_HIERARCHies
                    .Where(x => x.deleteFlag != "Y" && x.level == level);

                var source = query
                    .Select(x => new
                    {
                        x.phCode,
                        x.phDescription,
                        x.level
                    })
                    .AsEnumerable(); // Everything below runs in C#, not Oracle

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.Trim();

                    source = source.Where(x =>
                        (x.phCode ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        (x.phDescription ?? "").Contains(search, StringComparison.OrdinalIgnoreCase)
                    );
                }

                var result = source
                    .Select(x => new
                    {
                        display = $"{x.phCode} : {x.phDescription}",
                        phCode = x.phCode,
                        phDescription = x.phDescription,
                        level = x.level
                    })
                    .DistinctBy(x => new { x.phCode, x.phDescription, x.level })
                    .OrderBy(x => x.display)
                    .Take(300)
                    .ToList();

                return Ok(result);

                ///////////////////////////////////////////////////

                //var phList = _context.V_MDM_PRODUCT_HIERARCHies
                //.Where(x => x.deleteFlag != "Y"
                //    && x.level == level
                //    && x.phCode.Contains(search)
                //)
                //.Select(x => new
                //{
                //    x.phCode,
                //    x.phDescription,
                //    x.level
                //})
                //.AsEnumerable();

                
                //var phList2 = phList.Select(x => new
                //{
                //    display = x.phCode + " : " + x.phDescription,
                //    phCode = x.phCode,
                //    phDescription = x.phDescription,
                //    level = x.level
                //})
                //.Distinct()
                //.OrderBy(x => x.level)
                //.ThenBy(x => x.phCode)
                //.Take(300)
                //.ToList();


                //if (phList2 == null || phList2.Count == 0)
                //    return NotFound();

                //return Ok(phList2);
            }
            catch (Exception ex)
            {
                string xx = ex.Message;
                string xx2 = ex.Message;
                return NotFound();
            }


        }

        [Authorize]
        [Route("api/[controller]/SearchPartNumber")]
        [HttpGet]
        public IActionResult SearchPartNumber(string search = "")
        {
            IQueryable<OUT_PRODUCT_CONSOLIDATE> query = _context.OUT_PRODUCT_CONSOLIDATEs.Where(x => 
                x.deleteFlag != "Y" 
                && new[] { "ZFER", "ZSER", "ZHAW" }.Contains(x.materialType)
            );

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                query = query.Where(x => x.partNumber.Contains(search));
            }

            var result = query
                .Select(x => new
                {
                    x.partNumber
                })
                .Distinct()
                .OrderBy(x => x.partNumber)
                .Take(300)
                .ToList();

            return Ok(result);

        }

        [Authorize]
        [Route("api/[controller]/GetApplicationLevel3Code")]
        [HttpGet]
        public IActionResult GetApplicationLevel2Code()
        {
            var mdmList = _context.V_CFG_APP_APPLICATION3s.Where(x => x.deleteFlag != "Y")
                .GroupBy(x => new { x.applicationLevel3Code }).Select(x => x.First()).ToList();
            if (mdmList == null || mdmList.Count() == 0)
                return NotFound();
            return Ok(mdmList.Select(x => new {
                applicationLevel3Code = x.applicationLevel3Code
            }));
        }
    }
}
