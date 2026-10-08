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
    public class CfgProductLineController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgProductLineController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PRODUCT_LINEs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_LINEs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCT_LINE_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   //CFG_CDB_HIS_ID = cfg.CFG_CDB_HIS_ID,
                                   //updateDateAndTime = cfg.CFG_CDB_HIS_DATE,
                                   //CFG_CDB_HIS_USERID = cfg.CFG_CDB_HIS_USERID,
                                   //CFG_CDB_HIS_DELEGATE = cfg.CFG_CDB_HIS_DELEGATE,
                                   //recordKey = cfg.recordKey,
                                   //opn = cfg.opn,
                                   //partNumber = cfg.partNumber,
                                   //legacyOrganization = cfg.legacyOrganization,
                                   //plmStatus = cfg.plmStatus,
                                   //lineName = cfg.lineName,
                                   //deleteFlag = cfg.deleteFlag,
                                   //activeFlag = cfg.activeFlag,
                                   //lastUpdateBy = cfg.lastUpdateBy

                                    CFG_PRODUCT_LINE_HIS_ID = cfg.CFG_PRODUCT_LINE_HIS_ID,
                                    updateDateAndTime = cfg.CFG_PRODUCT_LINE_HIS_DATE,
                                    CFG_PRODUCT_LINE_HIS_USERID = cfg.CFG_PRODUCT_LINE_HIS_USERID,
                                    CFG_PRODUCT_LINE_HIS_DELEGATE = cfg.CFG_PRODUCT_LINE_HIS_DELEGATE,
                                    recordKey = cfg.recordKey,

                                    productHierarchy1 = cfg.productHierarchy1,
                                    productHierarchy2 = cfg.productHierarchy2,
                                    productHierarchy3 = cfg.productHierarchy3,
                                    productLine = cfg.productLine,

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
        public IActionResult Post([FromBody] RAW_CFG_PRODUCT_LINE cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCT_LINE>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCT_LINE> excelList = new List<RAW_CFG_PRODUCT_LINE>();
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
        public IActionResult Put([FromBody] RAW_CFG_PRODUCT_LINE cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PRODUCT_LINE> excelList = new List<RAW_CFG_PRODUCT_LINE>();
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
                    List<RAW_CFG_PRODUCT_LINE> excelList = ExcelImporter.Import<RAW_CFG_PRODUCT_LINE>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCT_LINE> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCT_LINE>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false,
                    "createdBy",
                    "productHierarchy1",
                    "productHierarchy2",
                    "productHierarchy3",
                    "productLine",
                    "deleteFlag",
                    "insertOrUpdate",
                    "haveError",
                    "errorMessage",
                    "haveDifference"
                );



                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCT_LINE", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCT_LINE", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCT_LINE> raws = _context.RAW_CFG_PRODUCT_LINEs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCT_LINE raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            productHierarchy1 = raw.productHierarchy1,
                            productHierarchy2 = raw.productHierarchy2,
                            productHierarchy3 = raw.productHierarchy3,
                            productLine = raw.productLine,

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
            List<RAW_CFG_PRODUCT_LINE> master = new List<RAW_CFG_PRODUCT_LINE>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCT_LINE> raws = _context.RAW_CFG_PRODUCT_LINEs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCT_LINE raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        productHierarchy1 = raw.productHierarchy1,
                        productHierarchy2 = raw.productHierarchy2,
                        productHierarchy3 = raw.productHierarchy3,
                        productLine = raw.productLine,

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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCT_LINE", token.USER_ID);
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
                return Ok(_context.V_CFG_PRODUCT_LINEs.Where(x => x.reviewStatus == "Pending Review"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_LINEs.Where(x => x.reviewStatus == "Pending Review"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_PRODUCT_LINE")]
        [HttpPost]
        public IActionResult REVIEW_PRODUCT_LINE([FromQuery] string[] p_PPP_s)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_PRODUCT_LINE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_PPP_s", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_PPP_s,
                            Size = p_PPP_s.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_PPP_s.Select(s => s.Length).ToArray()
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

                        return Ok(new { p_PPP_s, Result = result });
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

                    using (var command = new OracleCommand("SP_CFG_OUT_PRODUCT_LINE", connection))
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
                Console.WriteLine($"Error executing SP_CFG_OUT_PRODUCT_LINE: {ex.Message}");
            }
        }
    }
}
