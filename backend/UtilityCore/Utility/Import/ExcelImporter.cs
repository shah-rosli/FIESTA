using Microsoft.VisualBasic;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UtilityCore.Models;

namespace UtilityCore.Utility.Import
{
    public static class ExcelImporter
    {
        public static List<T> Import<T>(Stream stream) where T : new()
        {
            XSSFWorkbook workbook;
            using (stream)
            {
                workbook = new XSSFWorkbook(stream);
            }

            var sheet = workbook.GetSheetAt(0);

            var rowHeader = sheet.GetRow(0);
            var colIndexList = new Dictionary<string, int>();
            foreach (var cell in rowHeader.Cells)
            {
                var colName = cell.StringCellValue;
                colIndexList.Add(colName, cell.ColumnIndex);
            }

            var listResult = new List<T>();
            var currentRow = 0;//decrease the currentRow from 1 to 0, because we will increment it first ++currentRow later
            List<string> array_error_message = new List<string>(); //to store formatting error message for all number columns, and it won't repeat formatting error on same column.  

            while (currentRow <= sheet.LastRowNum)
            {
                var row = sheet.GetRow(++currentRow);//increment the rowCount first
                if (row == null) break;

                //detect blank row - skip (continue) if true
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;

                var obj = new T();

                foreach (var property in typeof(T).GetProperties())
                {
                    //only process property found in colIndexList
                    if (colIndexList.ContainsKey(property.Name))
                    {
                        var colIndex = colIndexList[property.Name];
                        var cell = row.GetCell(colIndex);

                        if (cell == null 
                            || cell.CellType == CellType.Blank
                            || (cell.CellType == CellType.String && string.IsNullOrWhiteSpace(cell.StringCellValue))
                        ){
                            property.SetValue(obj, null);
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            cell.SetCellType(CellType.String);
                            property.SetValue(obj, cell.StringCellValue);
                        }
                        else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                        {
                            if (cell.CellType == CellType.Numeric)
                            {
                                property.SetValue(obj, Convert.ToInt32(cell.NumericCellValue));
                            }
                            else if (cell.CellType == CellType.String)
                            {
                                if (Int32.TryParse(cell.StringCellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out Int32 num))
                                {
                                    property.SetValue(obj, Convert.ToInt32(cell.StringCellValue));
                                }
                                else
                                {
                                    if (!array_error_message.Any(msg => msg.Contains("[" + property.Name + "] has invalid number")))
                                    {
                                        array_error_message.Add("[" + property.Name + "] has invalid number '" + cell.StringCellValue + "'!");
                                    }
                                }
                            }
                            else if (cell.CellType == CellType.Blank)
                            {
                                property.SetValue(obj, null);
                            }
                            else
                            {
                                property.SetValue(obj, Convert.ChangeType(cell.StringCellValue, property.PropertyType));
                            }
                        }
                        else if (property.PropertyType == typeof(long) || property.PropertyType == typeof(long?))
                        {
                            if (cell.CellType == CellType.Numeric)
                            {
                                property.SetValue(obj, Convert.ToInt64(cell.NumericCellValue));
                            }
                            else if (cell.CellType == CellType.String)
                            {
                                if (Int32.TryParse(cell.StringCellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out Int32 num))
                                {
                                    property.SetValue(obj, Convert.ToInt64(cell.StringCellValue));
                                }
                                else
                                {
                                    if (!array_error_message.Any(msg => msg.Contains("[" + property.Name + "] has invalid number")))
                                    {
                                        array_error_message.Add("[" + property.Name + "] has invalid number '" + cell.StringCellValue + "'!");
                                    }
                                }
                            }
                            else if (cell.CellType == CellType.Blank)
                            {
                                property.SetValue(obj, null);
                            }
                            else
                            {
                                property.SetValue(obj, Convert.ChangeType(cell.StringCellValue, property.PropertyType));
                            }
                        }
                        else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                        {
                            if (cell.CellType == CellType.Numeric)
                            {
                                property.SetValue(obj, Convert.ToDecimal(cell.NumericCellValue));
                            }
                            else if (cell.CellType == CellType.String)
                            {
                                if (decimal.TryParse(cell.StringCellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num))
                                {
                                    property.SetValue(obj, Convert.ToDecimal(cell.StringCellValue));
                                }
                                else
                                {
                                    if (!array_error_message.Any(msg => msg.Contains("[" + property.Name + "] has invalid number")))
                                    {
                                        array_error_message.Add("[" + property.Name + "] has invalid number '" + cell.StringCellValue + "'!");
                                    }
                                }
                            }
                            else if (cell.CellType == CellType.Blank)
                            {
                                property.SetValue(obj, null);
                            }
                            else {
                                property.SetValue(obj, Convert.ChangeType(cell.StringCellValue, property.PropertyType));
                            }
                        }
                        else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            property.SetValue(obj, Convert.ToDateTime(cell.DateCellValue));
                        }
                        else if (property.PropertyType == typeof(DateTimeOffset) || property.PropertyType == typeof(DateTimeOffset?))
                        {
                            DateTime? dt = Convert.ToDateTime(cell.DateCellValue);
                            if(dt.HasValue)
                            {
                                //convert datetime to datetimeoffset
                                property.SetValue(obj, (DateTimeOffset?)new DateTimeOffset(dt.Value.Year, dt.Value.Month, dt.Value.Day, dt.Value.Hour, dt.Value.Minute, dt.Value.Second, new TimeSpan(0, 0, 0)));
                            }
                            else
                            {
                                property.SetValue(obj, null);
                            }
                        }
                        else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                        {
                            cell.SetCellType(CellType.Boolean);
                            property.SetValue(obj, cell.BooleanCellValue);
                        }
                        else
                        {
                            property.SetValue(obj, Convert.ChangeType(cell.StringCellValue, property.PropertyType));
                        }
                    }
                }

                listResult.Add(obj);
                //currentRow++; no longer needed as we increment it on top
            }

