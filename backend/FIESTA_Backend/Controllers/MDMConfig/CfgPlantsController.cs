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
using Oracle.ManagedDataAccess.Client;
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
    public class CfgPlantsController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgPlantsController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PLANTs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PLANTs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PLANTS_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_PLANTS_HIS_ID = cfg.CFG_PLANTS_HIS_ID,
                                   updateDateAndTime = cfg.CFG_PLANTS_HIS_DATE,
                                   CFG_PLANTS_HIS_USERID = cfg.CFG_PLANTS_HIS_USERID,
                                   CFG_PLANTS_HIS_DELEGATE = cfg.CFG_PLANTS_HIS_DELEGATE,

                                   recordKey = cfg.recordKey,
                                   plant = cfg.plant,
                                   name1 = cfg.name1,
                                   valuationArea = cfg.valuationArea,
                                   customerNumberOfPlant = cfg.customerNumberOfPlant,
                                   supplierNumberOfPlant = cfg.supplierNumberOfPlant,
                                   factoryCalendar = cfg.factoryCalendar,
                                   name2 = cfg.name2,
                                   streetAndHouseNumber = cfg.streetAndHouseNumber,
                                   poBox = cfg.poBox,
                                   postalCode = cfg.postalCode,
                                   city = cfg.city,
                                   purchOrganization = cfg.purchOrganization,
                                   salesOrganization = cfg.salesOrganization,
                                   batchStatusMgmt = cfg.batchStatusMgmt,
                                   condsAtPlantLevel = cfg.condsAtPlantLevel,
                                   sourceList = cfg.sourceList,
                                   reqmtsPlanning = cfg.reqmtsPlanning,
                                   countryRegionKey = cfg.countryRegionKey,
                                   region = cfg.region,
                                   countyCode = cfg.countyCode,
                                   cityCode = cfg.cityCode,
                                   address = cfg.address,
                                   planningPlant = cfg.planningPlant,
                                   taxJurisdiction = cfg.taxJurisdiction,
                                   distribchannel = cfg.distribchannel,
                                   intCOBillingDiv = cfg.intCOBillingDiv,
                                   languageKey = cfg.languageKey,
                                   sopPlant = cfg.sopPlant,
                                   varianceKey = cfg.varianceKey,
                                   batchStatusMgmtOld = cfg.batchStatusMgmtOld,
                                   plantCat = cfg.plantCat,
                                   salesDistrict = cfg.salesDistrict,
                                   supplyRegion = cfg.supplyRegion,
                                   taxIndicatorPlant = cfg.taxIndicatorPlant,
                                   regularSupplier = cfg.regularSupplier,
                                   firstReminderExped = cfg.firstReminderExped,
                                   secondReminderExped = cfg.secondReminderExped,
                                   thirdReminderExped = cfg.thirdReminderExped,
                                   text1stDunning = cfg.text1stDunning,
                                   text2ndDunning = cfg.text2ndDunning,
                                   text3rdDunning = cfg.text3rdDunning,
                                   poTolerance = cfg.poTolerance,
                                   businessPlace = cfg.businessPlace,
                                   salesAreaDetrm = cfg.salesAreaDetrm,
                                   distribProfileOfPlant = cfg.distribProfileOfPlant,
                                   archivingMarker = cfg.archivingMarker,
                                   batchRecDMSType = cfg.batchRecDMSType,
                                   nodeTypesupplyChain = cfg.nodeTypesupplyChain,
                                   namingStructure = cfg.namingStructure,
                                   costObjControlling = cfg.costObjControlling,
                                   mixedCosting = cfg.mixedCosting,
                                   actualCosting = cfg.actualCosting,
                                   shippingPointReceivingPt = cfg.shippingPointReceivingPt,
                                   actualActivitiesUpdated = cfg.actualActivitiesUpdated,
                                   controlOfCreditOfCostCenters = cfg.controlOfCreditOfCostCenters,
                                   afSrceDetViaATP = cfg.afSrceDetViaATP,
                                   batchManagementNotActiveByDefault = cfg.batchManagementNotActiveByDefault,
                                   supplyAssignmentARun = cfg.supplyAssignmentARun,
                                   seasonActiveInInventoryManagement = cfg.seasonActiveInInventoryManagement,
                                   controlDataForBOM = cfg.controlDataForBOM,
                                   activateVariantGrouping = cfg.activateVariantGrouping,
                                   assignBatchesInARun = cfg.assignBatchesInARun,
                                   exchangeValuation = cfg.exchangeValuation,
                                   vendorType = cfg.vendorType,
                                   credIPI = cfg.credIPI,
                                   storeCat = cfg.storeCat,
                                   superiorDeptStore = cfg.superiorDeptStore,
                                   ownership = cfg.ownership,
                                   company = cfg.company,

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
        public IActionResult Post([FromBody] RAW_CFG_PLANT cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCTION_GROUP_STAGE>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PLANT> excelList = new List<RAW_CFG_PLANT>();
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
        public IActionResult Put([FromBody] RAW_CFG_PLANT cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PLANT> excelList = new List<RAW_CFG_PLANT>();
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
                    List<RAW_CFG_PLANT> excelList = ExcelImporter.Import<RAW_CFG_PLANT>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PLANT> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PLANT>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "plant", "name1", "valuationArea", "customerNumberOfPlant",
                    "supplierNumberOfPlant", "factoryCalendar", "name2", "streetAndHouseNumber", "poBox", 
                    "postalCode", "city", "purchOrganization", "salesOrganization", "batchStatusMgmt", 
                    "condsAtPlantLevel", "sourceList", "reqmtsPlanning", "countryRegionKey", "region", 
                    "countyCode", "cityCode", "address", "planningPlant", "taxJurisdiction", 
                    "distribchannel", "intCOBillingDiv", "languageKey", "sopPlant", "varianceKey", 
                    "batchStatusMgmtOld", "plantCat", "salesDistrict", "supplyRegion", "taxIndicatorPlant", 
                    "regularSupplier", "firstReminderExped", "secondReminderExped", "thirdReminderExped", "text1stDunning", 
                    "text2ndDunning", "text3rdDunning", "poTolerance", "businessPlace", "salesAreaDetrm", 
                    "distribProfileOfPlant", "archivingMarker", "batchRecDMSType", "nodeTypesupplyChain", "namingStructure", 
                    "costObjControlling", "mixedCosting", "actualCosting", "shippingPointReceivingPt", "actualActivitiesUpdated", 
                    "controlOfCreditOfCostCenters", "afSrceDetViaATP", "batchManagementNotActiveByDefault", "supplyAssignmentARun", "seasonActiveInInventoryManagement", 
                    "controlDataForBOM", "activateVariantGrouping", "assignBatchesInARun", "exchangeValuation", "vendorType", 
                    "credIPI", "storeCat", "superiorDeptStore", "ownership", "company", 
                    "activeFlag", "insertOrUpdate", "haveError", "errorMessage", 
                    "haveDifference"
                );

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PLANTS", token.USER_ID);
                allowContinue = dbStatus.isSuccessful;

                //bulk import
                if (allowContinue)
                {
                    req.SuccessMsg += dbStatus.message + "\n";
                    //bulk import to raw table using data table
                    dtForBulkInsert.TableName = "RAW_CFG_PLANTS"; //change table name from RAW_CFG_PLANT to RAW_CFG_PLANTS
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PLANTS", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PLANT> raws = _context.RAW_CFG_PLANTs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PLANT raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            plant = raw.plant,
                            name1 = raw.name1,
                            valuationArea = raw.valuationArea,
                            customerNumberOfPlant = raw.customerNumberOfPlant,
                            supplierNumberOfPlant = raw.supplierNumberOfPlant,
                            factoryCalendar = raw.factoryCalendar,
                            name2 = raw.name2,
                            streetAndHouseNumber = raw.streetAndHouseNumber,
                            poBox = raw.poBox,
                            postalCode = raw.postalCode,
                            city = raw.city,
                            purchOrganization = raw.purchOrganization,
                            salesOrganization = raw.salesOrganization,
                            batchStatusMgmt = raw.batchStatusMgmt,
                            condsAtPlantLevel = raw.condsAtPlantLevel,
                            sourceList = raw.sourceList,
                            reqmtsPlanning = raw.reqmtsPlanning,
                            countryRegionKey = raw.countryRegionKey,
                            region = raw.region,
                            countyCode = raw.countyCode,
                            cityCode = raw.cityCode,
                            address = raw.address,
                            planningPlant = raw.planningPlant,
                            taxJurisdiction = raw.taxJurisdiction,
                            distribchannel = raw.distribchannel,
                            intCOBillingDiv = raw.intCOBillingDiv,
                            languageKey = raw.languageKey,
                            sopPlant = raw.sopPlant,
                            varianceKey = raw.varianceKey,
                            batchStatusMgmtOld = raw.batchStatusMgmtOld,
                            plantCat = raw.plantCat,
                            salesDistrict = raw.salesDistrict,
                            supplyRegion = raw.supplyRegion,
                            taxIndicatorPlant = raw.taxIndicatorPlant,
                            regularSupplier = raw.regularSupplier,
                            firstReminderExped = raw.firstReminderExped,
                            secondReminderExped = raw.secondReminderExped,
                            thirdReminderExped = raw.thirdReminderExped,
                            text1stDunning = raw.text1stDunning,
                            text2ndDunning = raw.text2ndDunning,
                            text3rdDunning = raw.text3rdDunning,
                            poTolerance = raw.poTolerance,
                            businessPlace = raw.businessPlace,
                            salesAreaDetrm = raw.salesAreaDetrm,
                            distribProfileOfPlant = raw.distribProfileOfPlant,
                            archivingMarker = raw.archivingMarker,
                            batchRecDMSType = raw.batchRecDMSType,
                            nodeTypesupplyChain = raw.nodeTypesupplyChain,
                            namingStructure = raw.namingStructure,
                            costObjControlling = raw.costObjControlling,
                            mixedCosting = raw.mixedCosting,
                            actualCosting = raw.actualCosting,
                            shippingPointReceivingPt = raw.shippingPointReceivingPt,
                            actualActivitiesUpdated = raw.actualActivitiesUpdated,
                            controlOfCreditOfCostCenters = raw.controlOfCreditOfCostCenters,
                            afSrceDetViaATP = raw.afSrceDetViaATP,
                            batchManagementNotActiveByDefault = raw.batchManagementNotActiveByDefault,
                            supplyAssignmentARun = raw.supplyAssignmentARun,
                            seasonActiveInInventoryManagement = raw.seasonActiveInInventoryManagement,
                            controlDataForBOM = raw.controlDataForBOM,
                            activateVariantGrouping = raw.activateVariantGrouping,
                            assignBatchesInARun = raw.assignBatchesInARun,
                            exchangeValuation = raw.exchangeValuation,
                            vendorType = raw.vendorType,
                            credIPI = raw.credIPI,
                            storeCat = raw.storeCat,
                            superiorDeptStore = raw.superiorDeptStore,
                            ownership = raw.ownership,
                            company = raw.company,

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
            List<RAW_CFG_PLANT> master = new List<RAW_CFG_PLANT>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PLANT> raws = _context.RAW_CFG_PLANTs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PLANT raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        plant = raw.plant,
                        name1 = raw.name1,
                        valuationArea = raw.valuationArea,
                        customerNumberOfPlant = raw.customerNumberOfPlant,
                        supplierNumberOfPlant = raw.supplierNumberOfPlant,
                        factoryCalendar = raw.factoryCalendar,
                        name2 = raw.name2,
                        streetAndHouseNumber = raw.streetAndHouseNumber,
                        poBox = raw.poBox,
                        postalCode = raw.postalCode,
                        city = raw.city,
                        purchOrganization = raw.purchOrganization,
                        salesOrganization = raw.salesOrganization,
                        batchStatusMgmt = raw.batchStatusMgmt,
                        condsAtPlantLevel = raw.condsAtPlantLevel,
                        sourceList = raw.sourceList,
                        reqmtsPlanning = raw.reqmtsPlanning,
                        countryRegionKey = raw.countryRegionKey,
                        region = raw.region,
                        countyCode = raw.countyCode,
                        cityCode = raw.cityCode,
                        address = raw.address,
                        planningPlant = raw.planningPlant,
                        taxJurisdiction = raw.taxJurisdiction,
                        distribchannel = raw.distribchannel,
                        intCOBillingDiv = raw.intCOBillingDiv,
                        languageKey = raw.languageKey,
                        sopPlant = raw.sopPlant,
                        varianceKey = raw.varianceKey,
                        batchStatusMgmtOld = raw.batchStatusMgmtOld,
                        plantCat = raw.plantCat,
                        salesDistrict = raw.salesDistrict,
                        supplyRegion = raw.supplyRegion,
                        taxIndicatorPlant = raw.taxIndicatorPlant,
                        regularSupplier = raw.regularSupplier,
                        firstReminderExped = raw.firstReminderExped,
                        secondReminderExped = raw.secondReminderExped,
                        thirdReminderExped = raw.thirdReminderExped,
                        text1stDunning = raw.text1stDunning,
                        text2ndDunning = raw.text2ndDunning,
                        text3rdDunning = raw.text3rdDunning,
                        poTolerance = raw.poTolerance,
                        businessPlace = raw.businessPlace,
                        salesAreaDetrm = raw.salesAreaDetrm,
                        distribProfileOfPlant = raw.distribProfileOfPlant,
                        archivingMarker = raw.archivingMarker,
                        batchRecDMSType = raw.batchRecDMSType,
                        nodeTypesupplyChain = raw.nodeTypesupplyChain,
                        namingStructure = raw.namingStructure,
                        costObjControlling = raw.costObjControlling,
                        mixedCosting = raw.mixedCosting,
                        actualCosting = raw.actualCosting,
                        shippingPointReceivingPt = raw.shippingPointReceivingPt,
                        actualActivitiesUpdated = raw.actualActivitiesUpdated,
                        controlOfCreditOfCostCenters = raw.controlOfCreditOfCostCenters,
                        afSrceDetViaATP = raw.afSrceDetViaATP,
                        batchManagementNotActiveByDefault = raw.batchManagementNotActiveByDefault,
                        supplyAssignmentARun = raw.supplyAssignmentARun,
                        seasonActiveInInventoryManagement = raw.seasonActiveInInventoryManagement,
                        controlDataForBOM = raw.controlDataForBOM,
                        activateVariantGrouping = raw.activateVariantGrouping,
                        assignBatchesInARun = raw.assignBatchesInARun,
                        exchangeValuation = raw.exchangeValuation,
                        vendorType = raw.vendorType,
                        credIPI = raw.credIPI,
                        storeCat = raw.storeCat,
                        superiorDeptStore = raw.superiorDeptStore,
                        ownership = raw.ownership,
                        company = raw.company,

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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PLANTS", token.USER_ID);
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
                return Ok(_context.V_CFG_PLANTs.Where(x => x.reviewStatus == "Pending Review" && x.deleteFlag != "Y"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PLANTs.Where(x => x.reviewStatus == "Pending Review" && x.deleteFlag != "Y"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_PLANTS")]
        [HttpPost]
        public IActionResult REVIEW_PLANTS([FromQuery] string[] p_plants)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_PLANTS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_plants", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_plants,
                            Size = p_plants.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_plants.Select(s => s.Length).ToArray()
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

                        return Ok(new { p_plants, Result = result });
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

                    using (var command = new OracleCommand("SP_CFG_OUT_PLANTS", connection))
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
                Console.WriteLine($"Error executing SP_CFG_OUT_PLANTS: {ex.Message}");
            }
        }

        [Authorize]
        [Route("api/[controller]/GetCompanyCode")]
        [HttpGet]
        public IActionResult GetCompanyCode()
        {
            try
            {
                var companyList = _context.V_CFG_COMPANY_CODEs
                .Where(x => x.deleteFlag != "Y")
                .Select(x => new
                {
                    x.companyCode
                })
                .Distinct()
                .OrderBy(x => x.companyCode)
                .ToList();

                if (companyList == null || companyList.Count == 0)
                    return NotFound();

                return Ok(companyList);
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
