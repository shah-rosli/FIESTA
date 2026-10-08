using DocumentFormat.OpenXml.Office.Word;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.Record;
using NPOI.SS.Formula.Functions;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Ocsp;
using System.Data;
using System.Dynamic;
using System.Numerics;
using System.Security.Claims;
using UtilityCore.Utility.BulkImport;

namespace FIESTA_Backend.Controllers.PLM
{
    public class BuyoffController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;

        private IServiceScopeFactory _scopeFactory;

        
        public BuyoffController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, IServiceScopeFactory scopeFactory)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _scopeFactory = scopeFactory;

        }

        [Authorize]
        [Route("api/UserBuyoff")]
        [HttpGet]
        public IActionResult UserBuyoff(string opn)
        {
            try {

                if (string.IsNullOrWhiteSpace(opn))
                {
                    return BadRequest(new { message = "OPN is required but not provided." });
                }

                TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
                token = token.GetTokenObject();
                string token_USER_ID = token.USER_ID;

                var record = _context.PLM_OPN_STATUSes.FirstOrDefault(x => x.opn == opn);

                if (record == null)
                {
                    return BadRequest(new { message = $"OPN {opn} not found in PLM_OPN_STATUS." });
                }

                if (record.userSignOff == "Y")
                {
                    return BadRequest(new { message = $"OPN {opn} was already bought off earlier." });
                }

                record.userSignOff = "Y";
                record.userSignOffBy = token_USER_ID;

                _context.SaveChanges();

                //using (var conn = new OracleConnection(_context.Database.GetConnectionString()))
                //{
                //    conn.Open();
                //    using (var cmd = conn.CreateCommand())
                //    {
                //        cmd.CommandText = "SP_UPDATE_BUYOFF";
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.Add(
                //            new OracleParameter("p_opn", OracleDbType.Varchar2)
                //            {
                //                Value = opn
                //            }
                //        );
                //        cmd.ExecuteNonQuery();
                //    }
                //}

                Task.Run(() => RefreshMvOpnList());

                return Ok(new { message = "User buyoff completed successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.InnerException });
            }
            
        }

        private async Task RefreshMvOpnList()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<FiestaDbContext>();

                await db.Database.ExecuteSqlRawAsync(@"
                    BEGIN
                      DBMS_MVIEW.REFRESH('MV_OPN_LIST');
                    END;
                ");

                await db.Database.ExecuteSqlRawAsync(@"
                    BEGIN
                      DBMS_MVIEW.REFRESH('MVW_VIEW_BY_OPN');
                    END;
                ");
            }
            catch (Exception ex)
            {
                string exMsg = ex.Message;
                // Optional: log error (Serilog / NLog / DB log)
            }
        }

        [Authorize]
        [Route("api/UserBuyoffPreviousVersion")]
        [HttpGet]
        public IActionResult UserBuyoffPreviousVersion(string opn)
        {
            if (!string.IsNullOrEmpty(opn))
            {
                var findByOpn = _context.PLM_PRODUCTION_BUYOFF_HIs.Where(x => x.opn == opn);
                if (!findByOpn.Any())
                {
                    return Ok(new List<PLM_PRODUCTION_BUYOFF_HI>());
                }
                var buyoffVersion = findByOpn.Max(x => x.opnVersion);
                var result = _context.PLM_PRODUCTION_BUYOFF_HIs.Where(x => x.opn == opn).Where(x => x.opnVersion == buyoffVersion);

                return Ok(result.ToList<PLM_PRODUCTION_BUYOFF_HI>());
            }
            return BadRequest(new { message = "OPN is required but not provided." });
        }

        [Authorize]
        [Route("api/UserBuyoffR4")]
        [HttpGet]
        public IActionResult UserBuyoffR4(string opn)
        {
            if (!string.IsNullOrEmpty(opn))
            {
                var result = _context.V_FIESTA_PRODUCTION_BUYOFFs.Where(x => x.opn == opn);
                return Ok(result.ToList<V_FIESTA_PRODUCTION_BUYOFF>());
            }
            return BadRequest(new { message = "OPN is required but not provided." });
        }

        [Authorize]
        [Route("api/UserBuyoffR4PreviousVersion")]
        [HttpGet]
        public IActionResult UserBuyoffR4PreviousVersion(string opn)
        {
            if (!string.IsNullOrEmpty(opn))
            {
                var findByOpn = _context.V_FIESTA_PRODUCTION_BUYOFF_HIs.Where(x => x.opn == opn);
                if (!findByOpn.Any())
                {
                    return Ok(new List<V_FIESTA_PRODUCTION_BUYOFF_HI>());
                }
                var buyoffVersion = findByOpn.Max(x => x.opnVersion);
                var result = _context.V_FIESTA_PRODUCTION_BUYOFF_HIs.Where(x => x.opn == opn).Where(x => x.opnVersion == buyoffVersion);

                return Ok(result.ToList<V_FIESTA_PRODUCTION_BUYOFF_HI>());
            }
            return BadRequest(new { message = "OPN is required but not provided." });
        }

        [Authorize]
        [Route("api/UserBuyoff")]
        [HttpPost]
        public IActionResult UserBuyoff([FromBody] Buyoff buyOffObj)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                var result = _context.PLM_PRODUCTION_BUYOFFs.Where(x => x.opn == buyOffObj.opn);
                if (!result.Any())
                {
                    return NotFound();
                }
                foreach (PLM_PRODUCTION_BUYOFF row in result)
                {
                    row.buyoffUserId = token.USER_ID;
                    row.buyoffDate = DateTimeOffset.UtcNow;
                    row.buyOffComment = buyOffObj.buyOffComment;
                    row.userBuyoff = "Y";
                }
                _context.SaveChanges();
                objReturn.SuccessMsg = "Record(s) are Updated Successfully";
                return Ok(objReturn);
            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/UserBuyoffR4")]
        [HttpPost]
        public IActionResult UserBuyoffR4([FromBody] Buyoff buyOffObj)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            JsonReturn objReturn = new JsonReturn();

            try
            {
                var result = _context.PLM_TR4_PRODUCTION_BUYOFFs.Where(x => x.opn == buyOffObj.opn);
                if (!result.Any())
                {
                    return NotFound();
                }
                foreach (PLM_TR4_PRODUCTION_BUYOFF row in result)
                {
                    row.buyoffUserId = token.USER_ID;
                    row.buyoffDate = DateTimeOffset.UtcNow;
                    row.buyOffComment = buyOffObj.buyOffComment;
                    row.userBuyoff = "Y";
                }
                _context.SaveChanges();
                objReturn.SuccessMsg = "Record(s) are Updated Successfully";
                return Ok(objReturn);
            }
            catch (Exception ex)
            {

                objReturn.ErrorMsg = ex.Message;
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        //[Authorize]
        //[Route("api/ProductBuyoff")]
        //[HttpGet]
        //public IActionResult ProductBuyoff()
        //{
        //    try
        //    {
        //        var result = _context.V_BYO_PRODUCTs.Where(x => x.userSignOffBy == null); //.Where(x => x.userSignOffBy == null) && x.deleteFlag != "Y"
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
        //    }
        //}

        //[Authorize]
        //[Route("api/ProductionBuyoff")]
        //[HttpGet]
        //public IActionResult ProductionBuyoff()
        //{
        //    try
        //    {
        //        var result = _context.V_BYO_PRODUCTIONs.Where(x => x.userSignOffBy == null); // && x.deleteFlag != "Y" && x.productionEOLFlag != "Y"
                
        //        var result_2 = result
        //        .GroupBy(b => new
        //        {
        //            b.opn,
        //            b.productionChangeOrder,
        //            b.companyCode,
        //            b.legacyOrganization,
        //            b.plmStatus,
        //            b.remarks
        //        })
        //        .Select(g => new
        //        {
        //            opn = g.Key.opn,
        //            productionChangeOrder = g.Key.productionChangeOrder,
        //            companyCode = g.Key.companyCode,
        //            legacyOrganization = g.Key.legacyOrganization,
        //            plmStatus = g.Key.plmStatus,
        //            remarks = g.Key.remarks,

        //            TT = g.Select(x => x.TT).FirstOrDefault(),
        //            updateDateAndTime = g.Max(x => x.updateDateAndTime)
        //        });

        //        return Ok(result_2);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
        //    }
        //}

        [Authorize]
        [Route("api/BYO_PRODUCT")]
        [HttpGet]
        public IActionResult BYO_PRODUCT([FromQuery] string[] partNumbers, string[] type, string[] remarks)
        {
            try
            {
                if (type[0] == "BYO_PRODUCTION" && remarks[0].Contains("SCENARIO-2"))
                {
                    var query = _context.PLM_PRODUCTs.AsQueryable();

                    if (partNumbers != null && partNumbers.Length > 0)
                    {
                        //query = query.Where(x => partNumbers.Contains(x.partNumber));
                        query = query.Where(x => x.partNumber == partNumbers[0]);
                    }
                    
                    var result = query.ToList();
                    return Ok(new
                    {
                        source = "OUT_PRODUCT",
                        data = result
                    });
                    return Ok(result);
                    //return Ok(result);
                }
                else {
                    var query = _context.V_BYO_PRODUCTs.AsQueryable();

                    if (partNumbers != null && partNumbers.Length > 0)
                    {
                        query = query.Where(x => x.partNumber == partNumbers[0]);
                    }
                    var result = query.ToList();
                    return Ok(new
                    {
                        source = "BYO_PRODUCT",
                        data = result
                    });
                    return Ok(result);
                    //return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

        [Authorize]
        [Route("api/BYO_PRODUCTION")]
        [HttpGet]
        public IActionResult BYO_PRODUCTION([FromQuery] string[] partNumbers, string[] type, string[] remarks, string[] materialType)
        {
            try
            {
                if (remarks[0] == "SCENARIO-1" || remarks[0] == "SCENARIO-2")
                {
                    var query = _context.V_BYO_PRODUCTIONs.AsQueryable();

                    if (partNumbers != null && partNumbers.Length > 0)
                    {
                        query = query.Where(x => x.opn == partNumbers[0]);
                    }

                    var result = query.ToList();
                    return Ok(new
                    {
                        source = "BYO_PRODUCTION",
                        data = result
                    });
                    return Ok(result);
                    //return Ok(result)
                }
                else if (remarks[0] == "SCENARIO-3" && materialType[0] == "ZFER") //OPN
                {
                    var query = _context.PLM_PRODUCTIONs.AsQueryable();

                    if (partNumbers != null && partNumbers.Length > 0)
                    {
                        query = query.Where(x => x.opn == partNumbers[0]);
                    }

                    var result = query.ToList();
                    return Ok(new
                    {
                        source = "OUT_PRODUCTION",
                        data = result
                    });
                    return Ok(result);
                    //return Ok(result)
                }
                else if (remarks[0] == "SCENARIO-3" && materialType[0] == "ZHAL") //MPN
                {
                    var query = _context.PLM_PRODUCTIONs.AsQueryable();

                    if (partNumbers != null && partNumbers.Length > 0)
                    {
                        query = query.Where(x => x.partNumber == partNumbers[0]);
                    }

                    var result = query.ToList();
                    return Ok(new
                    {
                        source = "OUT_PRODUCTION",
                        data = result
                    });
                    return Ok(result);
                    //return Ok(result)
                }
                else
                {
                    return Ok(null);
                }
                
                
                //var query = _context.V_BYO_PRODUCTIONs.AsQueryable();

                //if (partNumbers != null && partNumbers.Length > 0)
                //{
                //    query = query.Where(x => partNumbers.Contains(x.opn));
                //}

                //var result = query.ToList();

                //return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

        [Authorize]
        [Route("api/Buyoff_BYO_Product")]
        [HttpPost]
        public IActionResult Buyoff_BYO_Product([FromQuery] string[] partNumbers)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();
            
            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {
                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_BUYOFF_BYO_PRODUCT", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_partNumbers", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = partNumbers,
                            Size = partNumbers.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = partNumbers.Select(s => s.Length).ToArray()
                        };
                        command.Parameters.Add(param);

                        command.Parameters.Add("p_createdby", OracleDbType.Varchar2).Value = token.USER_ID;

                        var outputParam = new OracleParameter("p_result", OracleDbType.Varchar2, 4000)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        command.ExecuteNonQuery();

                        string result = outputParam.Value?.ToString();
                        return Ok(new { partNumbers, Result = result });
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/Buyoff_BYO_Production")]
        [HttpPost]
        public IActionResult Buyoff_BYO_Production([FromQuery] string[] OPNs)
        {
            TokenProperties token = new TokenProperties(User.Identity as ClaimsIdentity);
            token = token.GetTokenObject();

            BulkImportOperation biOperation = new BulkImportOperation(_context.Database.GetConnectionString());

            try
            {

                using (var connection = new OracleConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (var command = new OracleCommand("SP_BUYOFF_BYO_PRODUCTION", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        var param = new OracleParameter("p_OPNs", OracleDbType.Varchar2)
                        {
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = OPNs,
                            Size = OPNs.Length,
                            Direction = ParameterDirection.Input,
                            ArrayBindSize = OPNs.Select(s => s.Length).ToArray()
                        };
                        command.Parameters.Add(param);

                        command.Parameters.Add("p_createdby", OracleDbType.Varchar2).Value = token.USER_ID;

                        var outputParam = new OracleParameter("p_result", OracleDbType.Varchar2, 4000)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        command.ExecuteNonQuery();

                        string result = outputParam.Value?.ToString();
                        return Ok(new { OPNs, Result = result });

                    }
                }

                return Ok(OPNs);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }


        //[Authorize]
        //[HttpGet]
        //[Route("api/[controller]/GetHistory/{id}")]

        [Authorize]
        [Route("api/BYO/GetHistory")]
        [HttpGet]
        public IActionResult GetHistory(string TableName, string Id)
        {
            try
            {
                
                if (TableName == "BYO_PRODUCT_HIS") {
                    var result = _context.V_BYO_PRODUCT_HIs.Where(x => x.partNumber == Id).OrderByDescending(x => x.userSignOffDate);
                    return Ok(result);

                    //var result = (from p in _context.BYO_PRODUCT_HIs
                    //             where p.partNumber == Id
                    //             orderby p.updateDateAndTime descending
                    //             join user in _context.CFG_USERs
                    //                 on p.userSignOffBy equals user.USER_ID into userGroup
                    //             from u in userGroup.DefaultIfEmpty() // Left join
                    //             select new
                    //             {
                    //                 p.recordKey,
                    //                 p.partNumberKey,
                    //                 p.partNumber,
                    //                 p.materialType,
                    //                 p.materialTypeDetail,
                    //                 p.materialGroup,
                    //                 p.partDescription,
                    //                 p.legacyOrganization,
                    //                 p.originalPartNumber,
                    //                 p.groupStage,
                    //                 p.companyCode,
                    //                 p.baseUnitOfMeasure,
                    //                 p.plmStatus,
                    //                 p.legacyMPN,
                    //                 p.marketGroup,
                    //                 p.marketFamily,
                    //                 p.marketFamilyDetail,
                    //                 p.marketSegment,
                    //                 p.productHierarchyCode,
                    //                 p.productHierarchy1,
                    //                 p.productHierarchy2,
                    //                 p.productHierarchy3,
                    //                 p.productHierarchy4,
                    //                 p.productHierarchy5,
                    //                 p.profitCenter,
                    //                 p.businessUnit,
                    //                 p.businessDivision,
                    //                 p.gradeCode,
                    //                 p.gradeCodeDescription,
                    //                 p.priority1OPN,
                    //                 p.isPartAutomotive,
                    //                 p.isPartASIC,
                    //                 p.isPartITAR,
                    //                 p.isPartDolbyCapable,
                    //                 p.isPartMultipleComponent,
                    //                 p.isPartActive,
                    //                 p.whitePartNumber,
                    //                 p.basePartNumber,
                    //                 p.classCode,
                    //                 p.classCodeDescription,
                    //                 p.totalShelfLife,
                    //                 p.minimumOrderQuantity,
                    //                 p.frequencyOrderIncrement,
                    //                 p.defaultSalesOrderCreationPlant,
                    //                 p.companyOfOrigin,
                    //                 p.partAxis,
                    //                 p.autoShipping,
                    //                 p.packagingPackage,
                    //                 p.grossWeight,
                    //                 p.netWeight,
                    //                 p.standardPackingQuantity,
                    //                 p.packagingCarrier,
                    //                 p.packagingBox,
                    //                 p.packagingSpec,
                    //                 p.tsFlag,
                    //                 p.expiryDatePrintingFlag,
                    //                 p.sealDateFlag,
                    //                 p.halogenFreePrintingFlag,
                    //                 p.moistureSensitiveLevel,
                    //                 p.pcbOnBoardReflowStorageCondition,
                    //                 p.pcbOnBoardReflowRebakeCondition,
                    //                 p.roHSCompliant,
                    //                 p.roHSCompliantChina,
                    //                 p.roHSExemptPrintingFlag,
                    //                 p.roHSChinaExemptPrintingFlag,
                    //                 p.reachPrintingFlag,
                    //                 p.ulRegistrationFlag,
                    //                 p.lotSequenceCode,
                    //                 p.packageCode,
                    //                 p.packageCodeDescription,
                    //                 p.jedecReferenceID,
                    //                 p.pbFreeIndicator,
                    //                 p.finalTerminalFinish,
                    //                 p.packageType,
                    //                 p.packageGroup,
                    //                 p.packageCategory,
                    //                 p.packagePinCount,
                    //                 p.packagePitch,
                    //                 p.packageLength,
                    //                 p.packageWidth,
                    //                 p.packageBodyThickness,
                    //                 p.packageLayer,
                    //                 p.packageBodySize,
                    //                 p.numberOfDie,
                    //                 p.diePositionForMultiDie,
                    //                 p.assemblyOutPackagingType,
                    //                 p.singulationProcess,
                    //                 p.totalNumberOfAllWires,
                    //                 p.wireDiameter,
                    //                 p.wireType,
                    //                 p.chipVersion,
                    //                 p.thickness,
                    //                 p.bumpType,
                    //                 p.processTechnology,
                    //                 p.waferTechnology,
                    //                 p.roughWaferProcess,
                    //                 p.waferOrInStockClass,
                    //                 p.foundryPartNumber,
                    //                 p.grossDiePerWafer,
                    //                 p.productDiscontinueNotification,
                    //                 p.pdnIssueDate,
                    //                 p.pdnLastBuyDate,
                    //                 p.pdnLastShipDate,
                    //                 p.extendedSupportDate,
                    //                 p.orderUntilDate,
                    //                 p.businessPlannerCode,
                    //                 p.activeDate,
                    //                 p.productionDateP4,
                    //                 p.obsoleteDateP6,
                    //                 p.deactivateDateP7,
                    //                 p.mrpType,
                    //                 p.specNo,
                    //                 p.specNoGreenOrYellow,
                    //                 p.retisSeqNo,
                    //                 p.createDateAndTime,
                    //                 p.updateDateAndTime,
                    //                 p.updateType,
                    //                 p.deleteFlag,
                    //                 p.deleteDateAndTime,
                    //                 p.originalSourceSystem,
                    //                 p.fiestaRules,
                    //                 p.fiestaBuyoff,
                    //                 p.userBuyoff,
                    //                 p.customerPartNumber,
                    //                 p.matrixWafer,
                    //                 p.finalTestTestProgramRevision,
                    //                 p.ulRatingsText,
                    //                 p.plasticReelSize,
                    //                 p.carrierTapePocketPitch,
                    //                 p.carrierTapeWidth,
                    //                 p.packagingCarrierQuantity,
                    //                 p.bomItemText,
                    //                 p.reelHubSize,
                    //                 p.finalTerminalFinishDescription,
                    //                 p.assemblyOutPackagingQty,
                    //                 p.manufacturerPart,
                    //                 p.manufacturerPartDescription,
                    //                 p.unitLoadingOrientationQuadrant,
                    //                 p.pcbOnBoardReflowPeakTemperature,
                    //                 p.waferSize,
                    //                 p.moistureExposureTime,
                    //                 p.processSpecialTechnology,
                    //                 p.netDieBypass,
                    //                 p.referencePackageType,
                    //                 //p.userSignOffBy,
                    //                 userSignOffBy = u != null ? u.USER_FULL_NAME : "SYSTEM",
                    //                 p.userSignOffDate,
                    //                 p.productChangeOrder
                    //             }).OrderByDescending(x => x.userSignOffDate);
                    //return Ok(result);

                }
                else if (TableName == "BYO_PRODUCTION_HIS") {
                    var result = _context.V_BYO_PRODUCTION_HIs.Where(x => x.opn == Id).OrderByDescending(x => x.userSignOffDate);
                    return Ok(result);

                    //var result = (from p in _context.BYO_PRODUCTION_HIs
                    //             where p.partNumber == Id
                    //             orderby p.updateDateAndTime descending
                    //             join user in _context.CFG_USERs
                    //                 on p.userSignOffBy equals user.USER_ID into userGroup
                    //             from u in userGroup.DefaultIfEmpty() // Left join
                    //             select new
                    //             {
                    //                 p.recordKey,
                    //                 p.opn,
                    //                 p.bomLevel,
                    //                 p.parentPartNumber,
                    //                 p.parentOriginalPartNumber,
                    //                 p.parentProcessingSubType,
                    //                 p.parentGroupStage,
                    //                 p.partNumber,
                    //                 p.originalPartNumber,
                    //                 p.processingSubType,
                    //                 p.groupStage,
                    //                 p.groupStageType,
                    //                 p.unitOfMeasure,
                    //                 p.flowNumber,
                    //                 p.flowDescription,
                    //                 p.flowPlmStatus,
                    //                 p.operation,
                    //                 p.operationSequenceNumber,
                    //                 p.operationNumber,
                    //                 p.operationPlmStatus,
                    //                 p.companyCode,
                    //                 p.plant,
                    //                 p.storageLocation,
                    //                 p.lineName,
                    //                 p.dieSet,
                    //                 p.dieOrder,
                    //                 p.qty,
                    //                 p.supplyPlant,
                    //                 p.supplyStorageLocation,
                    //                 p.supplyLineName,
                    //                 p.createDateAndTime,
                    //                 p.updateDateAndTime,
                    //                 p.updateType,
                    //                 p.deleteFlag,
                    //                 p.deleteDateAndTime,
                    //                 p.fiestaRules,
                    //                 p.fiestaSource,
                    //                 p.productionEOLFlag,
                    //                 //p.userSignOffBy,
                    //                 userSignOffBy = u != null ? u.USER_FULL_NAME : "SYSTEM",
                    //                 p.userSignOffDate,
                    //                 p.productionChangeOrder
                    //             }).OrderByDescending(x => x.userSignOffDate);
                    //return Ok(result);
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }



        [Authorize]
        [Route("api/BuyoffSummary")]
        [HttpGet]
        public IActionResult BuyoffSummary()
        {
            try
            {
                var result = _context.V_BYO_SUMMARies; //.Where(x => x.userSignOffBy == null) && x.deleteFlag != "Y"
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
        }

        [Authorize]
        [Route("api/BYO/GetDDLProductChangeOrder")]
        [HttpGet]
        public IActionResult GetDDLProductChangeOrder(string partNumber)
        {
            try
            {
                var result = _context.V_BYO_PRODUCTs
                .Where(x => x.partNumber == partNumber)
                .Select(x => new
                {
                    x.prefixChangeOrder,
                    Source = 1
                }).Distinct();

                var result2 = _context.V_BYO_PRODUCT_HIs
                .Where(x => x.partNumber == partNumber)
                .Select(x => new
                {
                    x.prefixChangeOrder,
                    Source = 2
                }).Distinct();

                var combined = result
                    .Union(result2)
                    .Distinct()
                    .OrderBy(x => x.Source)
                    .ThenByDescending(x => x.prefixChangeOrder);

                return Ok(combined);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

        [Authorize]
        [Route("api/BYO/GetDDLProductionChangeOrder")]
        [HttpGet]
        public IActionResult GetDDLProductionChangeOrder(string opn)
        {
            try
            {
                var result = _context.V_BYO_PRODUCTIONs
                .Where(x => x.opn == opn)
                .Select(x => new
                {
                    x.prefixChangeOrder,
                    Source = 1
                }).Distinct();

                var result2 = _context.V_BYO_PRODUCTION_HIs
                .Where(x => x.opn == opn)
                .Select(x => new
                {
                    x.prefixChangeOrder,
                    Source = 2
                }).Distinct();

                var combined = result
                    .Union(result2)
                    .Distinct()
                    .OrderBy(x => x.Source)
                    .ThenByDescending(x => x.prefixChangeOrder);

                return Ok(combined);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

        [Authorize]
        [Route("api/BYO/GetProductVersionCompare")]
        [HttpGet]
        public IActionResult GetProductVersionCompare(string partNumber, string prefixChangeOrder)
        {
            try
            {
                var result = _context.V_BYO_PRODUCTs
                .Where(x => x.partNumber == partNumber & x.prefixChangeOrder == prefixChangeOrder);

                if (result.Count() >= 1)
                {
                    return Ok(result);
                }
                //else if (result.Count() == 0)
                //{
                //    var result2 = _context.V_BYO_PRODUCT_HIs
                //    .Where(x => x.partNumber == partNumber & x.prefixChangeOrder == prefixChangeOrder);
                //    return Ok(result2);
                //}
                else {
                    return BadRequest("Data not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

        [Authorize]
        [Route("api/BYO/GetProduct_His_VersionCompare")]
        [HttpGet]
        public IActionResult GetProduct_His_VersionCompare(string partNumber, string prefixChangeOrder)
        {
            try
            {
                var result = _context.V_BYO_PRODUCT_HIs
                .Where(x => x.partNumber == partNumber & x.prefixChangeOrder == prefixChangeOrder);

                if (result.Count() >= 1)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Data not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }


        [Authorize]
        [Route("api/BYO/GetProductionVersionCompare")]
        [HttpGet]
        public IActionResult GetProductionVersionCompare(string opn, string prefixChangeOrder)
        {
            try
            {
                var result = _context.V_BYO_PRODUCTIONs
                .Where(x => x.opn == opn & x.prefixChangeOrder == prefixChangeOrder)
                .OrderBy(x => x.opn)
                .ThenBy(x => x.parentPartNumber)
                .ThenBy(x => x.partNumber)
                .ThenBy(x => x.flowNumber)
                .ThenBy(x => x.plant)
                .ThenBy(x => x.storageLocation)
                .ThenBy(x => x.operationNumber)
                .ThenBy(x => x.dieSet)
                .ThenBy(x => x.supplyPlant)
                .ThenBy(x => x.supplyStorageLocation);

                if (result.Count() >= 1)
                {
                    return Ok(result);
                }
                //else if (result.Count() == 0)
                //{
                //    var result2 = _context.V_BYO_PRODUCTION_HIs
                //    .Where(x => x.opn == opn & x.prefixChangeOrder == prefixChangeOrder)
                //    .OrderBy(x => x.opn)
                //    .ThenBy(x => x.parentPartNumber)
                //    .ThenBy(x => x.partNumber)
                //    .ThenBy(x => x.flowNumber)
                //    .ThenBy(x => x.plant)
                //    .ThenBy(x => x.storageLocation)
                //    .ThenBy(x => x.operationNumber)
                //    .ThenBy(x => x.dieSet)
                //    .ThenBy(x => x.supplyPlant)
                //    .ThenBy(x => x.supplyStorageLocation);
                //    return Ok(result2);
                //}
                else
                {
                    return BadRequest("Data not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

        [Authorize]
        [Route("api/BYO/GetProduction_His_VersionCompare")]
        [HttpGet]
        public IActionResult GetProduction_His_VersionCompare(string opn, string prefixChangeOrder)
        {
            try
            {
                var result = _context.V_BYO_PRODUCTION_HIs
                .Where(x => x.opn == opn & x.prefixChangeOrder == prefixChangeOrder)
                .OrderBy(x => x.opn)
                .ThenBy(x => x.parentPartNumber)
                .ThenBy(x => x.partNumber)
                .ThenBy(x => x.flowNumber)
                .ThenBy(x => x.plant)
                .ThenBy(x => x.storageLocation)
                .ThenBy(x => x.operationNumber)
                .ThenBy(x => x.dieSet)
                .ThenBy(x => x.supplyPlant)
                .ThenBy(x => x.supplyStorageLocation);

                if (result.Count() >= 1)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Data not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }

    }

}
