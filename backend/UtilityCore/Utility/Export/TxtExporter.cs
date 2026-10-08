using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Models;
//using FIESTA_Backend.FIESTA_Backend.EfModels.FixedLengthConst;
//using FIESTA_Backend.EfModels;

namespace UtilityCore.Utility.Export
{
    public static class TxtExporter
    {

        public static string ExportFixedLength<T>(List<T> genericList, string fileName, string? basePath = null, bool needT = false, string delimiter = "", bool shouldQuote = true, bool needDoubleBackslash = false, bool HasHeaderRecord = true, int codePage = 65001)
        {
            if (basePath == null)
                basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Export\\";

            //check if export exist
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            var finalPath = Path.Combine(basePath, fileName + (needT? ".txt": ".dat"));

            string[] fixedLengthLines = genericList.Select(p => p.ToString()).ToArray();

            //File.WriteAllLines(finalPath, fixedLengthLines);
            using (var writer = new StreamWriter(finalPath))
            {
                foreach (var line in fixedLengthLines)
                {
                    writer.Write(line);
                    writer.Write('\n');
                }
                writer.Close();
            }

            return finalPath;
        }
    }
}

