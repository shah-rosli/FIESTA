using DocumentFormat.OpenXml.Spreadsheet;
using FIESTA_Backend.EfModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgSysColumnConfigDAL
    {
        private readonly FiestaDbContext _context;

        public CfgSysColumnConfigDAL(FiestaDbContext context)
        {
            _context = context;
        }

        public List<string> GetPatternListing(string tableName)
        {
            List<string> patternList = new List<string>();
            var result = _context.CFG_SYS_TABLE_CONFIGs
                            .Join(_context.CFG_SYS_COLUMN_CONFIGs,
                                  table => table.CFG_SYS_TABLE_CONFIG_ID,
                                  column => column.CFG_SYS_TABLE_CONFIG_ID,
                                  (table, column) => new
                                  {
                                      table.CFG_SYS_TABLE_NAME,
                                      TABLE_ACTIVE = table.ACTIVE,
                                      column.patternRequired,
                                      COLUMN_ACTIVE = column.ACTIVE
                                  })
                            .Where(x => x.CFG_SYS_TABLE_NAME == tableName &&
                                        x.TABLE_ACTIVE == "Yes" &&
                                        x.COLUMN_ACTIVE == "Yes" &&
                                        !string.IsNullOrEmpty(x.patternRequired))
                            .Select(x => new
                            {
                                patternRequired = x.patternRequired
                            });

            foreach (var pattern in result)
            {
                string[] val;
                if (pattern != null)
                {
                    val = pattern.patternRequired.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < val.Length; i++)
                    {
                        //insert when not exist
                        if (!string.IsNullOrEmpty(val[i]) && !patternList.Exists(x => x == val[i]))
                        {
                            patternList.Add(val[i]);
                        }
                    }
                }
            }

            return patternList;
        }

        public List<string> GetPatternRequiredFields(string tableName, string pattern)
        {
            var result = _context.CFG_SYS_TABLE_CONFIGs
                            .Join(_context.CFG_SYS_COLUMN_CONFIGs,
                                  table => table.CFG_SYS_TABLE_CONFIG_ID,
                                  column => column.CFG_SYS_TABLE_CONFIG_ID,
                                  (table, column) => new
                                  {
                                      table.CFG_SYS_TABLE_NAME,
                                      TABLE_ACTIVE = table.ACTIVE,
                                      column.patternRequired,
                                      COLUMN_ACTIVE = column.ACTIVE,
                                      column.dataField,
                                      column.visibleIndex
                                  })
                            .Where(x => x.CFG_SYS_TABLE_NAME == tableName &&
                                        x.TABLE_ACTIVE == "Yes" &&
                                        x.COLUMN_ACTIVE == "Yes" &&
                                        x.patternRequired.Contains(pattern + ";")
                                        )
                            .Select(x => new
                            {
                                dataField = x.dataField,
                                visibleIndex = x.visibleIndex,
                            }).OrderBy(x => x.visibleIndex);

            List<string> ret = new List<string>();
            foreach(var val in result)
            {
                ret.Add(val.dataField);
            }

            return ret;
        }

        public bool TryGetPropertyValue<TType, TObj>(TObj obj, string propertyName, out TType? value)
        {
            value = default;
            if (obj is null)
            {
                Console.WriteLine("Object is null.");
                return false;
            }
            PropertyInfo? propertyInfo = typeof(TObj).GetProperty(propertyName);
            if (propertyInfo is null)
            {
                Console.WriteLine($"Property '{propertyName}' not found.");
                return false;
            }
            object? propertyValue = propertyInfo.GetValue(obj);
            if (propertyValue is null && Nullable.GetUnderlyingType(typeof(TType)) is not null)
            {
                return true;
            }
            if (propertyValue is not TType typedValue)
            {
                Console.WriteLine($"Property '{propertyName}' is of type {propertyInfo.PropertyType}, got {typeof(TType)}.");
                return false;
            }
            value = typedValue;
            return true;
        }
    }
}
