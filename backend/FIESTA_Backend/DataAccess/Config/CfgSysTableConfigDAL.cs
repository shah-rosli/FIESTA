using FIESTA_Backend.EfModels;
using UtilityCore.Models;

namespace FIESTA_Backend.DataAccess.Config
{
    public class CfgSysTableConfigDAL
    {
        private readonly FiestaDbContext _context;

        public CfgSysTableConfigDAL(FiestaDbContext context)
        {
            _context = context;
        }

        public List<CfgSysTableColumnConfig> GetColumnConfigByTableName(string tableName)
        {
            List<CfgSysTableColumnConfig> result = _context.CFG_SYS_TABLE_CONFIGs
                            .Join(_context.CFG_SYS_COLUMN_CONFIGs,
                                  table => table.CFG_SYS_TABLE_CONFIG_ID,
                                  column => column.CFG_SYS_TABLE_CONFIG_ID,
                                  (table, column) => new
                                  {
                                      table.CFG_SYS_TABLE_NAME,
                                      TABLE_ACTIVE = table.ACTIVE,
                                      FIXED = column._fixed,
                                      column.fixedPosition,
                                      column.dataField,
                                      column.dataType,
                                      column.caption,
                                      column.visibleIndex,
                                      column.visible,
                                      column.format,
                                      column.sortIndex,
                                      column.sortOrder,
                                      table.CFG_SYS_ALLOW_CREATE,
                                      table.CFG_SYS_ALLOW_EDIT,
                                      column.editable,
                                      column.nullable,
                                      column.minChar,
                                      column.maxChar,
                                      column.minNum,
                                      column.maxNum,
                                      COLUMN_ACTIVE = column.ACTIVE
                                  })
                            .Where(x => x.CFG_SYS_TABLE_NAME == tableName &&
                                        x.TABLE_ACTIVE == "Yes" &&
                                        x.COLUMN_ACTIVE == "Yes")
                            .Select(x => new CfgSysTableColumnConfig()
                            {
                                format = x.format,
                                dataField = x.dataField,
                                dataType = x.dataType,
                                caption = x.caption,
                                visible = bool.Parse(x.visible),
                                visibleIndex = x.visibleIndex,
                                sortIndex = x.sortIndex,
                                sortOrder = x.sortOrder,
                                allowCreate = !string.IsNullOrEmpty(x.CFG_SYS_ALLOW_CREATE) ? bool.Parse(x.CFG_SYS_ALLOW_CREATE) : false,
                                allowEdit = !string.IsNullOrEmpty(x.CFG_SYS_ALLOW_EDIT) ? bool.Parse(x.CFG_SYS_ALLOW_EDIT) : false,
                                editable = !string.IsNullOrEmpty(x.editable) ? bool.Parse(x.editable) : false,
                                nullable = !string.IsNullOrEmpty(x.nullable) ? bool.Parse(x.nullable) : true,
                                //mandatory = !string.IsNullOrEmpty(x.mandatory) ? bool.Parse(x.mandatory) : false,
                                minChar = x.minChar,
                                maxChar = x.maxChar,
                                minNum = x.minNum,
                                maxNum = x.maxNum
                            })
                            .OrderBy(x => x.visibleIndex).ToList<CfgSysTableColumnConfig>();

            return result;
        }
    }
}
