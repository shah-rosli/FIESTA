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
using Org.BouncyCastle.Ocsp;
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
	public class CfgProductionVersionController : ControllerBase
	{
		private IConfiguration _config;
		private HttpContext _httpContext;
		private readonly FiestaDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public CfgProductionVersionController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, IWebHostEnvironment webHostEnvironment)
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
				return Ok(_context.V_CFG_PRODUCTION_VERSIONs);
			}
			else
			{
				return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCTION_VERSIONs, loadOptions));
			}

		}

		[Authorize]
		[Route("api/[controller]/GetById")]
		[HttpGet]
		public IActionResult GetById([FromQuery] decimal id)
		{
			CFG_PRODUCTION_VERSION? c = _context.CFG_PRODUCTION_VERSIONs
					.FirstOrDefault(x => x.recordKey == id);

			if (c != null)
				return Ok(c);

			return NotFound();
		}

		//For create or update 
		[Authorize]
		[Route("api/[controller]")]
		[HttpPost]
		public IActionResult Post([FromBody] RAW_CFG_PRODUCTION_VERSION cfg)
		{
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_VERSION>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCTION_VERSION> excelList = new List<RAW_CFG_PRODUCTION_VERSION>();
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
		public IActionResult Put([FromBody] RAW_CFG_PRODUCTION_VERSION cfg)
		{
			//get the token
			TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
			token = token.GetTokenObject();

			JsonReturn req = new JsonReturn();

			try
			{
                List<RAW_CFG_PRODUCTION_VERSION> excelList = new List<RAW_CFG_PRODUCTION_VERSION>();
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
				var result = _context.V_CFG_PRODUCTION_VERSION_HIs.Where(x => x.recordKey == id).ToList();
                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_PRODUCTION_VERSION_HIS_ID = cfg.CFG_PRODUCTION_VERSION_HIS_ID,
                                   updateDateAndTime = cfg.CFG_PRODUCTION_VERSION_HIS_DATE,
                                   CFG_PRODUCTION_VERSION_HIS_USERID = cfg.CFG_PRODUCTION_VERSION_HIS_USERID,
                                   CFG_PRODUCTION_VERSION_HIS_DELEGATE = cfg.CFG_PRODUCTION_VERSION_HIS_DELEGATE,
                                   recordKey = cfg.recordKey,
                                   partNumber = cfg.partNumber,
                                   plant = cfg.plant,
                                   storageLocation = cfg.storageLocation,
                                   productionVersion = cfg.productionVersion,
                                   productionVersionLock = cfg.productionVersionLock,
                                   validFromDate = cfg.validFromDate,
                                   validToDate = cfg.validToDate,
                                   deleteFlag = cfg.deleteFlag,
                                   lastUpdateBy = cfg.lastUpdateBy
                               };

                return Ok(result_2.OrderByDescending(x => x.updateDateAndTime));

                //var result_join = result.GroupJoin(_context.CFG_USERs,
                //				cfg => cfg.CFG_PRODUCTION_VERSION_HIS_USERID,
                //				usr => usr.USER_ID,
                //				(cfg, usr) => new
                //				{
                //					CFG_PRODUCTION_VERSION_HIS_ID = cfg.CFG_PRODUCTION_VERSION_HIS_ID,
                //                                updateDateAndTime = cfg.CFG_PRODUCTION_VERSION_HIS_DATE,
                //					CFG_PRODUCTION_VERSION_HIS_USERID = cfg.CFG_PRODUCTION_VERSION_HIS_USERID,
                //					CFG_PRODUCTION_VERSION_HIS_DELEGATE = cfg.CFG_PRODUCTION_VERSION_HIS_DELEGATE,
                //					recordKey = cfg.recordKey,
                //					partNumber = cfg.partNumber,
                //					plant = cfg.plant,
                //					storageLocation = cfg.storageLocation,
                //					productionVersion = cfg.productionVersion,
                //					productionVersionLock = cfg.productionVersionLock,
                //                                validFromDate = cfg.validFromDate,
                //                                validToDate = cfg.validToDate,
                //					deleteFlag=cfg.deleteFlag,
                //                                lastUpdateBy = usr.FirstOrDefault() != null ? usr.FirstOrDefault().USER_FULL_NAME + " <" + usr.FirstOrDefault().USER_EMAIL + ">" : "SYSTEM"
                //                            }).Where(x => x.deleteFlag == "N").OrderByDescending(x => x.updateDateAndTime);

                //            return Ok(result_join);

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
                    List<RAW_CFG_PRODUCTION_VERSION> excelList = ExcelImporter.Import<RAW_CFG_PRODUCTION_VERSION>(upload.OpenReadStream());

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


        private JsonReturn Validate(List<RAW_CFG_PRODUCTION_VERSION> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                foreach (RAW_CFG_PRODUCTION_VERSION raw in excelList)
                {
                    raw.validFromDateStr = raw.validFromDate.HasValue ? raw.validFromDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    raw.validToDateStr = raw.validToDate.HasValue ? raw.validToDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                }

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCTION_VERSION>(excelList, token.USER_ID, "Insert", 0, 1);

                //take only specified column to bulk insert
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "partNumber", "plant", "storageLocation", "productionVersion", "productionVersionLock", "validFromDateStr", "validToDateStr", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCTION_VERSION", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCTION_VERSION", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCTION_VERSION> raws = _context.RAW_CFG_PRODUCTION_VERSIONs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCTION_VERSION raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            partNumber = raw.partNumber,
                            plant = raw.plant,
                            storageLocation = raw.storageLocation,
                            productionVersion = raw.productionVersion,
                            productionVersionLock = raw.productionVersionLock,
                            validFromDate = raw.validFromDateStr,
                            validToDate = raw.validToDateStr//,
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
            List<RAW_CFG_PRODUCTION_VERSION> master = new List<RAW_CFG_PRODUCTION_VERSION>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCTION_VERSION> raws = _context.RAW_CFG_PRODUCTION_VERSIONs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCTION_VERSION raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        partNumber = raw.partNumber,
                        plant = raw.plant,
                        storageLocation = raw.storageLocation,
                        productionVersion = raw.productionVersion,
                        productionVersionLock = raw.productionVersionLock//,
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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCTION_VERSION", token.USER_ID);
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
