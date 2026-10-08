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
    public class CfgProductionPlantConversionController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgProductionPlantConversionController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PRODUCTION_PLANT_CONVERSIONs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCTION_PLANT_CONVERSIONs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCTION_PLANT_CONVERSION_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_PRODUCTION_PLANT_CONVERSION_HIS_ID = cfg.CFG_PRODUCTION_PLANT_CONVERSION_HIS_ID,
                                   updateDateAndTime = cfg.CFG_PRODUCTION_PLANT_CONVERSION_HIS_DATE,
                                   CFG_PRODUCTION_PLANT_CONVERSION_HIS_USERID = cfg.CFG_PRODUCTION_PLANT_CONVERSION_HIS_USERID,
                                   CFG_PRODUCTION_PLANT_CONVERSION_HIS_DELEGATE = cfg.CFG_PRODUCTION_PLANT_CONVERSION_HIS_DELEGATE,

                                   recordKey = cfg.recordKey,
                                   company = cfg.company,
                                   plant = cfg.plant,
                                   storageLocation = cfg.storageLocation,
                                   legacyType = cfg.legacyType,
                                   legacyLine = cfg.legacyLine,
                                   groupStage = cfg.groupStage,
                                   massProductionFlag = cfg.massProductionFlag,
                                   plantAndSlocVsLegacyLineRecordID = cfg.plantAndSlocVsLegacyLineRecordID,
                                   hmeType = cfg.hmeType,

                                   activeFlag = cfg.activeFlag,
                                   deleteFlag = cfg.deleteFlag,
                                   lastUpdateBy = cfg.lastUpdateBy,
                                   reviewBy = cfg.reviewBy,
                                   reviewDateAndTime = cfg.reviewDateAndTime,
                                   reviewStatus = cfg.reviewStatus,
                                   processStatus = cfg.processStatus

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
        public IActionResult Post([FromBody] RAW_CFG_PRODUCTION_PLANT_CONVERSION cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_GROUP_STAGE>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> excelList = new List<RAW_CFG_PRODUCTION_PLANT_CONVERSION>();
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
        public IActionResult Put([FromBody] RAW_CFG_PRODUCTION_PLANT_CONVERSION cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> excelList = new List<RAW_CFG_PRODUCTION_PLANT_CONVERSION>();
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
                    List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> excelList = ExcelImporter.Import<RAW_CFG_PRODUCTION_PLANT_CONVERSION>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCTION_PLANT_CONVERSION>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "company", "plant", "storageLocation", "legacyType", "legacyLine", "groupStage", "massProductionFlag", "plantAndSlocVsLegacyLineRecordID", "hmeType", "activeFlag", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCTION_PLANT_CONVERSION", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCTION_PLANT_CONVERSION", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> raws = _context.RAW_CFG_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCTION_PLANT_CONVERSION raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            company = raw.company,
                            plant = raw.plant,
                            storageLocation = raw.storageLocation,
                            legacyType = raw.legacyType,
                            legacyLine = raw.legacyLine,
                            groupStage = raw.groupStage,
                            massProductionFlag = raw.massProductionFlag,
                            plantAndSlocVsLegacyLineRecordID = raw.plantAndSlocVsLegacyLineRecordID,
                            hmeType = raw.hmeType,

                            updateDateAndTime = raw.createdDate,
                            lastUpdateBy = raw.createdBy,
                            activeFlag = raw.activeFlag
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
            List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> master = new List<RAW_CFG_PRODUCTION_PLANT_CONVERSION>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCTION_PLANT_CONVERSION> raws = _context.RAW_CFG_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCTION_PLANT_CONVERSION raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        company = raw.company,
                        plant = raw.plant,
                        storageLocation = raw.storageLocation,
                        legacyType = raw.legacyType,
                        legacyLine = raw.legacyLine,
                        groupStage = raw.groupStage,
                        massProductionFlag = raw.massProductionFlag,
                        plantAndSlocVsLegacyLineRecordID = raw.plantAndSlocVsLegacyLineRecordID,
                        hmeType = raw.hmeType,

                        updateDateAndTime = raw.createdDate,
                        lastUpdateBy = raw.createdBy,
                        activeFlag = raw.activeFlag
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCTION_PLANT_CONVERSION", token.USER_ID);
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
                return Ok(_context.V_CFG_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.reviewStatus == "Pending Review" && x.deleteFlag != "Y"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.reviewStatus == "Pending Review" && x.deleteFlag != "Y"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_PRODUCTION_PLANT_CONVERSION")]
        [HttpPost]
        public IActionResult REVIEW_PRODUCTION_PLANT_CONVERSION([FromQuery] string[] p_CPSLLGM_s)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_PRODUCTION_PLANT_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_CPSLLGM_s", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_CPSLLGM_s,
                            Size = p_CPSLLGM_s.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_CPSLLGM_s.Select(s => s.Length).ToArray()
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

                        return Ok(new { p_CPSLLGM_s, Result = result });
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

                    using (var command = new OracleCommand("SP_CFG_OUT_PRODUCTION_PLANT_CONVERSION", connection))
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
                Console.WriteLine($"Error executing SP_CFG_OUT_PRODUCTION_PLANT_CONVERSION: {ex.Message}");
            }
        }

        [Authorize]
        [Route("api/[controller]/GetPlant")]
        [HttpGet]
        public IActionResult GetPlant()
        {
            var mdmList = _context.V_CFG_STORAGE_LOCATIONs.Where(x => x.activeFlag != "N").GroupBy(x => new { x.plant }).Select(x => x.First()).ToList();
            if (mdmList == null || mdmList.Count() == 0)
                return NotFound();
            return Ok(mdmList.Select(x => new {
                plant = x.plant
            }));
        }

        [Authorize]
        [Route("api/[controller]/GetStorageLocation")]
        [HttpGet]
        public IActionResult GetStorageLocation()
        {
            var mdmList = _context.V_CFG_STORAGE_LOCATIONs.Where(x => x.activeFlag != "N").GroupBy(x => new { x.storageLocation }).Select(x => x.First()).ToList();
            if (mdmList == null || mdmList.Count() == 0)
                return NotFound();
            return Ok(mdmList.Select(x => new {
                storageLocation = x.storageLocation
            }));
        }
    }
}
