using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Linq;
using System.Security.Claims;
using UtilityCore.Utility.BulkImport;

namespace FIESTA_Backend.Controllers.MDM
{
    public class MdmController : Controller
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly MDMDbContext _context;

        private IServiceScopeFactory _scopeFactory;

        public MdmController(IConfiguration config, IHttpContextAccessor httpContextAccessor, MDMDbContext context, IServiceScopeFactory scopeFactory)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _scopeFactory = scopeFactory;
        }

        [Authorize]
        [Route("api/Out_Cus_Bill_ToUI")]
        [HttpGet]
        public IActionResult Out_Cus_Bill_ToUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_CUS_BILL_TOs.ToList<V_OUT_CUS_BILL_TO>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_CUS_BILL_TOs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Cus_Ship_ToUI")]
        [HttpGet]
        public IActionResult Out_Cus_Ship_ToUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_CUS_SHIP_TOs.ToList<V_OUT_CUS_SHIP_TO>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_CUS_SHIP_TOs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Cus_Sold_ToUI")]
        [HttpGet]
        public IActionResult Out_Cus_Sold_ToUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_CUS_SOLD_TOs.ToList<V_OUT_CUS_SOLD_TO>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_CUS_SOLD_TOs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Cus_End_CustomerUI")]
        [HttpGet]
        public IActionResult Out_Cus_End_CustomerUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_CUS_END_CUSTOMERs.ToList<V_OUT_CUS_END_CUSTOMER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_CUS_END_CUSTOMERs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Cus_Partner_FunctionUI")]
        [HttpGet]
        public IActionResult Out_Cus_Partner_FunctionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_CUS_PARTNER_FUNCTIONs.ToList<V_OUT_CUS_PARTNER_FUNCTION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_CUS_PARTNER_FUNCTIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Fin_Cost_CenterUI")]
        [HttpGet]
        public IActionResult Out_Fin_Cost_CenterUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_FIN_COST_CENTERs.ToList<V_OUT_FIN_COST_CENTER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_FIN_COST_CENTERs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Fin_IP_CustomerUI")]
        [HttpGet]
        public IActionResult Out_Fin_IP_CustomerUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_FIN_IP_CUSTOMERs.ToList<V_OUT_FIN_IP_CUSTOMER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_FIN_IP_CUSTOMERs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Fin_IP_OPNUI")]
        [HttpGet]
        public IActionResult Out_Fin_IP_OPNUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_FIN_IP_OPNs.ToList<V_OUT_FIN_IP_OPN>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_FIN_IP_OPNs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_App_Application1UI")]
        [HttpGet]
        public IActionResult Out_App_Application1UI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_APP_APPLICATION1s.ToList<V_OUT_APP_APPLICATION1>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_APP_APPLICATION1s, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_App_Application2UI")]
        [HttpGet]
        public IActionResult Out_App_Application2UI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_APP_APPLICATION2s.ToList<V_OUT_APP_APPLICATION2>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_APP_APPLICATION2s, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_App_Application3UI")]
        [HttpGet]
        public IActionResult Out_App_Application3UI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_APP_APPLICATION3s.ToList<V_OUT_APP_APPLICATION3>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_APP_APPLICATION3s, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_HistoricalUI")]
        [HttpGet]
        public IActionResult Out_Product_HistoricalUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_HISTORICALs.ToList<V_OUT_PRODUCT_HISTORICAL>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_HISTORICALs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_Sales_Root_PartNumberUI")]
        [HttpGet]
        public IActionResult Out_Product_Sales_Root_PartNumberUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_SALES_ROOT_PARTNUMBERs.ToList<V_OUT_PRODUCT_SALES_ROOT_PARTNUMBER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_SALES_ROOT_PARTNUMBERs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_LineUI")]
        [HttpGet]
        public IActionResult Out_Product_LineUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_LINEs.ToList<V_OUT_PRODUCT_LINE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_LINEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_TypeUI")]
        [HttpGet]
        public IActionResult Out_Product_TypeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_TYPEs.ToList<V_OUT_PRODUCT_TYPE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_TYPEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_ECCN_ConversionUI")]
        [HttpGet]
        public IActionResult Out_Product_ECCN_ConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_ECCN_CONVERSIONs.ToList<V_OUT_PRODUCT_ECCN_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_ECCN_CONVERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_HS_ConversionUI")]
        [HttpGet]
        public IActionResult Out_Product_HS_ConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_HS_CONVERSIONs.ToList<V_OUT_PRODUCT_HS_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_HS_CONVERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Production_Group_StageUI")]
        [HttpGet]
        public IActionResult MDM_Production_Group_StageUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PRODUCTION_GROUP_STAGEs.ToList<V_MDM_PRODUCTION_GROUP_STAGE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PRODUCTION_GROUP_STAGEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Production_Group_Stage_ConversionUI")]
        [HttpGet]
        public IActionResult MDM_Production_Group_Stage_ConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.ToList<V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Production_Plant_ConversionUI")]
        [HttpGet]
        public IActionResult MDM_Production_Plant_ConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PRODUCTION_PLANT_CONVERSIONs.ToList<V_MDM_PRODUCTION_PLANT_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PRODUCTION_PLANT_CONVERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Storage_LocationUI")]
        [HttpGet]
        public IActionResult MDM_Storage_LocationUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_STORAGE_LOCATIONs.ToList<V_MDM_STORAGE_LOCATION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_STORAGE_LOCATIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_PlantsUI")]
        [HttpGet]
        public IActionResult MDM_PlantsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PLANTs.ToList<V_MDM_PLANT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PLANTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Company_CodeUI")]
        [HttpGet]
        public IActionResult MDM_Company_CodeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_COMPANY_CODEs.ToList<V_MDM_COMPANY_CODE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_COMPANY_CODEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_Standard_CostUI")]
        [HttpGet]
        public IActionResult Out_Product_Standard_CostUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_STANDARD_COSTs.ToList<V_OUT_PRODUCT_STANDARD_COST>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_STANDARD_COSTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_Wip_Sell_PriceUI")]
        [HttpGet]
        public IActionResult Out_Product_Wip_Sell_PriceUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_WIP_SELL_PRICEs.ToList<V_OUT_PRODUCT_WIP_SELL_PRICE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_WIP_SELL_PRICEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Ven_VendorUI")]
        [HttpGet]
        public IActionResult Out_Ven_VendorUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_VEN_VENDORs.ToList<V_OUT_VEN_VENDOR>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_VEN_VENDORs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Ven_Vendor_CompanyUI")]
        [HttpGet]
        public IActionResult Out_Ven_Vendor_CompanyUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_VEN_VENDOR_COMPANies.ToList<V_OUT_VEN_VENDOR_COMPANY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_VEN_VENDOR_COMPANies, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Ven_Vendor_Purchase_Info_RecUI")]
        [HttpGet]
        public IActionResult Out_Ven_Vendor_Purchase_Info_RecUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_VEN_VENDOR_PURCHASE_INFO_RECs.ToList<V_OUT_VEN_VENDOR_PURCHASE_INFO_REC>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_VEN_VENDOR_PURCHASE_INFO_RECs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_Product_Can_FlagS4UI")]
        [HttpGet]
        public IActionResult Out_Product_Can_FlagS4UI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_CAN_FLAGS4s.ToList<V_OUT_PRODUCT_CAN_FLAGS4>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_CAN_FLAGS4s, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Profit_CenterUI")]
        [HttpGet]
        public IActionResult MDM_Profit_CenterUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PROFIT_CENTERs.ToList<V_MDM_PROFIT_CENTER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PROFIT_CENTERs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_profit_Center_HierarchyUI")]
        [HttpGet]
        public IActionResult MDM_profit_Center_HierarchyUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PROFIT_CENTER_HIERARCHies.ToList<V_MDM_PROFIT_CENTER_HIERARCHY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PROFIT_CENTER_HIERARCHies, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Product_HierarchyUI")]
        [HttpGet]
        public IActionResult MDM_Product_HierarchyUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PRODUCT_HIERARCHies.ToList<V_MDM_PRODUCT_HIERARCHY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PRODUCT_HIERARCHies, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDM_Product_Hierarchy_Profitcenter_ConversionUI")]
        [HttpGet]
        public IActionResult MDM_Product_Hierarchy_Profitcenter_ConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs.ToList<V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_NonProduction_ProductUI")]
        [HttpGet]
        public IActionResult Out_NonProduction_ProductUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_NONPRODUCTION_PRODUCTs.ToList<V_OUT_NONPRODUCTION_PRODUCT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_NONPRODUCTION_PRODUCTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_NonProduction_Product_PlantUI")]
        [HttpGet]
        public IActionResult Out_NonProduction_Product_PlantUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_NONPRODUCTION_PRODUCT_PLANTs.ToList<V_OUT_NONPRODUCTION_PRODUCT_PLANT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_NONPRODUCTION_PRODUCT_PLANTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/Out_NonProduction_Product_SalesUI")]
        [HttpGet]
        public IActionResult Out_NonProduction_Product_SalesUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_NONPRODUCTION_PRODUCT_SALEs.ToList<V_OUT_NONPRODUCTION_PRODUCT_SALE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_NONPRODUCTION_PRODUCT_SALEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/OutProductConsolidateUI")]
        [HttpGet]
        public IActionResult OutProductConsolidateUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_OUT_PRODUCT_CONSOLIDATEs.ToList<V_OUT_PRODUCT_CONSOLIDATE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_OUT_PRODUCT_CONSOLIDATEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/OutProductPlantConsolidateUI")]
        [HttpGet]
        public IActionResult OutProductPlantConsolidateUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MV_OUT_PRODUCT_PLANT_CONSOLIDATEs.ToList<MV_OUT_PRODUCT_PLANT_CONSOLIDATE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MV_OUT_PRODUCT_PLANT_CONSOLIDATEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/OutProductSalesConsolidateUI")]
        [HttpGet]
        public IActionResult OutProductSalesConsolidateUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MV_OUT_PRODUCT_SALES_CONSOLIDATEs.ToList<MV_OUT_PRODUCT_SALES_CONSOLIDATE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MV_OUT_PRODUCT_SALES_CONSOLIDATEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MDMGLMSLOCPlantCompanyUI")]
        [HttpGet]
        public IActionResult MDMGLMSLOCPlantCompanyUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_GLM_SLOC_PLANT_COMPANies.ToList<V_GLM_SLOC_PLANT_COMPANY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_GLM_SLOC_PLANT_COMPANies, loadOptions));
            }

            //var data = _context.V_GLM_SLOC_PLANT_COMPANies
            //.Select((x, index) => new
            //{
            //    recordKey = x.recordKey_sloc,
            //    x.alternativeCOA_co,
            //    x.taxesOnSlsPurc_co,
            //    x.globalCoCde_co,
            //    x.fieldStatusVariant_co,
            //    x.pstngPeriodVariant_co,
            //    x.hedgeRequestActive_co,
            //    x.taxCrcyTranslation_co,
            //    x.workflowVariant_co,
            //    x.inventoryManagement_co,
            //    x.poSchedulingAgmt_co,
            //    x.purchaseRequisition_co,
            //    x.contract_co,
            //    x.taxDetermwithDocDate_co,
            //    x.inputTaxCode_co,
            //    x.outputTaxCode_co,
            //    x.importDataInPurchaseOrder_co,
            //    x.negativePostingsPermitted_co,
            //    x.controlAreaCanBeInput_co,
            //    x.extendedWithholdingTaxActive_co,
            //    x.postingDateForParking_co,
            //    x.inflationMethod_co,
            //    x.fundsReservationFieldStatusVariant_co,
            //    x.copyingControlGoodsReceipt_co,
            //    x.importDataGoodsReceipt_co,
            //    x.methodOffsttngAcct_co,
            //    x.baVariant_co,
            //    x.costOfSalesAccountingActv_co,
            //    x.acctsRecblePledActive_co,
            //    x.enableAmountSplit_co,
            //    x.surchargeMethod_co,
            //    x.documentTypeForProvisionsForTaxes_co,
            //    x.documentTypeForJVAmountCorrection_co,
            //    x.documentTypeForJVTaxCode_co,
            //    x.remittanceChallanDocumentType_co,
            //    x.deferredTaxRule_co,
            //    x.taxReportingDateActive_co,
            //    x.managePostingPeriodForCoCodeLedger_co,
            //    x.shoppingCart_co,
            //    x.hideEntryInInputHelp_co,
            //    x.activateAADerivation_co,
            //    x.activeFlag_co,
            //    x.createDateAndTime_co,
            //    x.updateDateAndTime_co,
            //    x.updateType_co,
            //    x.deleteFlag_co,
            //    x.deleteDateAndTime_co,
            //    x.processStatus_co,
            //    x.updateDateAndTime_max,
            //    x.recordKey_sloc,
            //    x.plant_sloc,
            //    x.storageLocation_sloc,
            //    x.descrOfStorageLoc_sloc,
            //    x.division_sloc,
            //    x.negStocksInSLoc_sloc,
            //    x.freezeBookInvSLoc_sloc,
            //    x.sLocMRPIndicator_sloc,
            //    x.authorizationCheck_sloc,
            //    x.storageResource_sloc,
            //    x.huReqmnt_sloc,
            //    x.partnerStorLoc_sloc,
            //    x.salesOrganization_sloc,
            //    x.distributionChannel_sloc,
            //    x.shippingPointReceivingPt_sloc,
            //    x.supplier_sloc,
            //    x.customer_sloc,
            //    x.businessSystemOfMES_sloc,
            //    x.inventoryManagementType_sloc,
            //    x.validity_sloc,
            //    x.licenseNumber_sloc,
            //    x.inTransitAssignment_sloc,
            //    x.tankAssgn_sloc,
            //    x.storageLocationType_sloc,
            //    x.countryCode_sloc,
            //    x.region_sloc,
            //    x.timeZone_sloc,
            //    x.glmPlantCode_sloc,
            //    x.activeFlag_sloc,
            //    x.createDateAndTime_sloc,
            //    x.updateDateAndTime_sloc,
            //    x.updateType_sloc,
            //    x.deleteFlag_sloc,
            //    x.deleteDateAndTime_sloc,
            //    x.processStatus_sloc,
            //    x.recordKey_plant,
            //    x.plant_plant,
            //    x.name1_plant,
            //    x.valuationArea_plant,
            //    x.customerNumberOfPlant_plant,
            //    x.supplierNumberOfPlant_plant,
            //    x.factoryCalendar_plant,
            //    x.name2_plant,
            //    x.streetAndHouseNumber_plant,
            //    x.poBox_plant,
            //    x.postalCode_plant,
            //    x.city_plant,
            //    x.purchOrganization_plant,
            //    x.salesOrganization_plant,
            //    x.batchStatusMgmt_plant,
            //    x.condsAtPlantLevel_plant,
            //    x.sourceList_plant,
            //    x.reqmtsPlanning_plant,
            //    x.countryRegionKey_plant,
            //    x.region_plant,
            //    x.countyCode_plant,
            //    x.cityCode_plant,
            //    x.address_plant,
            //    x.planningPlant_plant,
            //    x.taxJurisdiction_plant,
            //    x.distribchannel_plant,
            //    x.intCOBillingDiv_plant,
            //    x.languageKey_plant,
            //    x.sopPlant_plant,
            //    x.varianceKey_plant,
            //    x.batchStatusMgmtOld_plant,
            //    x.plantCat_plant,
            //    x.salesDistrict_plant,
            //    x.supplyRegion_plant,
            //    x.taxIndicatorPlant_plant,
            //    x.regularSupplier_plant,
            //    x.firstReminderExped_plant,
            //    x.secondReminderExped_plant,
            //    x.thirdReminderExped_plant,
            //    x.text1stDunning_plant,
            //    x.text2ndDunning_plant,
            //    x.text3rdDunning_plant,
            //    x.poTolerance_plant,
            //    x.businessPlace_plant,
            //    x.salesAreaDetrm_plant,
            //    x.distribProfileOfPlant_plant,
            //    x.archivingMarker_plant,
            //    x.batchRecDMSType_plant,
            //    x.nodeTypesupplyChain_plant,
            //    x.namingStructure_plant,
            //    x.costObjControlling_plant,
            //    x.mixedCosting_plant,
            //    x.actualCosting_plant,
            //    x.shippingPointReceivingPt_plant,
            //    x.actualActivitiesUpdated_plant,
            //    x.controlOfCreditOfCostCenters_plant,
            //    x.afSrceDetViaATP_plant,
            //    x.batchManagementNotActiveByDefault_plant,
            //    x.supplyAssignmentARun_plant,
            //    x.seasonActiveInInventoryManagement_plant,
            //    x.controlDataForBOM_plant,
            //    x.activateVariantGrouping_plant,
            //    x.assignBatchesInARun_plant,
            //    x.exchangeValuation_plant,
            //    x.vendorType_plant,
            //    x.credIPI_plant,
            //    x.storeCat_plant,
            //    x.superiorDeptStore_plant,
            //    x.ownership_plant,
            //    x.company_plant,
            //    x.activeFlag_plant,
            //    x.createDateAndTime_plant,
            //    x.updateDateAndTime_plant,
            //    x.updateType_plant,
            //    x.deleteFlag_plant,
            //    x.deleteDateAndTime_plant,
            //    x.processStatus_plant,
            //    x.recordKey_co,
            //    x.companyCode_co,
            //    x.companyName_co,
            //    x.city_co,
            //    x.countryRegionKey_co,
            //    x.currency_co,
            //    x.languageKey_co,
            //    x.chartOfAccounts_co,
            //    x.maxExchangeRateDeviation_co,
            //    x.fiscalYearVariant_co,
            //    x.coArea_co,
            //    x.company_co,
            //    x.address_co,
            //    x.vatRegistrationNo_co,
            //    x.fmArea_co,
            //    x.projectCashMgmtActive_co,
            //    x.cshBdgtMgtActive_co,
            //    x.updateFM_co,
            //    x.jurisdictionCode_co,
            //    x.fdsCtrActiveInHR_co,
            //    x.template_co,
            //    x.transitPlant_co,
            //    x.documentEntryScreenVariant_co,
            //    x.cashManagementCompanyCode_co,
            //    x.cashManagementActivated_co,
            //    x.defineDefaultValueDate_co,
            //    x.discountBaseIsNetValue_co,
            //    x.creditControlArea_co,
            //    x.taxBaseIsNetValue_co,
            //    x.sampleAcctRulesVar_co,
            //    x.businessAreaFinStatements_co,
            //    x.proposeFiscalYear_co,
            //    x.postTranslation_co,
            //    x.companyCodeIsProductive_co,
            //    x.purchaseAccountProcessing_co,
            //    x.jvAccountingActive_co,
            //    x.financialAssetsMgmtActive_co,
            //    x.noExchRateDiffWhenClearingInLC_co,
            //    x.updateMMInCMF_co,
            //    x.updateSDInCMF_co,
            //    x.externalCoCode_co,
            //    x.originalKey_co
            //});

            //return new JsonResult(DataSourceLoader.Load(data, loadOptions));
        }



        [Authorize]
        [Route("api/get_OUT_PRODUCT_CONSOLIDATE_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_CONSOLIDATE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCT_CONSOLIDATEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_PLANT_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_PLANT_processStatus([FromQuery] string processStatus)
        {
            var query = _context.MV_OUT_PRODUCT_PLANT_CONSOLIDATEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_PLANT")]
        [HttpPost]
        public async Task<IActionResult> STATUS_CHANGE_3_OUT_PRODUCT_PLANT([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_PLANT", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
                        };
                        command.Parameters.Add(param);
                        var outputParam = new OracleParameter("p_output_msg", OracleDbType.Varchar2, 4000)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        command.ExecuteNonQuery();
                        string result = outputParam.Value?.ToString();

                        await Refresh_MV_OUT_PRODUCT_PLANT_CONSOLIDATE();

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        private async Task Refresh_MV_OUT_PRODUCT_PLANT_CONSOLIDATE()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<MDMDbContext>();

                await db.Database.ExecuteSqlRawAsync(@"
                    BEGIN
                      DBMS_MVIEW.REFRESH('MV_OUT_PRODUCT_PLANT_CONSOLIDATE');
                    END;
                ");
            }
            catch (Exception ex)
            {
                string exMsg = ex.Message;
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_SALES_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_SALES_processStatus([FromQuery] string processStatus)
        {
            var query = _context.MV_OUT_PRODUCT_SALES_CONSOLIDATEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_SALES")]
        [HttpPost]
        public async Task<IActionResult> STATUS_CHANGE_3_OUT_PRODUCT_SALES([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_SALES", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
                        };
                        command.Parameters.Add(param);
                        var outputParam = new OracleParameter("p_output_msg", OracleDbType.Varchar2, 4000)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        command.ExecuteNonQuery();
                        string result = outputParam.Value?.ToString();

                        await Refresh_MV_OUT_PRODUCT_SALES_CONSOLIDATE();

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        private async Task Refresh_MV_OUT_PRODUCT_SALES_CONSOLIDATE()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<MDMDbContext>();

                await db.Database.ExecuteSqlRawAsync(@"
                    BEGIN
                      DBMS_MVIEW.REFRESH('MV_OUT_PRODUCT_SALES_CONSOLIDATE');
                    END;
                ");
            }
            catch (Exception ex)
            {
                string exMsg = ex.Message;
            }
        }

        [Authorize]
        [Route("api/get_OUT_COMPONENTS_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_COMPONENTS_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_COMPONENTs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_COMPONENTS")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_COMPONENTS([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_COMPONENTS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_VENDOR_CHAR_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_VENDOR_CHAR_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCT_VENDOR_CHARs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_VENDOR_CHAR")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_VENDOR_CHAR([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_VENDOR_CHAR", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_MATRIX_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_MATRIX_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCT_MATRices
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_MATRIX")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_MATRIX([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_MATRIX", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_CAN_FLAGS4_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_CAN_FLAGS4_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_CAN_FLAGS4s
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_CAN_FLAGS4")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_CAN_FLAGS4([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_CAN_FLAGS4", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_ECCN_CONVERSION_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_ECCN_CONVERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_ECCN_CONVERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_ECCN_CONVERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_ECCN_CONVERSION([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_ECCN_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_HS_CONVERSION_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_HS_CONVERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_HS_CONVERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_HS_CONVERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_HS_CONVERSION([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_HS_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_STANDARD_COST_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_STANDARD_COST_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_STANDARD_COSTs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_STANDARD_COST")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_STANDARD_COST([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_STANDARD_COST", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_SALES_ROOT_PARTNUMBER_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_SALES_ROOT_PARTNUMBER_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_SALES_ROOT_PARTNUMBERs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_SALES_ROOT_PARTNUMBER")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_SALES_ROOT_PARTNUMBER([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_SALES_ROOT_PARTNUMBER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_WIP_SELL_PRICE_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_WIP_SELL_PRICE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_WIP_SELL_PRICEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_WIP_SELL_PRICE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_WIP_SELL_PRICE([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_WIP_SELL_PRICE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCT_HIERARCHY_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCT_HIERARCHY_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PRODUCT_HIERARCHies
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY([FromQuery] string[] phCodes)
        {

            if (phCodes == null || phCodes.Length == 0)
            {
                return BadRequest("phCodes is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("phCodes", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = phCodes,
                            Size = phCodes.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = phCodes.Select(s => s.Length).ToArray()
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
                        return Ok(new { phCodes, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION([FromQuery] string[] productHierarchyCodes)
        {

            if (productHierarchyCodes == null || productHierarchyCodes.Length == 0)
            {
                return BadRequest("productHierarchyCodes is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("productHierarchyCodes", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = productHierarchyCodes,
                            Size = productHierarchyCodes.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = productHierarchyCodes.Select(s => s.Length).ToArray()
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
                        return Ok(new { productHierarchyCodes, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_TYPE_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_TYPE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_TYPEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_TYPE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_TYPE([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_TYPE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_LINE_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_LINE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_LINEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_LINE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_LINE([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_LINE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCT_HISTORICAL_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCT_HISTORICAL_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_PRODUCT_HISTORICALs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCT_HISTORICAL")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCT_HISTORICAL([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCT_HISTORICAL", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_BOM_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_BOM_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_BOMs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_BOM")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_BOM([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_BOM", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_ROUTING_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_ROUTING_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_ROUTINGs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_ROUTING_S4_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_ROUTING_S4_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_ROUTING_S4s
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING_S4")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING_S4([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_ROUTING_S4", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_VERSION_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_VERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_VERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_VERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_VERSION([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_VERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_LOTSIZE_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_LOTSIZE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_LOTSIZEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_LOTSIZE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_LOTSIZE([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_LOTSIZE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_YIELD_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_YIELD_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_YIELDs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_YIELD")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_YIELD([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_YIELD", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_LEADTIME_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_LEADTIME_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_LEADTIMEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_LEADTIME")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_LEADTIME([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_LEADTIME", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_PRODUCTION_CYCLETIME_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_PRODUCTION_CYCLETIME_processStatus([FromQuery] string processStatus)
        {
            var query = _context.OUT_PRODUCTION_CYCLETIMEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_PRODUCTION_CYCLETIME")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_PRODUCTION_CYCLETIME([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_PRODUCTION_CYCLETIME", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCTION_STAGE_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCTION_STAGE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.MDM_PRODUCTION_STAGEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCTION_STAGE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCTION_STAGE([FromQuery] string[] stages)
        {

            if (stages == null || stages.Length == 0)
            {
                return BadRequest("stages is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCTION_STAGE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("stages", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = stages,
                            Size = stages.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = stages.Select(s => s.Length).ToArray()
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
                        return Ok(new { stages, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCTION_STAGE_CONVERSION_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCTION_STAGE_CONVERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.MDM_PRODUCTION_STAGE_CONVERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCTION_STAGE_CONVERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCTION_STAGE_CONVERSION([FromQuery] string[] p_sll_s)
        {

            if (p_sll_s == null || p_sll_s.Length == 0)
            {
                return BadRequest("MDM_PRODUCTION_STAGE_CONVERSION parameter is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCTION_STAGE_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("p_sll_s", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_sll_s,
                            Size = p_sll_s.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_sll_s.Select(s => s.Length).ToArray()
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
                        return Ok(new { p_sll_s, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCTION_GROUP_STAGE_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCTION_GROUP_STAGE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PRODUCTION_GROUP_STAGEs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCTION_GROUP_STAGE_CONVERSION_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCTION_GROUP_STAGE_CONVERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE_CONVERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE_CONVERSION([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCTION_GROUP_STAGE_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PRODUCTION_PLANT_CONVERSION_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PRODUCTION_PLANT_CONVERSION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PRODUCTION_PLANT_CONVERSIONs
            .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PRODUCTION_PLANT_CONVERSION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PRODUCTION_PLANT_CONVERSION([FromQuery] string[] recordKeys)
        {

            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PRODUCTION_PLANT_CONVERSION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;
                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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
                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_APP_APPLICATION1_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_APP_APPLICATION1_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_APP_APPLICATION1s
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_APP_APPLICATION1")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_APP_APPLICATION1([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_APP_APPLICATION1", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_APP_APPLICATION2_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_APP_APPLICATION2_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_APP_APPLICATION2s
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_APP_APPLICATION2")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_APP_APPLICATION2([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_APP_APPLICATION2", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_APP_APPLICATION3_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_APP_APPLICATION3_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_APP_APPLICATION3s
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_APP_APPLICATION3")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_APP_APPLICATION3([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_APP_APPLICATION3", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_CUS_BILL_TO_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_CUS_BILL_TO_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_CUS_BILL_TOs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_CUS_BILL_TO")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_CUS_BILL_TO([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_CUS_BILL_TO", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_CUS_SHIP_TO_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_CUS_SHIP_TO_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_CUS_SHIP_TOs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_CUS_SHIP_TO")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_CUS_SHIP_TO([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_CUS_SHIP_TO", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_CUS_SOLD_TO_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_CUS_SOLD_TO_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_CUS_SOLD_TOs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_CUS_SOLD_TO")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_CUS_SOLD_TO([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_CUS_SOLD_TO", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }
        
        [Authorize]
        [Route("api/get_OUT_CUS_END_CUSTOMER_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_CUS_END_CUSTOMER_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_CUS_END_CUSTOMERs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_CUS_END_CUSTOMER")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_CUS_END_CUSTOMER([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_CUS_END_CUSTOMER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PROFIT_CENTER_HIERARCHY_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PROFIT_CENTER_HIERARCHY_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PROFIT_CENTER_HIERARCHies
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PROFIT_CENTER_HIERARCHY")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PROFIT_CENTER_HIERARCHY([FromQuery] string[] p_sl_s)
        {
            if (p_sl_s == null || p_sl_s.Length == 0)
            {
                return BadRequest("p_sl_s is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PROFIT_CENTER_HIERARCHY", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_sl_s", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = p_sl_s,
                            Size = p_sl_s.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = p_sl_s.Select(s => s.Length).ToArray()
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

                        return Ok(new { p_sl_s, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_FIN_IP_CUSTOMER_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_FIN_IP_CUSTOMER_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_FIN_IP_CUSTOMERs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_FIN_IP_CUSTOMER")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_FIN_IP_CUSTOMER([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_FIN_IP_CUSTOMER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }
        
        [Authorize]
        [Route("api/get_OUT_FIN_IP_OPN_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_FIN_IP_OPN_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_FIN_IP_OPNs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_FIN_IP_OPN")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_FIN_IP_OPN([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_FIN_IP_OPN", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_PLANTS_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_PLANTS_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_PLANTs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_PLANTS")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_PLANTS([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_PLANTS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_STORAGE_LOCATION_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_STORAGE_LOCATION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_STORAGE_LOCATIONs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_STORAGE_LOCATION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_STORAGE_LOCATION([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_STORAGE_LOCATION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_MDM_COMPANY_CODE_processStatus")]
        [HttpPost]
        public IActionResult get_MDM_COMPANY_CODE_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_MDM_COMPANY_CODEs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_MDM_COMPANY_CODE")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_MDM_COMPANY_CODE([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_MDM_COMPANY_CODE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_VEN_VENDOR_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_VEN_VENDOR_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_VEN_VENDORs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_VEN_VENDOR")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_VEN_VENDOR([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_VEN_VENDOR", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_VEN_VENDOR_COMPANY_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_VEN_VENDOR_COMPANY_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_VEN_VENDOR_COMPANies
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_VEN_VENDOR_COMPANY")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_VEN_VENDOR_COMPANY([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_VEN_VENDOR_COMPANY", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_VEN_VENDOR_PURCHASE_INFO_REC_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_VEN_VENDOR_PURCHASE_INFO_REC_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_VEN_VENDOR_PURCHASE_INFO_RECs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_VEN_VENDOR_PURCHASE_INFO_REC")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_VEN_VENDOR_PURCHASE_INFO_REC([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_VEN_VENDOR_PURCHASE_INFO_REC", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }









        [Authorize]
        [Route("api/get_OUT_CUS_PARTNER_FUNCTION_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_CUS_PARTNER_FUNCTION_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_CUS_PARTNER_FUNCTIONs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_CUS_PARTNER_FUNCTION")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_CUS_PARTNER_FUNCTION([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_CUS_PARTNER_FUNCTION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/get_OUT_FIN_COST_CENTER_processStatus")]
        [HttpPost]
        public IActionResult get_OUT_FIN_COST_CENTER_processStatus([FromQuery] string processStatus)
        {
            var query = _context.V_OUT_FIN_COST_CENTERs
                .Where(x => x.processStatus == processStatus);

            int rowCount = query.Count();

            return Ok(query);
        }

        [Authorize]
        [Route("api/STATUS_CHANGE_3_OUT_FIN_COST_CENTER")]
        [HttpPost]
        public IActionResult STATUS_CHANGE_3_OUT_FIN_COST_CENTER([FromQuery] string[] recordKeys)
        {
            if (recordKeys == null || recordKeys.Length == 0)
            {
                return BadRequest("recordKeys is empty");
            }

            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_STATUS_CHANGE_3_OUT_FIN_COST_CENTER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("recordKeys", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = recordKeys,
                            Size = recordKeys.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = recordKeys.Select(s => s.Length).ToArray()
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

                        return Ok(new { recordKeys, Result = result });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

    }
}
