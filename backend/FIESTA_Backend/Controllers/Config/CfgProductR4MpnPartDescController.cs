using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using ExcelDataReader;
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
using Org.BouncyCastle.Asn1.Cmp;
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
    public class CfgProductR4MpnPartDescController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CfgProductR4MpnPartDescController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, IWebHostEnvironment webHostEnvironment)
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
                return Ok(_context.V_CFG_PRODUCT_R4_MPN_PARTDESCs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_R4_MPN_PARTDESCs, loadOptions));
            }

        }

        //For create or update 
        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromForm] string values)
        {
            return BadRequest("Insert not allowed!");
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                var cfg = JsonConvert.DeserializeObject<CFG_PRODUCT>(Uri.UnescapeDataString(values));
                //call DAL
                CfgProductDAL dal = new CfgProductDAL(_config, _httpContext, _context);
                return Ok(dal.InsertRecord(cfg, token));

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/[controller]/Approve")]
        [HttpPut]
        public IActionResult Approve([FromQuery] decimal values)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                //check if exist
                CFG_PRODUCT? c = _context.CFG_PRODUCTs
                    .FirstOrDefault(x => x.recordKey == values);

                objReturn.Data = c;

                //update only when exist
                if (c != null)
                {
                    c.modifiedBy = token.USER_ID;
                    c.partDescription = c.proposePartDesc;
                    c.proposePartDesc = null;//reset propose Part Desc after assign part desc
                    c.partDescApprovedBy = token.USER_ID;
                    c.partDescApprovedDateTime = DateTime.UtcNow;

                    _context.SaveChanges();

                    objReturn.SuccessMsg = "Record Updated Successfully";
                }
                else
                {
                    BadRequest("Record with RecordKey : " + values + "not found!");
                }

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }


            return Ok(objReturn);
        }

        [Authorize]
        [Route("api/[controller]/Reject")]
        [HttpPut]
        public IActionResult Reject([FromQuery] decimal values)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                //check if exist
                CFG_PRODUCT? c = _context.CFG_PRODUCTs
                    .FirstOrDefault(x => x.recordKey == values);

                objReturn.Data = c;

                //update only when exist
                if (c != null)
                {
                    c.modifiedBy = token.USER_ID;
                    c.proposePartDesc = null;//reset current propose part description to propose partdesc to reject
                    c.partDescApprovedBy = token.USER_ID;
                    c.partDescApprovedDateTime = DateTime.UtcNow;

                    _context.SaveChanges();

                    objReturn.SuccessMsg = "Record Updated Successfully";
                }
                else
                {
                    BadRequest("Record with RecordKey : " + values + "not found!");
                }

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }


            return Ok(objReturn);
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromForm] string values)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                var cfg = JsonConvert.DeserializeObject<CFG_PRODUCT>(Uri.UnescapeDataString(values));
                //check if exist
                CFG_PRODUCT? c = _context.CFG_PRODUCTs
                    .FirstOrDefault(x => x.partNumber == cfg.partNumber);

                objReturn.Data = c;

                //update only when exist
                if (c != null)
                {
                    c.modifiedBy = token.USER_ID;
                    c.partDescription = cfg.partDescription;
                    c.proposePartDesc = null;//reset current propose part description to propose partdesc to reject
                    c.partDescApprovedBy = token.USER_ID;
                    c.partDescApprovedDateTime = DateTime.UtcNow;

                    _context.SaveChanges();

                    objReturn.SuccessMsg = "Record Updated Successfully";
                }
                else
                {
                    BadRequest("Record with PartNumber : " + cfg.partNumber + "not found!");
                }

            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }


            return Ok(objReturn);
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.CFG_PRODUCT_HIs.Where(x => x.recordKey == id && x.partDescApprovedDateTime != null).ToList();

                var result_join = result.GroupJoin(_context.V_CFG_PRODUCT_R4_MPN_PARTDESCs,
                                cfg => cfg.partNumber,
                                plm => plm.partNumber,
                                (cfg, plm) => new
                                {
                                    CFG_PRODUCT_HIS_ID = cfg.CFG_PRODUCT_HIS_ID,
                                    CFG_PRODUCT_HIS_USERID = cfg.CFG_PRODUCT_HIS_USERID,
                                    CFG_PRODUCT_HIS_DELEGATE = cfg.CFG_PRODUCT_HIS_DELEGATE,
                                    updateDateAndTime = cfg.partDescApprovedDateTime,
                                    recordKey = cfg.recordKey,
                                    partNumber = cfg.partNumber,
                                    partDescription = cfg.partDescription,
                                    proposePartDesc = cfg.proposePartDesc,
                                    needPartDescription = (cfg.partDescription is null || cfg.partDescription == "NA") ? "Yes" : "No",
                                    needApproval = (cfg.partDescription != cfg.proposePartDesc) ? "Yes" : "No",
                                    REG_USER = plm.FirstOrDefault()?.REG_USER ?? null,
                                    REG_DATE = plm.FirstOrDefault()?.REG_DATE ?? null,
                                    productHierarchyCode = plm.FirstOrDefault()?.productHierarchyCode ?? null,
                                    productHierarchy1 = plm.FirstOrDefault()?.productHierarchy1 ?? null,
                                    productHierarchy2 = plm.FirstOrDefault()?.productHierarchy2 ?? null,
                                    productHierarchy3 = plm.FirstOrDefault()?.productHierarchy3 ?? null,
                                    productHierarchy4 = plm.FirstOrDefault()?.productHierarchy4 ?? null,
                                    productHierarchy5 = plm.FirstOrDefault()?.productHierarchy5 ?? null,
                                    lastApprovedBy = (cfg.partDescApprovedBy is null || _context.CFG_USERs.FirstOrDefault(x => x.USER_ID == cfg.partDescApprovedBy) is null) ? "SYSTEM" : _context.CFG_USERs.FirstOrDefault(x => x.USER_ID == cfg.partDescApprovedBy)?.USER_FULL_NAME + " <" + _context.CFG_USERs.FirstOrDefault(x => x.USER_ID == cfg.partDescApprovedBy)?.USER_EMAIL + ">",
                                })
                                .OrderByDescending(x => x.updateDateAndTime)
                                .OrderByDescending(x => x.CFG_PRODUCT_HIS_ID);

                return Ok(result_join);

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
                    BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                    bool allowContinue = false;
                    // load product requests from excel file
                    List<RAW_CFG_PRODUCT_R4_MPN_PART_DESC> excelList = ExcelImporter.Import<RAW_CFG_PRODUCT_R4_MPN_PART_DESC>(upload.OpenReadStream());

                    DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCT_R4_MPN_PART_DESC>(excelList, token.USER_ID, "Insert", 0, 1);
                    //take only specified column to bulk insert
                    DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "partNumber", "partDescription", "proposePartDesc", "toBePartDesc", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");
                    //delete raw table before bulk import
                    DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCT_R4_MPN_PART_DESC", token.USER_ID);
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
                        dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCT_R4_MPN_PART_DESC", token.USER_ID);
                        allowContinue = dbStatus.isSuccessful;
                    }
                    else
                    {
                        req.ErrorMsg += dbStatus.message + "\n";
                    }

                    List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                    List<RAW_CFG_PRODUCT_R4_MPN_PART_DESC> rawsOri = _context.RAW_CFG_PRODUCT_R4_MPN_PART_DESCs.Where(x => x.createdBy == token.USER_ID).ToList();
                    int count = 1;

                    //join with the view
                    var raws = rawsOri.GroupJoin(_context.V_CFG_PRODUCT_R4_MPN_PARTDESCs,
                                cfg => cfg.partNumber,
                                plm => plm.partNumber,
                                (cfg, plm) => new
                                {

                                    partNumber = cfg.partNumber,
                                    partDescription = cfg.partDescription,
                                    proposePartDesc = cfg.proposePartDesc,
                                    toBePartDesc = cfg.toBePartDesc,
                                    errorMessage = cfg.errorMessage,
                                    haveDifference = cfg.haveDifference,
                                    haveError = cfg.haveError,
                                    insertOrUpdate = cfg.insertOrUpdate,
                                    recordKey = plm.FirstOrDefault()?.recordKey ?? null,
                                    needPartDescription = (plm.FirstOrDefault()?.partDescription is null || plm.FirstOrDefault()?.partDescription == "NA") ? "Yes" : "No",
                                    needApproval = plm.FirstOrDefault()?.needApproval ?? null,
                                    REG_USER = plm.FirstOrDefault()?.REG_USER ?? null,
                                    REG_DATE = plm.FirstOrDefault()?.REG_DATE ?? null,
                                    productHierarchyCode = plm.FirstOrDefault()?.productHierarchyCode ?? null,
                                    productHierarchy1 = plm.FirstOrDefault()?.productHierarchy1 ?? null,
                                    productHierarchy2 = plm.FirstOrDefault()?.productHierarchy2 ?? null,
                                    productHierarchy3 = plm.FirstOrDefault()?.productHierarchy3 ?? null,
                                    productHierarchy4 = plm.FirstOrDefault()?.productHierarchy4 ?? null,
                                    productHierarchy5 = plm.FirstOrDefault()?.productHierarchy5 ?? null,
                                    lastApprovedBy = plm.FirstOrDefault()?.lastApprovedBy ?? null,
                                    updateDateAndTime = plm.FirstOrDefault()?.updateDateAndTime ?? null,
                                });

                    foreach (var raw in raws)
                    {
                        validateResult.Add(new CfgBulkImport()
                        {
                            id = count++,
                            bulkImportObj = new
                            {
                                partNumber = raw.partNumber,
                                partDescription = raw.partDescription,
                                proposePartDesc = raw.proposePartDesc,
                                toBePartDesc = raw.toBePartDesc,
                                recordKey = raw.recordKey,
                                needPartDescription = raw.needPartDescription,
                                needApproval = raw.needApproval,
                                REG_USER = raw.REG_USER,
                                REG_DATE = raw.REG_DATE,
                                productHierarchyCode = raw.productHierarchyCode,
                                productHierarchy1 = raw.productHierarchy1,
                                productHierarchy2 = raw.productHierarchy2,
                                productHierarchy3 = raw.productHierarchy3,
                                productHierarchy4 = raw.productHierarchy4,
                                productHierarchy5 = raw.productHierarchy5,
                                updateDateAndTime = raw.updateDateAndTime,
                                lastApprovedBy = raw.lastApprovedBy
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

                    return Ok(req);
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

            List<RAW_CFG_PRODUCT_R4_MPN_PART_DESC> master = new List<RAW_CFG_PRODUCT_R4_MPN_PART_DESC>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCT_R4_MPN_PART_DESC> raws = _context.RAW_CFG_PRODUCT_R4_MPN_PART_DESCs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCT_R4_MPN_PART_DESC raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        partNumber = raw.partNumber,
                        partDescription = raw.partDescription
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCT_R4_MPN_PART_DESC", token.USER_ID);
                allowContinue = dbStatus.isSuccessful;


                if (allowContinue)
                {
                    req.SuccessMsg = "Successfully updated all records.";
                    return Ok(req);
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                    return BadRequest(req);
                }
            }

            req.WarningMsg = "No Record valid for insert / update!";
            req.InfoMsg = "No Record valid for insert / update!";
            return Ok(req);
        }

    }
}
