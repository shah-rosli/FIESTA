using System.IO.Compression;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIESTA_Backend.Controllers.Admin;

/**
* TLDR: This thing receives a zipped frontend bundle and unzip/deploys it.
*
*/
public class FrontendDeployController : ControllerBase
{
    private readonly ILogger<FrontendDeployController> _logger;
    private readonly StringBuilder _deploymentLog;

    private const string FrontendFolder = "C:\\inetpub\\FIESTAWeb\\FrontEnd";
    private const string BackupParentFolder = "C:\\inetpub\\FIESTAWeb\\Backup\\Frontend";

    public FrontendDeployController(ILogger<FrontendDeployController> logger)
    {
        _logger = logger;
        _deploymentLog = new StringBuilder();
    }

    [Authorize]
    [Route("api/frontendDeploy")]
    [HttpPost]
    public async Task<IActionResult> frontendDeploy()
    {
        var environmentName = Environment.GetEnvironmentVariable("FIESTA_ENVIRONMENT", EnvironmentVariableTarget.Machine);
        
        if (Request.ContentType != "application/zip")
        {
            return Ok(new { Message = "Expected application/zip" });
        }

        var deploymentResult = await DeployBundle(Request);
        return Ok(deploymentResult);
    }

    private async Task<DeploymentResult> DeployBundle(HttpRequest request)
    {
        DeploymentResult result = new DeploymentResult();
        result.Success = true;
        result.Message = "Deployment complete";

        try
        {
            CheckFolderPermissions();
            string backupFolder = await SaveBundleIntoBackup(request);
            try
            {
                CopyFromBackupToFrontend(backupFolder);
                _logger.LogInformation("Successful deployment");
            }
            catch
            {
                Log("Catch, error while copy files from backup to FrontEnd.");
                if (Directory.Exists(backupFolder))
                {
                    Directory.Delete(backupFolder, true);
                }
                Log("Deleted Backup folder.");
                throw;
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = $"Error: {ex.Message}";
            Log($"Error: {ex.Message}");
        }
        finally
        {
            result.Log = _deploymentLog.ToString();
        }
        return result;
    }

    private void CheckFolderPermissions()
    {
        Log("Checking folder permission.");

        string frontendFolderTempFile = Path.Combine(FrontendFolder, Guid.NewGuid() + ".tmp");
        System.IO.File.Create(frontendFolderTempFile).Close();
        // If successful, delete the test file
        System.IO.File.Delete(frontendFolderTempFile);

        string backupFolderTempFile = Path.Combine(BackupParentFolder, Guid.NewGuid() + ".tmp");
        System.IO.File.Create(backupFolderTempFile).Close();
        // If successful, delete the test file
        System.IO.File.Delete(backupFolderTempFile);
    }

    private async Task<string> SaveBundleIntoBackup(HttpRequest request)
    {
        var timestamp = DateTime.Now.ToString("yyyyMMdd");
        var backupFolder = Path.Combine(BackupParentFolder, $"Frontend_{timestamp}");
        for (int i = 0; i <= 100; i++)
        {
            if (i > 0)
            {
                backupFolder = Path.Combine(BackupParentFolder, $"Frontend_{timestamp}_{i}");
            }

            if (!Directory.Exists(backupFolder))
            {
                break;
            }

            if (i == 100)
            {
                throw new Exception("Could not create a unique backup folder after 100 attempts.");
            }
        }

        Directory.CreateDirectory(backupFolder);

        var tempFilePath = Path.GetTempFileName();
        using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
        {
            await request.Body.CopyToAsync(fileStream);
        }
        Log("Unzipping into backup folder.");
        ZipFile.ExtractToDirectory(tempFilePath, backupFolder);
        System.IO.File.Delete(tempFilePath);

        if (!System.IO.File.Exists(Path.Combine(backupFolder, "index.html")))
        {
            throw new Exception("The backup folder does not contain index.html.");
        }

        return backupFolder;
    }

    private void CopyFromBackupToFrontend(string backupFolder)
    {
        DirectoryInfo di = new DirectoryInfo(FrontendFolder);
        foreach (FileInfo file in di.GetFiles())
        {
            using (FileStream fs = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                fs.Close();
            }
        }

        Log("Clearing FrontEnd folder.");
        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in di.GetDirectories())
        {
            dir.Delete(true);
        }

        if (di.GetFiles().Length > 0 || di.GetDirectories().Length > 0)
        {
            throw new Exception("FrontEnd folder is not empty after clearing.");
        }

        Log("Copying from backup to FrontEnd folder.");

        foreach (string dirPath in Directory.GetDirectories(backupFolder, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(backupFolder, FrontendFolder));
        }
        foreach (string newPath in Directory.GetFiles(backupFolder, "*.*", SearchOption.AllDirectories))
        {
            System.IO.File.Copy(newPath, newPath.Replace(backupFolder, FrontendFolder), true);
        }

        if (!System.IO.File.Exists(Path.Combine(FrontendFolder, "index.html")))
        {
            throw new Exception("The FrontEnd folder does not contain index.html.");
        }
    }

    private void Log(string message)
    {
        _deploymentLog.AppendLine(message);
        _logger.LogInformation(message);
    }

    public class DeploymentResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Log { get; set; }
    }
}