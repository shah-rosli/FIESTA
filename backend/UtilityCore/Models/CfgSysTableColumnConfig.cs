namespace UtilityCore.Models
{
    public class CfgSysTableColumnConfig
    {
        public int? outputIndex { get; set; }
        public int? dtIndex { get; set; }
        public string? format { get; set; }
        public string? dataField { get; set; }
        public string? dataType { get; set; }
        public string? caption { get; set; }
        public bool visible { get; set; }
        public decimal? visibleIndex { get; set; }
        public decimal? sortIndex { get; set; }
        public string? sortOrder { get; set; }
        public bool allowCreate { get; set; }
        public bool allowEdit { get; set; }
        public bool editable { get; set; }
        public bool nullable { get; set; }
        //public bool mandatory { get; set; } to be removed from database.
        public decimal? minChar { get; set; }
        public decimal? maxChar { get; set; }
        public decimal? minNum { get; set; }
        public decimal? maxNum { get; set; }
    }
}
