using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_BASIC
    {
        public string MARA_MATNR { get; set; } = null!;

        public string MARA_MTART { get; set; } = null!;

        public string? MARA_MBRSH { get; set; }

        public string? MAKT_MAKTX { get; set; }

        public string MARA_MATKL { get; set; } = null!;

        public string MARA_BISMT { get; set; } = null!;

        public string MARA_MEINS { get; set; } = null!;

        public string? MARA_EXTWG { get; set; }

        public string? MARA_SPART { get; set; }

        public string? MARA_LABOR { get; set; }

        public string? MARA_KOSCH { get; set; }

        public string MARA_PRDHA { get; set; } = null!;

        public string? MARA_MSTAE { get; set; }

        public string? MARA_MSTDE { get; set; }

        public string? MARA_MTPOS { get; set; }

        public string? MARA_BEGRU { get; set; }

        public decimal? MARA_BRGEW { get; set; }

        public string? MARA_GEWEI { get; set; }

        public decimal? MARA_NTGEW { get; set; }

        public string? MARA_VOLUM { get; set; }

        public string? MARA_VOLEH { get; set; }

        public string? MARA_GROES { get; set; }

        public string? MARA_EAN11 { get; set; }

        public string? MARA_NUMTP { get; set; }

        public string? MARA_MAGRV { get; set; }

        public string? MARA_RMATP { get; set; }

        public string? MARA_CMREL { get; set; }

        public string? MARA_FERTH { get; set; }

        public string? MARA_NORMT { get; set; }

        public string? MARA_FORMT { get; set; }

        public string? MARA_CADKZ { get; set; }

        public string? MARA_WRKST { get; set; }

        public string? MARA_PROFL { get; set; }

        public string? MARA_KZUMW { get; set; }

        public string? MARA_IHIVI { get; set; }

        public string? MARA_ILOOS { get; set; }

        public string? RMMZU_MDZUO { get; set; }

        public string? MARA_ZEINR { get; set; }

        public string? MARA_ZEIAR { get; set; }

        public string? MARA_ZEIVR { get; set; }

        public string? MARA_BLATT { get; set; }

        public string? MARA_AESZN { get; set; }
        public string? MARA_XCHPF { get; set; }
        public string? MARA_KZEFF { get; set; }

        public string? MARA_LAEDA { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
