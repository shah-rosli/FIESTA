using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_SYS_TABLE_CONFIG
    {
        public CFG_SYS_TABLE_CONFIG()
        {
            CFG_SYS_COLUMN_CONFIGs = new HashSet<CFG_SYS_COLUMN_CONFIG>();
        }
        public decimal CFG_SYS_TABLE_CONFIG_ID { get; set; }

        public string? CFG_SYS_TABLE_NAME { get; set; }

        public string? CFG_SYS_TABLE_DESC { get; set; }

        public string? ACTIVE { get; set; }

        public string? CFG_SYS_TABLE_SP_EXPORT_NAME { get; set; }

        public string? CFG_SYS_TABLE_EXTRACT_FILENAME { get; set; }

        public DateTimeOffset? CFG_SYS_TABLE_EXTRACT_DATETIME { get; set; }

        public string? CFG_SYS_TABLE_GROUP_NAME { get; set; }

        public bool? CFG_SYS_TABLE_EXTRACT_IN_PROGRESS { get; set; }

        public DateTimeOffset? CFG_SYS_TABLE_EXTRACT_START_TIME { get; set; }

        public decimal? CFG_SYS_TABLE_SORT_INDEX { get; set; }

        public string CFG_SYS_ALLOW_CREATE { get; set; } = null!;

        public string CFG_SYS_ALLOW_EDIT { get; set; } = null!;

        public decimal? MAX_PERCENT { get; set; }

        public byte? MAX_PERCENT_ENABLE { get; set; }

        public decimal? LAST_UPDATED_PERCENT { get; set; }

        public DateTimeOffset? LAST_UPDATED_TIMESTAMP { get; set; }

        public decimal? LAST_ALERT_PERCENT { get; set; }

        public DateTimeOffset? LAST_ALERT_TIMESTAMP { get; set; }

        public virtual ICollection<CFG_SYS_COLUMN_CONFIG> CFG_SYS_COLUMN_CONFIGs { get; set; }
    }
}
