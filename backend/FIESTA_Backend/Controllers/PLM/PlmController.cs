using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FIESTA_Backend.Controllers.PLM
{
    public class PlmController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public PlmController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/RawAglComponentsUI")]
        [HttpGet]
        public IActionResult RawAglComponentsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.RAW_AGL_COMPONENTs.ToList<RAW_AGL_COMPONENT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.RAW_AGL_COMPONENTs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmAglComponentsUI")]
        [HttpGet]
        public IActionResult PlmAglComponentsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_COMPONENTs.ToList<PLM_AGL_COMPONENT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_COMPONENTs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/RawAglMatrixUI")]
        [HttpGet]
        public IActionResult RawAglMatrixUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.RAW_AGL_MATRices.ToList<RAW_AGL_MATRIX>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.RAW_AGL_MATRices, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmAglMatrixUI")]
        [HttpGet]
        public IActionResult PlmAglMatrixUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_MATRices.ToList<PLM_AGL_MATRIX>());
                
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_MATRices, loadOptions));
            }

        }

        [Authorize]
        [Route("api/RawAglProcessCharacteristicsUI")]
        [HttpGet]
        public IActionResult RawAglProcessCharacteristicsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MV_RAW_AGL_PROCESS_CHARACTERISTICS_UIs.ToList<MV_RAW_AGL_PROCESS_CHARACTERISTICS_UI>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MV_RAW_AGL_PROCESS_CHARACTERISTICS_UIs, loadOptions));
            }
            //if (loadOptions == null)
            //{
            //    return Ok(_context.RAW_AGL_PROCESS_CHARACTERISTICs.ToList<RAW_AGL_PROCESS_CHARACTERISTIC>());
            //}
            //else
            //{
            //    return new JsonResult(DataSourceLoader.Load(_context.RAW_AGL_PROCESS_CHARACTERISTICs, loadOptions));
            //}
        }

        [Authorize]
        [Route("api/PlmAglProcessCharacteristicsUI")]
        [HttpGet]
        public IActionResult PlmAglProcessCharacteristicsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_PROCESS_CHARACTERISTICs.ToList<PLM_AGL_PROCESS_CHARACTERISTIC>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_PROCESS_CHARACTERISTICs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/RawAglProductUI")]
        [HttpGet]
        public IActionResult RawAglProductUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.RAW_AGL_PRODUCTs.ToList<RAW_AGL_PRODUCT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.RAW_AGL_PRODUCTs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmAglProductUI")]
        [HttpGet]
        public IActionResult PlmAglProductUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_PRODUCTs.ToList<PLM_AGL_PRODUCT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_PRODUCTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/RawAglProductionUI")]
        [HttpGet]
        public IActionResult RawAglProductionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.RAW_AGL_PRODUCTIONs.ToList<RAW_AGL_PRODUCTION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.RAW_AGL_PRODUCTIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmAglProductionUI")]
        [HttpGet]
        public IActionResult PlmAglProductionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_PRODUCTIONs.ToList<PLM_AGL_PRODUCTION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_PRODUCTIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmAglMaterialsUI")]
        [HttpGet]
        public IActionResult PlmAglMaterialsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_MATERIALs.ToList<PLM_AGL_MATERIAL>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_MATERIALs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmAglCharacteristicsUI")]
        [HttpGet]
        public IActionResult PlmAglCharacteristicsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_AGL_PROCESS_CHARACTERISTICs.ToList<PLM_AGL_PROCESS_CHARACTERISTIC>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_AGL_PROCESS_CHARACTERISTICs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProductionUI")]
        [HttpGet]
        public IActionResult PlmProductionUI([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery] int basic = 0)
        {
            if (loadOptions == null)
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return Ok(_context.MV_PLM_PRODUCTIONs.Where(x => x.deleteFlag == "N").ToList<MV_PLM_PRODUCTION>());
                }
                else
                    return Ok(_context.MV_PLM_PRODUCTIONs.ToList<MV_PLM_PRODUCTION>());
            }
            else
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return new JsonResult(DataSourceLoader.Load(_context.MV_PLM_PRODUCTIONs.Where(x => x.deleteFlag == "N"), loadOptions));
                }
                else
                    return new JsonResult(DataSourceLoader.Load(_context.MV_PLM_PRODUCTIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProductUI")]
        [HttpGet]
        public IActionResult PlmProductUI([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery] int basic = 0)
        {
            if (loadOptions == null)
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return Ok(_context.MV_PLM_PRODUCTs.Where(x => x.deleteFlag == "N").ToList<MV_PLM_PRODUCT>());
                }
                else
                    return Ok(_context.MV_PLM_PRODUCTs.ToList<MV_PLM_PRODUCT>());
            }
            else
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return new JsonResult(DataSourceLoader.Load(_context.MV_PLM_PRODUCTs.Where(x => x.deleteFlag == "N"), loadOptions));
                }
                else
                    return new JsonResult(DataSourceLoader.Load(_context.MV_PLM_PRODUCTs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProductionGoldenOpnUI")]
        [HttpGet]
        public IActionResult PlmProductionGoldenOpnUI([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery] int basic = 0)
        {
            if (loadOptions == null)
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return Ok(_context.PLM_PRODUCTION_GOLDENOPNs.Where(x => x.deleteFlag == "N").ToList<PLM_PRODUCTION_GOLDENOPN>());
                }
                else
                    return Ok(_context.PLM_PRODUCTION_GOLDENOPNs.ToList<PLM_PRODUCTION_GOLDENOPN>());
            }
            else
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCTION_GOLDENOPNs.Where(x => x.deleteFlag == "N"), loadOptions));
                }
                else
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCTION_GOLDENOPNs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProductGoldenOpnUI")]
        [HttpGet]
        public IActionResult PlmProductGoldenOpnUI([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery] int basic = 0)
        {
            if (loadOptions == null)
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return Ok(_context.PLM_PRODUCT_GOLDENOPNs.Where(x => x.deleteFlag == "N").ToList<PLM_PRODUCT_GOLDENOPN>());
                }
                else
                    return Ok(_context.PLM_PRODUCT_GOLDENOPNs.ToList<PLM_PRODUCT_GOLDENOPN>());
            }
            else
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCT_GOLDENOPNs.Where(x => x.deleteFlag == "N"), loadOptions));
                }
                else
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCT_GOLDENOPNs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProductionPrevCycleR3ITC1UI")]
        [HttpGet]
        public IActionResult PlmProductionPrevCycleR3ITC1UI([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery] int basic = 0)
        {
            if (loadOptions == null)
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return Ok(_context.PLM_PRODUCTION_PREVCYCLE_R3ITC1s.Where(x => x.deleteFlag == "N").ToList<PLM_PRODUCTION_PREVCYCLE_R3ITC1>());
                }
                else
                    return Ok(_context.PLM_PRODUCTION_PREVCYCLE_R3ITC1s.ToList<PLM_PRODUCTION_PREVCYCLE_R3ITC1>());
            }
            else
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCTION_PREVCYCLE_R3ITC1s.Where(x => x.deleteFlag == "N"), loadOptions));
                }
                else
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCTION_PREVCYCLE_R3ITC1s, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProductPrevCycleR3ITC1UI")]
        [HttpGet]
        public IActionResult PlmProductPrevCycleR3ITC1UI([FromQuery] DataSourceLoadOptions loadOptions, [FromQuery] int basic = 0)
        {
            if (loadOptions == null)
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return Ok(_context.PLM_PRODUCT_PREVCYCLE_R3ITC1s.Where(x => x.deleteFlag == "N").ToList<PLM_PRODUCT_PREVCYCLE_R3ITC1>());
                }
                else
                    return Ok(_context.PLM_PRODUCT_PREVCYCLE_R3ITC1s.ToList<PLM_PRODUCT_PREVCYCLE_R3ITC1>());
            }
            else
            {
                //basic view take active records only
                if (basic > 0)
                {
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCT_PREVCYCLE_R3ITC1s.Where(x => x.deleteFlag == "N"), loadOptions));
                }
                else
                    return new JsonResult(DataSourceLoader.Load(_context.PLM_PRODUCT_PREVCYCLE_R3ITC1s, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmEolStatusUI")]
        [HttpGet]
        public IActionResult PlmEolStatusUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_EOL_STATUSes.ToList<PLM_EOL_STATUS>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_EOL_STATUSes, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmPriOpnUI")]
        [HttpGet]
        public IActionResult PlmPriOpnUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRI_OPNs.ToList<PLM_PRI_OPN>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRI_OPNs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProAltMixRatiosUI")]
        [HttpGet]
        public IActionResult PlmProAltMixRatiosUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_ALT_MIX_RATIOs.ToList<PLM_PRO_ALT_MIX_RATIO>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_ALT_MIX_RATIOs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProBomUI")]
        [HttpGet]
        public IActionResult PlmProBomUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_BOMs.ToList<PLM_PRO_BOM>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_BOMs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProLeadtimeMinitsUI")]
        [HttpGet]
        public IActionResult PlmProLeadtimeMinitsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_LEADTIME_MINITs.ToList<PLM_PRO_LEADTIME_MINIT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_LEADTIME_MINITs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProLeadtimeProsterUI")]
        [HttpGet]
        public IActionResult PlmProLeadtimeProsterUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_LEADTIME_PROSTERs.ToList<PLM_PRO_LEADTIME_PROSTER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_LEADTIME_PROSTERs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProMpnS4UI")]
        [HttpGet]
        public IActionResult PlmProMpnS4UI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_MPN_S4s.ToList<PLM_PRO_MPN_S4>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_MPN_S4s, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProRoutingUI")]
        [HttpGet]
        public IActionResult PlmProRoutingUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_ROUTINGs.ToList<PLM_PRO_ROUTING>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_ROUTINGs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProVersionUI")]
        [HttpGet]
        public IActionResult PlmProVersionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_VERSIONs.ToList<PLM_PRO_VERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_VERSIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProYieldMinitsUI")]
        [HttpGet]
        public IActionResult PlmProYieldMinitsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_YIELD_MINITs.ToList<PLM_PRO_YIELD_MINIT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_YIELD_MINITs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProYieldProsterUI")]
        [HttpGet]
        public IActionResult PlmProYieldProsterUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_YIELD_PROSTERs.ToList<PLM_PRO_YIELD_PROSTER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_YIELD_PROSTERs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmProCycleTimeUI")]
        [HttpGet]
        public IActionResult PlmProCycleTimeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_PRO_CYCLE_TIMEs.ToList<PLM_PRO_CYCLE_TIME>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_PRO_CYCLE_TIMEs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmRetMaterialUI")]
        [HttpGet]
        public IActionResult PlmRetMaterialUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_RET_MATERIALs.ToList<PLM_RET_MATERIAL>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_RET_MATERIALs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmRetPnstatusUI")]
        [HttpGet]
        public IActionResult PlmRetPnstatusUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_RET_PNSTATUSes.ToList<PLM_RET_PNSTATUS>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_RET_PNSTATUSes, loadOptions));
            }

        }

        [Authorize]
        [Route("api/PlmBlacklistedOpnProductUI")]
        [HttpGet]
        public IActionResult PlmBlacklistedOpnProductUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_PLM_BLACKLISTED_PRODUCTs.ToList<V_PLM_BLACKLISTED_PRODUCT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_PLM_BLACKLISTED_PRODUCTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmBlacklistedByOPNUI")]
        [HttpGet]
        public IActionResult PlmBlacklistedByOPNUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            var query = _context.MVW_VIEW_BY_OPNs.Where(x => x.materialType == "ZFER");

            if (loadOptions == null)
            {
                return Ok(query.ToList());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(query, loadOptions));
            }
            //if (loadOptions == null)
            //{
            //    return Ok(_context.VW_VIEW_BY_OPNs.ToList<VW_VIEW_BY_OPN>());
            //}
            //else
            //{
            //    return new JsonResult(DataSourceLoader.Load(_context.VW_VIEW_BY_OPNs, loadOptions));
            //}
        }

        [Authorize]
        [Route("api/PlmBlacklistedByPartUI")]
        [HttpGet]
        public IActionResult PlmBlacklistedByPartUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            var query = _context.MVW_VIEW_BY_OPNs;

            if (loadOptions == null)
            {
                return Ok(query.ToList());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(query, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmProductionViewUI")]
        [HttpGet]
        public IActionResult PlmProductionView([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MV_RPPE_PLM_PRODUCTIONs.ToList<MV_RPPE_PLM_PRODUCTION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MV_RPPE_PLM_PRODUCTIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmTr4ProductionUI")]
        [HttpGet]
        public IActionResult PlmTr4ProductionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_TR4_PRODUCTIONs.ToList<PLM_TR4_PRODUCTION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_TR4_PRODUCTIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionUI")]
        [HttpGet]
        public IActionResult TrnProductionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTIONs.ToList<TRN_PRODUCTION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmTr4ProductUI")]
        [HttpGet]
        public IActionResult PlmTr4ProductUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_TR4_PRODUCTs.ToList<PLM_TR4_PRODUCT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_TR4_PRODUCTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductUI")]
        [HttpGet]
        public IActionResult TrnProductUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTs.ToList<TRN_PRODUCT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmTr4BomUI")]
        [HttpGet]
        public IActionResult PlmTr4BomUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_TR4_BOMs.ToList<PLM_TR4_BOM>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_TR4_BOMs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionBomUI")]
        [HttpGet]
        public IActionResult TrnProductionBomUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_BOMs.ToList<TRN_PRODUCTION_BOM>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_BOMs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmTr4RoutingUI")]
        [HttpGet]
        public IActionResult PlmTr4RoutingUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_TR4_ROUTINGs.ToList<PLM_TR4_ROUTING>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_TR4_ROUTINGs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionRoutingUI")]
        [HttpGet]
        public IActionResult TrnProductionRoutingUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_ROUTINGs.ToList<TRN_PRODUCTION_ROUTING>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_ROUTINGs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmTr4VersionUI")]
        [HttpGet]
        public IActionResult PlmTr4VersionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_TR4_VERSIONs.ToList<PLM_TR4_VERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_TR4_VERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionVersionUI")]
        [HttpGet]
        public IActionResult TrnProductionVersionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_VERSIONs.ToList<TRN_PRODUCTION_VERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_VERSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmTr4MixRatioUI")]
        [HttpGet]
        public IActionResult PlmTr4MixRatioUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.PLM_TR4_MIX_RATIOs.ToList<PLM_TR4_MIX_RATIO>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.PLM_TR4_MIX_RATIOs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionAlternativesMixRatiosUI")]
        [HttpGet]
        public IActionResult TrnProductionAlternativesMixRatiosUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_ALTERNATIVES_MIX_RATIOs.ToList<TRN_PRODUCTION_ALTERNATIVES_MIX_RATIO>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_ALTERNATIVES_MIX_RATIOs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/MesStageExpansionUI")]
        [HttpGet]
        public IActionResult MesStageExpansionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MES_STAGE_EXPANSIONs.ToList<MES_STAGE_EXPANSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MES_STAGE_EXPANSIONs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmComponentsUI")]
        [HttpGet]
        public IActionResult PlmComponentsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MV_PLM_COMPONENTs.ToList<MV_PLM_COMPONENT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MV_PLM_COMPONENTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/AgileOpnSummaryUI")]
        [HttpGet]
        public IActionResult AgileOpnSummaryUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_AGILE_OPN_SUMMARies.ToList<V_AGILE_OPN_SUMMARY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_AGILE_OPN_SUMMARies, loadOptions));
            }
        }

        [Authorize]
        [Route("api/PlmBlacklistSummaryUI")]
        [HttpGet]
        public IActionResult PlmBlacklistSummaryUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_PLM_BLACKLIST_SUMMARies.ToList<V_PLM_BLACKLIST_SUMMARY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_PLM_BLACKLIST_SUMMARies, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductPlantUI")]
        [HttpGet]
        public IActionResult TrnProductPlantUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCT_PLANTs.ToList<TRN_PRODUCT_PLANT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCT_PLANTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductSalesUI")]
        [HttpGet]
        public IActionResult TrnProductSalesUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCT_SALEs.ToList<TRN_PRODUCT_SALE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCT_SALEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnComponentsUI")]
        [HttpGet]
        public IActionResult TrnComponentsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_COMPONENTs.ToList<TRN_COMPONENT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_COMPONENTs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductVendorCharUI")]
        [HttpGet]
        public IActionResult TrnProductVendorCharUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCT_VENDOR_CHARs.ToList<TRN_PRODUCT_VENDOR_CHAR>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCT_VENDOR_CHARs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductMatrixUI")]
        [HttpGet]
        public IActionResult TrnProductMatrixUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCT_MATRices.ToList<TRN_PRODUCT_MATRIX>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCT_MATRices, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionRoutingS4UI")]
        [HttpGet]
        public IActionResult TrnProductionRoutingS4UI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_ROUTING_S4s.ToList<TRN_PRODUCTION_ROUTING_S4>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_ROUTING_S4s, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionLeadtimeUI")]
        [HttpGet]
        public IActionResult TrnProductionLeadtimeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_LEADTIMEs.ToList<TRN_PRODUCTION_LEADTIME>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_LEADTIMEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionYieldUI")]
        [HttpGet]
        public IActionResult TrnProductionYieldUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_YIELDs.ToList<TRN_PRODUCTION_YIELD>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_YIELDs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionLotsizeUI")]
        [HttpGet]
        public IActionResult TrnProductionLotsizeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_LOTSIZEs.ToList<TRN_PRODUCTION_LOTSIZE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_LOTSIZEs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/TrnProductionCycletimeUI")]
        [HttpGet]
        public IActionResult TrnProductionCycletimeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.TRN_PRODUCTION_CYCLETIMEs.ToList<TRN_PRODUCTION_CYCLETIME>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.TRN_PRODUCTION_CYCLETIMEs, loadOptions));
            }
        }
    }
}
