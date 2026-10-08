using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FIESTA_Backend.Controllers.Inbound
{
    public class MdmController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public MdmController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Authorize]
        [Route("api/MdmProductionPlantConversionUI")]
        [HttpGet]
        public IActionResult MdmProductionPlantConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_PLANT_CONVERSIONs.ToList<MDM_PRODUCTION_PLANT_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_PLANT_CONVERSIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionPlantConversion")]
        [HttpGet]
        public IActionResult MdmProductionPlantConversion([FromQuery] DataSourceLoadOptions loadOptions)
        {
            var data = _context.MDM_PRODUCTION_PLANT_CONVERSIONs.Select(x => new { company = x.company, plant = x.plant, storageLocation = x.storageLocation, legacyLine = x.legacyLine });

            if (loadOptions == null)
            {
                return Ok(data.ToList());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load( data, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductHierarchyUI")]
        [HttpGet]
        public IActionResult MdmProductHierarchyUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCT_HIERARCHies.ToList<MDM_PRODUCT_HIERARCHY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCT_HIERARCHies, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProfitCenterUI")]
        [HttpGet]
        public IActionResult MdmProfitCenterUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PROFIT_CENTERs.ToList<MDM_PROFIT_CENTER>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PROFIT_CENTERs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProfitCenterHierarchyUI")]
        [HttpGet]
        public IActionResult MdmProfitCenterHierarchyUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PROFIT_CENTER_HIERARCHies.ToList<MDM_PROFIT_CENTER_HIERARCHY>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PROFIT_CENTER_HIERARCHies, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionGroupStageUI")]
        [HttpGet]
        public IActionResult MdmProductionGroupStageUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_GROUP_STAGEs.ToList<MDM_PRODUCTION_GROUP_STAGE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_GROUP_STAGEs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductHierarchyProfitcenterConversionUI")]
        [HttpGet]
        public IActionResult MdmProductHierarchyProfitcenterConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs.ToList<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionStageConversionUI")]
        [HttpGet]
        public IActionResult MdmProductionStageConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_STAGE_CONVERSIONs.ToList<MDM_PRODUCTION_STAGE_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_STAGE_CONVERSIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionStageUI")]
        [HttpGet]
        public IActionResult MdmProductionStageUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_STAGEs.ToList<MDM_PRODUCTION_STAGE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_STAGEs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionStageConversionPrevCycleR3DryrunUI")]
        [HttpGet]
        public IActionResult MdmProductionStageConversionPrevCycleR3DryrunUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_STAGE_CONVERSION_PREVCYCLE_R3DRYRUNs.ToList<MDM_PRODUCTION_STAGE_CONVERSION_PREVCYCLE_R3DRYRUN>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_STAGE_CONVERSION_PREVCYCLE_R3DRYRUNs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionStagePrevCycleR3DryrunUI")]
        [HttpGet]
        public IActionResult MdmProductionStagePrevCycleR3DryrunUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_STAGE_PREVCYCLE_R3DRYRUNs.ToList<MDM_PRODUCTION_STAGE_PREVCYCLE_R3DRYRUN>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_STAGE_PREVCYCLE_R3DRYRUNs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProductionGroupStageConversionUI")]
        [HttpGet]
        public IActionResult MdmProductionGroupStageConversionUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.ToList<MDM_PRODUCTION_GROUP_STAGE_CONVERSION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmStorageLocationUI")]
        [HttpGet]
        public IActionResult MdmStorageLocationUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_STORAGE_LOCATIONs.ToList<MDM_STORAGE_LOCATION>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_STORAGE_LOCATIONs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmCompanyCodeUI")]
        [HttpGet]
        public IActionResult MdmCompanyCodeUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_COMPANY_CODEs.ToList<MDM_COMPANY_CODE>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_COMPANY_CODEs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmPlantsUI")]
        [HttpGet]
        public IActionResult MdmPlantsUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.MDM_PLANTs.ToList<MDM_PLANT>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.MDM_PLANTs, loadOptions));
            }

        }

        [Authorize]
        [Route("api/MdmProfitCenterMappingUI")]
        [HttpGet]
        public IActionResult MdmProfitCenterMappingUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_PROFITCENTER_MAPPINGs.ToList<V_PROFITCENTER_MAPPING>());
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_PROFITCENTER_MAPPINGs, loadOptions));
            }

        }
    }
}
