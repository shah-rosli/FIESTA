using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
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
using static NPOI.HSSF.Util.HSSFColor;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgCdbController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgCdbController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
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
                return Ok(_context.V_CFG_CDBs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_CDBs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/[controller]/GetMdmByOpn")]
        [HttpGet]
        public IActionResult GetMdmByOpn([FromQuery] string opn)
        {
            var plmProduct = _context.PLM_PRODUCTs.FirstOrDefault(x => x.partNumber == opn);
            if (plmProduct == null)
            {
                //return NotFound();
                //return Ok(opn + " does not exist in PLM Product.");
                return Ok(new
                {
                    errorMessage = $"This OPN {opn} does not exist in PLM Product.",
                    data = Array.Empty<object>()
                });
            }
            //else if (opn == "1338D-31DCGI8")
            //{
            //    return Ok(new
            //    {
            //        //This OPN (xxx) cannot be edited because it has been blacklisted. Please contact SCM-MD team to review the blacklist reasons.
            //        errorMessage = "This OPN " + opn + " cannot be edited because it has been blacklisted. Please contact SCM-MD team to review the blacklist reasons.",
            //        data = Array.Empty<object>()
            //    });
            //}
            else if (plmProduct.companyCode == "0")
            {
                return Ok(new
                {
                    //This OPN (xxx) cannot be edited because it has been blacklisted. Please contact SCM-MD team to review the blacklist reasons.
                    errorMessage = "This OPN " + opn + " cannot be edited because it has been blacklisted. Please contact SCM-MD team to review the blacklist reasons.",
                    data = Array.Empty<object>()
                });
            }
            else if (string.IsNullOrEmpty(plmProduct.companyCode))
            {
                return Ok(new
                {
                    errorMessage = $"This OPN {opn} Company Code is empty.",
                    data = Array.Empty<object>()
                });
            }
            else
            {
                return Ok(new
                {
                    data = Array.Empty<object>()
                });
            }
        }

        [Authorize]
        [Route("api/[controller]/GetMdmByPartNumber")]
        [HttpGet]
        public IActionResult GetMdmByPartNumber([FromQuery] string partNumber)
        {
            var plmProduct = _context.PLM_PRODUCTs.FirstOrDefault(x => x.partNumber == partNumber);
            if (plmProduct == null)
            {
                //return NotFound();
                return Ok(new
                {
                    errorMessage = $"This Part Number {partNumber} does not have record in PLM Product.",
                    data = Array.Empty<object>()
                });
            }
            else if (plmProduct.companyCode == "0")
            {
                return Ok(new
                {
                    //errorMessage = partNumber + " has Company Code " + plmProduct.companyCode + ", it is blacklisted OPN.",
                    errorMessage = "This Part Number " + partNumber + " cannot be edited because it has been blacklisted. Please contact SCM-MD team to review the blacklist reasons.",
                    data = Array.Empty<object>()
                });
            }
            else if (string.IsNullOrEmpty(plmProduct.companyCode))
            {
                return Ok(new
                {
                    errorMessage = $"This Part Number {partNumber} Company Code is empty.",
                    data = Array.Empty<object>()
                });
            }
            else
            {
                var mdmList = _context.MDM_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.company == plmProduct.companyCode && x.activeFlag == "1").GroupBy(x => new { x.plant, x.storageLocation, x.legacyLine }).Select(x => x.First()).ToList();
                if (mdmList == null || mdmList.Count() == 0) {
                    //return NotFound();
                    return Ok(new
                    {
                        errorMessage = "Production Plant Conversion record not found for Company Code " + plmProduct.companyCode + ", and The record must be active.",
                        data = Array.Empty<object>()
                    });
                }
                    

                return Ok(mdmList.Select(x => new {
                    plant = x.plant,
                    storageLocation = x.storageLocation,
                    lineName = x.legacyLine
                }));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_CDB_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_CDB_HIS_ID = cfg.CFG_CDB_HIS_ID,
                                   updateDateAndTime = cfg.CFG_CDB_HIS_DATE,
                                   CFG_CDB_HIS_USERID = cfg.CFG_CDB_HIS_USERID,
                                   CFG_CDB_HIS_DELEGATE = cfg.CFG_CDB_HIS_DELEGATE,
                                   recordKey = cfg.recordKey,
                                   opn = cfg.opn,
                                   partNumber = cfg.partNumber,
                                   legacyOrganization = cfg.legacyOrganization,
                                   plmStatus = cfg.plmStatus,
                                   lineName = cfg.lineName,
                                   deleteFlag = cfg.deleteFlag,
                                   activeFlag = cfg.activeFlag,
                                   lastUpdateBy = cfg.lastUpdateBy
                               };

                return Ok(result_2.OrderByDescending(x => x.updateDateAndTime));

                //var result_join = result.GroupJoin(_context.CFG_USERs,
                //                cfg => cfg.CFG_CDB_HIS_USERID,
                //                usr => usr.USER_ID,
                //                (cfg, usr) => new
                //                {
                //                    CFG_CDB_HIS_ID = cfg.CFG_CDB_HIS_ID,
                //                    updateDateAndTime = cfg.CFG_CDB_HIS_DATE,
                //                    CFG_CDB_HIS_USERID = cfg.CFG_CDB_HIS_USERID,
                //                    CFG_CDB_HIS_DELEGATE = cfg.CFG_CDB_HIS_DELEGATE,
                //                    recordKey = cfg.recordKey,
                //                    opn = cfg.opn,
                //                    partNumber = cfg.partNumber,
                //                    //plant = cfg.plant,
                //                    //storageLocation = cfg.storageLocation,
                //                    lineName = cfg.lineName,
                //                    deleteFlag = cfg.deleteFlag,
                //                    activeFlag = cfg.activeFlag,
                //                    lastUpdateBy = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_FULL_NAME + " <" + usr.FirstOrDefault().USER_EMAIL + ">" : "SYSTEM"
                //                }).Where(x => x.deleteFlag == "N").OrderByDescending(x => x.updateDateAndTime);

                //var result_join2 = result_join.GroupJoin(_context.PLM_PRODUCTs,
                //                cfg => cfg.opn,
                //                plm => plm.partNumber,
                //                (cfg, plm) => new
                //                {
                //                    CFG_CDB_HIS_ID = cfg.CFG_CDB_HIS_ID,
                //                    updateDateAndTime = cfg.updateDateAndTime,
                //                    CFG_CDB_HIS_USERID = cfg.CFG_CDB_HIS_USERID,
                //                    CFG_CDB_HIS_DELEGATE = cfg.CFG_CDB_HIS_DELEGATE,
                //                    recordKey = cfg.recordKey,
                //                    opn = cfg.opn,
                //                    partNumber = cfg.partNumber,
                //                    legacyOrganization = plm.FirstOrDefault() != null ? plm.FirstOrDefault().legacyOrganization : null,
                //                    plmStatus = plm.FirstOrDefault() != null ? plm.FirstOrDefault().plmStatus : null,
                //                    lineName = cfg.lineName,
                //                    deleteFlag = cfg.deleteFlag,
                //                    activeFlag = cfg.activeFlag,
                //                    lastUpdateBy = cfg.lastUpdateBy
                //                }).OrderByDescending(x => x.updateDateAndTime);

                //return Ok(result_join2);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] RAW_CFG_CDB cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_CDB>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_CDB> excelList = new List<RAW_CFG_CDB>();
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
        public IActionResult Put([FromBody] RAW_CFG_CDB cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_CDB>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_CDB> excelList = new List<RAW_CFG_CDB>();
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
                    List<RAW_CFG_CDB> excelList = ExcelImporter.Import<RAW_CFG_CDB>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_CDB> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_CDB>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "opn", "partNumber", "lineName", "activeFlag", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_CDB", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_CDB", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_CDB> raws = _context.RAW_CFG_CDBs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_CDB raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            opn = raw.opn,
                            partNumber = raw.partNumber,
                            //plant = raw.plant,
                            //storageLocation = raw.storageLocation,
                            lineName = raw.lineName,
                            updateDateAndTime = raw.createdDate,
                            lastUpdateBy = raw.createdBy,
                            activeFlag = raw.activeFlag
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
            List<RAW_CFG_CDB> master = new List<RAW_CFG_CDB>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_CDB> raws = _context.RAW_CFG_CDBs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_CDB raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        opn = raw.opn,
                        partNumber = raw.partNumber,
                        //plant = raw.plant,
                        //storageLocation = raw.storageLocation,
                        lineName = raw.lineName,
                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy,
                        activeFlag = raw.activeFlag
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_CDB", token.USER_ID);
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
