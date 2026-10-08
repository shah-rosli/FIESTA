using DocumentFormat.OpenXml.Office.CustomUI;
using FIESTA_Backend.EfModels;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NPOI.HPSF;
using NPOI.SS.Formula.Functions;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using UtilityCore.Models;
using UtilityCore.Utility.Compression;
using UtilityCore.Utility.Export;
using UtilityCore.Utility.Log;
using UtilityCore.Utility.Mail;
using WinSCP;
//using Microsoft.Data.SqlClient;

namespace FIESTA_Console
{
    internal class Program
    {
        static string csvTempPath = string.Empty;
        static string csvDelimiter = string.Empty;
        static bool csvQuote = true;
        static string filesLogPath = string.Empty;
        static string filesFolder = string.Empty;
        static string filesDownloadPath = string.Empty;
        static int logRetentionPeriod = 29;
        static int arcRetentionPeriod = 6;
        static string errorEmailSender = string.Empty;
        static string errorEmailRecipient = string.Empty;
        static string copyTo = string.Empty;
        static string copyToFileName = string.Empty;
        static bool toUI = true;
        static bool toSFTP = true;
        static string emailHost = string.Empty;
        static string sftpHostname = string.Empty;
        static string sftpUsername = string.Empty;
        static string sftpKeyPath = string.Empty;
        static string outBoundPath = string.Empty;
        static WinSCP.SessionOptions sessionOptions = null;
        public static string environmentName = string.Empty;
        static int maxRetryCount = 5;

        static string tableName = string.Empty;
        static string extMode = string.Empty;
        static bool needTxt = false;
        static bool needZipped = true;
        static bool needHeader = true;
        static bool fullChunkData = false;

        static string errorLog = string.Empty;
        static bool sendErrorLogEmail = false;
        static LogObject outLog;
        static LogDAL logDAL = null;

