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
using System.Reflection;

namespace FIESTA_Backend.Controllers.MDMConfig
{
    public class CfgProductHistoricalController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgProductHistoricalController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_PRODUCT_HISTORICALs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_HISTORICALs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_PRODUCT_HISTORICAL_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {

                                    CFG_PRODUCT_HISTORICAL_HIS_ID = cfg.CFG_PRODUCT_HISTORICAL_HIS_ID,
                                    updateDateAndTime = cfg.CFG_PRODUCT_HISTORICAL_HIS_DATE,
                                    CFG_PRODUCT_HISTORICAL_HIS_USERID = cfg.CFG_PRODUCT_HISTORICAL_HIS_USERID,
                                    CFG_PRODUCT_HISTORICAL_HIS_DELEGATE = cfg.CFG_PRODUCT_HISTORICAL_HIS_DELEGATE,

                                    recordKey = cfg.recordKey,
                                    partNumberKey = cfg.partNumberKey,
                                    partNumber = cfg.partNumber,
                                    materialType = cfg.materialType,
                                    materialTypeDetail = cfg.materialTypeDetail,
                                    materialGroup = cfg.materialGroup,
                                    partDescription = cfg.partDescription,
                                    legacyOrganization = cfg.legacyOrganization,
                                    originalPartNumber = cfg.originalPartNumber,
                                    groupStage = cfg.groupStage,
                                    groupStageName = cfg.groupStageName,
                                    companyCode = cfg.companyCode,
                                    companyName = cfg.companyName,
                                    baseUnitOfMeasure = cfg.baseUnitOfMeasure,
                                    plmStatus = cfg.plmStatus,
                                    legacyMPN = cfg.legacyMPN,
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
                                    gradeCode = cfg.gradeCode,
                                    gradeCodeDescription = cfg.gradeCodeDescription,
                                    priority1OPN = cfg.priority1OPN,
                                    isPartAutomotive = cfg.isPartAutomotive,
                                    isPartASIC = cfg.isPartASIC,
                                    isPartITAR = cfg.isPartITAR,
                                    isPartDolbyCapable = cfg.isPartDolbyCapable,
                                    isPartMultipleComponent = cfg.isPartMultipleComponent,
                                    isPartActive = cfg.isPartActive,
                                    isPartNotRecommendNewDesign = cfg.isPartNotRecommendNewDesign,
                                    whitePartNumber = cfg.whitePartNumber,
                                    basePartNumber = cfg.basePartNumber,
                                    classCode = cfg.classCode,
                                    classCodeDescription = cfg.classCodeDescription,
                                    totalShelfLife = cfg.totalShelfLife,
                                    minimumOrderQuantity = cfg.minimumOrderQuantity,
                                    frequencyOrderIncrement = cfg.frequencyOrderIncrement,
                                    defaultSalesOrderCreationPlant = cfg.defaultSalesOrderCreationPlant,
                                    companyOfOrigin = cfg.companyOfOrigin,
                                    partAxis = cfg.partAxis,
                                    autoShipping = cfg.autoShipping,
                                    packagingPackage = cfg.packagingPackage,
                                    grossWeight = cfg.grossWeight,
                                    netWeight = cfg.netWeight,
                                    standardPackingQuantity = cfg.standardPackingQuantity,
                                    packagingCarrier = cfg.packagingCarrier,
                                    packagingBox = cfg.packagingBox,
                                    packagingSpec = cfg.packagingSpec,
                                    tsFlag = cfg.tsFlag,
                                    expiryDatePrintingFlag = cfg.expiryDatePrintingFlag,
                                    sealDateFlag = cfg.sealDateFlag,
                                    halogenFreePrintingFlag = cfg.halogenFreePrintingFlag,
                                    moistureSensitiveLevel = cfg.moistureSensitiveLevel,
                                    pcbOnBoardReflowPeakTemperature = cfg.pcbOnBoardReflowPeakTemperature,
                                    pcbOnBoardReflowStorageCondition = cfg.pcbOnBoardReflowStorageCondition,
                                    pcbOnBoardReflowRebakeCondition = cfg.pcbOnBoardReflowRebakeCondition,
                                    roHSCompliant = cfg.roHSCompliant,
                                    roHSCompliantChina = cfg.roHSCompliantChina,
                                    roHSExemptPrintingFlag = cfg.roHSExemptPrintingFlag,
                                    roHSChinaExemptPrintingFlag = cfg.roHSChinaExemptPrintingFlag,
                                    reachPrintingFlag = cfg.reachPrintingFlag,
                                    ulRegistrationFlag = cfg.ulRegistrationFlag,
                                    lotSequenceCode = cfg.lotSequenceCode,
                                    packageCode = cfg.packageCode,
                                    packageCodeDescription = cfg.packageCodeDescription,
                                    jedecReferenceID = cfg.jedecReferenceID,
                                    pbFreeIndicator = cfg.pbFreeIndicator,
                                    packageType = cfg.packageType,
                                    packageGroup = cfg.packageGroup,
                                    packageCategory = cfg.packageCategory,
                                    packagePinCount = cfg.packagePinCount,
                                    packagePitch = cfg.packagePitch,
                                    packageLength = cfg.packageLength,
                                    packageWidth = cfg.packageWidth,
                                    packageBodyThickness = cfg.packageBodyThickness,
                                    packageLayer = cfg.packageLayer,
                                    packageBodySize = cfg.packageBodySize,
                                    numberOfDie = cfg.numberOfDie,
                                    diePositionForMultiDie = cfg.diePositionForMultiDie,
                                    assemblyOutPackagingType = cfg.assemblyOutPackagingType,
                                    singulationProcess = cfg.singulationProcess,
                                    totalNumberOfAllWires = cfg.totalNumberOfAllWires,
                                    wireDiameter = cfg.wireDiameter,
                                    wireType = cfg.wireType,
                                    chipVersion = cfg.chipVersion,
                                    thickness = cfg.thickness,
                                    bumpType = cfg.bumpType,
                                    processTechnology = cfg.processTechnology,
                                    waferTechnology = cfg.waferTechnology,
                                    roughWaferProcess = cfg.roughWaferProcess,
                                    waferOrInStockClass = cfg.waferOrInStockClass,
                                    foundryPartNumber = cfg.foundryPartNumber,
                                    grossDiePerWafer = cfg.grossDiePerWafer,
                                    waferSize = cfg.waferSize,
                                    productDiscontinueNotification = cfg.productDiscontinueNotification,
                                    pdnIssueDate = cfg.pdnIssueDate,
                                    pdnLastBuyDate = cfg.pdnLastBuyDate,
                                    pdnLastShipDate = cfg.pdnLastShipDate,
                                    extendedSupportDate = cfg.extendedSupportDate,
                                    orderUntilDate = cfg.orderUntilDate,
                                    businessPlannerCode = cfg.businessPlannerCode,
                                    activeDate = cfg.activeDate,
                                    productionDateP4 = cfg.productionDateP4,
                                    obsoleteDateP6 = cfg.obsoleteDateP6,
                                    deactivateDateP7 = cfg.deactivateDateP7,
                                    mrpType = cfg.mrpType,
                                    specNo = cfg.specNo,
                                    specNoGreenOrYellow = cfg.specNoGreenOrYellow,
                                    retisSeqNo = cfg.retisSeqNo,
                                    originalSourceSystem = cfg.originalSourceSystem,
                                    salesRootPartNumberKey = cfg.salesRootPartNumberKey,
                                    salesRootPartNumber = cfg.salesRootPartNumber,
                                    isSalesRoot = cfg.isSalesRoot,
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
                                    eccn = cfg.eccn,
                                    htsus = cfg.htsus,
                                    customerPartNumber = cfg.customerPartNumber,
                                    matrixWafer = cfg.matrixWafer,
                                    finalTestTestProgramRevision = cfg.finalTestTestProgramRevision,
                                    ulRatingsText = cfg.ulRatingsText,
                                    unitLoadingOrientationQuadrant = cfg.unitLoadingOrientationQuadrant,
                                    plasticReelSize = cfg.plasticReelSize,
                                    carrierTapePocketPitch = cfg.carrierTapePocketPitch,
                                    carrierTapeWidth = cfg.carrierTapeWidth,
                                    fiestaRules = cfg.fiestaRules,
                                    goldenAll = cfg.goldenAll,
                                    goldenRecord = cfg.goldenRecord,
                                    partNumberType = cfg.partNumberType,
                                    productGeneralType = cfg.productGeneralType,
                                    productType = cfg.productType,
                                    packagingCarrierQuantity = cfg.packagingCarrierQuantity,
                                    reelHubSize = cfg.reelHubSize,
                                    finalTerminalFinishDescription = cfg.finalTerminalFinishDescription,
                                    assemblyOutPackagingQty = cfg.assemblyOutPackagingQty,
                                    manufacturerPart = cfg.manufacturerPart,
                                    manufacturerPartDescription = cfg.manufacturerPartDescription,
                                    bomItemText = cfg.bomItemText,
                                    finalTerminalFinish = cfg.finalTerminalFinish,
                                    moistureExposureTime = cfg.moistureExposureTime,
                                    processSpecialTechnology = cfg.processSpecialTechnology,
                                    netDieBypass = cfg.netDieBypass,
                                    productLine = cfg.productLine,
                                    referencePackageType = cfg.referencePackageType,
                                    eccn_my = cfg.eccn_my,
                                    htsus_my = cfg.htsus_my,


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
        public IActionResult Post([FromBody] RAW_CFG_PRODUCT_HISTORICAL cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_PRODUCT_HISTORICAL>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_PRODUCT_HISTORICAL> excelList = new List<RAW_CFG_PRODUCT_HISTORICAL>();
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
        public IActionResult Put([FromBody] RAW_CFG_PRODUCT_HISTORICAL cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_PRODUCT_HISTORICAL> excelList = new List<RAW_CFG_PRODUCT_HISTORICAL>();
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
                    List<RAW_CFG_PRODUCT_HISTORICAL> excelList = ExcelImporter.Import<RAW_CFG_PRODUCT_HISTORICAL>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_PRODUCT_HISTORICAL> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_PRODUCT_HISTORICAL>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false,
                    "createdBy",
                    "partNumberKey",
                    "partNumber",
                    "materialType",
                    "materialTypeDetail",
                    "materialGroup",
                    "partDescription",
                    "legacyOrganization",
                    "originalPartNumber",
                    "groupStage",
                    "groupStageName",
                    "companyCode",
                    "companyName",
                    "baseUnitOfMeasure",
                    "plmStatus",
                    "legacyMPN",
                    "marketGroup",
                    "marketFamily",
                    "marketFamilyDetail",
                    "marketSegment",
                    "productHierarchyCode",
                    "productHierarchy1",
                    "productHierarchy2",
                    "productHierarchy3",
                    "productHierarchy4",
                    "productHierarchy5",
                    "profitCenter",
                    "businessUnit",
                    "businessDivision",
                    "gradeCode",
                    "gradeCodeDescription",
                    "priority1OPN",
                    "isPartAutomotive",
                    "isPartASIC",
                    "isPartITAR",
                    "isPartDolbyCapable",
                    "isPartMultipleComponent",
                    "isPartActive",
                    "isPartNotRecommendNewDesign",
                    "whitePartNumber",
                    "basePartNumber",
                    "classCode",
                    "classCodeDescription",
                    "totalShelfLife",
                    "minimumOrderQuantity",
                    "frequencyOrderIncrement",
                    "defaultSalesOrderCreationPlant",
                    "companyOfOrigin",
                    "partAxis",
                    "autoShipping",
                    "packagingPackage",
                    "grossWeight",
                    "netWeight",
                    "standardPackingQuantity",
                    "packagingCarrier",
                    "packagingBox",
                    "packagingSpec",
                    "tsFlag",
                    "expiryDatePrintingFlag",
                    "sealDateFlag",
                    "halogenFreePrintingFlag",
                    "moistureSensitiveLevel",
                    "pcbOnBoardReflowPeakTemperature",
                    "pcbOnBoardReflowStorageCondition",
                    "pcbOnBoardReflowRebakeCondition",
                    "roHSCompliant",
                    "roHSCompliantChina",
                    "roHSExemptPrintingFlag",
                    "roHSChinaExemptPrintingFlag",
                    "reachPrintingFlag",
                    "ulRegistrationFlag",
                    "lotSequenceCode",
                    "packageCode",
                    "packageCodeDescription",
                    "jedecReferenceID",
                    "pbFreeIndicator",
                    "packageType",
                    "packageGroup",
                    "packageCategory",
                    "packagePinCount",
                    "packagePitch",
                    "packageLength",
                    "packageWidth",
                    "packageBodyThickness",
                    "packageLayer",
                    "packageBodySize",
                    "numberOfDie",
                    "diePositionForMultiDie",
                    "assemblyOutPackagingType",
                    "singulationProcess",
                    "totalNumberOfAllWires",
                    "wireDiameter",
                    "wireType",
                    "chipVersion",
                    "thickness",
                    "bumpType",
                    "processTechnology",
                    "waferTechnology",
                    "roughWaferProcess",
                    "waferOrInStockClass",
                    "foundryPartNumber",
                    "grossDiePerWafer",
                    "waferSize",
                    "productDiscontinueNotification",
                    "pdnIssueDate",
                    "pdnLastBuyDate",
                    "pdnLastShipDate",
                    "extendedSupportDate",
                    "orderUntilDate",
                    "businessPlannerCode",
                    "activeDate",
                    "productionDateP4",
                    "obsoleteDateP6",
                    "deactivateDateP7",
                    "mrpType",
                    "specNo",
                    "specNoGreenOrYellow",
                    "retisSeqNo",
                    "originalSourceSystem",
                    "salesRootPartNumberKey",
                    "salesRootPartNumber",
                    "isSalesRoot",
                    "publishedLeadTimeInWeeks",
                    "isPartRegisterable",
                    "isPartSoleSource",
                    "canSample",
                    "canQuote",
                    "canContract",
                    "canOrder",
                    "canSearch",
                    "canDebit",
                    "canOpportunity",
                    "canRegister",
                    "canRotate",
                    "canForecast",
                    "canKit",
                    "isPartNonCancelableNonReschedule",
                    "isPartPublish",
                    "canFlagMasterComments",
                    "autoApprThresholdFocusSales",
                    "autoApprThresholdNonFocusSales",
                    "autoApprThresholdFocusPL",
                    "autoApprThresholdNonFocusPL",
                    "sampleAutoApprQtyThreshold",
                    "sampleAutoApprTotalValThreshold",
                    "tacticalMarketingMgr",
                    "marketingMgr",
                    "applicationCode3Default",
                    "eccn",
                    "htsus",
                    "customerPartNumber",
                    "matrixWafer",
                    "finalTestTestProgramRevision",
                    "ulRatingsText",
                    "unitLoadingOrientationQuadrant",
                    "plasticReelSize",
                    "carrierTapePocketPitch",
                    "carrierTapeWidth",
                    "fiestaRules",
                    "goldenAll",
                    "goldenRecord",
                    "partNumberType",
                    "productGeneralType",
                    "productType",
                    "packagingCarrierQuantity",
                    "reelHubSize",
                    "finalTerminalFinishDescription",
                    "assemblyOutPackagingQty",
                    "manufacturerPart",
                    "manufacturerPartDescription",
                    "bomItemText",
                    "finalTerminalFinish",
                    "moistureExposureTime",
                    "processSpecialTechnology",
                    "netDieBypass",
                    "productLine",
                    "referencePackageType",
                    "eccn_my",
                    "htsus_my",
                    "deleteFlag",
                    "insertOrUpdate",
                    "haveError",
                    "errorMessage",
                    "haveDifference"
                );

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_PRODUCT_HISTORICAL", token.USER_ID);
                allowContinue = dbStatus.isSuccessful;

                //bulk import
                if (allowContinue)
                {
                    req.SuccessMsg += dbStatus.message + "\n";

                    //special handling for date time column to avoid bulk insert error,
                    //need to convert validFrom and validTo to datetime type in datatable before bulk insert,
                    //and then convert back to original column after bulk insert

                    var dateTypeMap = typeof(RAW_CFG_PRODUCT_HISTORICAL)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p =>
                        p.PropertyType == typeof(DateTime) ||
                        p.PropertyType == typeof(DateTime?) ||
                        p.PropertyType == typeof(DateTimeOffset) ||
                        p.PropertyType == typeof(DateTimeOffset?))
                    .ToDictionary(
                        p => p.Name,
                        p => Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType,
                        StringComparer.OrdinalIgnoreCase
                    );

                    DataTable dtNew = new DataTable();

                    foreach (DataColumn col in dtForBulkInsert.Columns) {
                        // Default: keep original DataTable column type
                        Type colType = col.DataType;

                        // Override if column exists in RAW_CFG_PRODUCT_HISTORICAL date fields
                        if (dateTypeMap.TryGetValue(col.ColumnName, out Type mappedType)) {
                            colType = mappedType;
                        }

                        dtNew.Columns.Add(col.ColumnName, colType);
                    }
                    foreach (DataRow row in dtForBulkInsert.Rows) {
                        DataRow newRow = dtNew.NewRow();

                        foreach (DataColumn col in dtForBulkInsert.Columns) {
                            object value = row[col.ColumnName];

                            if (value == DBNull.Value || string.IsNullOrWhiteSpace(value?.ToString())) {
                                newRow[col.ColumnName] = DBNull.Value;
                                continue;
                            }

                            if (dateTypeMap.TryGetValue(col.ColumnName, out Type dateType)) {
                                if (dateType == typeof(DateTime)) {
                                    newRow[col.ColumnName] = Convert.ToDateTime(value);
                                }
                                else if (dateType == typeof(DateTimeOffset)) {
                                    newRow[col.ColumnName] = DateTimeOffset.Parse(value.ToString());
                                }
                            }
                            else {
                                newRow[col.ColumnName] = value;
                            }
                        }

                        dtNew.Rows.Add(newRow);
                    }
                    dtNew.TableName = "RAW_CFG_PRODUCT_HISTORICAL";

                    //bulk import to raw table using data table
                    //dbStatus = biOperation.BulkCopyToStagingTable(dtForBulkInsert);
                    dbStatus = biOperation.BulkCopyToStagingTable(dtNew);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_PRODUCT_HISTORICAL", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_PRODUCT_HISTORICAL> raws = _context.RAW_CFG_PRODUCT_HISTORICALs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_PRODUCT_HISTORICAL raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            partNumberKey = raw.partNumberKey,
                            partNumber = raw.partNumber,
                            materialType = raw.materialType,
                            materialTypeDetail = raw.materialTypeDetail,
                            materialGroup = raw.materialGroup,
                            partDescription = raw.partDescription,
                            legacyOrganization = raw.legacyOrganization,
                            originalPartNumber = raw.originalPartNumber,
                            groupStage = raw.groupStage,
                            groupStageName = raw.groupStageName,
                            companyCode = raw.companyCode,
                            companyName = raw.companyName,
                            baseUnitOfMeasure = raw.baseUnitOfMeasure,
                            plmStatus = raw.plmStatus,
                            legacyMPN = raw.legacyMPN,
                            marketGroup = raw.marketGroup,
                            marketFamily = raw.marketFamily,
                            marketFamilyDetail = raw.marketFamilyDetail,
                            marketSegment = raw.marketSegment,
                            productHierarchyCode = raw.productHierarchyCode,
                            productHierarchy1 = raw.productHierarchy1,
                            productHierarchy2 = raw.productHierarchy2,
                            productHierarchy3 = raw.productHierarchy3,
                            productHierarchy4 = raw.productHierarchy4,
                            productHierarchy5 = raw.productHierarchy5,
                            profitCenter = raw.profitCenter,
                            businessUnit = raw.businessUnit,
                            businessDivision = raw.businessDivision,
                            gradeCode = raw.gradeCode,
                            gradeCodeDescription = raw.gradeCodeDescription,
                            priority1OPN = raw.priority1OPN,
                            isPartAutomotive = raw.isPartAutomotive,
                            isPartASIC = raw.isPartASIC,
                            isPartITAR = raw.isPartITAR,
                            isPartDolbyCapable = raw.isPartDolbyCapable,
                            isPartMultipleComponent = raw.isPartMultipleComponent,
                            isPartActive = raw.isPartActive,
                            isPartNotRecommendNewDesign = raw.isPartNotRecommendNewDesign,
                            whitePartNumber = raw.whitePartNumber,
                            basePartNumber = raw.basePartNumber,
                            classCode = raw.classCode,
                            classCodeDescription = raw.classCodeDescription,
                            totalShelfLife = raw.totalShelfLife,
                            minimumOrderQuantity = raw.minimumOrderQuantity,
                            frequencyOrderIncrement = raw.frequencyOrderIncrement,
                            defaultSalesOrderCreationPlant = raw.defaultSalesOrderCreationPlant,
                            companyOfOrigin = raw.companyOfOrigin,
                            partAxis = raw.partAxis,
                            autoShipping = raw.autoShipping,
                            packagingPackage = raw.packagingPackage,
                            grossWeight = raw.grossWeight,
                            netWeight = raw.netWeight,
                            standardPackingQuantity = raw.standardPackingQuantity,
                            packagingCarrier = raw.packagingCarrier,
                            packagingBox = raw.packagingBox,
                            packagingSpec = raw.packagingSpec,
                            tsFlag = raw.tsFlag,
                            expiryDatePrintingFlag = raw.expiryDatePrintingFlag,
                            sealDateFlag = raw.sealDateFlag,
                            halogenFreePrintingFlag = raw.halogenFreePrintingFlag,
                            moistureSensitiveLevel = raw.moistureSensitiveLevel,
                            pcbOnBoardReflowPeakTemperature = raw.pcbOnBoardReflowPeakTemperature,
                            pcbOnBoardReflowStorageCondition = raw.pcbOnBoardReflowStorageCondition,
                            pcbOnBoardReflowRebakeCondition = raw.pcbOnBoardReflowRebakeCondition,
                            roHSCompliant = raw.roHSCompliant,
                            roHSCompliantChina = raw.roHSCompliantChina,
                            roHSExemptPrintingFlag = raw.roHSExemptPrintingFlag,
                            roHSChinaExemptPrintingFlag = raw.roHSChinaExemptPrintingFlag,
                            reachPrintingFlag = raw.reachPrintingFlag,
                            ulRegistrationFlag = raw.ulRegistrationFlag,
                            lotSequenceCode = raw.lotSequenceCode,
                            packageCode = raw.packageCode,
                            packageCodeDescription = raw.packageCodeDescription,
                            jedecReferenceID = raw.jedecReferenceID,
                            pbFreeIndicator = raw.pbFreeIndicator,
                            packageType = raw.packageType,
                            packageGroup = raw.packageGroup,
                            packageCategory = raw.packageCategory,
                            packagePinCount = raw.packagePinCount,
                            packagePitch = raw.packagePitch,
                            packageLength = raw.packageLength,
                            packageWidth = raw.packageWidth,
                            packageBodyThickness = raw.packageBodyThickness,
                            packageLayer = raw.packageLayer,
                            packageBodySize = raw.packageBodySize,
                            numberOfDie = raw.numberOfDie,
                            diePositionForMultiDie = raw.diePositionForMultiDie,
                            assemblyOutPackagingType = raw.assemblyOutPackagingType,
                            singulationProcess = raw.singulationProcess,
                            totalNumberOfAllWires = raw.totalNumberOfAllWires,
                            wireDiameter = raw.wireDiameter,
                            wireType = raw.wireType,
                            chipVersion = raw.chipVersion,
                            thickness = raw.thickness,
                            bumpType = raw.bumpType,
                            processTechnology = raw.processTechnology,
                            waferTechnology = raw.waferTechnology,
                            roughWaferProcess = raw.roughWaferProcess,
                            waferOrInStockClass = raw.waferOrInStockClass,
                            foundryPartNumber = raw.foundryPartNumber,
                            grossDiePerWafer = raw.grossDiePerWafer,
                            waferSize = raw.waferSize,
                            productDiscontinueNotification = raw.productDiscontinueNotification,
                            pdnIssueDate = raw.pdnIssueDate,
                            pdnLastBuyDate = raw.pdnLastBuyDate,
                            pdnLastShipDate = raw.pdnLastShipDate,
                            extendedSupportDate = raw.extendedSupportDate,
                            orderUntilDate = raw.orderUntilDate,
                            businessPlannerCode = raw.businessPlannerCode,
                            activeDate = raw.activeDate,
                            productionDateP4 = raw.productionDateP4,
                            obsoleteDateP6 = raw.obsoleteDateP6,
                            deactivateDateP7 = raw.deactivateDateP7,
                            mrpType = raw.mrpType,
                            specNo = raw.specNo,
                            specNoGreenOrYellow = raw.specNoGreenOrYellow,
                            retisSeqNo = raw.retisSeqNo,
                            originalSourceSystem = raw.originalSourceSystem,
                            salesRootPartNumberKey = raw.salesRootPartNumberKey,
                            salesRootPartNumber = raw.salesRootPartNumber,
                            isSalesRoot = raw.isSalesRoot,
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
                            eccn = raw.eccn,
                            htsus = raw.htsus,
                            customerPartNumber = raw.customerPartNumber,
                            matrixWafer = raw.matrixWafer,
                            finalTestTestProgramRevision = raw.finalTestTestProgramRevision,
                            ulRatingsText = raw.ulRatingsText,
                            unitLoadingOrientationQuadrant = raw.unitLoadingOrientationQuadrant,
                            plasticReelSize = raw.plasticReelSize,
                            carrierTapePocketPitch = raw.carrierTapePocketPitch,
                            carrierTapeWidth = raw.carrierTapeWidth,
                            fiestaRules = raw.fiestaRules,
                            goldenAll = raw.goldenAll,
                            goldenRecord = raw.goldenRecord,
                            partNumberType = raw.partNumberType,
                            productGeneralType = raw.productGeneralType,
                            productType = raw.productType,
                            packagingCarrierQuantity = raw.packagingCarrierQuantity,
                            reelHubSize = raw.reelHubSize,
                            finalTerminalFinishDescription = raw.finalTerminalFinishDescription,
                            assemblyOutPackagingQty = raw.assemblyOutPackagingQty,
                            manufacturerPart = raw.manufacturerPart,
                            manufacturerPartDescription = raw.manufacturerPartDescription,
                            bomItemText = raw.bomItemText,
                            finalTerminalFinish = raw.finalTerminalFinish,
                            moistureExposureTime = raw.moistureExposureTime,
                            processSpecialTechnology = raw.processSpecialTechnology,
                            netDieBypass = raw.netDieBypass,
                            productLine = raw.productLine,
                            referencePackageType = raw.referencePackageType,
                            eccn_my = raw.eccn_my,
                            htsus_my = raw.htsus_my,

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
            List<RAW_CFG_PRODUCT_HISTORICAL> master = new List<RAW_CFG_PRODUCT_HISTORICAL>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_PRODUCT_HISTORICAL> raws = _context.RAW_CFG_PRODUCT_HISTORICALs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_PRODUCT_HISTORICAL raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        partNumberKey = raw.partNumberKey,
                        partNumber = raw.partNumber,
                        materialType = raw.materialType,
                        materialTypeDetail = raw.materialTypeDetail,
                        materialGroup = raw.materialGroup,
                        partDescription = raw.partDescription,
                        legacyOrganization = raw.legacyOrganization,
                        originalPartNumber = raw.originalPartNumber,
                        groupStage = raw.groupStage,
                        groupStageName = raw.groupStageName,
                        companyCode = raw.companyCode,
                        companyName = raw.companyName,
                        baseUnitOfMeasure = raw.baseUnitOfMeasure,
                        plmStatus = raw.plmStatus,
                        legacyMPN = raw.legacyMPN,
                        marketGroup = raw.marketGroup,
                        marketFamily = raw.marketFamily,
                        marketFamilyDetail = raw.marketFamilyDetail,
                        marketSegment = raw.marketSegment,
                        productHierarchyCode = raw.productHierarchyCode,
                        productHierarchy1 = raw.productHierarchy1,
                        productHierarchy2 = raw.productHierarchy2,
                        productHierarchy3 = raw.productHierarchy3,
                        productHierarchy4 = raw.productHierarchy4,
                        productHierarchy5 = raw.productHierarchy5,
                        profitCenter = raw.profitCenter,
                        businessUnit = raw.businessUnit,
                        businessDivision = raw.businessDivision,
                        gradeCode = raw.gradeCode,
                        gradeCodeDescription = raw.gradeCodeDescription,
                        priority1OPN = raw.priority1OPN,
                        isPartAutomotive = raw.isPartAutomotive,
                        isPartASIC = raw.isPartASIC,
                        isPartITAR = raw.isPartITAR,
                        isPartDolbyCapable = raw.isPartDolbyCapable,
                        isPartMultipleComponent = raw.isPartMultipleComponent,
                        isPartActive = raw.isPartActive,
                        isPartNotRecommendNewDesign = raw.isPartNotRecommendNewDesign,
                        whitePartNumber = raw.whitePartNumber,
                        basePartNumber = raw.basePartNumber,
                        classCode = raw.classCode,
                        classCodeDescription = raw.classCodeDescription,
                        totalShelfLife = raw.totalShelfLife,
                        minimumOrderQuantity = raw.minimumOrderQuantity,
                        frequencyOrderIncrement = raw.frequencyOrderIncrement,
                        defaultSalesOrderCreationPlant = raw.defaultSalesOrderCreationPlant,
                        companyOfOrigin = raw.companyOfOrigin,
                        partAxis = raw.partAxis,
                        autoShipping = raw.autoShipping,
                        packagingPackage = raw.packagingPackage,
                        grossWeight = raw.grossWeight,
                        netWeight = raw.netWeight,
                        standardPackingQuantity = raw.standardPackingQuantity,
                        packagingCarrier = raw.packagingCarrier,
                        packagingBox = raw.packagingBox,
                        packagingSpec = raw.packagingSpec,
                        tsFlag = raw.tsFlag,
                        expiryDatePrintingFlag = raw.expiryDatePrintingFlag,
                        sealDateFlag = raw.sealDateFlag,
                        halogenFreePrintingFlag = raw.halogenFreePrintingFlag,
                        moistureSensitiveLevel = raw.moistureSensitiveLevel,
                        pcbOnBoardReflowPeakTemperature = raw.pcbOnBoardReflowPeakTemperature,
                        pcbOnBoardReflowStorageCondition = raw.pcbOnBoardReflowStorageCondition,
                        pcbOnBoardReflowRebakeCondition = raw.pcbOnBoardReflowRebakeCondition,
                        roHSCompliant = raw.roHSCompliant,
                        roHSCompliantChina = raw.roHSCompliantChina,
                        roHSExemptPrintingFlag = raw.roHSExemptPrintingFlag,
                        roHSChinaExemptPrintingFlag = raw.roHSChinaExemptPrintingFlag,
                        reachPrintingFlag = raw.reachPrintingFlag,
                        ulRegistrationFlag = raw.ulRegistrationFlag,
                        lotSequenceCode = raw.lotSequenceCode,
                        packageCode = raw.packageCode,
                        packageCodeDescription = raw.packageCodeDescription,
                        jedecReferenceID = raw.jedecReferenceID,
                        pbFreeIndicator = raw.pbFreeIndicator,
                        packageType = raw.packageType,
                        packageGroup = raw.packageGroup,
                        packageCategory = raw.packageCategory,
                        packagePinCount = raw.packagePinCount,
                        packagePitch = raw.packagePitch,
                        packageLength = raw.packageLength,
                        packageWidth = raw.packageWidth,
                        packageBodyThickness = raw.packageBodyThickness,
                        packageLayer = raw.packageLayer,
                        packageBodySize = raw.packageBodySize,
                        numberOfDie = raw.numberOfDie,
                        diePositionForMultiDie = raw.diePositionForMultiDie,
                        assemblyOutPackagingType = raw.assemblyOutPackagingType,
                        singulationProcess = raw.singulationProcess,
                        totalNumberOfAllWires = raw.totalNumberOfAllWires,
                        wireDiameter = raw.wireDiameter,
                        wireType = raw.wireType,
                        chipVersion = raw.chipVersion,
                        thickness = raw.thickness,
                        bumpType = raw.bumpType,
                        processTechnology = raw.processTechnology,
                        waferTechnology = raw.waferTechnology,
                        roughWaferProcess = raw.roughWaferProcess,
                        waferOrInStockClass = raw.waferOrInStockClass,
                        foundryPartNumber = raw.foundryPartNumber,
                        grossDiePerWafer = raw.grossDiePerWafer,
                        waferSize = raw.waferSize,
                        productDiscontinueNotification = raw.productDiscontinueNotification,
                        pdnIssueDate = raw.pdnIssueDate,
                        pdnLastBuyDate = raw.pdnLastBuyDate,
                        pdnLastShipDate = raw.pdnLastShipDate,
                        extendedSupportDate = raw.extendedSupportDate,
                        orderUntilDate = raw.orderUntilDate,
                        businessPlannerCode = raw.businessPlannerCode,
                        activeDate = raw.activeDate,
                        productionDateP4 = raw.productionDateP4,
                        obsoleteDateP6 = raw.obsoleteDateP6,
                        deactivateDateP7 = raw.deactivateDateP7,
                        mrpType = raw.mrpType,
                        specNo = raw.specNo,
                        specNoGreenOrYellow = raw.specNoGreenOrYellow,
                        retisSeqNo = raw.retisSeqNo,
                        originalSourceSystem = raw.originalSourceSystem,
                        salesRootPartNumberKey = raw.salesRootPartNumberKey,
                        salesRootPartNumber = raw.salesRootPartNumber,
                        isSalesRoot = raw.isSalesRoot,
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
                        eccn = raw.eccn,
                        htsus = raw.htsus,
                        customerPartNumber = raw.customerPartNumber,
                        matrixWafer = raw.matrixWafer,
                        finalTestTestProgramRevision = raw.finalTestTestProgramRevision,
                        ulRatingsText = raw.ulRatingsText,
                        unitLoadingOrientationQuadrant = raw.unitLoadingOrientationQuadrant,
                        plasticReelSize = raw.plasticReelSize,
                        carrierTapePocketPitch = raw.carrierTapePocketPitch,
                        carrierTapeWidth = raw.carrierTapeWidth,
                        fiestaRules = raw.fiestaRules,
                        goldenAll = raw.goldenAll,
                        goldenRecord = raw.goldenRecord,
                        partNumberType = raw.partNumberType,
                        productGeneralType = raw.productGeneralType,
                        productType = raw.productType,
                        packagingCarrierQuantity = raw.packagingCarrierQuantity,
                        reelHubSize = raw.reelHubSize,
                        finalTerminalFinishDescription = raw.finalTerminalFinishDescription,
                        assemblyOutPackagingQty = raw.assemblyOutPackagingQty,
                        manufacturerPart = raw.manufacturerPart,
                        manufacturerPartDescription = raw.manufacturerPartDescription,
                        bomItemText = raw.bomItemText,
                        finalTerminalFinish = raw.finalTerminalFinish,
                        moistureExposureTime = raw.moistureExposureTime,
                        processSpecialTechnology = raw.processSpecialTechnology,
                        netDieBypass = raw.netDieBypass,
                        productLine = raw.productLine,
                        referencePackageType = raw.referencePackageType,
                        eccn_my = raw.eccn_my,
                        htsus_my = raw.htsus_my,

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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_PRODUCT_HISTORICAL", token.USER_ID);
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
                return Ok(_context.V_CFG_PRODUCT_HISTORICALs.Where(x => x.reviewStatus == "Pending Review"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_PRODUCT_HISTORICALs.Where(x => x.reviewStatus == "Pending Review"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_PRODUCT_HISTORICAL")]
        [HttpPost]
        public IActionResult REVIEW_PRODUCT_HISTORICAL([FromQuery] string[] p_partNumbers)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_PRODUCT_HISTORICAL", connection))
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

                    using (var command = new OracleCommand("SP_CFG_OUT_PRODUCT_HISTORICAL", connection))
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
                Console.WriteLine($"Error executing SP_CFG_OUT_PRODUCT_HISTORICAL: {ex.Message}");
            }
        }
    }
}
