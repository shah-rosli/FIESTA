using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Asn1.Cmp;
using System;
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
    public class CfgProductV2Controller : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgProductV2Controller(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PRODUCT_V2s);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_V2s, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCT_HIS_V2s.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_PRODUCT_HIS_ID = cfg.CFG_PRODUCT_HIS_ID,
                                   updateDateAndTime = cfg.CFG_PRODUCT_HIS_DATE,
                                   CFG_PRODUCT_HISS_USERID = cfg.CFG_PRODUCT_HIS_USERID,
                                   CFG_PRODUCT_HIS_DELEGATE = cfg.CFG_PRODUCT_HIS_DELEGATE,

                                   recordKey = cfg.recordKey,
                                   
                                   partDescription = cfg.partDescription,
                                   plmStatus = cfg.plmStatus,
                                   minimumOrderQuantity = cfg.minimumOrderQuantity,
                                   standardPackingQuantity = cfg.standardPackingQuantity,
                                   businessPlannerCode = cfg.businessPlannerCode,
                                   deleteFlag = cfg.deleteFlag,
                                   proposePartDesc = cfg.proposePartDesc,
                                   partDescApprovedBy = cfg.partDescApprovedBy,
                                   partDescApprovedDateTime = cfg.partDescApprovedDateTime,
                                   sentFromSystem = cfg.sentFromSystem,
                                   lastUpdateBy = cfg.lastUpdateBy,
                                   reviewBy = cfg.reviewBy,
                                   reviewDateAndTime = cfg.reviewDateAndTime,
                                   reviewStatus = cfg.reviewStatus,
                                   processStatus = cfg.processStatus,

                                   partNumber = cfg.partNumber,
                                   marketGroup = cfg.marketGroup,
                                   marketFamily = cfg.marketFamily,
                                   marketFamilyDetail = cfg.marketFamilyDetail,
                                   marketSegment = cfg.marketSegment,
                                   productHierarchyCode = cfg.productHierarchyCode,
                                   productHierarchy1 = cfg.productHierarchy1,
                                   productHierarchy2 = cfg.productHierarchy2,
                                   productHierarchy3 = cfg.productHierarchy3,
                                   productHierarchy4 = cfg.productHierarchy4,
                                   productHierarchy5 = cfg.productHierarchy5,
                                   profitCenter = cfg.profitCenter,
                                   businessUnit = cfg.businessUnit,
                                   businessDivision = cfg.businessDivision,
                                   isPartNotRecommendNewDesign = cfg.isPartNotRecommendNewDesign,
                                   salesRootPartNumber = cfg.salesRootPartNumber,
                                   isSalesRoot = cfg.isSalesRoot,
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
                                   canKit = cfg.canKit

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
        public IActionResult Post([FromBody] RAW_CFG_PRODUCT_V2 cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_GROUP_STAGE>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCT_V2> excelList = new List<RAW_CFG_PRODUCT_V2>();
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
        public IActionResult Put([FromBody] RAW_CFG_PRODUCT_V2 cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PRODUCT_V2> excelList = new List<RAW_CFG_PRODUCT_V2>();
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
                    List<RAW_CFG_PRODUCT_V2> excelList = ExcelImporter.Import<RAW_CFG_PRODUCT_V2>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCT_V2> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCT_V2>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false,
                    "createdBy", "partNumber", "salesRootPartNumber", "deleteFlag", "insertOrUpdate", "haveError", "errorMessage", "haveDifference"
                );
                //"partDescription", "plmStatus", "minimumOrderQuantity", "standardPackingQuantity", "businessPlannerCode", 


                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCT_V2", token.USER_ID);
                allowContinue = dbStatus.isSuccessful;

                //bulk import
                if (allowContinue)
                {
                    req.SuccessMsg += dbStatus.message + "\n";
                    //bulk import to raw table using data table
                    dtForBulkInsert.TableName = "RAW_CFG_PRODUCT_V2";
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCT_V2", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCT_V2> raws = _context.RAW_CFG_PRODUCT_V2s.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCT_V2 raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            partNumber = raw.partNumber,
                            salesRootPartNumber = raw.salesRootPartNumber,
                            deleteFlag = raw.deleteFlag,

                            updateDateAndTime = raw.createdDate,
                            lastUpdateBy = raw.createdBy,
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
            List<RAW_CFG_PRODUCT_V2> master = new List<RAW_CFG_PRODUCT_V2>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCT_V2> raws = _context.RAW_CFG_PRODUCT_V2s.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCT_V2 raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        partNumber = raw.partNumber,
                        salesRootPartNumber = raw.salesRootPartNumber,
                        deleteFlag = raw.deleteFlag,
                        
                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy,
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCT_V2", token.USER_ID);
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
                return Ok(_context.V_CFG_PRODUCT_V2s.Where(x => x.reviewStatus == "Pending Review"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_V2s.Where(x => x.reviewStatus == "Pending Review"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_PRODUCT_V2")]
        [HttpPost]
        public IActionResult REVIEW_PRODUCT_V2([FromQuery] string[] p_partNumbers)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_PRODUCT_V2", connection))
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

                        //_ = Task.Run(() => Execute_SP_CFG_OUT(token.USER_ID));

                        return Ok(new { p_partNumbers, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        //private void Execute_SP_CFG_OUT(string USER_ID)
        //{
        //    try
        //    {
        //        using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
        //        {
        //            connection.Open();

        //            using (var command = new OracleCommand("SP_CFG_OUT_PLANTS", connection))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.BindByName = true;

        //                command.Parameters.Add("p_user_id", OracleDbType.Varchar2).Value = USER_ID;

        //                var outputParam = new OracleParameter("p_output_msg", OracleDbType.Varchar2, 4000)
        //                {
        //                    Direction = ParameterDirection.Output
        //                };
        //                command.Parameters.Add(outputParam);

        //                command.ExecuteNonQuery();

        //                // You can log or handle the output message if needed
        //                string result = outputParam.Value?.ToString();
        //                // Log result or handle accordingly
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error executing SP_CFG_OUT_PLANTS: {ex.Message}");
        //    }
        //}


        [Authorize]
        [Route("api/[controller]/SearchSalesRootPartNumber")]
        [HttpGet]
        public IActionResult SearchSalesRootPartNumber(string search = "")
        {
            IQueryable<V_OUT_PRODUCT_SALES_ROOT_PARTNUMBER> query =
                _context.V_OUT_PRODUCT_SALES_ROOT_PARTNUMBERs
                    .Where(x => x.deleteFlag != "Y");

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
                .Take(300)  // return only first 300 matches
                .ToList();

            //if (!result.Any())
            //    return NotFound();

            return Ok(result);

            


        }
    }


}
