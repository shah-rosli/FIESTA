using FIESTA_Backend.DataAccess.Attachment;
using FIESTA_Backend.EfModels;
using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIESTA_Backend.Controllers.Files
{
    [ApiController]
    public class DownloadFileController : ControllerBase
    {
        private IConfiguration _config;
        private HttpContext _httpContext;
        private readonly FiestaDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public DownloadFileController(IConfiguration config, IHttpContextAccessor httpContextAccessor, FiestaDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [Route("api/DownloadFile")]
        [Authorize]
        public IActionResult DownloadFile(string tableName)
        {
            CFG_SYS_TABLE_CONFIG? table = _context.CFG_SYS_TABLE_CONFIGs.FirstOrDefault(x => x.CFG_SYS_TABLE_NAME == tableName);

            if (table == null)
            {
                return NotFound("Table Name: " + tableName + " not found.");
            }

            if (string.IsNullOrEmpty(table.CFG_SYS_TABLE_GROUP_NAME))
            {
                return NotFound("Table Group Name for Table: " + tableName + " is null or empty.");
            }

            var folderPath = Path.Combine(_hostEnvironment.ContentRootPath, "Export", "OUT", table.CFG_SYS_TABLE_GROUP_NAME, table.CFG_SYS_TABLE_NAME);
            if (!Directory.Exists(folderPath))
                return NotFound("Folder: "+ folderPath +" not found.");

            // Get a list of files in the folder
            var files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
                return NotFound("No files found to download in folder: "+folderPath+".");

            // Create a temporary memory stream to hold the zip archive
            using (var memoryStream = new MemoryStream())
            {
                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);

                    if (fileInfo.Name == table.CFG_SYS_TABLE_EXTRACT_FILENAME)
                    {
                        // Write the file contents into the entry
                        using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            fileStream.CopyTo(memoryStream);
                        }
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                // Return the zip file as a byte array
                return File(memoryStream.ToArray(), "application/zip", table.CFG_SYS_TABLE_EXTRACT_FILENAME);
            }

        }
    }
}
