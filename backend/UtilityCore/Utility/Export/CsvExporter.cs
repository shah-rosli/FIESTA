using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.Export
{
    public static class CsvExporter
    {
        public static string ExportCsvOld<T>(List<T> genericList, string fileName)
        {
            try
            {
                var sb = new StringBuilder();
                var basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Export\\";

                //check if export exist
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                var finalPath = Path.Combine(basePath, fileName + ".csv");
                var header = "";
                var info = typeof(T).GetProperties();
                if (!File.Exists(finalPath))
                {
                    var file = File.Create(finalPath);
                    file.Close();
                    foreach (var prop in typeof(T).GetProperties())
                    {
                        header += prop.Name + ", ";
                    }
                    header = header.Substring(0, header.Length - 2);
                    sb.AppendLine(header);
                    TextWriter sw = new StreamWriter(finalPath, true);
                    sw.Write(sb.ToString());
                    sw.Close();
                }
                foreach (var obj in genericList)
                {
                    sb = new StringBuilder();
                    var line = "";
                    foreach (var prop in info)
                    {
                        line += "\"" + prop.GetValue(obj, null) + "\", ";
                    }
                    line = line.Substring(0, line.Length - 2);
                    sb.AppendLine(line);
                    TextWriter sw = new StreamWriter(finalPath, true);
                    sw.Write(sb.ToString());
                    sw.Close();
                }

                return finalPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ExportCsv<T>(List<T> genericList, string fileName, string? basePath = null, bool needT = false, string delimiter = ",", bool shouldQuote = true, bool needDoubleBackslash = false, bool HasHeaderRecord = true, int codePage = 65001)
        {
            if (basePath == null)
                basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Export\\";

            //check if export exist
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            var finalPath = Path.Combine(basePath, fileName + ".csv");

            byte[] result;
            using (var memoryStream = new MemoryStream())
            {
                var enc = CodePagesEncodingProvider.Instance.GetEncoding(codePage);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (var streamWriter = new StreamWriter(memoryStream, enc))
                {
                    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = HasHeaderRecord,
                        Delimiter = delimiter,
                        ShouldQuote = args => shouldQuote
                    };

                    //added 20260824 Keith
                    //if (!fileName.Contains("VENDOR_PURCHASE_INFO_REC", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    csvConfig.ShouldQuote = args => shouldQuote;
                    //}

                    using (var csvWriter = new CsvWriter(streamWriter, csvConfig))
                    {
                        csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateOnly?>().Formats = new[] { "yyyy-MM-dd" };
                        csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateOnly>().Formats = new[] { "yyyy-MM-dd" };
                        if (needT)
                        {
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTime?>().Formats = new[] { "yyyy-MM-ddTHH:mm:ss" };
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTimeOffset?>().Formats = new[] { "yyyy-MM-ddTHH:mm:ss" };
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "yyyy-MM-ddTHH:mm:ss" };
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTimeOffset>().Formats = new[] { "yyyy-MM-ddTHH:mm:ss" };
                        }
                        else
                        {
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTime?>().Formats = new[] { "yyyy-MM-dd HH:mm:ss" };
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTimeOffset?>().Formats = new[] { "yyyy-MM-dd HH:mm:ss" };
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "yyyy-MM-dd HH:mm:ss" };
                            csvWriter.Context.TypeConverterOptionsCache.GetOptions<DateTimeOffset>().Formats = new[] { "yyyy-MM-dd HH:mm:ss" };
                        }

                        if (needDoubleBackslash)
                        {
                            csvWriter.Context.TypeConverterCache.AddConverter<string>(new DoubleBackslashConverter());
                            csvWriter.Context.TypeConverterCache.AddConverter<string?>(new DoubleBackslashConverter());
                        }

                        csvWriter.WriteRecords(genericList);
                        streamWriter.Flush();
                        result = memoryStream.ToArray();
                    }
                }
            }

            using (FileStream fs = new FileStream(finalPath, FileMode.Create, System.IO.FileAccess.Write))
            {
                fs.Write(result, 0, result.Length);
            }

            return finalPath;
        }
    }

    public class DoubleBackslashConverter : StringConverter
    {
        public override string ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            var stringValue = (string)value;

            if (stringValue != null)
            {
                stringValue = stringValue.Replace(@"\", @"\\");
            }

            return base.ConvertToString(stringValue, row, memberMapData);
        }
    }
}
