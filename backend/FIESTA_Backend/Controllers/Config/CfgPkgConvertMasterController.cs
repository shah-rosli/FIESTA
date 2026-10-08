using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ExcelDataReader;
using FIESTA_Backend.Converters;
using FIESTA_Backend.DataAccess.Config;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using my.com.idt.score.Model;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using System.Data;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using UtilityCore.Models;
using UtilityCore.Utility.BulkImport;
using UtilityCore.Utility.DataAccess;
using UtilityCore.Utility.Import;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgPkgConvertMasterController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CfgPkgConvertMasterController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_CFG_PKG_CONVERT_MASTERs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PKG_CONVERT_MASTERs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/[controller]/GetById")]
        [HttpGet]
        public IActionResult GetById([FromQuery] decimal id)
        {
            CFG_PKG_CONVERT_MASTER? c = _context.CFG_PKG_CONVERT_MASTERs
                    .FirstOrDefault(x => x.CFG_PKG_CONVERT_MASTER_ID == id);

            if (c != null)
                return Ok(c);

            return NotFound();
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] RAW_CFG_PKG_CONVERT_MASTER cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<CFG_PKG_CONVERT_MASTER>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PKG_CONVERT_MASTER> excelList = new List<RAW_CFG_PKG_CONVERT_MASTER>();
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
        public IActionResult Put([FromBody] RAW_CFG_PKG_CONVERT_MASTER cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<CFG_PKG_CONVERT_MASTER>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PKG_CONVERT_MASTER> excelList = new List<RAW_CFG_PKG_CONVERT_MASTER>();
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
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.CFG_PKG_CONVERT_MASTER_HIs.Where(x => x.CFG_PKG_CONVERT_MASTER_ID == id).ToList();
                var result_join = result.GroupJoin(_context.CFG_USERs,
                                cfg => cfg.CFG_PKG_CONVERT_MASTER_HIS_USERID,
                                usr => usr.USER_ID,
                                (cfg, usr) => new
                                {
                                    CFG_PKG_CONVERT_MASTER_HIS_ID = cfg.CFG_PKG_CONVERT_MASTER_HIS_ID,
                                    CFG_PKG_CONVERT_MASTER_HIS_DATE = cfg.CFG_PKG_CONVERT_MASTER_HIS_DATE,
                                    CFG_PKG_CONVERT_MASTER_HIS_USERID = cfg.CFG_PKG_CONVERT_MASTER_HIS_USERID,
                                    CFG_PKG_CONVERT_MASTER_HIS_DELEGATE = cfg.CFG_PKG_CONVERT_MASTER_HIS_DELEGATE,
                                    CFG_PKG_CONVERT_MASTER_ID = cfg.CFG_PKG_CONVERT_MASTER_ID,
                                    detailPackage = cfg.detailPackage,
                                    packageLayer = cfg.packageLayer,
                                    roughPackage = cfg.roughPackage,
                                    packageType = cfg.packageType,
                                    bodySize = cfg.bodySize,
                                    pinCount = cfg.pinCount,
                                    deleteFlag = cfg.deleteFlag,
                                    MODIFIED_BY_EMAIL = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_EMAIL : null,
                                    MODIFIED_BY_NAME = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_FULL_NAME : null,
                                });
                var result_join_del = result_join.GroupJoin(_context.CFG_USERs,
                                cfg => cfg.CFG_PKG_CONVERT_MASTER_HIS_DELEGATE,
                                usr => usr.USER_ID,
                                (cfg, usr) => new
                                {
                                    CFG_PKG_CONVERT_MASTER_HIS_ID = cfg.CFG_PKG_CONVERT_MASTER_HIS_ID,
                                    CFG_PKG_CONVERT_MASTER_HIS_DATE = cfg.CFG_PKG_CONVERT_MASTER_HIS_DATE,
                                    CFG_PKG_CONVERT_MASTER_HIS_USERID = cfg.CFG_PKG_CONVERT_MASTER_HIS_USERID,
                                    CFG_PKG_CONVERT_MASTER_HIS_DELEGATE = cfg.CFG_PKG_CONVERT_MASTER_HIS_DELEGATE,
                                    CFG_PKG_CONVERT_MASTER_ID = cfg.CFG_PKG_CONVERT_MASTER_ID,
                                    detailPackage = cfg.detailPackage,
                                    packageLayer = cfg.packageLayer,
                                    roughPackage = cfg.roughPackage,
                                    packageType = cfg.packageType,
                                    bodySize = cfg.bodySize,
                                    pinCount = cfg.pinCount,
                                    deleteFlag = cfg.deleteFlag,
                                    MODIFIED_BY_EMAIL = cfg.MODIFIED_BY_EMAIL,
                                    MODIFIED_BY_NAME = cfg.MODIFIED_BY_NAME,
                                    MODIFIED_BY_DELNAME = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_FULL_NAME : null,
                                });

                return Ok(result_join_del);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    List<RAW_CFG_PKG_CONVERT_MASTER> excelList = ExcelImporter.Import<RAW_CFG_PKG_CONVERT_MASTER>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PKG_CONVERT_MASTER> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();
            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PKG_CONVERT_MASTER>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "detailPackage", "packageLayer", "roughPackage", "packageType", "bodySize", "pinCount", "deleteFlag", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PKG_CONVERT_MASTER", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PKG_CONVERT_MASTER", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PKG_CONVERT_MASTER> raws = _context.RAW_CFG_PKG_CONVERT_MASTERs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PKG_CONVERT_MASTER raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            detailPackage = raw.detailPackage,
                            packageLayer = raw.packageLayer,
                            roughPackage = raw.roughPackage,
                            packageType = raw.packageType,
                            bodySize = raw.bodySize,
                            pinCount = raw.pinCount,
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
            List<RAW_CFG_PKG_CONVERT_MASTER> master = new List<RAW_CFG_PKG_CONVERT_MASTER>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PKG_CONVERT_MASTER> raws = _context.RAW_CFG_PKG_CONVERT_MASTERs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PKG_CONVERT_MASTER raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        detailPackage = raw.detailPackage,
                        packageLayer = raw.packageLayer,
                        roughPackage = raw.roughPackage,
                        packageType = raw.packageType,
                        bodySize = raw.bodySize,
                        pinCount = raw.pinCount,
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

            //if there is actually records to update, and allow error proceeed (2025-07-20)
            if (validateResult.Count > 0 && validateResult.Count(x => x.haveDifference) > 0)
            {
                bool allowContinue = false;

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PKG_CONVERT_MASTER", token.USER_ID);
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
