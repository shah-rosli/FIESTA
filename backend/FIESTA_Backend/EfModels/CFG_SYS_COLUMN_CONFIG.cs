using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_SYS_COLUMN_CONFIG
    {
        public decimal CFG_SYS_COLUMN_CONFIG_ID { get; set; }
        public decimal CFG_SYS_TABLE_CONFIG_ID { get; set; }
        public string ACTIVE { get; set; } = null!;
        public string _fixed { get; set; } = null!;
        public decimal? fixedPosition { get; set; }
        public string dataField { get; set; } = null!;
        public string dataType { get; set; } = null!;
        public string? caption { get; set; }
        public string visible { get; set; } = null!;
        public decimal? visibleIndex { get; set; }
        public string? format { get; set; }
        public decimal? sortIndex { get; set; }
        public string? sortOrder { get; set; }
        public string? editable { get; set; }
        public string? nullable { get; set; }
        public decimal? minChar { get; set; }
        public decimal? maxChar { get; set; }
        public decimal? minNum { get; set; }
        public decimal? maxNum { get; set; }
        public decimal? width { get; set; }
        public string? patternRequired { get; set; }

        public virtual CFG_SYS_TABLE_CONFIG CFG_SYS_TABLE_CONFIG { get; set; } = null!;
    }
}