        static void Main(string[] args)
        {
            AppendLog("Processing Started!");
            environmentName = Environment.GetEnvironmentVariable("FIESTA_ENVIRONMENT", EnvironmentVariableTarget.Machine);
            AppendLog("Environment Detected:" + environmentName);
            AppendLog("Current DIR:" + AppDomain.CurrentDomain.BaseDirectory);

            string zipDestination = string.Empty;
            try
            {
                IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("consoleappsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

                IConfiguration backendConfig = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

                if (backendConfig == null)
                {
                    throw new Exception($"{nameof(backendConfig)} cannot be null");
                }

                var connectionString = backendConfig.GetConnectionString("ConnectionString_SB_" + environmentName);
                if (!string.IsNullOrEmpty(connectionString))
                    logDAL = new LogDAL(connectionString);

                //argument [tablename]
                tableName = Configuration["tablename"];

                //argument [zipDestination]
                zipDestination = Configuration["zipdestination"];

                //argument [needTxt] = default is false
                if (!string.IsNullOrEmpty(Configuration["needTxt"]?.ToString())) bool.TryParse(Configuration["needTxt"]?.ToString(), out needTxt);

                //argument [needHeader] = default is true
                if (!string.IsNullOrEmpty(Configuration["needHeader"]?.ToString())) bool.TryParse(Configuration["needHeader"]?.ToString(), out needHeader);

                //argument [needZipped] = default is true
                if (!string.IsNullOrEmpty(Configuration["needZipped"]?.ToString())) bool.TryParse(Configuration["needZipped"]?.ToString(), out needZipped);

                //argument [extFolder] = default is empty
                extMode = Configuration["mode"] is null ? string.Empty : Configuration["mode"];

                //argument [outboundpath] = default is empty
                outBoundPath = Configuration["outboundpath"] is null ? string.Empty : Configuration["outboundpath"].Replace("/", "\\");

                //initialize log obj
                outLog = new LogObject()
                {
                    OBJECT = "FIESTA_Console " + tableName,
                    EXEC_BY = "FIESTAADM",
                    OPERATION = "OUT"
                };

                if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(zipDestination))
                {
                    AppendError("Program Argument tablename or zipdestination is empty!");
                }
                else
                {
                    var version = Assembly.GetExecutingAssembly().GetName().Version;
                    AppendLog("Version:" + version);
                    AppendLog("TableName:" + tableName);
                    AppendLog("ZipDestination:" + zipDestination);
                    AppendLog("NeedTxt:" + needTxt);
                    AppendLog("NeedZipped:" + needZipped);
                    AppendLog("NeedHeader:" + needHeader);

                    csvTempPath = Configuration.GetSection("CsvTempPath").Value;
                    filesDownloadPath = Configuration.GetSection("FilesDownloadPath").Value;
                    //setting variable
                    errorEmailSender = Configuration.GetSection("errorEmailSender").Value;
                    errorEmailRecipient = Configuration.GetSection("errorEmailRecipient").Value;
                    emailHost = Configuration.GetSection("emailHost").Value;

                    filesLogPath = Configuration.GetSection("FilesLogPath").Value;
                    int.TryParse(Configuration.GetSection("LogRetentionPeriod").Value, out logRetentionPeriod);
                    int.TryParse(Configuration.GetSection("ArcRetentionPeriod").Value, out arcRetentionPeriod);
                    sftpKeyPath = Configuration.GetSection("SftpKeyPath").Value;
                    sftpHostname = Configuration.GetSection("SftpHostname").Value;
                    sftpUsername = Configuration.GetSection("SftpUsername").Value;

                    copyTo = Configuration.GetSection("copyTo").Value ?? "";
                    toUI = Configuration.GetSection("toUI")?.Value?.ToLower() == "false" ? false : true;
                    toSFTP = Configuration.GetSection("toSFTP")?.Value?.ToLower() == "false" ? false : true;

                    if (!toSFTP) sftpHostname = "";     // To disabled SFTP if toSFTP is false
                    if (!toUI)
                    {
                        // To disabled extended UI file if toUI is false
                        copyTo = "";
                        filesDownloadPath = "";     // Disable download path if toUI is false
                    }

                    if (!toUI && !toSFTP)
                    {
                        AppendError("Both toUI and toSFTP are false, no output will be generated.");
                        goto EndOfProgram;
                    }

                    sessionOptions = new WinSCP.SessionOptions
                    {
                        Protocol = Protocol.Sftp,
                        HostName = sftpHostname,
                        UserName = sftpUsername,
                        GiveUpSecurityAndAcceptAnySshHostKey = true,
                        SshPrivateKeyPath = sftpKeyPath,
                    };

                    if (tableName == "CFG_SYSTEM_TRIGGERING")
                    {
                        ExecuteSystemTriggers();
                    }
                    else
                    {
                        GetRecordsOfTable(tableName, zipDestination);
                    }
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
            }

        EndOfProgram:

            //log into the txt file.
            Logging(tableName);
        }

        public static async void GetRecordsOfTable(string tableName, string zipDestination)
        {
            MDMDbContext MDMContext = new MDMDbContext();
            FiestaDbContext context = new FiestaDbContext();
            bool isMDMContext = false;
            string fileName = string.Empty;
            filesFolder = tableName;
            try
            {
                CFG_SYS_TABLE_CONFIG? cfg = context
                    .CFG_SYS_TABLE_CONFIGs
                    .FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == tableName);

                if (cfg != null &&
                    !string.IsNullOrEmpty(cfg.CFG_SYS_TABLE_GROUP_NAME))
                {
                    if (cfg.CFG_SYS_TABLE_EXTRACT_START_TIME.HasValue)
                        AppendLog("Last Extract Start Time:" + cfg.CFG_SYS_TABLE_EXTRACT_START_TIME.Value.UtcDateTime);

                    if (extMode != "DELTA")
                    {
                        if (toUI)
                        {
                            AppendLog("Set CFG_SYS_TABLE_EXTRACT_IN_PROGRESS to true");
                            //update the flag
                            cfg.CFG_SYS_TABLE_EXTRACT_IN_PROGRESS = true;
                            cfg.CFG_SYS_TABLE_EXTRACT_START_TIME = DateTime.UtcNow;
                            context.SaveChanges();
                        }
                    }


                    //start log
                    outLog.STATUS = 0;
                    outLog = await logDAL.PerformLogging(outLog);

                    AppendLog("---GetRecordsOfTable---");
                    fileName = string.Empty;
                    //use table description as filename if there is value, otherwise default to tablename
                    if (!string.IsNullOrEmpty(cfg.CFG_SYS_TABLE_DESC))
                    {
                        fileName = cfg.CFG_SYS_TABLE_DESC + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                        if (tableName == "V_CFG_PRODUCT_RAINBOW_IDT" || tableName == "V_CFG_PRODUCT_RAINBOW_ISL") fileName = cfg.CFG_SYS_TABLE_DESC;
                    }
                    else
                    {
                        fileName = tableName + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                    }

                    AppendLog("Generated FileName:" + fileName);
                    IEnumerable<string> fullPath = null;

                    //wait for 5 - 10 seconds
                    Random rand = new Random();
                    int seconds = rand.Next(5, 10);
                    AppendLog("Waiting for " + seconds + " seconds...");
                    Thread.Sleep(seconds * 1000);
                    AppendLog("Extraction Started ...");

                    //Extra parameter for MDM extraction
                    switch (tableName)
                    {
                        case "PRODUCT_PRODUCT":
                        case "PRODUCTION_ROUTING":
                        case "APPLICATION_APPLICATION1":
                        case "APPLICATION_APPLICATION2":
                        case "APPLICATION_APPLICATION3":
                        case "CUSTOMER_SOLDTO":
                        case "CUSTOMER_BILLTO":
                        case "CUSTOMER_BILLTO_MODELN":
                        case "CUSTOMER_SHIPTO":
                        case "CUSTOMER_SHIPTO_MODELN":
                        case "CUSTOMER_END_CUSTOMER":
                        case "FINANCE_COST_CENTER":
                        case "FINANCE_PROFIT_CENTER":
                        case "FINANCE_PROFIT_CENTER_HIERARCHY":
                        case "FINANCE_IP_CUSTOMER":
                        case "FINANCE_IP_OPN":
                        case "ORGANIZATION_STORAGE_LOCATION":
                        case "ORGANIZATION_PLANTS":
                        case "ORGANIZATION_COMPANY_CODE":
                        case "PRODUCT_HIERARCHY":
                        case "PRODUCT_STANDARD_COST":
                        case "PRODUCT_COMPONENTS":
                        case "PRODUCTION_GROUP_STAGE":
                        case "PRODUCTION_GROUP_STAGE_CONVERSION":
                        case "PRODUCTION_PLANT_CONVERSION":
                        case "PRODUCTION_STAGE":
                        case "PRODUCTION_STAGE_CONVERSION":
                        case "PRODUCTION_BOM":
                        case "PRODUCTION_VERSION":
                        case "PRODUCTION_ALTERNATIVES_MIX_RATIOS":
                        case "PRODUCTION_YIELD":
                        case "PRODUCTION_LEADTIME":
                        case "PRODUCTION_LOTSIZE":

                        case "PRODUCT_HISTORICAL":
                        case "PRODUCT_SALES_ROOT_PARTNUMBER":
                        case "PRODUCT_ECCN_CONVERSION":
                        case "PRODUCT_HS_CONVERSION":
                        case "VENDOR_VENDOR":
                        case "VENDOR_COMPANY":

                        case "OUT_PRODUCT_CONSOLIDATE":
                        case "OUT_PRODUCT_SALES_CONSOLIDATE":
                        case "OUT_PRODUCT_PLANT_CONSOLIDATE":
                        case "OUT_PRODUCT_CAN_FLAGS4":
                        case "OUT_PRODUCT_STANDARD_COST":
                        case "OUT_PRODUCT_SALES_ROOT_PARTNUMBER":
                        case "OUT_PRODUCT_WIP_SELL_PRICE":
                        case "OUT_PRODUCT_ECCN_CONVERSION":
                        case "OUT_PRODUCT_HS_CONVERSION":
                        case "MDM_PRODUCT_HIERARCHY_V2":
                        case "MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_V2":
                        case "V_MDM_PRODUCTION_GROUP_STAGE":
                        case "V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION":
                        case "V_MDM_PRODUCTION_PLANT_CONVERSION":
                        case "OUT_PRODUCT_TYPE":
                        case "OUT_PRODUCT_LINE":
                            csvDelimiter = "|";
                            csvQuote = false;
                            fullChunkData = true;
                            break;
                    }

                    try
                    {
                        switch (tableName)
                        {
                            case "APPLICATION_APPLICATION1":
                                {
                                    List<OUT_APP_APPLICATION1> result = MDMContext.OUT_APP_APPLICATION1s.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_APP_APPLICATION1>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_APP_APPLICATION1s.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_APP_APPLICATION1s.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_APP_APPLICATION1s.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "APPLICATION_APPLICATION2":
                                {
                                    List<OUT_APP_APPLICATION2> result = MDMContext.OUT_APP_APPLICATION2s.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_APP_APPLICATION2>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_APP_APPLICATION2s.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_APP_APPLICATION2s.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_APP_APPLICATION2s.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "APPLICATION_APPLICATION3":
                                {
                                    List<OUT_APP_APPLICATION3> result = MDMContext.OUT_APP_APPLICATION3s.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_APP_APPLICATION3>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_APP_APPLICATION3s.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_APP_APPLICATION3s.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_APP_APPLICATION3s.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "CUSTOMER_SOLDTO": { List<OUT_CUS_SOLD_TO> result = MDMContext.OUT_CUS_SOLD_TOs.ToList<OUT_CUS_SOLD_TO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "CUSTOMER_BILLTO": { List<OUT_CUS_BILL_TO> result = MDMContext.OUT_CUS_BILL_TOs.ToList<OUT_CUS_BILL_TO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "CUSTOMER_SHIPTO": { List<OUT_CUS_SHIP_TO> result = MDMContext.OUT_CUS_SHIP_TOs.ToList<OUT_CUS_SHIP_TO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "CUSTOMER_BILLTO_MODELN": { filesFolder = "CUSTOMER_BILLTO"; List<V_MODELN_CUS_BILL_TO> result = MDMContext.V_MODELN_CUS_BILL_TOs.ToList<V_MODELN_CUS_BILL_TO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "CUSTOMER_SHIPTO_MODELN": { filesFolder = "CUSTOMER_SHIPTO"; List<V_MODELN_CUS_SHIP_TO> result = MDMContext.V_MODELN_CUS_SHIP_TOs.ToList<V_MODELN_CUS_SHIP_TO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "CUSTOMER_END_CUSTOMER": { List<OUT_CUS_END_CUSTOMER> result = MDMContext.OUT_CUS_END_CUSTOMERs.ToList<OUT_CUS_END_CUSTOMER>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "FINANCE_COST_CENTER": { List<OUT_FIN_COST_CENTER> result = MDMContext.OUT_FIN_COST_CENTERs.ToList<OUT_FIN_COST_CENTER>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "FINANCE_IP_CUSTOMER": { List<OUT_FIN_IP_CUSTOMER> result = MDMContext.OUT_FIN_IP_CUSTOMERs.ToList<OUT_FIN_IP_CUSTOMER>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "FINANCE_IP_OPN":
                                {
                                    List<OUT_FIN_IP_OPN> result = MDMContext.OUT_FIN_IP_OPNs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_FIN_IP_OPN>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_FIN_IP_OPNs.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_FIN_IP_OPNs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_FIN_IP_OPNs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "PRODUCT_STANDARD_COST": { List<OUT_PRODUCT_STANDARD_COST> result = MDMContext.OUT_PRODUCT_STANDARD_COSTs.ToList<OUT_PRODUCT_STANDARD_COST>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "PRODUCT_HISTORICAL":
                                {
                                    List<OUT_PRODUCT_HISTORICAL> result = MDMContext.OUT_PRODUCT_HISTORICALs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_PRODUCT_HISTORICAL>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_PRODUCT_HISTORICALs.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_PRODUCT_HISTORICALs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_PRODUCT_HISTORICALs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "PRODUCT_SALES_ROOT_PARTNUMBER":
                                {
                                    List<OUT_PRODUCT_SALES_ROOT_PARTNUMBER> result = MDMContext.OUT_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_PRODUCT_SALES_ROOT_PARTNUMBER>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_PRODUCT_SALES_ROOT_PARTNUMBERs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "PRODUCT_PRODUCT":
                                {
                                    List<OUT_PRODUCT_CONSOLIDATE> result = MDMContext.OUT_PRODUCT_CONSOLIDATEs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_PRODUCT_CONSOLIDATE>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_PRODUCT_CONSOLIDATEs.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_PRODUCT_CONSOLIDATEs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_PRODUCT_CONSOLIDATEs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "PRODUCT_ECCN_CONVERSION":
                                {
                                    List<OUT_PRODUCT_ECCN_CONVERSION> result = MDMContext.OUT_PRODUCT_ECCN_CONVERSIONs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_PRODUCT_ECCN_CONVERSION>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_PRODUCT_ECCN_CONVERSIONs.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_PRODUCT_ECCN_CONVERSIONs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_PRODUCT_ECCN_CONVERSIONs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "PRODUCT_HS_CONVERSION":
                                {
                                    List<OUT_PRODUCT_HS_CONVERSION> result = MDMContext.OUT_PRODUCT_HS_CONVERSIONs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<OUT_PRODUCT_HS_CONVERSION>();
                                    if (result != null) outLog.REC_COUNT = result.Count;
                                    fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                                    isMDMContext = true;

                                    if (extMode == "DELTA")
                                    {
                                        if (outLog.REC_COUNT > 10000)
                                        {
                                            if (outLog.REC_COUNT == MDMContext.OUT_PRODUCT_HS_CONVERSIONs.Where(x => x.processStatus == "0").Count())
                                                MDMContext.OUT_PRODUCT_HS_CONVERSIONs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                            else
                                                throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                        }
                                        else
                                            MDMContext.OUT_PRODUCT_HS_CONVERSIONs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                    }
                                }
                                break;
                            case "VENDOR_VENDOR": { List<OUT_VEN_VENDOR> result = MDMContext.OUT_VEN_VENDORs.ToList<OUT_VEN_VENDOR>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "VENDOR_COMPANY": { List<OUT_VEN_VENDOR_COMPANY> result = MDMContext.OUT_VEN_VENDOR_COMPANies.ToList<OUT_VEN_VENDOR_COMPANY>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_CONSOLIDATE": { List<OUT_PRODUCT_CONSOLIDATE> result = MDMContext.OUT_PRODUCT_CONSOLIDATEs.ToList<OUT_PRODUCT_CONSOLIDATE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_SALES_CONSOLIDATE": { List<MV_OUT_PRODUCT_SALES_CONSOLIDATE> result = MDMContext.MV_OUT_PRODUCT_SALES_CONSOLIDATEs.ToList<MV_OUT_PRODUCT_SALES_CONSOLIDATE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_PLANT_CONSOLIDATE": { List<MV_OUT_PRODUCT_PLANT_CONSOLIDATE> result = MDMContext.MV_OUT_PRODUCT_PLANT_CONSOLIDATEs.ToList<MV_OUT_PRODUCT_PLANT_CONSOLIDATE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_CAN_FLAGS4": { List<OUT_PRODUCT_CAN_FLAGS4> result = MDMContext.OUT_PRODUCT_CAN_FLAGS4s.ToList<OUT_PRODUCT_CAN_FLAGS4>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_STANDARD_COST": { List<OUT_PRODUCT_STANDARD_COST> result = MDMContext.OUT_PRODUCT_STANDARD_COSTs.ToList<OUT_PRODUCT_STANDARD_COST>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_SALES_ROOT_PARTNUMBER": { List<OUT_PRODUCT_SALES_ROOT_PARTNUMBER> result = MDMContext.OUT_PRODUCT_SALES_ROOT_PARTNUMBERs.ToList<OUT_PRODUCT_SALES_ROOT_PARTNUMBER>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_WIP_SELL_PRICE": { List<OUT_PRODUCT_WIP_SELL_PRICE> result = MDMContext.OUT_PRODUCT_WIP_SELL_PRICEs.ToList<OUT_PRODUCT_WIP_SELL_PRICE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_HISTORICAL": { List<OUT_PRODUCT_HISTORICAL> result = MDMContext.OUT_PRODUCT_HISTORICALs.ToList<OUT_PRODUCT_HISTORICAL>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_ECCN_CONVERSION": { List<OUT_PRODUCT_ECCN_CONVERSION> result = MDMContext.OUT_PRODUCT_ECCN_CONVERSIONs.ToList<OUT_PRODUCT_ECCN_CONVERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_HS_CONVERSION": { List<OUT_PRODUCT_HS_CONVERSION> result = MDMContext.OUT_PRODUCT_HS_CONVERSIONs.ToList<OUT_PRODUCT_HS_CONVERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_TYPE": { List<OUT_PRODUCT_TYPE> result = MDMContext.OUT_PRODUCT_TYPEs.ToList<OUT_PRODUCT_TYPE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                            case "OUT_PRODUCT_LINE": { List<OUT_PRODUCT_LINE> result = MDMContext.OUT_PRODUCT_LINEs.ToList<OUT_PRODUCT_LINE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; isMDMContext = true; } break;
                        }
                    }
                    catch (Exception ex)
                    {
                        AppendError(ex.Message + "\n" + ex.StackTrace);
                        using (var context2 = new FiestaDbContext())
                        {
                            CFG_SYS_TABLE_CONFIG? cfg2 = context2
                                .CFG_SYS_TABLE_CONFIGs
                                .FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == tableName);

                            if (cfg2 != null)
                            {
                                AppendLog("Set CFG_SYS_TABLE_EXTRACT_IN_PROGRESS to false");
                                cfg2.CFG_SYS_TABLE_EXTRACT_IN_PROGRESS = false;
                                context2.SaveChanges();
                            }
                        }

                    }

                    if (outBoundPath == string.Empty)
                    {
                        //outBoundPath = Path.Combine("OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder, extMode);
                        outBoundPath = Path.Combine("OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder);
                    }

                    switch (tableName)
                    {
                        //MDM - only zipped CSV
                        case "OUT_PRODUCTION":
                            {
                                outLog.REC_COUNT = context.OUT_PRODUCTIONs.Count();
                                //fullPath = ExportCSVJob(context.OUT_PRODUCTIONs.OrderBy(x => x.updateDateAndTime), fileName, csvTempPath, true, false, true).Result;
                                //fullPath = ExportCSVJob(context.OUT_PRODUCTIONs.AsNoTracking().OrderBy(x => x.updateDateAndTime), fileName, csvTempPath, true, false, true).Result;
                                //use ExportCSVJob_V2

                                Console.WriteLine("outLog.REC_COUNT: " + outLog.REC_COUNT);
                                fullPath = ExportCSVJob_V2(context.OUT_PRODUCTIONs.AsNoTracking().OrderBy(x => x.updateDateAndTime), fileName, csvTempPath, true, false, true).Result;
                            }
                            break;
                        case "OUT_PRODUCT_PLANT": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCT_PLANTs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCT_PLANTs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCT_SALES": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCT_SALEs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCT_SALEs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_ROUTING": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_ROUTINGs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_ROUTINGs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_ROUTING_S4": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_ROUTING_S4s.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_ROUTING_S4s, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_VERSION": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_VERSIONs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_VERSIONs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_ALT_MIX_RATIOs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_ALT_MIX_RATIOs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_BOM": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_BOMs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_BOMs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCT": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCT_CONSOLIDATEs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCT_CONSOLIDATEs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_YIELD": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_YIELDs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_YIELDs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_LEADTIME": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_LEADTIMEs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_LEADTIMEs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_LOTSIZE": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_LOTSIZEs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_LOTSIZEs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCTION_CYCLETIME": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCTION_CYCLETIMEs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCTION_CYCLETIMEs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCT_MATRIX": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCT_MATRices.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCT_MATRices, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_PRODUCT_VENDOR_CHAR": { outLog.REC_COUNT = context.V_MDM_INIT_PRODUCT_VENDOR_CHARs.Count(); fullPath = ExportCSVJob(context.V_MDM_INIT_PRODUCT_VENDOR_CHARs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "OUT_COMPONENTS": { outLog.REC_COUNT = context.OUT_COMPONENTs.Count(); fullPath = ExportCSVJob(context.OUT_COMPONENTs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "MDM_PRODUCTION_STAGE": { outLog.REC_COUNT = context.MDM_PRODUCTION_STAGEs.Count(); fullPath = ExportCSVJob(context.MDM_PRODUCTION_STAGEs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "MDM_PRODUCTION_STAGE_CONVERSION": { outLog.REC_COUNT = context.MDM_PRODUCTION_STAGE_CONVERSIONs.Count(); fullPath = ExportCSVJob(context.MDM_PRODUCTION_STAGE_CONVERSIONs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "V_PLM_PRODUCT": { outLog.REC_COUNT = context.V_PLM_PRODUCTs.Count(); fullPath = ExportCSVJob(context.V_PLM_PRODUCTs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_PRI_OPN": { outLog.REC_COUNT = context.PLM_PRI_OPNs.Count(); fullPath = ExportCSVJob(context.PLM_PRI_OPNs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_EOL_STATUS": { outLog.REC_COUNT = context.PLM_EOL_STATUSes.Count(); fullPath = ExportCSVJob(context.PLM_EOL_STATUSes, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_RET_PNSTATUS": { outLog.REC_COUNT = context.PLM_RET_PNSTATUSes.Count(); fullPath = ExportCSVJob(context.PLM_RET_PNSTATUSes, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_RET_MATERIAL": { outLog.REC_COUNT = context.PLM_RET_MATERIALs.Count(); fullPath = ExportCSVJob(context.PLM_RET_MATERIALs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_PRO_MPN_S4": { outLog.REC_COUNT = context.PLM_PRO_MPN_S4s.Count(); fullPath = ExportCSVJob(context.PLM_PRO_MPN_S4s, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_PRODUCT": { outLog.REC_COUNT = context.PLM_PRODUCTs.Count(); fullPath = ExportCSVJob(context.PLM_PRODUCTs, fileName, csvTempPath, true, false, true).Result; } break;
                        case "PLM_PRODUCTION":
                            {
                                outLog.REC_COUNT = context.PLM_PRODUCTIONs.Count();
                                //fullPath = ExportCSVJob(context.PLM_PRODUCTIONs, fileName, csvTempPath, true, false, true).Result;
                                //fullPath = ExportCSVJob(context.PLM_PRODUCTIONs.AsNoTracking(), fileName, csvTempPath, true, false, true).Result;
                                //use ExportCSVJob_V2
                                Console.WriteLine("outLog.REC_COUNT: " + outLog.REC_COUNT);
                                fullPath = ExportCSVJob_V2(context.PLM_PRODUCTIONs.AsNoTracking(), fileName, csvTempPath, true, false, true).Result;
                            }
                            break;
                        //S4 - zipped txt and csv
                        case "V_S4_INIT_ACCOUNTING":
                            {
                                List<V_S4_INIT_ACCOUNTING> result = context.V_S4_INIT_ACCOUNTINGs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_ACCOUNTING>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_S4_INIT_BASIC":
                            {
                                List<V_S4_INIT_BASIC> result = context.V_S4_INIT_BASICs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_BASIC>();
                                if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_S4_INIT_MRB":
                            {
                                List<V_S4_INIT_MRB> result = context.V_S4_INIT_MRBs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_MRB>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_S4_INIT_SALES_PLANT":
                            {
                                List<V_S4_INIT_SALES_PLANT> result = context.V_S4_INIT_SALES_PLANTs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_SALES_PLANT>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_S4_INIT_STORAGE_LOCATION":
                            {
                                List<V_S4_INIT_STORAGE_LOCATION> result = context.V_S4_INIT_STORAGE_LOCATIONs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_STORAGE_LOCATION>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_S4_INIT_PURCHASING":
                            {
                                List<V_S4_INIT_PURCHASING> result = context.V_S4_INIT_PURCHASINGs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_PURCHASING>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_S4_INIT_SALES": { List<V_S4_INIT_SALE> result = context.V_S4_INIT_SALEs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_SALE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_INIT_BOM": { List<V_S4_INIT_BOM> result = context.V_S4_INIT_BOMs.OrderBy(x => x.MAST_MATNR).ToList<V_S4_INIT_BOM>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_INIT_ROUTING": { List<V_S4_INIT_ROUTING> result = context.V_S4_INIT_ROUTINGs.OrderBy(x => x.MAPL_MATNR).ToList<V_S4_INIT_ROUTING>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_INIT_PRODUCTION_VERSION": { List<V_S4_INIT_PRODUCTION_VERSION> result = context.V_S4_INIT_PRODUCTION_VERSIONs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_INIT_PRODUCTION_VERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_INIT_MATERIAL_CLASSIFICATION": { List<V_S4_INIT_MATERIAL_CLASSIFICATION> result = context.V_S4_INIT_MATERIAL_CLASSIFICATIONs.OrderBy(x => x.KSSK_OBJEK).ToList<V_S4_INIT_MATERIAL_CLASSIFICATION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_INIT_MIX_RATIOS": { List<V_S4_INIT_MIX_RATIO> result = context.V_S4_INIT_MIX_RATIOs.OrderBy(x => x.MATNR).ToList<V_S4_INIT_MIX_RATIO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_CHK_SALES_PLANT": { List<V_S4_CHK_SALES_PLANT> result = context.V_S4_CHK_SALES_PLANTs.OrderBy(x => x.MVKE_VKORG).ToList<V_S4_CHK_SALES_PLANT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_PV": { List<V_SCM_MASTER_PV> result = context.V_SCM_MASTER_PVs.ToList<V_SCM_MASTER_PV>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_LEADTIME_YIELD": { List<V_SCM_MASTER_LEADTIME_YIELD> result = context.V_SCM_MASTER_LEADTIME_YIELDs.ToList<V_SCM_MASTER_LEADTIME_YIELD>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_PLANT_SLOC": { List<V_SCM_MASTER_PLANT_SLOC> result = context.V_SCM_MASTER_PLANT_SLOCs.ToList<V_SCM_MASTER_PLANT_SLOC>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_BOM": { List<V_SCM_MASTER_BOM> result = context.V_SCM_MASTER_BOMs.ToList<V_SCM_MASTER_BOM>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_PRIORITY": { List<V_SCM_MASTER_PRIORITY> result = context.V_SCM_MASTER_PRIORITies.ToList<V_SCM_MASTER_PRIORITY>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_ROUTING": { List<V_SCM_MASTER_ROUTING> result = context.V_SCM_MASTER_ROUTINGs.ToList<V_SCM_MASTER_ROUTING>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_SCM_MASTER_ROUTING_S4": { List<V_SCM_MASTER_ROUTING_S4> result = context.V_SCM_MASTER_ROUTING_S4s.ToList<V_SCM_MASTER_ROUTING_S4>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        //case "V_PRODUCT_PIR_AS": { List<V_PRODUCT_PIR_A> result = context.V_PRODUCT_PIR_As.ToList<V_PRODUCT_PIR_A>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        //case "V_PRODUCT_PIR_FT": { List<V_PRODUCT_PIR_FT> result = context.V_PRODUCT_PIR_FTs.ToList<V_PRODUCT_PIR_FT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        //case "V_PRODUCT_PIR_WT": { List<V_PRODUCT_PIR_WT> result = context.V_PRODUCT_PIR_WTs.ToList<V_PRODUCT_PIR_WT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        //case "V_PRODUCT_PIR_AS_FULL_LOAD": { List<V_PRODUCT_PIR_AS_FULL_LOAD> result = context.V_PRODUCT_PIR_AS_FULL_LOADs.ToList<V_PRODUCT_PIR_AS_FULL_LOAD>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        //case "V_PRODUCT_PIR_FT_FULL_LOAD": { List<V_PRODUCT_PIR_FT_FULL_LOAD> result = context.V_PRODUCT_PIR_FT_FULL_LOADs.ToList<V_PRODUCT_PIR_FT_FULL_LOAD>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        //case "V_PRODUCT_PIR_WT_FULL_LOAD": { List<V_PRODUCT_PIR_WT_FULL_LOAD> result = context.V_PRODUCT_PIR_WT_FULL_LOADs.ToList<V_PRODUCT_PIR_WT_FULL_LOAD>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_ZMT_OPN_OSAT": { List<V_S4_ZMT_OPN_OSAT> result = context.V_S4_ZMT_OPN_OSATs.OrderBy(x => x.MARA_MATNR).ToList<V_S4_ZMT_OPN_OSAT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_S4_INIT_VENDOR_CHAR": { List<V_S4_INIT_VENDOR_CHAR> result = context.V_S4_INIT_VENDOR_CHARs.ToList<V_S4_INIT_VENDOR_CHAR>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_PRODUCT_VENDOR_CHAR_OSAT":
                            {
                                List<V_PRODUCT_VENDOR_CHAR_OSAT> result = context.V_PRODUCT_VENDOR_CHAR_OSATs.ToList<V_PRODUCT_VENDOR_CHAR_OSAT>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "V_CFG_PRODUCT_RAINBOW_IDT": { List<V_CFG_PRODUCT_RAINBOW_IDT> result = context.V_CFG_PRODUCT_RAINBOW_IDTs.OrderBy(x => x.ProdPN).ToList<V_CFG_PRODUCT_RAINBOW_IDT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportFixedLengthJob(result, fileName, csvTempPath).Result; } break;
                        case "V_CFG_PRODUCT_RAINBOW_ISL": { List<V_CFG_PRODUCT_RAINBOW_ISL> result = context.V_CFG_PRODUCT_RAINBOW_ISLs.Where(x => x.PRODUCTION_PN != null).OrderBy(x => x.ProdPN).ToList<V_CFG_PRODUCT_RAINBOW_ISL>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportFixedLengthJob(result, fileName, csvTempPath).Result; } break;

                        //case "PRODUCT_PRODUCT": { List<V_MDM_INIT_PRODUCT> result = context.V_MDM_INIT_PRODUCTs.ToList<V_MDM_INIT_PRODUCT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_ROUTING": { List<V_MDM_INIT_PRODUCTION_ROUTING> result = context.V_MDM_INIT_PRODUCTION_ROUTINGs.ToList<V_MDM_INIT_PRODUCTION_ROUTING>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "FINANCE_PROFIT_CENTER":
                            {
                                var result = context.MDM_PROFIT_CENTERs
                                    .Select(x => new { prctr = x.PRCTR, datbi = x.DATBI, khinr = x.KHINR, ktext = x.KTEXT, x.deleteFlag, x.createDateAndTime, x.updateDateAndTime, x.updateType, x.deleteDateAndTime })
                                    .ToList();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;
                            }
                            break;
                        case "FINANCE_PROFIT_CENTER_HIERARCHY": { List<MDM_PROFIT_CENTER_HIERARCHY> result = context.MDM_PROFIT_CENTER_HIERARCHies.ToList<MDM_PROFIT_CENTER_HIERARCHY>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "ORGANIZATION_STORAGE_LOCATION":
                            {
                                List<MDM_STORAGE_LOCATION> result = context.MDM_STORAGE_LOCATIONs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<MDM_STORAGE_LOCATION>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;

                                if (extMode == "DELTA")
                                {
                                    if (outLog.REC_COUNT > 10000)
                                    {
                                        if (outLog.REC_COUNT == context.MDM_STORAGE_LOCATIONs.Where(x => x.processStatus == "0").Count())
                                            context.MDM_STORAGE_LOCATIONs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                        else
                                            throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                    }
                                    else
                                        context.MDM_STORAGE_LOCATIONs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                }
                            }
                            break;
                        case "ORGANIZATION_PLANTS":
                            {
                                List<MDM_PLANT> result = context.MDM_PLANTs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<MDM_PLANT>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;

                                if (extMode == "DELTA")
                                {
                                    if (outLog.REC_COUNT > 10000)
                                    {
                                        if (outLog.REC_COUNT == context.MDM_PLANTs.Where(x => x.processStatus == "0").Count())
                                            context.MDM_PLANTs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                        else
                                            throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                    }
                                    else
                                        context.MDM_PLANTs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                }
                            }
                            break;
                        case "ORGANIZATION_COMPANY_CODE":
                            {
                                List<MDM_COMPANY_CODE> result = context.MDM_COMPANY_CODEs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<MDM_COMPANY_CODE>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;

                                if (extMode == "DELTA")
                                {
                                    if (outLog.REC_COUNT > 10000)
                                    {
                                        if (outLog.REC_COUNT == context.MDM_COMPANY_CODEs.Where(x => x.processStatus == "0").Count())
                                            context.MDM_COMPANY_CODEs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                        else
                                            throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                    }
                                    else
                                        context.MDM_COMPANY_CODEs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                }
                            }
                            break;
                        case "PRODUCT_HIERARCHY": { List<MDM_PRODUCT_HIERARCHY> result = context.MDM_PRODUCT_HIERARCHies.ToList<MDM_PRODUCT_HIERARCHY>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCT_COMPONENTS": { List<OUT_COMPONENT> result = context.OUT_COMPONENTs.ToList<OUT_COMPONENT>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_GROUP_STAGE":
                            {
                                List<MDM_PRODUCTION_GROUP_STAGE> result = context.MDM_PRODUCTION_GROUP_STAGEs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<MDM_PRODUCTION_GROUP_STAGE>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;

                                if (extMode == "DELTA")
                                {
                                    if (outLog.REC_COUNT > 10000)
                                    {
                                        if (outLog.REC_COUNT == context.MDM_PRODUCTION_GROUP_STAGEs.Where(x => x.processStatus == "0").Count())
                                            context.MDM_PRODUCTION_GROUP_STAGEs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                        else
                                            throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                    }
                                    else
                                        context.MDM_PRODUCTION_GROUP_STAGEs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                }
                            }
                            break;
                        case "PRODUCTION_GROUP_STAGE_CONVERSION":
                            {
                                List<MDM_PRODUCTION_GROUP_STAGE_CONVERSION> result = context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<MDM_PRODUCTION_GROUP_STAGE_CONVERSION>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;

                                if (extMode == "DELTA")
                                {
                                    if (outLog.REC_COUNT > 10000)
                                    {
                                        if (outLog.REC_COUNT == context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.Where(x => x.processStatus == "0").Count())
                                            context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                        else
                                            throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                    }
                                    else
                                        context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                }
                            }
                            break;
                        case "PRODUCTION_PLANT_CONVERSION":
                            {
                                List<MDM_PRODUCTION_PLANT_CONVERSION> result = context.MDM_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.processStatus == (extMode == "DELTA" ? "0" : x.processStatus)).ToList<MDM_PRODUCTION_PLANT_CONVERSION>();
                                if (result != null) outLog.REC_COUNT = result.Count;
                                fullPath = ExportCSVJob(result, fileName, csvTempPath).Result;

                                if (extMode == "DELTA")
                                {
                                    if (outLog.REC_COUNT > 10000)
                                    {
                                        if (outLog.REC_COUNT == context.MDM_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.processStatus == "0").Count())
                                            context.MDM_PRODUCTION_PLANT_CONVERSIONs.Where(x => x.processStatus == "0").ToList().ForEach(x => x.processStatus = "1");
                                        else
                                            throw new ArgumentException("Data count is changed in between process. Please re-run again.");
                                    }
                                    else
                                        context.MDM_PRODUCTION_PLANT_CONVERSIONs.Where(x => result.Select(x => x.recordKey).ToList<decimal>().Contains(x.recordKey)).ToList().ForEach(x => x.processStatus = "1");
                                }
                            }
                            break;
                        case "PRODUCTION_STAGE": { List<MDM_PRODUCTION_STAGE> result = context.MDM_PRODUCTION_STAGEs.ToList<MDM_PRODUCTION_STAGE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_STAGE_CONVERSION": { List<MDM_PRODUCTION_STAGE_CONVERSION> result = context.MDM_PRODUCTION_STAGE_CONVERSIONs.ToList<MDM_PRODUCTION_STAGE_CONVERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_BOM": { List<OUT_PRODUCTION_BOM> result = context.OUT_PRODUCTION_BOMs.ToList<OUT_PRODUCTION_BOM>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_VERSION": { List<OUT_PRODUCTION_VERSION> result = context.OUT_PRODUCTION_VERSIONs.ToList<OUT_PRODUCTION_VERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_ALTERNATIVES_MIX_RATIOS": { List<OUT_PRODUCTION_ALTERNATIVES_MIX_RATIO> result = context.OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOs.ToList<OUT_PRODUCTION_ALTERNATIVES_MIX_RATIO>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_YIELD": { List<OUT_PRODUCTION_YIELD> result = context.OUT_PRODUCTION_YIELDs.ToList<OUT_PRODUCTION_YIELD>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_LEADTIME": { List<OUT_PRODUCTION_LEADTIME> result = context.OUT_PRODUCTION_LEADTIMEs.ToList<OUT_PRODUCTION_LEADTIME>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "PRODUCTION_LOTSIZE": { List<OUT_PRODUCTION_LOTSIZE> result = context.OUT_PRODUCTION_LOTSIZEs.ToList<OUT_PRODUCTION_LOTSIZE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;

                        case "MDM_PRODUCT_HIERARCHY_V2": { List<MDM_PRODUCT_HIERARCHY> result = context.MDM_PRODUCT_HIERARCHies.ToList<MDM_PRODUCT_HIERARCHY>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION_V2": { List<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION> result = context.MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs.ToList<MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_MDM_PRODUCTION_GROUP_STAGE": { List<MDM_PRODUCTION_GROUP_STAGE> result = context.MDM_PRODUCTION_GROUP_STAGEs.ToList<MDM_PRODUCTION_GROUP_STAGE>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION": { List<MDM_PRODUCTION_GROUP_STAGE_CONVERSION> result = context.MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs.ToList<MDM_PRODUCTION_GROUP_STAGE_CONVERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;
                        case "V_MDM_PRODUCTION_PLANT_CONVERSION": { List<MDM_PRODUCTION_PLANT_CONVERSION> result = context.MDM_PRODUCTION_PLANT_CONVERSIONs.ToList<MDM_PRODUCTION_PLANT_CONVERSION>(); if (result != null) outLog.REC_COUNT = result.Count; fullPath = ExportCSVJob(result, fileName, csvTempPath).Result; } break;

                        default:
                            if (!isMDMContext) AppendError("Table Name:" + tableName + " does not exist or export failed!");
                            break;
                    }

                    //save log only when success, at this point, export is success
                    if (fullPath != null && fullPath.Count() > 0)
                    {
                        AppendLog("Extraction Complete! Full TempCsvPath: " + fullPath.FirstOrDefault());
                        //make sure zip destination is available
                        CreateDirectoryIfNotExistLocal(Path.Combine(zipDestination, outBoundPath, extMode));

                        //zip the file to destination
                        AppendLog("Attempt to Zip " + fullPath.Count() + " file(s) to :" + fileName + "...");
                        bool isZipSuccess = false;

                        Thread.Sleep(5000);

                        if (fullPath.Count() > 1)
                        {
                            isZipSuccess = ZipService.ZipMultiple(
                                fullPath,
                                //Path.Combine(zipDestination, "OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder, fileName + ".zip")
                                Path.Combine(zipDestination, outBoundPath, extMode, fileName + ".zip")
                            );
                        }
                        else
                        {
                            isZipSuccess = ZipService.Zip(
                            Path.Combine(csvTempPath, fileName + ".csv"),
                            Path.Combine(zipDestination, outBoundPath, extMode, fileName + ".zip"));
                        }

                        //move to download path if it is populated
                        if (!string.IsNullOrEmpty(filesDownloadPath))
                        {
                            //check directory exist
                            CreateDirectoryIfNotExistLocal(Path.Combine(filesDownloadPath, "OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder));
                            //CreateDirectoryIfNotExistLocal(Path.Combine(filesDownloadPath, outBoundPath));

                            //wait for 5 - 10 seconds
                            seconds = rand.Next(5, 10);
                            AppendLog("Done zipped File, waiting for " + seconds + " seconds...");
                            Thread.Sleep(seconds * 1000);

                            //copy file to download path, if zipped destination exist and download path not exist.
                            AppendLog("Copy zip file to download path:" + Path.Combine(filesDownloadPath, "OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder, fileName + ".zip"));
                            //AppendLog("Copy zip file to download path:" + Path.Combine(outBoundPath, fileName + ".zip"));
                            if (File.Exists(Path.Combine(zipDestination, outBoundPath, extMode, fileName + ".zip")))
                            {
                                //copy to download path only if not exist
                                if (!File.Exists(Path.Combine(filesDownloadPath, "OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder, fileName + ".zip")))
                                {
                                    CopyFileLocal(new FileInfo(Path.Combine(zipDestination, outBoundPath, extMode, fileName + ".zip")),
                                        Path.Combine(filesDownloadPath, "OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder)
                                        );
                                }
                                else
                                {
                                    AppendLog("File already exist in download path:" + Path.Combine(filesDownloadPath, "OUT", cfg.CFG_SYS_TABLE_GROUP_NAME, filesFolder, fileName + ".zip"));
                                }
                            }
                            else
                            {
                                AppendError("Unable copy to Download path:" + Path.Combine(zipDestination, outBoundPath, extMode, fileName + ".zip"));
                            }
                        }

                        //upload to SFTP folder
                        if (!string.IsNullOrEmpty(sftpKeyPath) &&
                            !string.IsNullOrEmpty(sftpHostname) &&
                            !string.IsNullOrEmpty(sftpUsername))
                        {

                            if (needZipped)
                            {
                                AppendLog("Uploading ZIP file...");
                                if (CopyToSftp(Path.Combine(outBoundPath, extMode), Path.Combine(zipDestination, outBoundPath, extMode, fileName + ".zip")))
                                {
                                    if (extMode == "DELTA")
                                    {
                                        if (isMDMContext) MDMContext.SaveChanges();
                                        else context.SaveChanges();
                                    }
                                }
                            }
                            else
                            {
                                string fileType = "_tab.txt";
                                if (csvDelimiter == "|") fileType = ".csv";
                                //only copy the txt file to SFTP
                                AppendLog("Uploading txt file...");
                                if (CopyToSftp(Path.Combine(outBoundPath, extMode), Path.Combine(csvTempPath, fileName + fileType)))
                                {
                                    if (extMode == "DELTA")
                                    {
                                        if (isMDMContext) MDMContext.SaveChanges();
                                        else context.SaveChanges();
                                    }
                                }
                            }
                        }

                        if (extMode != "DELTA")
                        {
                            if (toUI)
                            {
                                AppendLog("Set CFG_SYS_TABLE_EXTRACT_IN_PROGRESS to false");
                                cfg.CFG_SYS_TABLE_EXTRACT_IN_PROGRESS = false;
                                AppendLog("COMMIT!");
                                //commit
                                context.SaveChanges();
                            }

                            if (copyTo != "")
                            {
                                CFG_SYS_TABLE_CONFIG? cfgToCopy = context
                                .CFG_SYS_TABLE_CONFIGs
                                .FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == copyTo);

                                if (cfgToCopy != null && !string.IsNullOrEmpty(cfgToCopy.CFG_SYS_TABLE_GROUP_NAME))
                                {
                                    string outBoundCopyToPath = Path.Combine("OUT", cfgToCopy.CFG_SYS_TABLE_GROUP_NAME, copyTo);

                                    string copyToFileName = fileName.Replace(cfg.CFG_SYS_TABLE_DESC, cfgToCopy.CFG_SYS_TABLE_DESC);

                                    RenameFileLocal(new FileInfo(Path.Combine(csvTempPath, fileName + ".csv")), Path.Combine(csvTempPath, copyToFileName + ".csv"));

                                    CreateDirectoryIfNotExistLocal(Path.Combine(zipDestination, outBoundCopyToPath));

                                    isZipSuccess = ZipService.Zip(Path.Combine(csvTempPath, copyToFileName + ".csv"), Path.Combine(zipDestination, outBoundCopyToPath, copyToFileName + ".zip"));

                                    RenameFileLocal(new FileInfo(Path.Combine(csvTempPath, copyToFileName + ".csv")), Path.Combine(csvTempPath, fileName + ".csv"));

                                    CopyFileLocal(
                                        new FileInfo(Path.Combine(zipDestination, outBoundCopyToPath, copyToFileName + ".zip")),
                                        Path.Combine(filesDownloadPath, outBoundCopyToPath)
                                    );

                                    string path = Path.Combine(filesDownloadPath, outBoundCopyToPath);

                                    AppendLog("Copy to " + Path.Combine(path, copyToFileName + ".zip"));

                                    cfgToCopy.CFG_SYS_TABLE_EXTRACT_IN_PROGRESS = false;
                                    cfgToCopy.CFG_SYS_TABLE_EXTRACT_FILENAME = copyToFileName + ".zip";
                                    //cfgToCopy.CFG_SYS_TABLE_EXTRACT_DATETIME = cfg.CFG_SYS_TABLE_EXTRACT_DATETIME;
                                    cfgToCopy.CFG_SYS_TABLE_EXTRACT_DATETIME = DateTime.UtcNow;
                                    context.SaveChanges();
                                }
                            }
                        }

                        if (isZipSuccess)
                        {
                            AppendLog("Delete the file: " + csvTempPath + fileName + ".csv");
                            //delete original generated CSV at TEMP
                            DeleteFileLocal(Path.Combine(csvTempPath, fileName + ".csv"));

                            AppendLog("Delete the file: " + csvTempPath + fileName + "_tab.txt");
                            //delete original generated CSV at TEMP
                            DeleteFileLocal(Path.Combine(csvTempPath, fileName + "_tab.txt"));

                            AppendLog("Delete the file: " + csvTempPath + fileName + "_tab.csv");
                            //delete original generated CSV at TEMP
                            DeleteFileLocal(Path.Combine(csvTempPath, fileName + "_tab.csv"));
                        }

                        //house keeping download path
                        if (!string.IsNullOrEmpty(filesDownloadPath))
                        {
                            AppendLog("Delete Download path files older than retention period " + arcRetentionPeriod.ToString() + " days..");
                            //delete file older than retention period
                            FileInfo[] downloadFiles = ListDirectoryLocal(Path.Combine(filesDownloadPath, outBoundPath));
                            foreach (FileInfo file in downloadFiles)
                            {
                                if (file.CreationTime < DateTime.Now.AddDays(-arcRetentionPeriod))
                                {
                                    AppendLog("Delete file: " + file.Name + " in download folder over retention period of " + arcRetentionPeriod + " days.");
                                    DeleteFileLocal(file.FullName);
                                }
                            }
                        }

                        //end time and result
                        outLog.MESSAGE = "CSV Exported: " + zipDestination + "\\" + fileName + ".zip";

                        //update table extract name and datetime
                        AppendLog("Update CFG_SYS_TABLE_CONFIG...");

                        cfg.CFG_SYS_TABLE_EXTRACT_FILENAME = fileName + ".zip";
                        cfg.CFG_SYS_TABLE_EXTRACT_DATETIME = DateTime.UtcNow;
                        context.SaveChanges();
                    }
                    else
                    {
                        outLog.MESSAGE = "Empty fullpath, skip file generation!";
                        //something wrong, fullpath is empty
                        AppendLog("Empty fullpath, skip file generation!");
                    }
                }
                else
                {
                    outLog.MESSAGE = "CFG_SYS_TABLE_GROUP_NAME empty or CFG_SYS_TABLE record not found for:" + tableName;
                    //something wrong, fullpath is empty
                    AppendError("CFG_SYS_TABLE_GROUP_NAME empty or CFG_SYS_TABLE record not found for:" + tableName);
                    return;
                }
                //add to log table
                AppendLog("Insert LOG_DATA_REQUEST...");
                outLog.STATUS = 1;
                outLog = await logDAL.PerformLogging(outLog);

            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
                using (context)
                {
                    CFG_SYS_TABLE_CONFIG? cfg = context

                        .CFG_SYS_TABLE_CONFIGs

                        .FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == tableName);

                    if (cfg != null)
                    {
                        AppendLog("Set CFG_SYS_TABLE_EXTRACT_IN_PROGRESS to false");
                        cfg.CFG_SYS_TABLE_EXTRACT_IN_PROGRESS = false;
                        context.SaveChanges();
                    }
                }
            }
        }

        static bool CopyToSftp(string parentFolderName, string filePath)
        {
            string localFile = filePath;
            string extPath = extMode == "" ? extMode : $"/{extMode}";
            RemoteFileInfo remFile;
            parentFolderName = parentFolderName.Replace("\\", "/");
            try
            {
                AppendLog("Upload ZIP file: " + filePath);
                AppendLog("To SFTP folder: " + parentFolderName);

                CreateDirectoryIfNotExist(parentFolderName);

                //list directory
                RemoteDirectoryInfo directory = ListDirectory(parentFolderName);

                if (File.Exists(filePath))
                {
                    UploadFile(filePath, parentFolderName);
                }
                else
                {
                    AppendError("Unable copy to SFTP path:" + filePath);
                }
            }
            catch (Exception ex)
            {
                AppendError(ex.Message + "\n" + ex.StackTrace);
                return false;
            }

            return true;
        }

        public static void AppendLog(string log)
        {
            log = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "][INFO] " + log + Environment.NewLine;
            errorLog += log;
            Console.WriteLine(log);
        }

        public static void AppendWarning(string log)
        {
            log = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "][WRN] " + log + Environment.NewLine;
            errorLog += log;
            Console.WriteLine(log);
        }

        public static void AppendError(string log)
        {
            log = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "][ERR] " + log + Environment.NewLine;
            errorLog += log;
            Console.WriteLine(log);

            sendErrorLogEmail = true;
        }

        static async void Logging(string tableName)
        {
            //write the log into log folder
            string filename = filename = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + tableName + "_log.txt";
            string logFullPath = Path.Combine(string.Format(@"{0}\{1}", filesLogPath, filename));
            using (StreamWriter writer = new StreamWriter(logFullPath))
            {
                writer.WriteLine(errorLog);
            }

            if (sendErrorLogEmail)
            {
                //send email
                try
                {
                    EmailOperation.SendEmailWithErrorLog(
                    emailHost,
                    "FIESTA CSV Generation Error " + environmentName + ": " + tableName,
                    errorEmailRecipient,
                    errorEmailSender,
                    logFullPath,
                    filename);
                }
                catch (Exception ex)
                {
                    AppendLog("Error Sending Email:" + ex.Message + "\n" + ex.StackTrace);
                }

                outLog.MESSAGE = errorLog;
                outLog.STATUS = 9;
                outLog = await logDAL.PerformLogging(outLog);
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
        private static Task<string> Export<T>(IEnumerable<T> result, string fileName, string? csvTempPath, bool needT = false, string delimiter = ",", bool shouldQuote = true, bool needDoubleBackslash = false, int codePage = 65001)
        {
            string path = CsvExporter.ExportCsv(result.ToList<T>(), fileName, csvTempPath, needT, delimiter, shouldQuote, needDoubleBackslash, needHeader, codePage);

            return Task.FromResult(path);
        }

        private static Task<string> FLExport<T>(IEnumerable<T> result, string fileName, string? csvTempPath, bool needT = false, string delimiter = "", bool shouldQuote = true, bool needDoubleBackslash = false, int codePage = 65001)
        {
            string path = TxtExporter.ExportFixedLength(result.ToList<T>(), fileName, csvTempPath, needT, delimiter, shouldQuote, needDoubleBackslash, needHeader, codePage);

            return Task.FromResult(path);
        }

        private static async Task<IEnumerable<string>> ExportCSVJob<T>(IEnumerable<T> result, string fileName, string? csvTempPath, bool needT = false, bool needRenaming = true, bool needDoubleBackslash = false, int codePage = 65001)
        {
            List<Task<string>> exportTasks = new List<Task<string>>();
            csvDelimiter = csvDelimiter == string.Empty ? "," : csvDelimiter;

            if (result == null || result.Count() == 0)
            {

                AppendLog("Query result is empty, stop file generation ...");
                return new List<string>();
            }

            if (fullChunkData)
            {
                AppendLog("Exporting to CSV: " + fileName + " ...");
                exportTasks.Add(Export(result.Cast<T>().ToList(), fileName, csvTempPath, needT, csvDelimiter, csvQuote, needDoubleBackslash, codePage));
            }
            else
            {
                //check if need to chunk the result, 1 million per csv (include header)
                int i = 0;
                foreach (var chunk in result.Chunk<T>(999999))
                {
                    string newFileName = fileName;
                    if (i > 0)
                        newFileName = fileName + "_" + i.ToString();
                    else
                    {
                        newFileName = fileName;
                    }
                    i++;

                    AppendLog("Exporting to CSV: " + newFileName + " ...");
                    exportTasks.Add(Export(chunk.Cast<T>(), newFileName, csvTempPath, needT, csvDelimiter, csvQuote, needDoubleBackslash, codePage));
                }
            }


            //if need txt, export one more file
            if (needTxt)
            {
                //int j = 0;
                //foreach (var chunk in result.Chunk<T>(999999))
                //{
                //    string newFileName = fileName;
                //    if (j > 0)
                //        newFileName = fileName + "_tab_" + j.ToString();
                //    else
                //    {
                //        newFileName = fileName + "_tab";
                //    }
                //    i++;
                //    AppendLog("Exporting to CSV with TAB delimiter: " + newFileName + " ...");
                //    exportTasks.Add(Export(chunk.Cast<T>().ToList(), newFileName, csvTempPath, needT, "\t", false, needDoubleBackslash, codePage));
                //}

                //temporary extract 1 txt file regardless size
                AppendLog("Exporting to CSV with TAB delimiter: " + fileName + "_tab" + " ...");
                exportTasks.Add(Export(result.Cast<T>().ToList(), fileName + "_tab", csvTempPath, needT, "\t", false, needDoubleBackslash, codePage));

            }

            var stat = await Task.WhenAll<string>(exportTasks);

            //wait for 5 - 10 seconds
            Random rand = new Random();
            int seconds = rand.Next(5, 10);
            AppendLog("Done Export File, waiting for " + seconds + " seconds...");
            Thread.Sleep(seconds * 1000);

            //change extension from csv to txt, remove _txt in the naming
            List<string> realPaths = new List<string>();

            foreach (string s in stat)
            {
                if (needTxt && File.Exists(s) && s.Contains("_tab") && needRenaming)
                {
                    AppendLog("Changing file to txt extension ...");
                    FileInfo f = new FileInfo(s);
                    f.MoveTo(Path.ChangeExtension(s, ".txt"));
                    realPaths.Add(f.FullName);
                }
                else
                {
                    realPaths.Add(s);
                }
            }

            return realPaths;
        }

        private static async Task<List<string>> ExportCSVJob_V2<T>(
            IQueryable<T> query,
            string fileName,
            string? csvTempPath,
            bool needT = false,
            bool needRenaming = true,
            bool needDoubleBackslash = false,
            int codePage = 65001,
            int chunkSize = 999999) //500000
            where T : class
        {
            List<string> exportedFiles = new();

            if (query == null)
            {
                AppendLog("Query is null, stop file generation ...");
                return exportedFiles;
            }

            bool hasData = await query.AnyAsync();

            if (!hasData)
            {
                AppendLog("Query result is empty, stop file generation ...");
                return exportedFiles;
            }

            int offset = 0;
            int fileIndex = 0;

            while (true)
            {
                AppendLog($"Loading chunk {fileIndex} from database ...");

                List<T> chunk = await query
                    .Skip(offset)
                    .Take(chunkSize)
                    .ToListAsync();

                if (chunk.Count == 0)
                    break;

                string newFileName =
                    fileIndex == 0
                    ? fileName
                    : $"{fileName}_{fileIndex}";

                AppendLog($"Exporting CSV: {newFileName} ...");

                // =========================================================
                // CREATE CSV MANUALLY HERE
                // =========================================================

                string csvPath = Path.Combine(
                    csvTempPath ?? Path.GetTempPath(),
                    $"{newFileName}.csv");

                using (var writer = new StreamWriter(
                    csvPath,
                    false,
                    Encoding.GetEncoding(codePage)))
                {
                    PropertyInfo[] props = typeof(T).GetProperties();

                    // HEADER
                    string header = string.Join(",",
                        props.Select(p => $"\"{p.Name}\""));

                    await writer.WriteLineAsync(header);

                    // DATA ROWS
                    foreach (T item in chunk)
                    {
                        List<string> row = new();

                        // =====================================================
                        // THIS IS WHERE foreach(PropertyInfo...) GOES
                        // =====================================================
                        foreach (PropertyInfo prop in props)
                        {
                            object? value = prop.GetValue(item);

                            string output;

                            // Handle DateTimeOffset
                            if (value is DateTimeOffset dto)
                            {
                                output = dto.ToString("yyyy-MM-ddTHH:mm:ss");
                            }
                            // Handle DateTime
                            else if (value is DateTime dt)
                            {
                                output = dt.ToString("yyyy-MM-ddTHH:mm:ss");
                            }
                            else
                            {
                                output = value?.ToString() ?? "";
                            }

                            // Escape quotes
                            output = output.Replace("\"", "\"\"");

                            if (needDoubleBackslash)
                            {
                                output = output.Replace("\\", "\\\\");
                            }

                            row.Add($"\"{output}\"");
                        }

                        await writer.WriteLineAsync(string.Join(",", row));
                    }
                }

                exportedFiles.Add(csvPath);

                // =========================================================
                // TXT EXPORT
                // =========================================================

                if (needTxt)
                {
                    string txtTempName =
                        fileIndex == 0
                        ? $"{fileName}_tab"
                        : $"{fileName}_tab_{fileIndex}";

                    string txtPath = Path.Combine(
                        csvTempPath ?? Path.GetTempPath(),
                        $"{txtTempName}.txt");

                    AppendLog($"Exporting TXT: {txtTempName} ...");

                    using (var writer = new StreamWriter(
                        txtPath,
                        false,
                        Encoding.GetEncoding(codePage)))
                    {
                        PropertyInfo[] props = typeof(T).GetProperties();

                        string header = string.Join("\t",
                            props.Select(p => p.Name));

                        await writer.WriteLineAsync(header);

                        foreach (T item in chunk)
                        {
                            List<string> row = new();

                            foreach (PropertyInfo prop in props)
                            {
                                object? value = prop.GetValue(item);

                                string output;

                                if (value is DateTimeOffset dto)
                                {
                                    output = dto.ToString("yyyy-MM-ddTHH:mm:ss");
                                }
                                else if (value is DateTime dt)
                                {
                                    output = dt.ToString("yyyy-MM-ddTHH:mm:ss");
                                }
                                else
                                {
                                    output = value?.ToString() ?? "";
                                }

                                if (needDoubleBackslash)
                                {
                                    output = output.Replace("\\", "\\\\");
                                }

                                row.Add(output);
                            }

                            await writer.WriteLineAsync(string.Join("\t", row));
                        }
                    }

                    exportedFiles.Add(txtPath);
                }

                // Release memory
                chunk.Clear();

                offset += chunkSize;
                fileIndex++;

                AppendLog($"Completed chunk {fileIndex} ...");
            }

            AppendLog("All export completed.");

            return exportedFiles;
        }

        private static async Task<IEnumerable<string>> ExportFixedLengthJob<T>(IEnumerable<T> result, string fileName, string? csvTempPath, bool needT = false, bool needRenaming = true, bool needDoubleBackslash = false, int codePage = 65001)
        {
            List<Task<string>> exportTasks = new List<Task<string>>();

            if (result == null || result.Count() == 0)
            {
                AppendLog("Query result is empty, stop file generation ...");
                return new List<string>();
            }

            //check if need to chunk the result, 1 million per file (include header)
            int i = 0;
            foreach (var chunk in result.Chunk<T>(999999))
            {
                string newFileName = fileName;
                if (i > 0)
                    newFileName = fileName + "_" + i.ToString();
                else
                {
                    newFileName = fileName;
                }
                i++;

                AppendLog("Exporting to TXT: " + newFileName + " ...");
                exportTasks.Add(FLExport(result.Cast<T>().ToList(), fileName, csvTempPath, needT, "", false, needDoubleBackslash, codePage));
            }

            var stat = await Task.WhenAll<string>(exportTasks);

            //wait for 5 - 10 seconds
            Random rand = new Random();
            int seconds = rand.Next(5, 10);
            AppendLog("Done Export File, waiting for " + seconds + " seconds...");
            Thread.Sleep(seconds * 1000);

            //change extension from csv to txt, remove _txt in the naming
            List<string> realPaths = new List<string>();

            return new List<string>();
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

        static void MoveFile(RemoteFileInfo info, string destination)
        {
            int retryCount = 1;
            Session session = null;
            string internalErrorStack = string.Empty;
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

                    string destName = info.Name;
                    //if file exist, renamed append current date time.
                    if (session.FileExists(destination + "/" + info.Name))
                    {
                        destName = Path.GetFileNameWithoutExtension(info.Name) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(info.Name);
                        AppendLog(info.Name + " exist in dest folder, renamed to:" + destName);
                    }

                    if (session.FileExists(info.FullName))
                    {
                        AppendLog("Moving " + info.Name + " from " + info.FullName + " to " + destination + " ...");
                        session.MoveFile(info.FullName, destination + "/" + destName);
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

        static void CopyFileLocal(FileInfo info, string destination)
        {
            int retryCount = 1;
            string internalErrorStack = string.Empty;
            AppendLog("===Function: CopyFileLocal===");
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
                        File.Copy(info.FullName, destination + "/" + destName);
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

        static void RenameFileLocal(FileInfo info, string destination)
        {
            int retryCount = 1;
            string internalErrorStack = string.Empty;
            FileInfo dest = new FileInfo(destination);

            AppendLog("===Function: RenameFileLocal===");
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    AppendLog("Attempt: #" + retryCount);
                    if (File.Exists(info.FullName))
                    {
                        File.Move(info.FullName, destination);
                        AppendLog(info.FullName + " rename to:" + dest.Name);
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
                        AppendLog("Directory created! : " + directory);
                        Directory.CreateDirectory(directory);
                    }
                    else
                    {
                        AppendLog("Directory exist! : " + directory);
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

        static TransferEventArgs UploadFile(string localFilePath, string remoteDirectory)
        {
            int retryCount = 1;
            TransferEventArgs args = null;
            string originalExt = null;
            string tmpExt = "tmp";
            Session session = null;
            string internalErrorStack = string.Empty;
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

                    //Change to *.tmp before upload
                    originalExt = Path.GetExtension(localFilePath);
                    File.Move(localFilePath, Path.ChangeExtension(localFilePath, tmpExt));
                    localFilePath = Path.ChangeExtension(localFilePath, tmpExt);

                    AppendLog("Uploading ...");
                    args = session.PutFileToDirectory(localFilePath, remoteDirectory, false, transferOptions);
                    var remFileInfo = session.GetFileInfo(remoteDirectory + "/" + Path.GetFileName(localFilePath));
                    AppendLog("Upload Completed!");

                    //Change back both for local and FTP
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

        static void ExecuteSystemTriggers()
        {
            AppendLog("Executing System Triggers...");

            List<CFG_SYSTEM_TRIGGERING> triggers;
            using (var context = new FiestaDbContext())
            {
                triggers = context.CFG_SYSTEM_TRIGGERINGs.Where(x => x.ACTIVE == "Yes").ToList();
            }

            if (triggers.Count == 0)
            {
                AppendLog("No active trigger, exiting");
                return;
            }

            foreach (CFG_SYSTEM_TRIGGERING trigger in triggers)
            {
                bool shouldTrigger = ShouldTrigger(trigger.LAST_RUN_DATETIME, trigger.FREQUENCY);
                if (!shouldTrigger)
                {
                    continue;
                }
                AppendLog($"Triggering \"{trigger.TRIGGERING_NAME}\", frequency \"{trigger.FREQUENCY}\"");

                var dataTable = ExecuteQuery(trigger.QUERY);
                if (dataTable.Rows.Count <= 0)
                {
                    AppendLog("No query results, skipping email");
                    UpdateLastRunDateTime(trigger.CFG_SYSTEM_TRIGGERING_ID);
                    continue;
                }

                AppendLog("Will compile and send email");

                if (trigger.AS_ATTACHMENT == "Yes")
                {
                    AppendLog("Will include data as excel attachment");
                    var emailContent = EmailOperation.CompileNotificationEmail(trigger.TRIGGERING_NAME, trigger.MAILBODY, trigger.URL_LINK);
                    var attachmentFileName =
                        $"{trigger.TRIGGERING_NAME}_{DateTime.Now.ToString("yyyy-MM-dd")}_{dataTable.Rows.Count}.xlsx";
                    var attachment = EmailOperation.DataTableToExcelMailAttachment(dataTable, attachmentFileName);

                    EmailOperation.SendEmailWithHtml(emailHost, trigger.MAILSUBJECT, trigger.RECIPIENT, emailContent, environmentName, attachment);
                }
                else
                {
                    AppendLog("Will include data as html");
                    string emailContent = EmailOperation.CompileNotificationEmail(trigger.TRIGGERING_NAME, trigger.MAILBODY, trigger.URL_LINK, dataTable);

                    EmailOperation.SendEmailWithHtml(emailHost, trigger.MAILSUBJECT, trigger.RECIPIENT, emailContent, environmentName, null);
                }

                UpdateLastRunDateTime(trigger.CFG_SYSTEM_TRIGGERING_ID);
            }

            AppendLog("System Triggers execution completed.");

            static bool ShouldTrigger(DateTimeOffset? lastRunDateTime, string frequency)
            {
                if (lastRunDateTime == null) return true;

                DateTime lastRun = new DateTime(
                    year: lastRunDateTime.Value.Year,
                    month: lastRunDateTime.Value.Month,
                    day: lastRunDateTime.Value.Day,
                    hour: lastRunDateTime.Value.Hour,
                    minute: 0,
                    second: 0
                );

                DateTime now = DateTime.Now;

                bool isDayPassed = now >= lastRun.AddDays(1);
                bool isWeekPassed = now >= lastRun.AddDays(7);
                bool isMonthPassed = now >= lastRun.AddMonths(1);

                if (frequency == "Hourly")
                {
                    // asssume this program to be sceduled every hour.
                    return true;
                }
                if (frequency == "Daily")
                {
                    return isDayPassed;
                }
                if (frequency == "Weekly")
                {
                    return isWeekPassed;
                }
                if (frequency == "Monthly")
                {
                    return isMonthPassed;
                }
                return false;
            }

            static DataTable ExecuteQuery(string query)
            {
                DataTable resultTable = new DataTable();

                using (var context = new FiestaDbContext())
                {
                    try
                    {
                        using (var command = context.Database.GetDbConnection().CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.Text;

                            context.Database.OpenConnection();

                            using (var reader = command.ExecuteReader())
                            {
                                resultTable.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        AppendError($"Error executing query: {ex.Message}");
                    }
                }

                return resultTable;
            }

            static void UpdateLastRunDateTime(decimal triggerId)
            {
                using (var context = new FiestaDbContext())
                {
                    var trigger = context.CFG_SYSTEM_TRIGGERINGs.Find(triggerId);
                    if (trigger != null)
                    {
                        trigger.LAST_RUN_DATETIME = DateTime.Now;
                        AppendLog($"Update last run to {trigger.LAST_RUN_DATETIME}");
                        context.SaveChanges();
                    }
                }
            }

            static void AppendLog_file_log_capture(string message)
            {
                string LogFilePath = "file_log_capture.txt";
                try
                {
                    string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}";
                    File.AppendAllText(LogFilePath, logLine + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    // Last resort: write to console if file logging fails
                    Console.WriteLine($"Logging failed: {ex.Message}");
                }
            }
        }
    }
}

