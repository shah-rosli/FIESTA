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
    public class CfgCompanyCodeController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        public CfgCompanyCodeController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context)
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
                return Ok(_context.V_CFG_COMPANY_CODEs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_COMPANY_CODEs, loadOptions));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/GetHistory/{id}")]
        public ActionResult GetHistory(int id)
        {

            try
            {
                var result = _context.V_CFG_COMPANY_CODE_HIs.Where(x => x.recordKey == id).ToList();

                var result_2 = from cfg in result
                               select new
                               {
                                   CFG_COMPANY_CODE_HIS_ID = cfg.CFG_COMPANY_CODE_HIS_ID,
                                   updateDateAndTime = cfg.CFG_COMPANY_CODE_HIS_DATE,
                                   CFG_COMPANY_CODE_HIS_USERID = cfg.CFG_COMPANY_CODE_HIS_USERID,
                                   CFG_COMPANY_CODE_HIS_DELEGATE = cfg.CFG_COMPANY_CODE_HIS_DELEGATE,
                                   recordKey = cfg.recordKey,
                                   companyCode = cfg.companyCode,
                                   companyName = cfg.companyName,
                                   city = cfg.city,
                                   countryRegionKey = cfg.countryRegionKey,
                                   currency = cfg.currency,
                                   languageKey = cfg.languageKey,
                                   chartOfAccounts = cfg.chartOfAccounts,
                                   maxExchangeRateDeviation = cfg.maxExchangeRateDeviation,
                                   fiscalYearVariant = cfg.fiscalYearVariant,
                                   coArea = cfg.coArea,
                                   company = cfg.company,
                                   address = cfg.address,
                                   vatRegistrationNo = cfg.vatRegistrationNo,
                                   fmArea = cfg.fmArea,
                                   projectCashMgmtActive = cfg.projectCashMgmtActive,
                                   cshBdgtMgtActive = cfg.cshBdgtMgtActive,
                                   updateFM = cfg.updateFM,
                                   jurisdictionCode = cfg.jurisdictionCode,
                                   fdsCtrActiveInHR = cfg.fdsCtrActiveInHR,
                                   template = cfg.template,
                                   transitPlant = cfg.transitPlant,
                                   documentEntryScreenVariant = cfg.documentEntryScreenVariant,
                                   cashManagementCompanyCode = cfg.cashManagementCompanyCode,
                                   cashManagementActivated = cfg.cashManagementActivated,
                                   defineDefaultValueDate = cfg.defineDefaultValueDate,
                                   discountBaseIsNetValue = cfg.discountBaseIsNetValue,
                                   creditControlArea = cfg.creditControlArea,
                                   taxBaseIsNetValue = cfg.taxBaseIsNetValue,
                                   sampleAcctRulesVar = cfg.sampleAcctRulesVar,
                                   businessAreaFinStatements = cfg.businessAreaFinStatements,
                                   proposeFiscalYear = cfg.proposeFiscalYear,
                                   postTranslation = cfg.postTranslation,
                                   companyCodeIsProductive = cfg.companyCodeIsProductive,
                                   purchaseAccountProcessing = cfg.purchaseAccountProcessing,
                                   jvAccountingActive = cfg.jvAccountingActive,
                                   financialAssetsMgmtActive = cfg.financialAssetsMgmtActive,
                                   noExchRateDiffWhenClearingInLC = cfg.noExchRateDiffWhenClearingInLC,
                                   updateMMInCMF = cfg.updateMMInCMF,
                                   updateSDInCMF = cfg.updateSDInCMF,
                                   externalCoCode = cfg.externalCoCode,
                                   originalKey = cfg.originalKey,
                                   alternativeCOA = cfg.alternativeCOA,
                                   taxesOnSlsPurc = cfg.taxesOnSlsPurc,
                                   globalCoCde = cfg.globalCoCde,
                                   fieldStatusVariant = cfg.fieldStatusVariant,
                                   pstngPeriodVariant = cfg.pstngPeriodVariant,
                                   hedgeRequestActive = cfg.hedgeRequestActive,
                                   taxCrcyTranslation = cfg.taxCrcyTranslation,
                                   workflowVariant = cfg.workflowVariant,
                                   inventoryManagement = cfg.inventoryManagement,
                                   poSchedulingAgmt = cfg.poSchedulingAgmt,
                                   purchaseRequisition = cfg.purchaseRequisition,
                                   contract = cfg.contract,
                                   taxDetermwithDocDate = cfg.taxDetermwithDocDate,
                                   inputTaxCode = cfg.inputTaxCode,
                                   outputTaxCode = cfg.outputTaxCode,
                                   importDataInPurchaseOrder = cfg.importDataInPurchaseOrder,
                                   negativePostingsPermitted = cfg.negativePostingsPermitted,
                                   controlAreaCanBeInput = cfg.controlAreaCanBeInput,
                                   extendedWithholdingTaxActive = cfg.extendedWithholdingTaxActive,
                                   postingDateForParking = cfg.postingDateForParking,
                                   inflationMethod = cfg.inflationMethod,
                                   fundsReservationFieldStatusVariant = cfg.fundsReservationFieldStatusVariant,
                                   copyingControlGoodsReceipt = cfg.copyingControlGoodsReceipt,
                                   importDataGoodsReceipt = cfg.importDataGoodsReceipt,
                                   methodOffsttngAcct = cfg.methodOffsttngAcct,
                                   baVariant = cfg.baVariant,
                                   costOfSalesAccountingActv = cfg.costOfSalesAccountingActv,
                                   acctsRecblePledActive = cfg.acctsRecblePledActive,
                                   enableAmountSplit = cfg.enableAmountSplit,
                                   surchargeMethod = cfg.surchargeMethod,
                                   documentTypeForProvisionsForTaxes = cfg.documentTypeForProvisionsForTaxes,
                                   documentTypeForJVAmountCorrection = cfg.documentTypeForJVAmountCorrection,
                                   documentTypeForJVTaxCode = cfg.documentTypeForJVTaxCode,
                                   remittanceChallanDocumentType = cfg.remittanceChallanDocumentType,
                                   deferredTaxRule = cfg.deferredTaxRule,
                                   taxReportingDateActive = cfg.taxReportingDateActive,
                                   managePostingPeriodForCoCodeLedger = cfg.managePostingPeriodForCoCodeLedger,
                                   shoppingCart = cfg.shoppingCart,
                                   hideEntryInInputHelp = cfg.hideEntryInInputHelp,
                                   activateAADerivation = cfg.activateAADerivation,

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
        public IActionResult Post([FromBody] RAW_CFG_COMPANY_CODE cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                //var cfg = JsonConvert.DeserializeObject<RAW_CFG_COMPANY_CODE>(Uri.UnescapeDataString(values));
                // load product requests from excel file
                List<RAW_CFG_COMPANY_CODE> excelList = new List<RAW_CFG_COMPANY_CODE>();
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
        public IActionResult Put([FromBody] RAW_CFG_COMPANY_CODE cfg)
        {
            //get the token
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn req = new JsonReturn();

            try
            {
                List<RAW_CFG_COMPANY_CODE> excelList = new List<RAW_CFG_COMPANY_CODE>();
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
                    List<RAW_CFG_COMPANY_CODE> excelList = ExcelImporter.Import<RAW_CFG_COMPANY_CODE>(upload.OpenReadStream());

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

        private JsonReturn Validate(List<RAW_CFG_COMPANY_CODE> excelList, TokenProperties token)
        {
            JsonReturn req = new JsonReturn();

            try
            {
                BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());
                bool allowContinue = false;

                DataTable dt = DataConverter.ListToDataTable<RAW_CFG_COMPANY_CODE>(excelList, token.USER_ID, "Insert", 0, 1);
                //remove validFromDate column
                //DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "applicationLevel1Code", "applicationLevel1Name", "deleteFlag", "insertOrUpdate", "haveError", "errorMessage", "haveDifference");

                DataTable dtForBulkInsert = dt.DefaultView.ToTable(false, "createdBy", "companyCode", "companyName", "city", "countryRegionKey", 
                    "currency", "languageKey", "chartOfAccounts", "maxExchangeRateDeviation", "fiscalYearVariant", 
                    "coArea", "company", "address", "vatRegistrationNo", "fmArea", 
                    "projectCashMgmtActive", "cshBdgtMgtActive", "updateFM", "jurisdictionCode", "fdsCtrActiveInHR", 
                    "template", "transitPlant", "documentEntryScreenVariant", "cashManagementCompanyCode", "cashManagementActivated", 
                    "defineDefaultValueDate", "discountBaseIsNetValue", "creditControlArea", "taxBaseIsNetValue", "sampleAcctRulesVar", 
                    "businessAreaFinStatements", "proposeFiscalYear", "postTranslation", "companyCodeIsProductive", "purchaseAccountProcessing", 
                    "jvAccountingActive", "financialAssetsMgmtActive", "noExchRateDiffWhenClearingInLC", "updateMMInCMF", "updateSDInCMF", 
                    "externalCoCode", "originalKey", "alternativeCOA", "taxesOnSlsPurc", "globalCoCde", 
                    "fieldStatusVariant", "pstngPeriodVariant", "hedgeRequestActive", "taxCrcyTranslation", "workflowVariant", 
                    "inventoryManagement", "poSchedulingAgmt", "purchaseRequisition", "contract", "taxDetermwithDocDate", 
                    "inputTaxCode", "outputTaxCode", "importDataInPurchaseOrder", "negativePostingsPermitted", "controlAreaCanBeInput", 
                    "extendedWithholdingTaxActive", "postingDateForParking", "inflationMethod", "fundsReservationFieldStatusVariant", "copyingControlGoodsReceipt", 
                    "importDataGoodsReceipt", "methodOffsttngAcct", "baVariant", "costOfSalesAccountingActv", "acctsRecblePledActive", 
                    "enableAmountSplit", "surchargeMethod", "documentTypeForProvisionsForTaxes", "documentTypeForJVAmountCorrection", "documentTypeForJVTaxCode", 
                    "remittanceChallanDocumentType", "deferredTaxRule", "taxReportingDateActive", "managePostingPeriodForCoCodeLedger", "shoppingCart", 
                    "hideEntryInInputHelp", "activateAADerivation", "activeFlag", "insertOrUpdate", "haveError", 
                    "errorMessage", "haveDifference"
                );

                //delete raw table before bulk import
                DatabaseOperationStatus dbStatus = biOperation.TruncateTable("RAW_CFG_COMPANY_CODE", token.USER_ID);
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
                    dbStatus = biOperation.ExecuteStoredProcedure("SP_VALIDATE_RAW_CFG_COMPANY_CODE", token.USER_ID);
                    allowContinue = dbStatus.isSuccessful;
                }
                else
                {
                    req.ErrorMsg += dbStatus.message + "\n";
                }

                List<CfgBulkImport> validateResult = new List<CfgBulkImport>();

                List<RAW_CFG_COMPANY_CODE> raws = _context.RAW_CFG_COMPANY_CODEs.Where(x => x.createdBy == token.USER_ID).ToList();
                int count = 1;
                foreach (RAW_CFG_COMPANY_CODE raw in raws)
                {
                    validateResult.Add(new CfgBulkImport()
                    {
                        id = count++,
                        bulkImportObj = new
                        {
                            recordKey = raw.recordKey,
                            companyCode = raw.companyCode,
                            companyName = raw.companyName,
                            city = raw.city,
                            countryRegionKey = raw.countryRegionKey,
                            currency = raw.currency,
                            languageKey = raw.languageKey,
                            chartOfAccounts = raw.chartOfAccounts,
                            maxExchangeRateDeviation = raw.maxExchangeRateDeviation,
                            fiscalYearVariant = raw.fiscalYearVariant,
                            coArea = raw.coArea,
                            company = raw.company,
                            address = raw.address,
                            vatRegistrationNo = raw.vatRegistrationNo,
                            fmArea = raw.fmArea,
                            projectCashMgmtActive = raw.projectCashMgmtActive,
                            cshBdgtMgtActive = raw.cshBdgtMgtActive,
                            updateFM = raw.updateFM,
                            jurisdictionCode = raw.jurisdictionCode,
                            fdsCtrActiveInHR = raw.fdsCtrActiveInHR,
                            template = raw.template,
                            transitPlant = raw.transitPlant,
                            documentEntryScreenVariant = raw.documentEntryScreenVariant,
                            cashManagementCompanyCode = raw.cashManagementCompanyCode,
                            cashManagementActivated = raw.cashManagementActivated,
                            defineDefaultValueDate = raw.defineDefaultValueDate,
                            discountBaseIsNetValue = raw.discountBaseIsNetValue,
                            creditControlArea = raw.creditControlArea,
                            taxBaseIsNetValue = raw.taxBaseIsNetValue,
                            sampleAcctRulesVar = raw.sampleAcctRulesVar,
                            businessAreaFinStatements = raw.businessAreaFinStatements,
                            proposeFiscalYear = raw.proposeFiscalYear,
                            postTranslation = raw.postTranslation,
                            companyCodeIsProductive = raw.companyCodeIsProductive,
                            purchaseAccountProcessing = raw.purchaseAccountProcessing,
                            jvAccountingActive = raw.jvAccountingActive,
                            financialAssetsMgmtActive = raw.financialAssetsMgmtActive,
                            noExchRateDiffWhenClearingInLC = raw.noExchRateDiffWhenClearingInLC,
                            updateMMInCMF = raw.updateMMInCMF,
                            updateSDInCMF = raw.updateSDInCMF,
                            externalCoCode = raw.externalCoCode,
                            originalKey = raw.originalKey,
                            alternativeCOA = raw.alternativeCOA,
                            taxesOnSlsPurc = raw.taxesOnSlsPurc,
                            globalCoCde = raw.globalCoCde,
                            fieldStatusVariant = raw.fieldStatusVariant,
                            pstngPeriodVariant = raw.pstngPeriodVariant,
                            hedgeRequestActive = raw.hedgeRequestActive,
                            taxCrcyTranslation = raw.taxCrcyTranslation,
                            workflowVariant = raw.workflowVariant,
                            inventoryManagement = raw.inventoryManagement,
                            poSchedulingAgmt = raw.poSchedulingAgmt,
                            purchaseRequisition = raw.purchaseRequisition,
                            contract = raw.contract,
                            taxDetermwithDocDate = raw.taxDetermwithDocDate,
                            inputTaxCode = raw.inputTaxCode,
                            outputTaxCode = raw.outputTaxCode,
                            importDataInPurchaseOrder = raw.importDataInPurchaseOrder,
                            negativePostingsPermitted = raw.negativePostingsPermitted,
                            controlAreaCanBeInput = raw.controlAreaCanBeInput,
                            extendedWithholdingTaxActive = raw.extendedWithholdingTaxActive,
                            postingDateForParking = raw.postingDateForParking,
                            inflationMethod = raw.inflationMethod,
                            fundsReservationFieldStatusVariant = raw.fundsReservationFieldStatusVariant,
                            copyingControlGoodsReceipt = raw.copyingControlGoodsReceipt,
                            importDataGoodsReceipt = raw.importDataGoodsReceipt,
                            methodOffsttngAcct = raw.methodOffsttngAcct,
                            baVariant = raw.baVariant,
                            costOfSalesAccountingActv = raw.costOfSalesAccountingActv,
                            acctsRecblePledActive = raw.acctsRecblePledActive,
                            enableAmountSplit = raw.enableAmountSplit,
                            surchargeMethod = raw.surchargeMethod,
                            documentTypeForProvisionsForTaxes = raw.documentTypeForProvisionsForTaxes,
                            documentTypeForJVAmountCorrection = raw.documentTypeForJVAmountCorrection,
                            documentTypeForJVTaxCode = raw.documentTypeForJVTaxCode,
                            remittanceChallanDocumentType = raw.remittanceChallanDocumentType,
                            deferredTaxRule = raw.deferredTaxRule,
                            taxReportingDateActive = raw.taxReportingDateActive,
                            managePostingPeriodForCoCodeLedger = raw.managePostingPeriodForCoCodeLedger,
                            shoppingCart = raw.shoppingCart,
                            hideEntryInInputHelp = raw.hideEntryInInputHelp,
                            activateAADerivation = raw.activateAADerivation,

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
            List<RAW_CFG_COMPANY_CODE> master = new List<RAW_CFG_COMPANY_CODE>();
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            List<CfgBulkImport> validateResult = new List<CfgBulkImport>();
            List<RAW_CFG_COMPANY_CODE> raws = _context.RAW_CFG_COMPANY_CODEs.Where(x => x.createdBy == token.USER_ID).ToList();
            int count = 1;
            foreach (RAW_CFG_COMPANY_CODE raw in raws)
            {
                validateResult.Add(new CfgBulkImport()
                {
                    id = count++,
                    bulkImportObj = new
                    {
                        recordKey = raw.recordKey,
                        companyCode = raw.companyCode,
                        companyName = raw.companyName,
                        city = raw.city,
                        countryRegionKey = raw.countryRegionKey,
                        currency = raw.currency,
                        languageKey = raw.languageKey,
                        chartOfAccounts = raw.chartOfAccounts,
                        maxExchangeRateDeviation = raw.maxExchangeRateDeviation,
                        fiscalYearVariant = raw.fiscalYearVariant,
                        coArea = raw.coArea,
                        company = raw.company,
                        address = raw.address,
                        vatRegistrationNo = raw.vatRegistrationNo,
                        fmArea = raw.fmArea,
                        projectCashMgmtActive = raw.projectCashMgmtActive,
                        cshBdgtMgtActive = raw.cshBdgtMgtActive,
                        updateFM = raw.updateFM,
                        jurisdictionCode = raw.jurisdictionCode,
                        fdsCtrActiveInHR = raw.fdsCtrActiveInHR,
                        template = raw.template,
                        transitPlant = raw.transitPlant,
                        documentEntryScreenVariant = raw.documentEntryScreenVariant,
                        cashManagementCompanyCode = raw.cashManagementCompanyCode,
                        cashManagementActivated = raw.cashManagementActivated,
                        defineDefaultValueDate = raw.defineDefaultValueDate,
                        discountBaseIsNetValue = raw.discountBaseIsNetValue,
                        creditControlArea = raw.creditControlArea,
                        taxBaseIsNetValue = raw.taxBaseIsNetValue,
                        sampleAcctRulesVar = raw.sampleAcctRulesVar,
                        businessAreaFinStatements = raw.businessAreaFinStatements,
                        proposeFiscalYear = raw.proposeFiscalYear,
                        postTranslation = raw.postTranslation,
                        companyCodeIsProductive = raw.companyCodeIsProductive,
                        purchaseAccountProcessing = raw.purchaseAccountProcessing,
                        jvAccountingActive = raw.jvAccountingActive,
                        financialAssetsMgmtActive = raw.financialAssetsMgmtActive,
                        noExchRateDiffWhenClearingInLC = raw.noExchRateDiffWhenClearingInLC,
                        updateMMInCMF = raw.updateMMInCMF,
                        updateSDInCMF = raw.updateSDInCMF,
                        externalCoCode = raw.externalCoCode,
                        originalKey = raw.originalKey,
                        alternativeCOA = raw.alternativeCOA,
                        taxesOnSlsPurc = raw.taxesOnSlsPurc,
                        globalCoCde = raw.globalCoCde,
                        fieldStatusVariant = raw.fieldStatusVariant,
                        pstngPeriodVariant = raw.pstngPeriodVariant,
                        hedgeRequestActive = raw.hedgeRequestActive,
                        taxCrcyTranslation = raw.taxCrcyTranslation,
                        workflowVariant = raw.workflowVariant,
                        inventoryManagement = raw.inventoryManagement,
                        poSchedulingAgmt = raw.poSchedulingAgmt,
                        purchaseRequisition = raw.purchaseRequisition,
                        contract = raw.contract,
                        taxDetermwithDocDate = raw.taxDetermwithDocDate,
                        inputTaxCode = raw.inputTaxCode,
                        outputTaxCode = raw.outputTaxCode,
                        importDataInPurchaseOrder = raw.importDataInPurchaseOrder,
                        negativePostingsPermitted = raw.negativePostingsPermitted,
                        controlAreaCanBeInput = raw.controlAreaCanBeInput,
                        extendedWithholdingTaxActive = raw.extendedWithholdingTaxActive,
                        postingDateForParking = raw.postingDateForParking,
                        inflationMethod = raw.inflationMethod,
                        fundsReservationFieldStatusVariant = raw.fundsReservationFieldStatusVariant,
                        copyingControlGoodsReceipt = raw.copyingControlGoodsReceipt,
                        importDataGoodsReceipt = raw.importDataGoodsReceipt,
                        methodOffsttngAcct = raw.methodOffsttngAcct,
                        baVariant = raw.baVariant,
                        costOfSalesAccountingActv = raw.costOfSalesAccountingActv,
                        acctsRecblePledActive = raw.acctsRecblePledActive,
                        enableAmountSplit = raw.enableAmountSplit,
                        surchargeMethod = raw.surchargeMethod,
                        documentTypeForProvisionsForTaxes = raw.documentTypeForProvisionsForTaxes,
                        documentTypeForJVAmountCorrection = raw.documentTypeForJVAmountCorrection,
                        documentTypeForJVTaxCode = raw.documentTypeForJVTaxCode,
                        remittanceChallanDocumentType = raw.remittanceChallanDocumentType,
                        deferredTaxRule = raw.deferredTaxRule,
                        taxReportingDateActive = raw.taxReportingDateActive,
                        managePostingPeriodForCoCodeLedger = raw.managePostingPeriodForCoCodeLedger,
                        shoppingCart = raw.shoppingCart,
                        hideEntryInInputHelp = raw.hideEntryInInputHelp,
                        activateAADerivation = raw.activateAADerivation,

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

                DatabaseOperationStatus dbStatus = biOperation.ExecuteStoredProcedure("SP_RAW_TO_CFG_COMPANY_CODE", token.USER_ID);
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
                return Ok(_context.V_CFG_COMPANY_CODEs.Where(x => x.reviewStatus == "Pending Review" && x.deleteFlag != "Y"));
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_CFG_COMPANY_CODEs.Where(x => x.reviewStatus == "Pending Review" && x.deleteFlag != "Y"), loadOptions));
            }
        }


        [Authorize]
        [Route("api/REVIEW_COMPANY_CODE")]
        [HttpPost]
        public IActionResult REVIEW_COMPANY_CODE([FromQuery] string[] p_companyCodes)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_REVIEW_CFG_COMPANY_CODE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_companyCodes", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_companyCodes,
                            Size = p_companyCodes.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_companyCodes.Select(s => s.Length).ToArray()
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

                        return Ok(new { p_companyCodes, Result = result });
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

                    using (var command = new OracleCommand("SP_CFG_OUT_COMPANY_CODE", connection))
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
                Console.WriteLine($"Error executing SP_CFG_OUT_COMPANY_CODE: {ex.Message}");
            }
        }
    }
}
