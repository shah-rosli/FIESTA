using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace FIESTA_Backend.Controllers.Config
{
    public class CfgSysTableConfigController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        public CfgSysTableConfigController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        [Route("api/CfgSysTableConfig/GetColumnConfigByTableName")]
        [HttpGet]
        [Authorize]
        public IActionResult Get(string tableName)
        {
            var result = _context.CFG_SYS_TABLE_CONFIGs
                .Join(_context.CFG_SYS_COLUMN_CONFIGs,
                    table => table.CFG_SYS_TABLE_CONFIG_ID,
                    column => column.CFG_SYS_TABLE_CONFIG_ID,
                    (table, column) => new
                    {
                        table.CFG_SYS_TABLE_NAME,
                        TABLE_ACTIVE = table.ACTIVE,
                        FIXED = column._fixed,
                        column.fixedPosition,
                        column.dataField,
                        column.dataType,
                        column.caption,
                        column.visibleIndex,
                        column.visible,
                        column.format,
                        column.sortIndex,
                        column.sortOrder,
                        COLUMN_ACTIVE = column.ACTIVE,
                        column.width
                    })
                .Where(x => x.CFG_SYS_TABLE_NAME == tableName &&
                            x.TABLE_ACTIVE == "Yes" &&
                            x.COLUMN_ACTIVE == "Yes")
                .Select(x => new
                {
                    format = x.format,
                    dataField = x.dataField,
                    dataType = x.dataType,
                    caption = x.caption,
                    visible = bool.Parse(x.visible),
                    visibleIndex = x.visibleIndex,
                    sortIndex = x.sortIndex,
                    sortOrder = x.sortOrder,
                    width = x.width,
                    alignment = "left"
                })
                .OrderBy(x => x.visibleIndex);

            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }

        [Route("api/CfgSysTableConfig/GetColumnConfigByTableNames")]
        [HttpGet]
        [Authorize]
        public IActionResult Get(List<string> tableName)
        {
            var queried = _context.CFG_SYS_TABLE_CONFIGs
                .AsNoTracking()
                .Join(_context.CFG_SYS_COLUMN_CONFIGs,
                    table => table.CFG_SYS_TABLE_CONFIG_ID,
                    column => column.CFG_SYS_TABLE_CONFIG_ID,
                    (table, column) => new
                    {
                        table.CFG_SYS_TABLE_NAME,
                        TABLE_ACTIVE = table.ACTIVE,
                        FIXED = column._fixed,
                        column.fixedPosition,
                        column.dataField,
                        column.dataType,
                        column.caption,
                        column.visibleIndex,
                        column.visible,
                        column.format,
                        column.sortIndex,
                        column.sortOrder,
                        COLUMN_ACTIVE = column.ACTIVE,
                        column.width
                    })
                .Where(x => tableName.Contains(x.CFG_SYS_TABLE_NAME) &&
                            x.TABLE_ACTIVE == "Yes" &&
                            x.COLUMN_ACTIVE == "Yes")
                .Select(x => new
                {
                    tableName = x.CFG_SYS_TABLE_NAME,
                    format = x.format,
                    dataField = x.dataField,
                    dataType = x.dataType,
                    caption = x.caption,
                    visible = bool.Parse(x.visible),
                    visibleIndex = x.visibleIndex,
                    sortIndex = x.sortIndex,
                    sortOrder = x.sortOrder,
                    width = x.width,
                    alignment = "left"
                })
                .ToList();

            var result = queried
                .GroupBy(x => x.tableName)
                .Select(group => new
                {
                    tableName = group.Key,
                    columns = group.Select(x => new
                        {
                            format = x.format,
                            dataField = x.dataField,
                            dataType = x.dataType,
                            caption = x.caption,
                            visible = x.visible,
                            visibleIndex = x.visibleIndex,
                            sortIndex = x.sortIndex,
                            sortOrder = x.sortOrder,
                            width = x.width,
                            alignment = "left"
                        })
                        .OrderBy(c => c.visibleIndex)
                })
                .ToList();

            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [Route("api/CfgSysTableConfig/GetColumnConfigByTableID")]
        [HttpGet]
        [Authorize]
        public IActionResult GetColumnById(decimal id)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var result = _context.CFG_SYS_COLUMN_CONFIGs
                    .Where(x => x.CFG_SYS_TABLE_CONFIG_ID == id)
                    .OrderBy(x => x.visibleIndex);

                //if (result.Any())
                return Ok(result);
                //else
                //    return NotFound();
            }
            catch (Exception ex)
            {
                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Route("api/CfgSysTableConfig/UpdateTableColumns")]
        [HttpPost]
        [Authorize]
        public IActionResult UpdateTableColumns([FromQuery] decimal id, [FromBody] List<CFG_SYS_COLUMN_CONFIG> cols)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                //delete all the columns based on first item
                _context.CFG_SYS_COLUMN_CONFIGs.RemoveRange(_context.CFG_SYS_COLUMN_CONFIGs.Where(x => x.CFG_SYS_TABLE_CONFIG_ID == id));
                //if cols have records, add range.
                if (cols != null && cols.Count > 0)
                {
                    _context.CFG_SYS_COLUMN_CONFIGs.AddRange(cols);
                }

                _context.SaveChanges();

                objReturn.SuccessMsg = "Record Updated Successfully";
                objReturn.Data = cols;
            }
            catch (Exception ex)
            {
                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }

            return Ok(objReturn);
        }

        [Route("api/CfgSysTableConfig/GetSPTableName")]
        [HttpGet]
        [Authorize]
        public IActionResult GetSPTableName()
        {
            var result = _context.CFG_SYS_TABLE_CONFIGs.Where(x => !string.IsNullOrEmpty(x.CFG_SYS_TABLE_SP_EXPORT_NAME)).Select(x => new { TableName = x.CFG_SYS_TABLE_SP_EXPORT_NAME }).OrderBy(x => x.TableName);

            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }

        [Route("api/CfgSysTableConfig")]
        [HttpGet]
        [Authorize]
        public IActionResult GetTableConfig(string tableName)
        {
            var result = _context.CFG_SYS_TABLE_CONFIGs.FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == tableName);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [Route("api/CfgSysTableConfig/GetBySysTableGroupName")]
        [HttpGet]
        [Authorize]
        public IActionResult GetBySysTableGroupName(string? tableGroupName = null)
        {
            List<CFG_SYS_TABLE_CONFIG> result = new List<CFG_SYS_TABLE_CONFIG>();

            if (tableGroupName == null)
            {
                result = _context.CFG_SYS_TABLE_CONFIGs.Where(x => x.CFG_SYS_TABLE_GROUP_NAME != null && x.ACTIVE == "Yes").OrderByDescending(x => x.CFG_SYS_TABLE_GROUP_NAME).ThenBy(x => x.CFG_SYS_TABLE_NAME).ToList<CFG_SYS_TABLE_CONFIG>();
            }
            else
                result = _context.CFG_SYS_TABLE_CONFIGs.Where(x => x.CFG_SYS_TABLE_GROUP_NAME == tableGroupName && x.ACTIVE == "Yes").OrderBy(x => x.CFG_SYS_TABLE_NAME).ToList<CFG_SYS_TABLE_CONFIG>();

            if (result.Any())
                return Ok(result);
            else
                return NotFound();
        }

        [Route("api/CfgSysTableConfig/GetMultipleCfgSysTableConfig")]
        [HttpGet]
        [Authorize]
        public IActionResult GetMultipleCfgSysTableConfig(string[] tableNames)
        {
            if (tableNames == null || tableNames.Length == 0)
                return BadRequest("At least one table name is required.");

            var sequence = tableNames
                .Select((name, index) => new { name, index })
                .GroupBy(x => x.name)
                .ToDictionary(x => x.Key, x => x.First().index);

            var result = _context.CFG_SYS_TABLE_CONFIGs
                .Where(x => tableNames.Contains(x.CFG_SYS_TABLE_NAME) && x.ACTIVE == "Yes")
                .AsEnumerable() // Ordering below is performed in memory
                .OrderBy(x => sequence[x.CFG_SYS_TABLE_NAME])
                .ToList();

            return result.Any() ? Ok(result) : NotFound();
        }

        [Authorize]
        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.CFG_SYS_TABLE_CONFIGs);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.CFG_SYS_TABLE_CONFIGs, loadOptions));
            }
        }

        [Authorize]
        [Route("api/[controller]/GetById")]
        [HttpGet]
        public IActionResult GetById([FromQuery] decimal id)
        {
            CFG_SYS_TABLE_CONFIG? c = _context.CFG_SYS_TABLE_CONFIGs
                .FirstOrDefault(x => x.CFG_SYS_TABLE_CONFIG_ID == id);

            if (c != null)
                return Ok(c);

            return NotFound();
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] CFG_SYS_TABLE_CONFIG cfg)
        {
            //get the token
            //TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            //token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                //check if exist
                CFG_SYS_TABLE_CONFIG? c = _context.CFG_SYS_TABLE_CONFIGs
                    .FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == cfg.CFG_SYS_TABLE_NAME);

                //insert only when not exist
                if (c == null)
                {
                    _context.CFG_SYS_TABLE_CONFIGs.Add(cfg);
                    _context.SaveChanges();

                    //insert into history
                    //SnapAuditTrail(cfg, token);

                    objReturn.SuccessMsg = "Record Created Successfully";
                    objReturn.Data = cfg;
                }
                else
                {
                    objReturn.ErrorMsg = "Record with Table Name: " + cfg.CFG_SYS_TABLE_NAME + " exist!";
                    objReturn.Data = cfg;
                }

                return Ok(objReturn);
            }
            catch (Exception ex)
            {
                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put([FromBody] CFG_SYS_TABLE_CONFIG cfg)
        {
            //get the token
            //TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            //token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                //check if exist
                CFG_SYS_TABLE_CONFIG? c = _context.CFG_SYS_TABLE_CONFIGs
                    .FirstOrDefault(x => x.CFG_SYS_TABLE_CONFIG_ID == cfg.CFG_SYS_TABLE_CONFIG_ID);

                //updte only when exist
                if (c != null)
                {
                    c.CFG_SYS_TABLE_NAME = cfg.CFG_SYS_TABLE_NAME;
                    c.CFG_SYS_TABLE_DESC = cfg.CFG_SYS_TABLE_DESC;
                    c.ACTIVE = cfg.ACTIVE;
                    c.CFG_SYS_TABLE_SP_EXPORT_NAME = cfg.CFG_SYS_TABLE_SP_EXPORT_NAME;
                    c.CFG_SYS_TABLE_GROUP_NAME = cfg.CFG_SYS_TABLE_GROUP_NAME;
                    c.CFG_SYS_TABLE_SORT_INDEX = cfg.CFG_SYS_TABLE_SORT_INDEX;

                    _context.SaveChanges();

                    //insert into history
                    //SnapAuditTrail(cfg, token);

                    objReturn.SuccessMsg = "Record Updated Successfully";
                    objReturn.Data = cfg;
                }
                else
                {
                    objReturn.ErrorMsg = "Record with Table Name: " + cfg.CFG_SYS_TABLE_NAME + " not found!";
                    objReturn.Data = cfg;
                }

                return Ok(objReturn);
            }
            catch (Exception ex)
            {
                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Route("api/CfgSysTableConfig/GetTrantoOutStatusUI")]
        [HttpGet]
        [Authorize]
        public IActionResult GetTrantoOutStatusUI([FromQuery] DataSourceLoadOptions loadOptions)
        {
            if (loadOptions == null)
            {
                return Ok(_context.V_TRN_TO_OUT_STATUSes);
            }
            else
            {
                return new JsonResult(DataSourceLoader.Load(_context.V_TRN_TO_OUT_STATUSes, loadOptions));
            }
        }
    }
}