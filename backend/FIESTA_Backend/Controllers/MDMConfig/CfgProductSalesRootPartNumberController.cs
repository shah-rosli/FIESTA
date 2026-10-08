using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Spreadsheet;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Security.Claims;
using UtilityCore.Models;
using UtilityCore.Utility.BulkImport;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;
using static NPOI.HSSF.Util.HSSFColor;

namespace FIESTA_Backend.Controllers.MDMConfig
{
    public class CfgProductSalesRootPartNumberController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgProductSalesRootPartNumberController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {

                                    CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_ID = cfg.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_ID,
                                    updateDateAndTime = cfg.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_DATE,
                                    CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_USERID = cfg.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_USERID,
                                    CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_DELEGATE = cfg.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_DELEGATE,
                                    
                                    recordKey = cfg.recordKey,
                                    partNumberKey = cfg.partNumberKey,
                                    partNumber = cfg.partNumber,
                                    partDescription = cfg.partDescription,
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
                                    isPartNonCancelableNonReschedule = cfg.isPartNonCancelableNonReschedule,
                                    isPartNotRecommendNewDesign = cfg.isPartNotRecommendNewDesign,
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
                                    productHierarchyCode = cfg.productHierarchyCode,
                                    productHierarchy3Code = cfg.productHierarchy3Code,
                                    productHierarchy3 = cfg.productHierarchy3,
                                    productHierarchy2 = cfg.productHierarchy2,
                                    productHierarchy1 = cfg.productHierarchy1,
                                    companyOfOrigin = cfg.companyOfOrigin,
                                    materialType = cfg.materialType,
                                    isSalesRoot = cfg.isSalesRoot,
                                    goldenRecord = cfg.goldenRecord,
                                    minimumOrderQuantity = cfg.minimumOrderQuantity,
                                    frequencyOrderIncrement = cfg.frequencyOrderIncrement,

