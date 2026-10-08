using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.Import
{
    public class CsvImporter
    {
        public static IEnumerable<object?> ReadCsvFile(string csvFilePath, Type type, bool hasHeaderRecord = true)
        {
            return ReadCsvFile(csvFilePath, type, hasHeaderRecord, 65001);
        }

        public static IEnumerable<object?> ReadCsvFile(string csvFilePath, Type type, bool hasHeaderRecord, int codePage, string? delimiter = null, bool ignoreMissingHeader = false, bool modeNoEscape = false)
        {
            //note:
            //932 - SJIS encoding
            //65001 - UTF-8 encoding
            //1252 - ANSI encoding
            var enc = CodePagesEncodingProvider.Instance.GetEncoding(codePage);
            if (enc == null)
            {
                // Fall back to built-in UTF-8
                enc = Encoding.UTF8;
            }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(csvFilePath, enc, false))
            {
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = hasHeaderRecord
                };

                if (delimiter != null)
                {
                    config.Delimiter = delimiter;
                }

                if (ignoreMissingHeader)
                {
                    config.HeaderValidated = null;
                    config.MissingFieldFound = null;
                }

                if (modeNoEscape)
                {
                    config.Mode = CsvMode.NoEscape;
                }

                using (var csv = new CsvReader(reader, config))
                {
                    return csv.GetRecords(type).ToList();
                }
            }
        }

        public static IEnumerable<object?> ReadDatFile(string datFilePath, Type type, bool hasHeaderRecord = true)
        {
            return ReadDatFile(datFilePath, type, hasHeaderRecord, 932);
        }

        public static IEnumerable<object?> ReadDatFile(string datFilePath, Type type, bool hasHeaderRecord, int codePage)
        {
            var enc = CodePagesEncodingProvider.Instance.GetEncoding(codePage);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(datFilePath, enc, false))
            {
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    
                    HasHeaderRecord = hasHeaderRecord,
                    Delimiter = "\t",
                    Mode = CsvMode.NoEscape //23.12.13 KA: set no escape means reader will ignore all escape character. for remarks field PRIDES OPN dat file.
                };

                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.TypeConverterOptionsCache.GetOptions<decimal>().NumberStyles = NumberStyles.Number | NumberStyles.AllowExponent;

                    return csv.GetRecords(type).ToList();
                }
            }
        }
    }
}
