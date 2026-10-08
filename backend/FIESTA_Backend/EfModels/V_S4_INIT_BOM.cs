using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_BOM
    {
        public string MAST_MATNR { get; set; } = null!;

        public string MAST_WERKS { get; set; } = null!;

        public string? MAST_STLAL { get; set; }

        public string MAST_STLAN { get; set; } = null!;

        public string? STZU_EXSTL { get; set; }

        public string? STZU_ZTEXT { get; set; }

        public string? STKO_STKTX { get; set; }

        public long STKO_BMENG { get; set; }

        public string STKO_BMEIN { get; set; } = null!;

        public string? STKO_AENNR { get; set; }

        public string? STKO_DATUV { get; set; }

        public string STKO_STLST { get; set; } = null!;

        public string? STZU_STLBE { get; set; }

        public string? STKO_LKENZ { get; set; }

        public string? STKO_LABOR { get; set; }

        public string STKO_Z_STLNR_MDM { get; set; } = null!;

        public string STKO_Z_STLAL_MDM { get; set; } = null!;

        public string STPO_POSNR { get; set; } = null!;

        public string STPO_IDNRK { get; set; } = null!;

        public long STPO_MENGE { get; set; }

        public string STPO_MEINS { get; set; } = null!;

        public string? STPO_POSTP { get; set; }

        public string? STPO_ITMID { get; set; }

        public string? STPO_SORTF { get; set; }

        public string? STPO_POTX1 { get; set; }

        public string? STPO_POTX2 { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }

        public string headerDeleteFlag { get; set; } = null!;
    }
}