                                    deleteFlag = cfg.deleteFlag,
                                    lastUpdateBy = cfg.lastUpdateBy,
                                    reviewBy = cfg.reviewBy,
                                    reviewDateAndTime = cfg.reviewDateAndTime,
                                    reviewStatus = cfg.reviewStatus,
                                    processStatus = cfg.processStatus,
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
        public IActionResult Post([FromBody] RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> excelList = new List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>();
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
        public IActionResult Put([FromBody] RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> excelList = new List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>();
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
                    List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> excelList = ExcelImporter.Import<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                //DataTable dtForBulkInsert = dt.DefaultView.ToTable(false,
                //    "createdBy",
                //    "partNumberKey",
                //    "partNumber",
                //    "partDescription",
                //    "publishedLeadTimeInWeeks",
                //    "isPartRegisterable",
                //    "isPartSoleSource",
                //    "canSample",
                //    "canQuote",
                //    "canContract",
                //    "canOrder",
                //    "canSearch",
                //    "canDebit",
                //    "canOpportunity",
                //    "canRegister",
                //    "canRotate",
                //    "canForecast",
                //    "canKit",
                //    "isPartNonCancelableNonReschedule",
                //    "isPartNotRecommendNewDesign",
                //    "isPartPublish",
                //    "canFlagMasterComments",
                //    "autoApprThresholdFocusSales",
                //    "autoApprThresholdNonFocusSales",
                //    "autoApprThresholdFocusPL",
                //    "autoApprThresholdNonFocusPL",
                //    "sampleAutoApprQtyThreshold",
                //    "sampleAutoApprTotalValThreshold",
                //    "tacticalMarketingMgr",
                //    "marketingMgr",
                //    "applicationCode3Default",
                //    "productHierarchyCode",
                //    "productHierarchy3Code",
                //    "productHierarchy3",
                //    "productHierarchy2",
                //    "productHierarchy1",
                //    "companyOfOrigin",
                //    "materialType",
                //    "isSalesRoot",
                //    "goldenRecord",
                //    "minimumOrderQuantity",
                //    "frequencyOrderIncrement",
                //    "deleteFlag",
                //    "insertOrUpdate",
                //    "haveError",
                //    "errorMessage",
                //    "haveDifference"
                //);
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false,
                    "createdBy",
                    "partNumberKey",
                    "partNumber",
                    "isPartSoleSource",
                    "productHierarchy3Code",
                    "companyOfOrigin",
                    "deleteFlag",
                    "insertOrUpdate",
                    "haveError",
                    "errorMessage",
                    "haveDifference"
                );



                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> raws = _context.RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            partNumberKey = raw.partNumberKey,
                            partNumber = raw.partNumber,
                            partDescription = raw.partDescription,
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
                            isPartNonCancelableNonReschedule = raw.isPartNonCancelableNonReschedule,
                            isPartNotRecommendNewDesign = raw.isPartNotRecommendNewDesign,
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
                            productHierarchyCode = raw.productHierarchyCode,
                            productHierarchy3Code = raw.productHierarchy3Code,
                            productHierarchy3 = raw.productHierarchy3,
                            productHierarchy2 = raw.productHierarchy2,
                            productHierarchy1 = raw.productHierarchy1,
                            companyOfOrigin = raw.companyOfOrigin,
                            materialType = raw.materialType,
                            isSalesRoot = raw.isSalesRoot,
                            goldenRecord = raw.goldenRecord,
                            minimumOrderQuantity = raw.minimumOrderQuantity,
                            frequencyOrderIncrement = raw.frequencyOrderIncrement,

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
            List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> master = new List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> raws = _context.RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        partNumberKey = raw.partNumberKey,
                        partNumber = raw.partNumber,
                        partDescription = raw.partDescription,
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
                        isPartNonCancelableNonReschedule = raw.isPartNonCancelableNonReschedule,
                        isPartNotRecommendNewDesign = raw.isPartNotRecommendNewDesign,
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
                        productHierarchyCode = raw.productHierarchyCode,
                        productHierarchy3Code = raw.productHierarchy3Code,
                        productHierarchy3 = raw.productHierarchy3,
                        productHierarchy2 = raw.productHierarchy2,
                        productHierarchy1 = raw.productHierarchy1,
                        companyOfOrigin = raw.companyOfOrigin,
                        materialType = raw.materialType,
                        isSalesRoot = raw.isSalesRoot,
                        goldenRecord = raw.goldenRecord,
                        minimumOrderQuantity = raw.minimumOrderQuantity,
                        frequencyOrderIncrement = raw.frequencyOrderIncrement,

                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy,
                        //activeFlag = raw.activeFlag,
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCT_SALES_ROOT_PARTNUMBER", token.USER_ID);
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
        [Route("api/[controller]/GetReview")]
        [HttpGet]
        public IActionResult GetReview([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.reviewStatus == "Pending Review"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.reviewStatus == "Pending Review"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_PRODUCT_SALES_ROOT_PARTNUMBER")]
        [HttpPost]
        public IActionResult REVIEW_PRODUCT_SALES_ROOT_PARTNUMBER([FromQuery] string[] p_partNumbers)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_partNumbers", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_partNumbers,
                            Size = p_partNumbers.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_partNumbers.Select(s => s.Length).ToArray()
                        };
                        command.Parameters.Add(param);

                        command.Parameters.Add("p_user_id", OracleDbType.Varchar2).Value = token.USER_ID;

                        var outputParam = new OracleParameter("p_output_msg", OracleDbType.Varchar2, 4000)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        command.ExecuteNonQuery();

                        string result = outputParam.Value?.ToString();

                        _ = Task.Run(() => Execute_SP_CFG_OUT(token.USER_ID));

                        return Ok(new { p_partNumbers, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        private void Execute_SP_CFG_OUT(string USER_ID)
        {
            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_CFG_OUT_PRODUCT_SALES_ROOT_PARTNUMBER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        command.Parameters.Add("p_user_id", OracleDbType.Varchar2).Value = USER_ID;

                        var outputParam = new OracleParameter("p_output_msg", OracleDbType.Varchar2, 4000)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        command.ExecuteNonQuery();

                        // You can log or handle the output message if needed
                        string result = outputParam.Value?.ToString();
                        // Log result or handle accordingly
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SP_CFG_OUT_PRODUCT_SALES_ROOT_PARTNUMBER: {ex.Message}");
            }
        }

        [Authorize]
        [Route("api/[controller]/GetProductHierarchy3")]
        [HttpGet]
        public IActionResult GetProductHierarchy3()
        {
            try
            {

                var phList = _context.V_MDM_PRODUCT_HIERARCHies
                .Where(x => x.level == "3" && x.deleteFlag != "Y")
                .Select(x => new
                {
                    x.phCode,
                    x.phDescription
                })
                .AsEnumerable()
                .Select(x => new
                {
                    display = x.phCode + " : " + x.phDescription,
                    phCode = x.phCode,
                    phDescription = x.phDescription
                })
                .Distinct()
                .OrderBy(x => x.display)
                .ToList();

                //var phList = _context.V_MDM_PRODUCT_HIERARCHies
                //.Where(x => x.level == "3" && x.deleteFlag != "Y")
                //.Select(x => new {
                //    display = x.phCode + " : " + x.phDescription,
                //    phCode = x.phCode
                //})
                //.Distinct()
                //.OrderBy(x => x.display)
                //.ToList();

                if (phList == null || phList.Count == 0)
                    return NotFound();

                return Ok(phList);
            }
            catch (Exception ex) { 
                string xx = ex.Message;
                string xx2 = ex.Message;
                return NotFound();
            }
            
        }

        [Authorize]
        [Route("api/[controller]/GetCompanyOfOrigin")]
        [HttpGet]
        public IActionResult GetCompanyOfOrigin()
        {
            var Default_Value = _context.CFG_SYSTEM_PARAMs
            .Where(x => x.PARAM_CATEGORY == "companyOfOrigin_CFG_PRODUCT_SALES_ROOT_PARTNUMBER")
            .OrderBy(x => x.PARAM_KEY)
            .Select(s => s.PARAM_VALUE)
            .ToList();

            if (Default_Value == null || Default_Value.Count == 0)
                return NotFound();

            return Ok(Default_Value);
        }

        [Authorize]
        [Route("api/[controller]/GetDefaultValue")]
        [HttpGet]
        public IActionResult GetDefaultValue()
        {
            var Default_Value = _context.CFG_SYSTEM_PARAMs
            .Where(x => x.PARAM_CATEGORY == "Default_Value_CFG_PRODUCT_SALES_ROOT_PARTNUMBER")
            .ToList();

            if (Default_Value == null || Default_Value.Count == 0)
                return NotFound();

            return Ok(Default_Value);
        }

        [Authorize]
        [Route("api/[controller]/GetProductHierarchy21")]
        [HttpGet]
        public IActionResult GetProductHierarchy21(string ProductHierarchy3)
        {
            try
            {

                var phList = _context.V_MDM_PRODUCT_HIERARCHies
                .Where(x => x.deleteFlag != "Y" && 
                    (
                        (x.phCode == ProductHierarchy3.Substring(0, 4) && x.level == "2")
                        || (x.phCode == ProductHierarchy3.Substring(0, 2) && x.level == "1")
                    )
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
                    phCode = x.phCode,
                    phDescription = x.phDescription,
                    level = x.level
                })
                .Distinct()
                .OrderBy(x => x.level)
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
    }
}