            if (array_error_message.Count > 0) {
                string error_message = string.Join("  \n", array_error_message);
                throw new FormatException($"Data import failed: {error_message}");
            }
            return listResult;
        }

        public static CfgBulkImport ValidateRecord<T>(T excelRecord, T dbRecord, List<CfgSysTableColumnConfig> columnConfigs, CfgBulkImport importResult) where T : new()
        {
            var obj = new T();

            //only validate editable column
            List<CfgSysTableColumnConfig> validatedColumn = columnConfigs.Where(x => x.editable).ToList();
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            foreach (CfgSysTableColumnConfig cfg in validatedColumn)
            {
                //get the property
                PropertyInfo property = typeof(T).GetProperty(cfg.dataField.ToString());
                //if property exist
                if(property != null)
                {
                    //compare value between both object
                    if(excelRecord != null && dbRecord != null && property.GetValue(excelRecord)?.ToString().Trim() != property.GetValue(dbRecord)?.ToString().Trim()
                        && (!string.IsNullOrEmpty(property.GetValue(excelRecord)?.ToString()) && !string.IsNullOrEmpty(property.GetValue(dbRecord)?.ToString()))//both field must not be null or empty string.
                        )
                    {
                        importResult.haveDifference = true;
                    }

                    //mandatory
                    if (!cfg.nullable && excelRecord != null && property.GetValue(excelRecord) == null)
                    {
                        importResult.errorMessage += "[" + cfg.caption + "] is mandatory! \n";
                    }

                    //char validation
                    if (!cfg.nullable && cfg.minChar.HasValue && property.GetValue(excelRecord) != null && property.GetValue(excelRecord)?.ToString().Length < cfg.minChar)
                    {
                        importResult.errorMessage += "[" + cfg.caption + "] field length must be >= " + cfg.minChar.ToString() + ". \n";
                    }
                    if (!cfg.nullable && cfg.maxChar.HasValue && property.GetValue(excelRecord) != null && property.GetValue(excelRecord)?.ToString().Length > cfg.maxChar)
                    {
                        importResult.errorMessage += "[" + cfg.caption + "] field length must be <= " + cfg.maxChar.ToString() + ". \n";
                    }

                    //number validation
                    if (!cfg.nullable && cfg.minNum.HasValue && property.GetValue(excelRecord) != null && Convert.ToDecimal(property.GetValue(excelRecord)) < cfg.minNum)
                    {
                        importResult.errorMessage += "[" + cfg.caption + "] numeric value must be >= " + cfg.minNum.ToString() + ". \n";
                    }
                    if (!cfg.nullable && cfg.maxNum.HasValue && property.GetValue(excelRecord) != null && Convert.ToDecimal(property.GetValue(excelRecord)) > cfg.maxNum)
                    {
                        importResult.errorMessage += "[" + cfg.caption + "] numeric value must be <= " + cfg.maxNum.ToString() + ". \n";
                    }
                }
            }

            return importResult;
        }
    }
}
