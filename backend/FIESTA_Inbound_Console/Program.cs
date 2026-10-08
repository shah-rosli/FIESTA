using CsvHelper;
using DevExtreme.AspNet.Mvc;
using DocumentFormat.OpenXml.Math;
using FIESTA_Backend.EfModels;
//using static Org.BouncyCastle.Math.EC.ECCurve;--Kian Ann commented on 21 Jan, after install NPOI
using FIESTA_Inbound_Console.DataAccess.Inbound;
using FIESTA_Inbound_Console.InboundConversion;
using FIESTA_Inbound_Console.Models;
using FIESTA_Inbound_Console.Models.EOL;
using FIESTA_Inbound_Console.Models.MES;
using FIESTA_Inbound_Console.Models.PRIDES;
using FIESTA_Inbound_Console.Models.PROSTER;
using FIESTA_Inbound_Console.Models.RETIS;
using FIESTA_Inbound_Console.Models.S4;
using FIESTA_Inbound_Console.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NPOI.HPSF;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using UtilityCore.Models;
using UtilityCore.Utility.Compression;
using UtilityCore.Utility.Export;
using UtilityCore.Utility.Import;
using UtilityCore.Utility.Log;
using UtilityCore.Utility.Mail;
using WinSCP;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FIESTA_Inbound_Console
{
    internal class Program
    {
        static string filesSourcePath = string.Empty;
        static string filesDestinationPath = string.Empty;
        static string filesErrorPath = string.Empty;
        static string connString = string.Empty;
        static string errorEmailSender = string.Empty;
        static string errorEmailRecipient = string.Empty;
        static string emailHost = string.Empty;
        static OperationType operationType = OperationType.None;
        static string errorLog = string.Empty;
        static string filesLogPath = string.Empty;
        static int logRetentionPeriod = 30;
        static string sftpHostname = string.Empty;
        static string sftpUsername = string.Empty;
        static string sftpKeyPath = string.Empty;
        static bool autoArchive = false;
        static bool sendEmail = false;
        static string environmentName = string.Empty;
        static string tableName = string.Empty;
        static string inBoundPath = string.Empty;
        static string outBoundPath = string.Empty;
        static LogObject inLog;
        static LogDAL logDAL = null;
        static string sftpSubPath = string.Empty;
        static string extension = string.Empty;
        static bool getOnlyLatest = true;
        static bool isAll = false;
        static int maxRetryCount = 5;
        static WinSCP.SessionOptions sessionOptions = null;

        static void Main(string[] args)
        {
            AppendLog("Processing Started!");
            environmentName = Environment.GetEnvironmentVariable("FIESTA_ENVIRONMENT", EnvironmentVariableTarget.Machine);
            AppendLog("Environment Detected:" + environmentName);
            AppendLog("Current DIR:" + AppDomain.CurrentDomain.BaseDirectory);

            try
            {
                IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("inboundappsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

                IConfiguration backendConfig = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

                if (backendConfig != null)
                {
                    connString = backendConfig.GetConnectionString("ConnectionString_SB_" + environmentName);
                    if (!string.IsNullOrEmpty(connString))
                        logDAL = new LogDAL(connString);
                }

                var version = Assembly.GetExecutingAssembly().GetName().Version;
                AppendLog("Version:" + version);
                //argument [tablename]
                tableName = Configuration["tablename"];
                AppendLog("Table Name:" + tableName);
                sftpSubPath = Configuration["sftpSubPath"];
                AppendLog("SFTP IN Path: /IN/" + sftpSubPath);
                AppendLog("SFTP ARC Path: /ARC/" + sftpSubPath);
                extension = Configuration["extension"];
                AppendLog("Extension:" + extension);

                if (!string.IsNullOrEmpty(Configuration["getOnlyLatest"]))
                {
                    bool.TryParse(Configuration["getOnlyLatest"], out getOnlyLatest);
                }
                AppendLog("GetOnlyLatest:" + getOnlyLatest);

                if (!string.IsNullOrEmpty(Configuration["isAll"]))
                {
                    bool.TryParse(Configuration["isAll"], out isAll);
                }
                AppendLog("Is All:" + isAll);

                //initialize log obj
                inLog = new LogObject()
                {
                    OBJECT = "FIESTA_Inbound_Console " + tableName,
                    EXEC_BY = "FIESTAADM",
                    OPERATION = "IN"
                };

                switch (tableName)
                {
                    case "PRODUCT_HIERARCHY":
                        operationType = OperationType.PRODUCT_HIERARCHY;
                        break;
                    case "PROFIT_CENTER":
                        operationType = OperationType.PROFIT_CENTER;
                        break;
                    case "PROFIT_CENTER_HIERARCHY":
                        operationType = OperationType.PROFIT_CENTER_HIERARCHY;
                        break;
                    case "PRODUCTION_GROUP_STAGE":
                        operationType = OperationType.PRODUCTION_GROUP_STAGE;
                        break;
                    case "PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION":
                        operationType = OperationType.PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION;
                        break;
                    case "PRODUCTION_STAGE_CONVERSION":
                        operationType = OperationType.PRODUCTION_STAGE_CONVERSION;
                        break;
                    case "PRODUCTION_STAGE":
                        operationType = OperationType.PRODUCTION_STAGE;
                        break;
                    case "PRODUCTION_GROUP_STAGE_CONVERSION":
                        operationType = OperationType.PRODUCTION_GROUP_STAGE_CONVERSION;
                        break;
                    case "PRODUCTION_PLANT_CONVERSION":
                        operationType = OperationType.PRODUCTION_PLANT_CONVERSION;
                        break;
                    case "COMPANY_CODE":
                        operationType = OperationType.COMPANY_CODE;
                        break;
                    case "STORAGE_LOCATION":
                        operationType = OperationType.STORAGE_LOCATION;
                        break;
                    case "PLANTS":
                        operationType = OperationType.PLANTS;
                        break;
                    case "YIELD_MINITS":
                        operationType = OperationType.YIELD_MINITS;
                        break;
                    case "YIELD_PROSTER":
                        operationType = OperationType.YIELD_PROSTER;
                        break;
                    case "ROUTING":
                        operationType = OperationType.ROUTING;
                        break;
                    case "MPN_S4":
                        operationType = OperationType.MPN_S4;
                        break;
                    case "ALT_MIX_RATIOS":
                        operationType = OperationType.ALT_MIX_RATIOS;
                        break;
                    case "VERSION":
                        operationType = OperationType.VERSION;
                        break;
                    case "LEADTIME_MINITS":
                        operationType = OperationType.LEADTIME_MINITS;
                        break;
                    case "LEADTIME_PROSTER":
                        operationType = OperationType.LEADTIME_PROSTER;
                        break;
                    case "BOM":
                        operationType = OperationType.BOM;
                        break;
                    case "CYCLE_TIME":
                        operationType = OperationType.CYCLE_TIME;
                        break;
                    case "PN_STATUS"://can be RETIS or EOL
                        operationType = OperationType.PN_STATUS;
                        break;
                    case "RAW_MATERIAL":
                        operationType = OperationType.RAW_MATERIAL;
                        break;
                    case "OPN":
                        operationType = OperationType.OPN;
                        break;
                    case "PRODUCTION":
                        operationType = OperationType.PRODUCTION;
                        break;
                    case "PRODUCT":
                        operationType = OperationType.PRODUCT;
                        break;
                    case "MATERIAL":
                        operationType = OperationType.MATERIAL;
                        break;
                    case "COMPONENT":
                        operationType = OperationType.COMPONENT;
                        break;
                    case "CHARACTERISTICS":
                        operationType = OperationType.CHARACTERISTICS;
                        break;
                    case "PRODUCTION_FULL":
                        operationType = OperationType.PRODUCTION_FULL;
                        break;
                    case "PRODUCT_FULL":
                        operationType = OperationType.PRODUCT_FULL;
                        break;
                    case "MATERIAL_FULL":
                        operationType = OperationType.MATERIAL_FULL;
                        break;
                    case "COMPONENT_FULL":
                        operationType = OperationType.COMPONENT_FULL;
                        break;
                    case "CHARACTERISTICS_FULL":
                        operationType = OperationType.CHARACTERISTICS_FULL;
                        break;
                    case "STAGE_EXPANSION":
                        operationType = OperationType.STAGE_EXPANSION;
                        break;
                    case "CUS_SOLD_TO":
                        operationType = OperationType.CUS_SOLD_TO;
                        break;
                    case "CUS_BILL_TO":
                        operationType = OperationType.CUS_BILL_TO;
                        break;
                    case "CUS_SHIP_TO":
                        operationType = OperationType.CUS_SHIP_TO;
                        break;
                    case "CUS_END_CUSTOMER":
                        operationType = OperationType.CUS_END_CUSTOMER;
                        break;
                    case "FIN_IP_CUSTOMER":
                        operationType = OperationType.FIN_IP_CUSTOMER;
                        break;
                    case "FIN_IP_OPN":
                        operationType = OperationType.FIN_IP_OPN;
                        break;
                    case "PRODUCT_STANDARD_COST":
                        operationType = OperationType.PRODUCT_STANDARD_COST;
                        break;
                    case "PRODUCT_WIP_SELL_PRICE":
                        operationType = OperationType.PRODUCT_WIP_SELL_PRICE;
                        break;
                    case "VEN_VENDOR":
                        operationType = OperationType.VEN_VENDOR;
                        break;
                    case "VEN_VENDOR_COMPANY":
                        operationType = OperationType.VEN_VENDOR_COMPANY;
                        break;
                    case "VEN_VENDOR_PURCHASE_INFO_REC":
                        operationType = OperationType.VEN_VENDOR_PURCHASE_INFO_REC;
                        break;
                    case "FIN_COST_CENTER":
                        operationType = OperationType.FIN_COST_CENTER;
                        break;
                    case "CUS_PARTNER_FUNCTION":
                        operationType = OperationType.CUS_PARTNER_FUNCTION;
                        break;
                    case "PRODUCT_CAN_FLAGS4":
                        operationType = OperationType.PRODUCT_CAN_FLAGS4;
                        break;
                    case "NONPRODUCTION_PRODUCT":
                        operationType = OperationType.NONPRODUCTION_PRODUCT;
                        break;
                    case "NONPRODUCTION_PRODUCT_PLANT":
                        operationType = OperationType.NONPRODUCTION_PRODUCT_PLANT;
                        break;
                    case "NONPRODUCTION_PRODUCT_SALES":
                        operationType = OperationType.NONPRODUCTION_PRODUCT_SALES;
                        break;
                    default:
                        operationType = OperationType.None;
                        break;
                }

                //setting variable
                filesSourcePath = Configuration.GetSection("FilesSourcePath").Value;
                filesDestinationPath = Configuration.GetSection("FilesDestinationPath").Value;
                filesErrorPath = Configuration.GetSection("FilesErrorPath").Value;
                errorEmailSender = Configuration.GetSection("errorEmailSender").Value;
                errorEmailRecipient = Configuration.GetSection("errorEmailRecipient").Value;
                emailHost = Configuration.GetSection("emailHost").Value;
                inBoundPath = Configuration.GetSection("inboundpath").Value is null ? string.Empty : Configuration.GetSection("inboundpath").Value.Replace("/", "\\");
                outBoundPath = Configuration.GetSection("outboundpath").Value is null ? string.Empty : Configuration.GetSection("outboundpath").Value.Replace("\\", "/");

                filesLogPath = Configuration.GetSection("FilesLogPath").Value;
                int.TryParse(Configuration.GetSection("logRetentionPeriod").Value, out logRetentionPeriod);

                sftpKeyPath = Configuration.GetSection("SftpKeyPath").Value;
                sftpHostname = Configuration.GetSection("SftpHostname").Value;
                sftpUsername = Configuration.GetSection("SftpUsername").Value;

                if (string.IsNullOrEmpty(inBoundPath))
                {
                    inBoundPath = "/IN/" + sftpSubPath + "/" + tableName;
                }

                if (Configuration.GetSection("autoArchive").Value != null)
                {
                    bool.TryParse(Configuration.GetSection("autoArchive").Value, out autoArchive);
                }
                AppendLog("Auto Archive Mode: " + autoArchive.ToString());

                sessionOptions = new WinSCP.SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = sftpHostname,
                    UserName = sftpUsername,
                    GiveUpSecurityAndAcceptAnySshHostKey = true,
                    SshPrivateKeyPath = sftpKeyPath,
                };

                bool allowContinue = true;
                while (allowContinue)
                {
                    if (sftpSubPath == "AGL")
                    {
                        allowContinue = StartAgileWorkflow();
                    }
                    else
                    {
                        allowContinue = StartWorkflow();
                    }
                }

                //Last Step: Generate Outbound File based on processStatus = 0
                switch (operationType)
                {
                    case OperationType.NONPRODUCTION_PRODUCT:
                        //execute the 2nd SP regardless
                        Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);
                        AppendLog("Executing SP: SP_OUT_PRODUCT_CONSOLIDATE()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_OUT_PRODUCT_CONSOLIDATE");
                        AppendLog("Done.");
                        break;
                    case OperationType.CUS_SOLD_TO:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_CUS_SOLD_TOs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_CUS_SOLD_TO>(), "CUSTOMER_SOLDTO_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/CUSTOMER_SOLDTO/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed.");

                                    //setting the processStatus to 1
                                    foreach (OUT_CUS_SOLD_TO o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.CUS_BILL_TO:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_CUS_BILL_TOs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_CUS_BILL_TO>(), "CUSTOMER_BILLTO_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/CUSTOMER_BILLTO/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_CUS_BILL_TO o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.CUS_SHIP_TO:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_CUS_SHIP_TOs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_CUS_SHIP_TO>(), "CUSTOMER_SHIPTO_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/CUSTOMER_SHIPTO/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_CUS_SHIP_TO o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.CUS_END_CUSTOMER:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_CUS_END_CUSTOMERs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_CUS_END_CUSTOMER>(), "CUSTOMER_END_CUSTOMER_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/CUSTOMER_END_CUSTOMER/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_CUS_END_CUSTOMER o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.FIN_IP_CUSTOMER:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_FIN_IP_CUSTOMERs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_FIN_IP_CUSTOMER>(), "FINANCE_IP_CUSTOMER_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/FINANCE_IP_CUSTOMER/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_FIN_IP_CUSTOMER o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.FIN_IP_OPN:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_FIN_IP_OPNs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_FIN_IP_OPN>(), "FINANCE_IP_OPN_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/FINANCE_IP_OPN/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_FIN_IP_OPN o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.PRODUCT_STANDARD_COST:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_PRODUCT_STANDARD_COSTs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_PRODUCT_STANDARD_COST>(), "PRODUCT_STANDARD_COST_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/PRODUCT_STANDARD_COST/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_PRODUCT_STANDARD_COST o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.PRODUCT_WIP_SELL_PRICE:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_PRODUCT_WIP_SELL_PRICEs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_PRODUCT_WIP_SELL_PRICE>(), "PRODUCT_WIP_SELL_PRICE_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/PRODUCT_WIP_SELL_PRICE/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_PRODUCT_WIP_SELL_PRICE o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.VEN_VENDOR:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_VEN_VENDORs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_VEN_VENDOR>(), "VENDOR_VENDOR_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/VENDOR_VENDOR/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_VEN_VENDOR o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.VEN_VENDOR_COMPANY:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_VEN_VENDOR_COMPANies.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_VEN_VENDOR_COMPANY>(), "VENDOR_COMPANY_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/VENDOR_COMPANY/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_VEN_VENDOR_COMPANY o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.VEN_VENDOR_PURCHASE_INFO_REC:
                        //check if need to export file
                        using (var context = new MDMDbContext())
                        {
                            var result = context.OUT_VEN_VENDOR_PURCHASE_INFO_RECs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<OUT_VEN_VENDOR_PURCHASE_INFO_REC>(), "VENDOR_PURCHASE_INFO_REC_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/VENDOR_PURCHASE_INFO_REC/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (OUT_VEN_VENDOR_PURCHASE_INFO_REC o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.PROFIT_CENTER_HIERARCHY:
                        //check if need to export file
                        using (var context = new FiestaDbContext())
                        {
                            var result = context.MDM_PROFIT_CENTER_HIERARCHies.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<MDM_PROFIT_CENTER_HIERARCHY>(), "PROFIT_CENTER_HIERARCHY_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/PROFIT_CENTER_HIERARCHY/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (MDM_PROFIT_CENTER_HIERARCHY o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    case OperationType.PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION:
                        //check if need to export file
                        using (var context = new FiestaDbContext())
                        {
                            var result = context.MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs.Where(x => x.processStatus == "0");
                            //generate the pipe csv if there is processStatus = 0 records
                            if (result != null & result.Count() > 0)
                            {
                                AppendLog(result.Count() + " record(s) found for outbound file generation.");
                                if (ExportCsvBasedOnProcessStatus(result.ToList<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION>(), "MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"), "/OUT/MDM/PRODUCT_HIERARCHY_PROFIT_CENTER_CONVERSION/DELTA/"))
                                {
                                    AppendLog("Outbound File Generation Completed, updating Processing Status = 1 ...");

                                    //setting the processStatus to 1
                                    foreach (MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION o in result)
                                    {
                                        o.processStatus = "1";
                                    }
                                    context.SaveChanges();
                                    AppendLog("Done Update Process Status = 1 for the records.");
                                }
                            }
                        }
                        break;
                    default:
                        AppendLog("No outbound generation required.");
                        break;
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
            }

            //log into the txt file and email if error.
            Logging();
        }

        static bool ExportCsvBasedOnProcessStatus<T>(IEnumerable<T> result, string fileName, string remoteDirectory)
        {
            if (string.IsNullOrEmpty(outBoundPath))
            {
                outBoundPath = remoteDirectory;
            }

            //generate the csv file at csvTempPath/filename
            string path = CsvExporter.ExportCsv(result.ToList<T>(), fileName, null, false, "|", false, false, true, 65001);
            AppendLog("Outbound File: " + path + " generated.");
            //upload
            UploadFile(path, outBoundPath);
            AppendLog("Uploaded to SFTP Path: " + outBoundPath + fileName + ".csv.");

            return true;
        }

        //this is actual workflow of the import process, once a step is error, it will not proceed the next task.
        static bool StartWorkflow()
        {
            //variable of outcome
            bool allowContinue = true;

            //STEP 1:
            //copy from sftp
            string transferedFullPath = CopyFromSftp(operationType.ToString()).Result;

            //when no file, end the program.
            if (string.IsNullOrEmpty(transferedFullPath))
            {
                allowContinue = false;
            }

            //exit if source and destination path not exist
            if (!Directory.Exists(filesDestinationPath) || !Directory.Exists(filesSourcePath))
            {
                AppendError("Does not allow to proceed.\nSource or destination path not exist.\nSource:" + filesSourcePath + "\nDestination:" + filesDestinationPath);
                allowContinue = false;
            }

            //STEP 2: 
            FileInfo fi = null;
            if (allowContinue)
            {
                //unzip if it is zip file
                if (Path.GetExtension(transferedFullPath) == ".zip")
                {
                    ZipService.Unzip(transferedFullPath, Path.GetDirectoryName(transferedFullPath));

                    //list all the files from the directory
                    FileInfo[] fis = ListDirectoryLocal(Path.GetDirectoryName(transferedFullPath));
                    //find a file with same name, but not .zip extension, assign to fi.
                    fi = fis.Where(x => x.Name.StartsWith(Path.GetFileNameWithoutExtension(transferedFullPath)) && x.Extension != ".zip").FirstOrDefault();


                }
                //get the file info if it is not zip file
                else
                {
                    fi = new FileInfo(transferedFullPath);
                }
            }

            //STEP 3:
            //check the extension of the file, then import
            if (allowContinue && (fi == null || !fi.Exists))
            {
                AppendError("No file found after unzip with the name:" + Path.GetFileNameWithoutExtension(transferedFullPath));
                allowContinue = false;
            }

            if (allowContinue)
            {
                switch (fi.Extension)
                {
                    case ".json":
                        allowContinue = ImportTheJsonFile(fi.FullName, operationType).Result;
                        break;
                    case ".csv":
                        allowContinue = ImportTheCsvFile(fi.FullName, operationType).Result;
                        break;
                    case ".dat":
                        allowContinue = ImportTheDatFile(fi.FullName, operationType).Result;
                        break;
                    case ".txt":
                        allowContinue = ImportTheTxtFile(fi.FullName, operationType).Result;
                        break;
                }
            }

            AppendLog("Allow Continue: " + allowContinue.ToString());

            if (allowContinue)
            {
                allowContinue = InsertUpdateToPLM(operationType).Result;
            }

            //move file to error folder when there is issue (if the file exist)
            if (fi != null && fi.Exists)
            {
                //no error, move file to destination path
                if (allowContinue)
                {
                    AppendLog("Moving File to Destination Path: " + filesDestinationPath);
                    MoveFileLocal(fi, filesDestinationPath);
                }
                //error!!, move to error path
                else
                {

                    //customization, tableName not the same with SFTP folder name
                    tableName = VerifySftpPathName(tableName);

                    //revert the file back to SFTP
                    AppendLog("Moving File to back to SFTP IN Folder: " + inBoundPath + "/ERR");
                    //read ARC directory
                    RemoteDirectoryInfo dirInfo = ListDirectory(inBoundPath + "/ARC");
                    RemoteFileInfo arcFileInfo = null;

                    //make sure the dirInfo is not null
                    if (dirInfo != null)
                    {
                        arcFileInfo = dirInfo.Files.FirstOrDefault<RemoteFileInfo>(x => x.Name.StartsWith(Path.GetFileNameWithoutExtension(transferedFullPath)));
                    }

                    if (arcFileInfo != null)
                    {
                        //create error directory if not exist
                        CreateDirectoryIfNotExist(inBoundPath + "/ERR");

                        MoveFile(arcFileInfo, inBoundPath + "/ERR");
                    }

                    AppendError("Moving File to Error Path: " + filesErrorPath);
                    MoveFileLocal(fi, filesErrorPath);
                }

                //delete the zip file when no error
                DeleteFileLocal(transferedFullPath);
            }

            return allowContinue;
        }

        static bool StartAgileWorkflow()
        {
            //variable of outcome
            bool allowContinue = true;

            //STEP 1: Copy from AGILE TABLE TO FIESTA RAW_AGL_* table
            allowContinue = CopyFromAgileToRaw(operationType).Result;

            //STEP 2: INSERT / UPDATE to PLM_AGL_* table, truncate RAW_* upon success
            if (allowContinue)
            {
                allowContinue = InsertUpdateToPLM(operationType).Result;
            }

            return false;
        }
        static async Task<string> CopyFromSftp(string tableName)
        {
            try
            {
                //start log
                inLog.STATUS = 0;
                inLog = await logDAL.PerformLogging(inLog);

                //customization, tableName not the same with SFTP folder name
                tableName = VerifySftpPathName(tableName);

                string _sftpInPath = string.Empty;
                string _sftpArcPath = string.Empty;
                string _sourcePath = string.Empty;
                if (!string.IsNullOrEmpty(sftpSubPath))
                {
                    _sftpInPath = inBoundPath.Replace("\\", "/");
                    _sftpArcPath = inBoundPath.Replace("\\", "/") + "/ARC";
                    _sourcePath = Path.Combine(filesSourcePath, sftpSubPath, tableName);
                }

                //check in IN/tableName exist
                if (!Directory.Exists(_sourcePath))
                {
                    Directory.CreateDirectory(_sourcePath);
                }

                //STEP 1 - List Directory
                AppendLog("Fetching " + tableName + " File...");
                RemoteDirectoryInfo dirInfo = ListDirectory(_sftpInPath);

                RemoteFileInfo fileInfo = null;

                //make sure the dirInfo is not null
                if (dirInfo != null)
                {
                    if (getOnlyLatest)
                    {
                        AppendLog("Get Only Lastest with extension:" + extension);
                        fileInfo = dirInfo.Files.OrderByDescending(x => x.LastWriteTime).FirstOrDefault<RemoteFileInfo>();
                    }
                    else
                    {
                        //monthly _ALL_ file
                        if (isAll)
                        {
                            AppendLog("Get Oldest file name contains '_ALL_' with extension:" + extension);
                            fileInfo = dirInfo.Files.Where(x => Path.GetExtension(x.Name) == extension && Path.GetFileNameWithoutExtension(x.FullName).Contains("_ALL_")).OrderBy(x => x.LastWriteTime).FirstOrDefault<RemoteFileInfo>();
                        }
                        //delta file
                        else
                        {
                            AppendLog("Get Oldest file with extension:" + extension);
                            fileInfo = dirInfo.Files.Where(x => Path.GetExtension(x.Name) == extension).OrderBy(x => x.LastWriteTime).FirstOrDefault<RemoteFileInfo>();
                        }

                    }
                }

                //if the file exist
                if (fileInfo != null && !fileInfo.IsDirectory)
                {
                    AppendLog("File: " + fileInfo.Name + " - " + Math.Round(fileInfo.Length / 1048576d, 2) + "MB  exist!");

                    //STEP 2 - Download File
                    AppendLog("Trying to download ...");
                    TransferEventArgs args = DownloadFile(fileInfo.FullName, _sourcePath);

                    AppendLog("File: " + args.FileName + " downloaded successfully!");
                    if (autoArchive)
                    {
                        //check ARC/tableName exist
                        CreateDirectoryIfNotExist(_sftpArcPath);

                        //if Get Latest, need backup all the files
                        if (getOnlyLatest)
                        {
                            foreach (RemoteFileInfo info in dirInfo.Files)
                            {
                                if (!info.IsDirectory)
                                {
                                    MoveFile(info, _sftpArcPath);
                                }
                            }
                        }
                        //only move the file involved
                        else
                        {
                            MoveFile(fileInfo, _sftpArcPath);
                        }
                    }

                    //return the filename
                    return _sourcePath + "\\" + fileInfo.Name;
                }
                else
                {
                    AppendLog("No File Found in SFTP " + _sftpInPath + " folder...");
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
            }

            return string.Empty;
        }

        static RemoteDirectoryInfo ListDirectory(string directory)
        {
            int retryCount = 1;
            RemoteDirectoryInfo dirInfo = null;
            Session session = null;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: ListDirectory===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    session = new Session();
                    session.Open(sessionOptions);
                    AppendLog("Sftp Connection Successful.");
                    dirInfo = session.ListDirectory(directory);

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
                finally
                {
                    session.Dispose();
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }

            return dirInfo;
        }

        static FileInfo[] ListDirectoryLocal(string directory)
        {
            int retryCount = 1;
            FileInfo[] fi = null;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: ListDirectoryLocal===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    fi = new DirectoryInfo(directory).GetFiles();

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }

            return fi;
        }

        static void DeleteFile(string fullPath)
        {
            int retryCount = 1;
            Session session = null;
            string internalErrorStack = string.Empty;

            AppendLog("===Function: DeleteFile===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    session = new Session();
                    session.Open(sessionOptions);
                    AppendLog("Sftp Connection Successful.");

                    if (session.FileExists(fullPath))
                    {
                        AppendLog("Delete " + fullPath + " ...");
                        session.RemoveFile(fullPath);
                    }
                    else
                    {
                        AppendLog("No file found " + fullPath + " ...");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
                finally
                {
                    session.Dispose();
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }
        }

        static void DeleteFileLocal(string fullPath)
        {
            int retryCount = 1;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: DeleteFileLocal===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }
        }

        static void CreateDirectoryIfNotExist(string directory)
        {
            int retryCount = 1;
            Session session = null;
            string internalErrorStack = string.Empty;
            string dPath = string.Empty;
            AppendLog("===Function: CreateDirectoryIfNotExist===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    session = new Session();
                    session.Open(sessionOptions);
                    AppendLog("Sftp Connection Successful.");

                    var c = "/";
                    var splt = directory.Split(c);
                    foreach (var tPath in splt)
                    {
                        if (tPath != "")
                        {
                            dPath += c + tPath;
                            if (!session.FileExists(dPath))
                            {
                                session.CreateDirectory(dPath);
                                AppendLog("Directory created! : " + dPath);
                            }
                        }
                    }

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
                finally
                {

                    session.Dispose();
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }
        }

        static void CreateDirectoryIfNotExistLocal(string directory)
        {
            int retryCount = 1;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: CreateDirectoryIfNotExistLocal===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }
        }

        static void MoveFile(RemoteFileInfo info, string destination)
        {
            int retryCount = 1;
            Session session = null;
            string internalErrorStack = string.Empty;
            string destName = info.Name;

            AppendLog("===Function: MoveFile===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    session = new Session();
                    session.Open(sessionOptions);
                    AppendLog("Sftp Connection Successful.");

                    //create directory if not exist
                    CreateDirectoryIfNotExist(destination);

                    //if file exist, renamed append current date time.
                    if (session.FileExists(destination + "/" + info.Name))
                    {
                        //rename existing file to something else
                        destName = Path.GetFileNameWithoutExtension(info.Name) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(info.Name);
                        session.MoveFile(destination + "/" + info.Name, destination + "/" + destName);
                        AppendLog(info.Name + " exist in dest folder, renamed existing file to:" + destName);
                    }

                    if (session.FileExists(info.FullName))
                    {
                        AppendLog("Moving " + info.Name + " from " + info.FullName + " to " + destination + " ...");
                        session.MoveFile(info.FullName, destination + "/" + info.Name);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
                finally
                {
                    session.Dispose();
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }
        }

        static void MoveFileLocal(FileInfo info, string destination)
        {
            int retryCount = 1;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: MoveFileLocal===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);


                    //create directory if not exist
                    CreateDirectoryIfNotExistLocal(Path.GetDirectoryName(destination));

                    string destName = info.Name;

                    if (File.Exists(destination + "/" + info.Name))
                    {
                        destName = Path.GetFileNameWithoutExtension(info.Name) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(info.Name);
                        AppendLog(info.Name + " exist in dest folder, renamed to:" + destName);
                    }

                    if (File.Exists(info.FullName))
                    {
                        File.Move(info.FullName, destination + "/" + destName);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }
        }

        static TransferEventArgs UploadFile(string localFilePath, string remoteDirectory)
        {
            int retryCount = 1;
            TransferEventArgs args = null;
            string originalExt = null;
            string tmpExt = "tmp";
            Session session = null;
            string internalErrorStack = string.Empty;

            CreateDirectoryIfNotExist(remoteDirectory);

            AppendLog("===Function: UploadFile===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    session = new Session();
                    session.Open(sessionOptions);
                    AppendLog("Sftp Connection Successful.");

                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    AppendLog("Change file to tmp extension ...");
                    originalExt = Path.GetExtension(localFilePath);
                    File.Move(localFilePath, Path.ChangeExtension(localFilePath, tmpExt));
                    localFilePath = Path.ChangeExtension(localFilePath, tmpExt);

                    AppendLog("Uploading ...");
                    args = session.PutFileToDirectory(localFilePath, remoteDirectory, false, transferOptions);
                    var remFileInfo = session.GetFileInfo(remoteDirectory + "/" + Path.GetFileName(localFilePath));
                    AppendLog("Upload Completed!");

                    AppendLog("Change file to " + originalExt + " extension ...");
                    session.MoveFile(remFileInfo.FullName, Path.ChangeExtension(remFileInfo.FullName, originalExt));
                    File.Move(localFilePath, Path.ChangeExtension(localFilePath, originalExt));

                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
                finally
                {

                    session.Dispose();
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }

            return args;
        }

        static TransferEventArgs DownloadFile(string remoteFilePath, string localDirectory)
        {
            int retryCount = 1;
            TransferEventArgs args = null;
            Session session = null;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: DownloadFile===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);

                    session = new Session();
                    session.Open(sessionOptions);
                    AppendLog("Sftp Connection Successful.");

                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    AppendLog("Downloading ...");
                    args = session.GetFileToDirectory(remoteFilePath, localDirectory, false, transferOptions);
                    AppendLog("Download Completed!");
                    break;
                }
                catch (Exception ex)
                {
                    internalErrorStack += ex.Message + "\n" + ex.StackTrace;

                    retryCount++;
                    continue;
                }
                finally
                {

                    session.Dispose();
                }
            }

            //log error if exceeded retry count
            if (retryCount > maxRetryCount)
            {
                AppendError(internalErrorStack);
            }

            return args;
        }

        static bool SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(filePath);
                if (!info.Exists)
                {
                    info.Create();
                }

                string path = Path.Combine(filePath, fileName);
                using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
                {
                    inputStream.CopyTo(outputFileStream);
                }


            }
            catch (Exception ex)
            {
                AppendLog("File: " + fileName + " failed to be downloaded.");
                AppendError(ex.Message + "\n" + ex.StackTrace);
                return false;
            }

            AppendLog("File: " + fileName + " downloaded successfully.");

            return true;

        }

        static async Task<bool> ImportTheJsonFile(string fullPath, OperationType operationType)
        {
            //modified the newly arrived file, add [ ] to the text, removed trailing comma
            //modify the file
            string s = File.ReadAllText(fullPath);
            if (!s.StartsWith("[") && !s.EndsWith("]"))
            {
                AppendLog("Append [] and remove trailing comma for original JSON file...");
                s = "[" + s.Substring(0, s.Length - 1) + "]";
                File.WriteAllText(fullPath, s);
            }

            AppendLog("Deserialize JSON file to CpiInboundObj...");
            List<CpiInboundObj> listObj = null;
            //deserialize the file
            using (StreamReader file = File.OpenText(fullPath))
            {
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    listObj = (List<CpiInboundObj>)serializer.Deserialize(file, typeof(List<CpiInboundObj>));
                }
                catch (Exception ex)
                {
                    AppendError("Failed to deserialize json to object!");
                    AppendError(ex.Message);
                    if (ex.InnerException != null)
                        AppendError(ex.InnerException.Message);
                }
            }

            if (listObj != null && listObj.Count() > 0)
            {

                CpiInboundObj obj = new CpiInboundObj();
                foreach (CpiInboundObj o in listObj)
                {
                    obj.rows.AddRange(o.rows);
                }
                AppendLog(listObj.Count() + " page(s) with " + obj.rows.Count() + " record(s) available...");
                AppendLog("----------Start importing record to FIESTA!");
                CpiInboundResult result = ProcessingImportBulk(obj);
                AppendLog("----------End importing record to FIESTA!");
                AppendLog("Import Table Name: " + result.TableName);
                AppendLog("Import Status: " + result.Status);
                AppendLog("Record Inserted: " + result.RecordInserted);
                AppendLog("Record Updated: " + result.RecordUpdated);
                AppendLog("Record Error: " + result.RecordError);
                AppendLog("Error?: " + result.isError);

                string message = "Import Table Name: " + result.TableName + "\n" +
                                 "Import Status: " + result.Status + "\n" +
                                 "Record Inserted: " + result.RecordInserted + "\n" +
                                 "Record Updated: " + result.RecordUpdated + "\n" +
                                 "Record Error: " + result.RecordError + "\n" +
                                 "Error?: " + result.isError;

                AppendLog("Insert LOG_DATA_REQUEST...");
                inLog.REC_COUNT = obj.rows.Count();
                inLog.PAYLOAD = fullPath;
                inLog.MESSAGE = message;
                inLog.STATUS = 1;
                inLog = await logDAL.PerformLogging(inLog);

                //validation, only display when applicable (when there is a table name)
                FiestaValidationResult valResult = null;// ProcessingValidation();
                if (valResult != null && !string.IsNullOrEmpty(valResult.TableName))
                {
                    AppendLog("----------Start validation!");
                    AppendLog("Validation Table Name: " + valResult.TableName);
                    AppendLog("Validation Status: " + valResult.Status);
                    if (valResult.Records != null && valResult.Records.Rows != null && valResult.Records.Rows.Count > 0)
                    {
                        //try to print column header
                        string c = string.Empty;
                        foreach (DataColumn col in valResult.Records.Columns)
                        {
                            c = c + col.ColumnName + "\t\t";
                        }
                        AppendError(c);

                        //try to print a row...
                        foreach (DataRow row in valResult.Records.Rows)
                        {
                            string r = string.Empty;
                            foreach (var item in row.ItemArray)
                            {
                                r = r + item + "\t\t";
                            }
                            AppendError(r);
                        }
                    }

                    AppendLog("----------End validation!");
                }

                AppendLog("Done processing Inbound file for " + operationType + ".");
                return true;
            }
            else
            {
                inLog.REC_COUNT = 0;
                inLog.PAYLOAD = fullPath;
                inLog.MESSAGE = "Invalid or empty json content!";
                inLog.STATUS = 9;
                inLog = await logDAL.PerformLogging(inLog);
                AppendError("Invalid or empty json content!");
                return false;
            }

        }

        static async Task<bool> ImportTheCsvFile(string fullPath, OperationType operationType)
        {
            AppendLog("----------Start importing CSV record to FIESTA!");
            CpiInboundResult result = new CpiInboundResult();
            result.isError = false;
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);
            DataTable dt = null;

            AppendLog("operationType " + operationType);

            try
            {
                switch (operationType)
                {
                    case OperationType.PN_STATUS:
                        if (sftpSubPath == "RETIS")
                            dt = RetisPnStatus.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_RET_PNSTATUS().GetType(), false, 932));
                        break;
                    case OperationType.RAW_MATERIAL:
                        dt = RetisRawMaterial.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_RET_MATERIAL().GetType(), false, 932));
                        break;
                    case OperationType.YIELD_MINITS:
                        dt = ProsterYieldMinits.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_YIELD_MINITS().GetType(), false, 932));
                        break;
                    case OperationType.YIELD_PROSTER:
                        dt = ProsterYieldProster.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_YIELD_PROSTER().GetType(), false, 932));
                        break;
                    case OperationType.ROUTING:
                        dt = ProsterRouting.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_ROUTING().GetType(), false, 932));
                        break;
                    case OperationType.MPN_S4:
                        dt = ProsterMpnS4.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_MPN_S4().GetType(), false, 932));
                        break;
                    case OperationType.ALT_MIX_RATIOS:
                        dt = ProsterAltMixRatios.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_ALT_MIX_RATIOS().GetType(), false, 932));
                        break;
                    case OperationType.VERSION:
                        dt = ProsterVersion.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_VERSION().GetType(), false, 932));
                        break;
                    case OperationType.LEADTIME_MINITS:
                        dt = ProsterLeadtimeMinits.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_LEADTIME_MINITS().GetType(), false, 932));
                        break;
                    case OperationType.LEADTIME_PROSTER:
                        dt = ProsterLeadtimeProster.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_LEADTIME_PROSTER().GetType(), false, 932));
                        break;
                    case OperationType.BOM:
                        dt = ProsterBom.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_BOM().GetType(), false, 932));
                        break;
                    case OperationType.CYCLE_TIME:
                        dt = ProsterCycleTime.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_PRO_CYCLE_TIME().GetType(), false, 932));
                        break;
                    case OperationType.CUS_SOLD_TO:
                        dt = S4CusSoldTo.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_CUS_SOLD_TO().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.CUS_BILL_TO:
                        dt = S4CusBillTo.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_CUS_BILL_TO().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.CUS_SHIP_TO:
                        dt = S4CusShipTo.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_CUS_SHIP_TO().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.CUS_END_CUSTOMER:
                        dt = S4CusEndCustomer.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_CUS_END_CUSTOMER().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.FIN_IP_CUSTOMER:
                        dt = S4FinIpCustomer.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_FIN_IP_CUSTOMER().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.FIN_IP_OPN:
                        dt = S4FinIpOpn.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_FIN_IP_OPN().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PRODUCT_STANDARD_COST:
                        dt = S4ProductStandardCost.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PRODUCT_STANDARD_COST().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PRODUCT_WIP_SELL_PRICE:
                        dt = S4ProductWipSellPrice.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PRODUCT_WIP_SELL_PRICE().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.VEN_VENDOR:
                        dt = S4VenVendor.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_VEN_VENDOR().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.VEN_VENDOR_COMPANY:
                        dt = S4VenVendorCompany.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_VEN_VENDOR_COMPANY().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.VEN_VENDOR_PURCHASE_INFO_REC:
                        dt = S4VenVendorPurchaseInfoRec.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_VEN_VENDOR_PURCHASE_INFO_REC().GetType(), true, 65001, "|", true, true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.CUS_PARTNER_FUNCTION:
                        dt = S4CusPartnerFunction.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_CUS_PARTNER_FUNCTION().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.FIN_COST_CENTER:
                        dt = S4FinCostCenter.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_FIN_COST_CENTER().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PRODUCT_CAN_FLAGS4:
                        dt = S4ProductCanFlags4.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PRODUCT_CAN_FLAGS4().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PROFIT_CENTER:
                        dt = S4ProfitCenter.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PROFIT_CENTER().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PROFIT_CENTER_HIERARCHY:
                        dt = S4ProfitCenterHierarchy.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PROFIT_CENTER_HIERARCHY().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PRODUCT_HIERARCHY:
                        dt = S4ProductHierarchy.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PRODUCT_HIERARCHY().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION:
                        dt = S4ProductHierarchyProfitcenterConversion.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.NONPRODUCTION_PRODUCT:
                        dt = S4NonProductionProduct.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_NONPRODUCTION_PRODUCT().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.NONPRODUCTION_PRODUCT_PLANT:
                        dt = S4NonProductionProductPlant.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_NONPRODUCTION_PRODUCT_PLANT().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                    case OperationType.NONPRODUCTION_PRODUCT_SALES:
                        dt = S4NonProductionProductSales.ConvertObjToDT(CsvImporter.ReadCsvFile(fullPath, new CSV_S4_NONPRODUCTION_PRODUCT_SALES().GetType(), true, 65001, "|", true), Path.GetFileNameWithoutExtension(fullPath));//use pipe delimiter
                        break;
                }

                AppendLog("dt.Columns.Count " + dt.Columns.Count);
                AppendLog("dt.Rows.Count " + dt.Rows.Count);
            }
            catch (Exception ex)
            {
                AppendError("CSV error --> " + ex.Message + "\n" + ex.StackTrace);
                dt = null;
            }

            //proceed only if data table have data
            if (dt != null && dt.Rows.Count > 0)
            {

                result.TableName = dt.TableName;

                //truncate RAW table before bulk load
                AppendLog("Truncate " + "RAW_" + dt.TableName + " before start bulk load...");
                if (!result.isError && !dbOps.TruncateTable("RAW_" + result.TableName))
                {
                    result.isError = true;
                    result.Status = "Error Truncate Staging Table!";
                }

                //bulk copy
                if (!result.isError && !dbOps.BulkCopyToStagingTable(dt, "RAW_"))
                {
                    result.isError = true;
                    result.Status = "Error Bulk Copy to Staging!";
                }
                else
                {
                    result.RecordInserted = dt.Rows.Count;
                }
            }
            //ERROR!
            else
            {
                result.TableName = operationType.ToString();
                result.Status = "Error or empty data table!";
                result.isError = true;
            }

            AppendLog("----------End importing record to FIESTA!");
            AppendLog("Import Table Name: " + result.TableName);
            AppendLog("Import Status: " + result.Status);
            AppendLog("Record Inserted: " + result.RecordInserted);
            AppendLog("Record Updated: " + result.RecordUpdated);
            AppendLog("Record Error: " + result.RecordError);
            AppendLog("Error?: " + result.isError);

            string message = "Import Table Name: " + result.TableName + "\n" +
                             "Import Status: " + result.Status + "\n" +
                             "Record Inserted: " + result.RecordInserted + "\n" +
                             "Record Updated: " + result.RecordUpdated + "\n" +
                             "Record Error: " + result.RecordError + "\n" +
                             "Error?: " + result.isError;

            AppendLog("Insert LOG_DATA_REQUEST...");
            inLog.REC_COUNT = result.RecordInserted;
            inLog.PAYLOAD = fullPath;
            inLog.MESSAGE = message;
            inLog.STATUS = 1;
            inLog = await logDAL.PerformLogging(inLog);

            AppendLog("Done processing Inbound file for " + operationType + ".");
            return !result.isError;//return negation of isError
        }

        static string VerifySftpPathName(string tableName)
        {
            if (tableName == "CUS_SOLD_TO")
            {
                return "CUSTOMER_SOLDTO";
            }
            else if (tableName == "CUS_BILL_TO")
            {
                return "CUSTOMER_BILLTO";
            }
            else if (tableName == "CUS_SHIP_TO")
            {
                return "CUSTOMER_SHIPTO";
            }
            else if (tableName == "FIN_IP_CUSTOMER")
            {
                return "IPCUSTOMER";
            }
            else if (tableName == "VEN_VENDOR")
            {
                return "VENDOR_VENDOR";
            }
            else if (tableName == "VEN_VENDOR_COMPANY")
            {
                return "VENDOR_VENDOR_COMPANY";
            }
            else if (tableName == "VEN_VENDOR_PURCHASE_INFO_REC")
            {
                return "VENDOR_PURCHASE_INFO_REC";
            }
            else if (tableName == "CUS_PARTNER_FUNCTION")
            {
                return "CUSTOMER_CUSTPARTFUNCTION";
            }
            else if (tableName == "PRODUCT_CAN_FLAGS4")
            {
                return "CAN_FLAG";
            }
            else if (tableName == "FIN_COST_CENTER")
            {
                return "FINANCE_COST_CENTER";
            }
            else if (tableName == "PROFIT_CENTER")
            {
                return "FINANCE_PROFIT_CENTER";
            }
            else if (tableName == "PROFIT_CENTER_HIERARCHY")
            {
                return "FINANCE_PROFIT_CENTER_HIERARCHY";
            }
            else if (tableName == "PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION")
            {
                return "PRODHIERARCHY_PROFITCENTERCONVERSION";
            }
            else if (tableName == "NONPRODUCTION_PRODUCT")
            {
                return "PRODUCT";
            }
            else if (tableName == "NONPRODUCTION_PRODUCT_PLANT")
            {
                return "PRODUCT_PLANT";
            }
            else if (tableName == "NONPRODUCTION_PRODUCT_SALES")
            {
                return "PRODUCT_SALES";
            }
            else if (tableName == "CUS_END_CUSTOMER")
            {
                return "END_CUSTOMER";
            }
            else if (tableName == "PRODUCT_WIP_SELL_PRICE")
            {
                return "WIP_SELLING_PRICE";
            }


            return tableName;
        }

        static async Task<bool> ImportTheDatFile(string fullPath, OperationType operationType)
        {
            AppendLog("----------Start importing record to FIESTA!");
            CpiInboundResult result = new CpiInboundResult();
            result.isError = false;
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);
            DataTable dt = null;

            try
            {
                switch (operationType)
                {
                    case OperationType.OPN:
                        dt = PridesOpn.ConvertObjToDT(CsvImporter.ReadDatFile(fullPath, new DAT_PRI_OPN().GetType(), true, 932));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
                dt = null;
            }

            //proceed only if data table have data
            if (dt != null && dt.Rows.Count > 0)
            {

                result.TableName = dt.TableName;
                //truncate before bulk import
                AppendLog("Truncate " + "RAW_" + dt.TableName + " before start bulk load...");
                if (!result.isError && !dbOps.TruncateTable("RAW_" + result.TableName))
                {
                    result.isError = true;
                    result.Status = "Error Truncate Staging Table!";
                }
                //bulk copy
                if (!result.isError && !dbOps.BulkCopyToStagingTable(dt, "RAW_"))
                {
                    result.isError = true;
                    result.Status = "Error Bulk Copy to Staging!";
                }
                else
                {
                    result.RecordInserted = dt.Rows.Count;
                }
            }
            //ERROR!
            else
            {
                result.TableName = operationType.ToString();
                result.Status = "Error or empty data table!";
                result.isError = true;
            }

            AppendLog("----------End importing record to FIESTA!");
            AppendLog("Import Table Name: " + result.TableName);
            AppendLog("Import Status: " + result.Status);
            AppendLog("Record Inserted: " + result.RecordInserted);
            AppendLog("Record Updated: " + result.RecordUpdated);
            AppendLog("Record Error: " + result.RecordError);
            AppendLog("Error?: " + result.isError);

            string message = "Import Table Name: " + result.TableName + "\n" +
                             "Import Status: " + result.Status + "\n" +
                             "Record Inserted: " + result.RecordInserted + "\n" +
                             "Record Updated: " + result.RecordUpdated + "\n" +
                             "Record Error: " + result.RecordError + "\n" +
                             "Error?: " + result.isError;

            AppendLog("Insert LOG_DATA_REQUEST...");
            inLog.REC_COUNT = result.RecordInserted;
            inLog.PAYLOAD = fullPath;
            inLog.MESSAGE = message;
            inLog.STATUS = 1;
            inLog = await logDAL.PerformLogging(inLog);

            AppendLog("Done processing Inbound file for " + operationType + ".");
            return !result.isError;
        }

        static async Task<bool> ImportTheTxtFile(string fullPath, OperationType operationType)
        {
            AppendLog("----------Start importing record to FIESTA!");
            CpiInboundResult result = new CpiInboundResult();
            result.isError = false;
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);
            DataTable dt = null;

            try
            {
                switch (operationType)
                {
                    case OperationType.PN_STATUS:
                        if (sftpSubPath == "EOL")
                            dt = EolPnStatus.ConvertObjToDT(CsvImporter.ReadDatFile(fullPath, new TXT_EOL_PNSTATUS().GetType(), false));
                        break;
                    case OperationType.STAGE_EXPANSION:
                        dt = MesStageExpansion.ConvertObjToDT(CsvImporter.ReadDatFile(fullPath, new TXT_MES_STAGE_EXPANSION().GetType(), true, 932));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
                dt = null;
            }

            //proceed only if data table have data
            if (dt != null && dt.Rows.Count > 0)
            {

                result.TableName = dt.TableName;
                AppendLog("Truncate " + "RAW_" + dt.TableName + " before start bulk load...");
                if (!result.isError && !dbOps.TruncateTable("RAW_" + result.TableName))
                {
                    result.isError = true;
                    result.Status = "Error Truncate Staging Table!";
                }
                //bulk copy
                if (!result.isError && !dbOps.BulkCopyToStagingTable(dt, "RAW_"))
                {
                    result.isError = true;
                    result.Status = "Error Bulk Copy to Staging!";
                }
                else
                {
                    result.RecordInserted = dt.Rows.Count;
                }
            }
            //ERROR!
            else
            {
                result.TableName = operationType.ToString();
                result.Status = "Error or empty data table!";
                result.isError = true;
            }

            AppendLog("----------End importing record to FIESTA!");
            AppendLog("Import Table Name: " + result.TableName);
            AppendLog("Import Status: " + result.Status);
            AppendLog("Record Inserted: " + result.RecordInserted);
            AppendLog("Record Updated: " + result.RecordUpdated);
            AppendLog("Record Error: " + result.RecordError);
            AppendLog("Error?: " + result.isError);

            string message = "Import Table Name: " + result.TableName + "\n" +
                             "Import Status: " + result.Status + "\n" +
                             "Record Inserted: " + result.RecordInserted + "\n" +
                             "Record Updated: " + result.RecordUpdated + "\n" +
                             "Record Error: " + result.RecordError + "\n" +
                             "Error?: " + result.isError;

            AppendLog("Insert LOG_DATA_REQUEST...");
            inLog.REC_COUNT = result.RecordInserted;
            inLog.PAYLOAD = fullPath;
            inLog.MESSAGE = message;
            inLog.STATUS = 1;
            inLog = await logDAL.PerformLogging(inLog);

            AppendLog("Done processing Inbound file for " + operationType + ".");
            return !result.isError;
        }
        static CpiInboundResult ProcessingImportNotUsed(CpiInboundObj obj)
        {
            CpiInboundResult result = new CpiInboundResult();

            using (FiestaDbContext _context = new FiestaDbContext())
            {
                MdmInboundDALNotUsed dal = new MdmInboundDALNotUsed(_context);
                switch (operationType)
                {
                    case OperationType.PRODUCT_HIERARCHY:
                        result = dal.InsertUpdateProductHierarchy(MdmProductHierarchy.ConvertObjNotUsed(obj));
                        break;
                    case OperationType.PROFIT_CENTER:
                        result = dal.InsertUpdateProfitCenter(MdmProfitCenter.ConvertObjNotUsed(obj));
                        break;
                    case OperationType.PROFIT_CENTER_HIERARCHY:
                        result = dal.InsertUpdateProfitCenterHierarchy(MdmProfitCenterHierarchy.ConvertObjNotUsed(obj));
                        break;
                    case OperationType.PRODUCTION_GROUP_STAGE:
                        result = dal.InsertUpdateProductionGroupStage(MdmProductionGroupStage.ConvertObjNotUsed(obj));
                        break;
                    case OperationType.PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION:
                        result = dal.InsertUpdateProductHierarchyProfitcenterConversion(MdmProductHierarchyProfitcenterConversion.ConvertObj(obj));
                        break;
                    case OperationType.PRODUCTION_STAGE_CONVERSION:
                        result = dal.InsertUpdateProductionStageConversion(MdmProductionStageConversion.ConvertObj(obj));
                        break;
                    case OperationType.PRODUCTION_STAGE:
                        result = dal.InsertUpdateProductionStage(MdmProductionStage.ConvertObj(obj));
                        break;
                    case OperationType.PRODUCTION_GROUP_STAGE_CONVERSION:
                        result = dal.InsertUpdateProductionGroupStageConversion(MdmProductionGroupStageConversion.ConvertObjNotUsed(obj));
                        break;
                    case OperationType.PRODUCTION_PLANT_CONVERSION:
                        result = dal.InsertUpdateProductionPlantConversion(MdmProductionPlantConversion.ConvertObjNotUsed(obj));
                        break;
                }
            }

            return result;
        }

        static CpiInboundResult ProcessingImportBulk(CpiInboundObj obj)
        {
            CpiInboundResult result = new CpiInboundResult();
            result.isError = false;
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);
            DataTable dt = null;
            //string columnNames = string.Empty;
            switch (operationType)
            {
                case OperationType.PRODUCT_HIERARCHY:
                    dt = MdmProductHierarchy.ConvertObjToDT(obj);
                    //columnNames = MdmProductHierarchy.GetColumnNames();
                    break;
                case OperationType.PROFIT_CENTER:
                    dt = MdmProfitCenter.ConvertObjToDT(obj);
                    //columnNames = MdmProfitCenter.GetColumnNames();
                    break;
                case OperationType.PROFIT_CENTER_HIERARCHY:
                    dt = MdmProfitCenterHierarchy.ConvertObjToDT(obj);
                    //columnNames = MdmProfitCenterHierarchy.GetColumnNames();
                    break;
                case OperationType.PRODUCTION_GROUP_STAGE:
                    dt = MdmProductionGroupStage.ConvertObjToDT(obj);
                    //columnNames = MdmProductionGroupStage.GetColumnNames();
                    break;
                case OperationType.PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION:
                    dt = MdmProductHierarchyProfitcenterConversion.ConvertObjToDT(obj);
                    //columnNames = MdmProductHierarchyProfitcenterConversion.GetColumnNames();
                    break;
                case OperationType.PRODUCTION_STAGE_CONVERSION:
                    dt = MdmProductionStageConversion.ConvertObjToDT(obj);
                    //columnNames = MdmProductionStageConversion.GetColumnNames();
                    break;
                case OperationType.PRODUCTION_STAGE:
                    dt = MdmProductionStage.ConvertObjToDT(obj);
                    //columnNames = MdmProductionStage.GetColumnNames();
                    break;
                case OperationType.PRODUCTION_GROUP_STAGE_CONVERSION:
                    dt = MdmProductionGroupStageConversion.ConvertObjToDT(obj);
                    //columnNames = MdmProductionGroupStageConversion.GetColumnNames();
                    break;
                case OperationType.PRODUCTION_PLANT_CONVERSION:
                    dt = MdmProductionPlantConversion.ConvertObjToDT(obj);
                    //columnNames = MdmProductionPlantConversion.GetColumnNames();
                    break;
                case OperationType.COMPANY_CODE:
                    dt = MdmCompanyCode.ConvertObjToDT(obj);
                    //columnNames = MdmCompanyCode.GetColumnNames();
                    break;
                case OperationType.STORAGE_LOCATION:
                    dt = MdmStorageLocation.ConvertObjToDT(obj);
                    //columnNames = MdmStorageLocation.GetColumnNames();
                    break;
                case OperationType.PLANTS:
                    dt = MdmPlants.ConvertObjToDT(obj);
                    //columnNames = MdmPlants.GetColumnNames();
                    break;
            }
            //proceed only if data table have data
            if (dt != null && dt.Rows.Count > 0)
            {
                result.TableName = dt.TableName;
                AppendLog("Truncate " + "RAW_" + dt.TableName + " before start bulk load...");
                if (!result.isError && !dbOps.TruncateTable("RAW_" + result.TableName))
                {
                    result.isError = true;
                    result.Status = "Error Truncate Staging Table!";
                }
                //bulk copy
                if (!result.isError && !dbOps.BulkCopyToStagingTable(dt, "RAW_"))
                {
                    result.isError = true;
                    result.Status = "Error Bulk Copy to Staging!";
                }

                result.RecordInserted = dt.Rows.Count;
            }
            //ERROR!
            else
            {
                result.TableName = operationType.ToString();
                result.Status = "Error or empty data table!";
                result.isError = true;
            }

            return result;
        }

        static FiestaValidationResult ProcessingValidation()
        {
            FiestaValidationResult result = new FiestaValidationResult();
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);

            switch (operationType)
            {
                case OperationType.PRODUCTION_PLANT_CONVERSION:
                    result.TableName = operationType.ToString();
                    result.Records = dbOps.ExecuteReader("select * from V_VALIDATE_PRODUCTION_PLANT");
                    break;
            }

            if (result.Records != null && result.Records.Rows != null && result.Records.Rows.Count > 0)
            {
                result.Status = "Error in Validation!";
            }
            else
            {
                result.Status = "Success in Validation!";
            }

            return result;
        }

        static async Task<bool> CopyFromAgileToRaw(OperationType operationType)
        {
            bool allowContinue = false;
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);

            try
            {
                switch (operationType)
                {
                    case OperationType.PRODUCTION:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_PRODUCTION()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_PRODUCTION");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_PRODUCT()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_PRODUCT");
                        AppendLog("Done.");
                        break;
                    case OperationType.MATERIAL:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_MATERIAL()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_MATERIAL");
                        AppendLog("Done.");
                        break;
                    case OperationType.COMPONENT:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_COMPONENT()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_COMPONENT");
                        AppendLog("Done.");
                        break;
                    case OperationType.CHARACTERISTICS:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_CHARACTERISTICS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_CHARACTERISTICS");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCTION_FULL:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_PRODUCTION_FULL()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_PRODUCTION_FULL");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_FULL:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_PRODUCT_FULL()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_PRODUCT_FULL");
                        AppendLog("Done.");
                        break;
                    case OperationType.MATERIAL_FULL:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_MATERIAL_FULL()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_MATERIAL_FULL");
                        AppendLog("Done.");
                        break;
                    case OperationType.COMPONENT_FULL:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_COMPONENT_FULL()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_COMPONENT_FULL");
                        AppendLog("Done.");
                        break;
                    case OperationType.CHARACTERISTICS_FULL:
                        AppendLog("Executing SP: SP_AGL_TO_RAW_CHARACTERISTICS_FULL()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_AGL_TO_RAW_CHARACTERISTICS_FULL");
                        AppendLog("Done.");
                        break;
                    default:
                        //default option for those dont have SP to execute
                        allowContinue = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
                allowContinue = false;
            }

            return allowContinue;
        }

        static async Task<bool> InsertUpdateToPLM(OperationType operationType)
        {
            bool allowContinue = false;
            Utility.DatabaseOperation dbOps = new Utility.DatabaseOperation(connString);

            try
            {
                switch (operationType)
                {
                    //MDM part
                    case OperationType.PLANTS:
                        AppendLog("Executing SP: SP_RAW_TO_MDM_PLANTS()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MDM_PLANTS");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_HIERARCHY:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_MDM_PRODUCT_HIERARCHY()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_MDM_PRODUCT_HIERARCHY");
                        AppendLog("Done.");
                        break;
                    case OperationType.PROFIT_CENTER:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_MDM_PROFIT_CENTER()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_MDM_PROFIT_CENTER");
                        AppendLog("Done.");
                        break;
                    case OperationType.PROFIT_CENTER_HIERARCHY:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_MDM_PROFIT_CENTER_HIERARCHY()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_MDM_PROFIT_CENTER_HIERARCHY");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCTION_GROUP_STAGE:
                        AppendLog("Executing SP: SP_RAW_TO_MDM_PRODUCTION_GROUP_STAGE()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MDM_PRODUCTION_GROUP_STAGE");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCTION_GROUP_STAGE_CONVERSION:
                        AppendLog("Executing SP: SP_RAW_TO_MDM_PRODUCTION_GROUP_STAGE_CONVERSION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MDM_PRODUCTION_GROUP_STAGE_CONVERSION");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCTION_PLANT_CONVERSION:
                        AppendLog("Executing SP: SP_RAW_TO_MDM_PRODUCTION_PLANT_CONVERSION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MDM_PRODUCTION_PLANT_CONVERSION");
                        AppendLog("Done.");
                        break;
                    case OperationType.COMPANY_CODE:
                        AppendLog("Executing SP: SP_RAW_TO_MDM_COMPANY_CODE()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MDM_COMPANY_CODE");
                        AppendLog("Done.");
                        break;
                    case OperationType.STORAGE_LOCATION:
                        AppendLog("Executing SP: SP_RAW_TO_MDM_STORAGE_LOCATION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MDM_STORAGE_LOCATION");
                        AppendLog("Done.");
                        break;
                    //MDM part
                    case OperationType.PN_STATUS:
                        if (sftpSubPath == "RETIS")
                        {
                            AppendLog("Executing SP: SP_RAW_TO_PLM_RET_PNSTATUS()");
                            allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_RET_PNSTATUS");
                            AppendLog("Done.");
                        }
                        else if (sftpSubPath == "EOL")
                        {
                            AppendLog("Executing SP: SP_RAW_TO_PLM_EOL_STATUS()");
                            allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_EOL_STATUS");
                            AppendLog("Done.");
                        }
                        break;
                    case OperationType.RAW_MATERIAL:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_RET_MATERIAL()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_RET_MATERIAL");
                        AppendLog("Done.");
                        break;
                    case OperationType.YIELD_MINITS:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_YIELD_MINITS()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_YIELD_MINITS");
                        AppendLog("Done.");
                        break;
                    case OperationType.YIELD_PROSTER:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_YIELD_PROSTER()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_YIELD_PROSTER");
                        AppendLog("Done.");
                        break;
                    case OperationType.ROUTING:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_ROUTING()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_ROUTING");
                        AppendLog("Done.");
                        break;
                    case OperationType.MPN_S4:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_MPN_S4()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_MPN_S4");
                        AppendLog("Done.");
                        break;
                    case OperationType.ALT_MIX_RATIOS:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_ALT_MIX_RATIOS()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_ALT_MIX_RATIOS");
                        AppendLog("Done.");
                        break;
                    case OperationType.VERSION:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_VERSION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_VERSION");
                        AppendLog("Done.");
                        break;
                    case OperationType.LEADTIME_MINITS:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_LEADTIME_MINITS()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_LEADTIME_MINITS");
                        AppendLog("Done.");
                        break;
                    case OperationType.LEADTIME_PROSTER:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_LEADTIME_PROSTER()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_LEADTIME_PROSTER");
                        AppendLog("Done.");
                        break;
                    case OperationType.BOM:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_BOM()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_BOM");
                        AppendLog("Done.");
                        break;
                    case OperationType.CYCLE_TIME:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRO_CYCLE_TIME()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRO_CYCLE_TIME");
                        AppendLog("Done.");
                        break;
                    case OperationType.OPN:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_PRI_OPN()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_PLM_PRI_OPN");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCTION:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_AGL_PRODUCTION()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_TO_PLM_AGL_PRODUCTION");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_AGL_PRODUCT()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_TO_PLM_AGL_PRODUCT");
                        AppendLog("Done.");
                        break;
                    case OperationType.MATERIAL:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_AGL_MATERIALS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_TO_PLM_AGL_MATERIALS");
                        AppendLog("Done.");
                        break;
                    case OperationType.COMPONENT:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_AGL_COMPONENTS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_TO_PLM_AGL_COMPONENTS");
                        AppendLog("Done.");
                        break;
                    case OperationType.CHARACTERISTICS:
                        AppendLog("Executing SP: SP_RAW_TO_PLM_AGL_CHARACTERISTICS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_TO_PLM_AGL_CHARACTERISTICS");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCTION_FULL:
                        AppendLog("Executing SP: SP_RAW_FULL_TO_PLM_AGL_PRODUCTION()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_FULL_TO_PLM_AGL_PRODUCTION");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_FULL:
                        AppendLog("Executing SP: SP_RAW_FULL_TO_PLM_AGL_PRODUCT()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_FULL_TO_PLM_AGL_PRODUCT");
                        AppendLog("Done.");
                        break;
                    case OperationType.MATERIAL_FULL:
                        AppendLog("Executing SP: SP_RAW_FULL_TO_PLM_AGL_MATERIALS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_FULL_TO_PLM_AGL_MATERIALS");
                        AppendLog("Done.");
                        break;
                    case OperationType.COMPONENT_FULL:
                        AppendLog("Executing SP: SP_RAW_FULL_TO_PLM_AGL_COMPONENTS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_FULL_TO_PLM_AGL_COMPONENTS");
                        AppendLog("Done.");
                        break;
                    case OperationType.CHARACTERISTICS_FULL:
                        AppendLog("Executing SP: SP_RAW_FULL_TO_PLM_CHARACTERISTICS()");
                        allowContinue = dbOps.ExecuteStoredProcedure("SP_RAW_FULL_TO_PLM_AGL_CHARACTERISTICS");
                        AppendLog("Done.");
                        break;
                    case OperationType.STAGE_EXPANSION:
                        AppendLog("Executing SP: SP_RAW_TO_MES_STAGE_EXPANSION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithReturn("SP_RAW_TO_MES_STAGE_EXPANSION");
                        AppendLog("Done.");
                        break;
                    case OperationType.CUS_SOLD_TO:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_CUS_SOLD_TO()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_CUS_SOLD_TO");
                        AppendLog("Done.");
                        break;
                    case OperationType.CUS_BILL_TO:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_CUS_BILL_TO()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_CUS_BILL_TO");
                        AppendLog("Done.");
                        break;
                    case OperationType.CUS_SHIP_TO:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_CUS_SHIP_TO()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_CUS_SHIP_TO");
                        AppendLog("Done.");
                        break;
                    case OperationType.CUS_END_CUSTOMER:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_CUS_END_CUSTOMER()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_CUS_END_CUSTOMER");
                        AppendLog("Done.");
                        break;
                    case OperationType.FIN_IP_CUSTOMER:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_FIN_IP_CUSTOMER()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_FIN_IP_CUSTOMER");
                        AppendLog("Done.");
                        break;
                    case OperationType.FIN_IP_OPN:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_FIN_IP_OPN()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_FIN_IP_OPN");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_STANDARD_COST:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_PRODUCT_STANDARD_COST()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_PRODUCT_STANDARD_COST");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_WIP_SELL_PRICE:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_PRODUCT_WIP_SELL_PRICE()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_PRODUCT_WIP_SELL_PRICE");
                        AppendLog("Done.");
                        break;
                    case OperationType.VEN_VENDOR:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_VEN_VENDOR()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_VEN_VENDOR");
                        AppendLog("Done.");
                        break;
                    case OperationType.VEN_VENDOR_COMPANY:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_VEN_VENDOR_COMPANY()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_VEN_VENDOR_COMPANY");
                        AppendLog("Done.");
                        break;
                    case OperationType.VEN_VENDOR_PURCHASE_INFO_REC:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_VEN_VENDOR_PURCHASE_INFO_REC()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_VEN_VENDOR_PURCHASE_INFO_REC");
                        AppendLog("Done.");
                        break;
                    case OperationType.CUS_PARTNER_FUNCTION:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_CUS_PARTNER_FUNCTION()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_CUS_PARTNER_FUNCTION");
                        AppendLog("Done.");
                        break;
                    case OperationType.PRODUCT_CAN_FLAGS4:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_PRODUCT_CAN_FLAGS4()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_PRODUCT_CAN_FLAGS4");
                        AppendLog("Done.");
                        break;
                    case OperationType.FIN_COST_CENTER:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_FIN_COST_CENTER()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_FIN_COST_CENTER");
                        AppendLog("Done.");
                        break;
                    case OperationType.NONPRODUCTION_PRODUCT:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_NONPRODUCTION_PRODUCT()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_NONPRODUCTION_PRODUCT");
                        AppendLog("Done.");
                        break;
                    case OperationType.NONPRODUCTION_PRODUCT_PLANT:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_NONPRODUCTION_PLANT()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_NONPRODUCTION_PLANT");
                        AppendLog("Done.");
                        break;
                    case OperationType.NONPRODUCTION_PRODUCT_SALES:
                        AppendLog("Executing SP: SP_RAW_TO_OUT_NONPRODUCTION_SALES()");
                        allowContinue = dbOps.ExecuteStoredProcedureWithStatusReturn("SP_RAW_TO_OUT_NONPRODUCTION_SALES");
                        AppendLog("Done.");
                        break;
                    default:
                        //default option for those dont have SP to execute
                        allowContinue = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
                allowContinue = false;
            }

            return allowContinue;
        }

        static string CopySql(string tableName, string columnName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into {0} ({1}) select {1} from RAW_{0}", tableName, columnName);
            return sb.ToString();
        }

        static void MoveFileToErrorFolder(string source, string filename)
        {
            File.Copy(source, Path.Combine(string.Format(@"{0}\{1}{2:_yyyyMMdd_HHmmss}{3}", filesErrorPath, filename, DateTime.Now, ".json")));
            //delete existing source
            File.Delete(source);
        }



        public static void AppendLog(string log)
        {
            log = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "][INFO] " + log + Environment.NewLine;
            errorLog += log;
            Console.WriteLine(log);
        }

        public static void AppendError(string log)
        {
            log = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "][ERR] " + log + Environment.NewLine;
            errorLog += log;
            Console.WriteLine(log);

            sendEmail = true;
        }

        static void Logging()
        {
            //write the log into log folder
            string filename = filename = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + operationType + ".txt";
            string logFullPath = Path.Combine(string.Format(@"{0}\{1}", filesLogPath, filename));
            using (StreamWriter writer = new StreamWriter(logFullPath))
            {
                writer.WriteLine(errorLog);
            }


            Console.WriteLine("sendEmail " + sendEmail);

            if (sendEmail)
            {
                //send email
                try
                {
                    EmailOperation.SendEmailWithErrorLog(
                    emailHost,
                    "FIESTA Inbound Loader Error " + environmentName + ": " + tableName,
                    errorEmailRecipient,
                    errorEmailSender,
                    logFullPath,
                    filename);
                }
                catch (Exception ex)
                {
                    AppendLog("Error Sending Email:" + ex.Message + "\n" + ex.StackTrace);
                }
            }

            //delete files older than retention period
            string[] files = Directory.GetFiles(filesLogPath);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTime < DateTime.Now.AddDays(-logRetentionPeriod))
                    fi.Delete();
            }
        }
    }
}