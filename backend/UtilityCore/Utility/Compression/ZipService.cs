using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace UtilityCore.Utility.Compression
{
    public class ZipService
    {
        public static bool Zip(string filePath, string destinationPath)
        {
            try
            {
                using (var zip = ZipFile.Open(destinationPath, ZipArchiveMode.Create))
                    zip.CreateEntryFromFile(filePath, Path.GetFileName(filePath), CompressionLevel.Optimal);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public static bool Unzip(string zipPath, string destinationPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(zipPath, destinationPath);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static bool ZipMultiple (IEnumerable<string> filePath, string destinationPath)
        {
            try
            {
                var zip = ZipFile.Open(destinationPath, ZipArchiveMode.Create);
                foreach (var file in filePath)
                {
                    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                }
                zip.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
