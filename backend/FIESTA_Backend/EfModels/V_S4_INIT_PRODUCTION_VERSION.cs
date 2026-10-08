using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_PRODUCTION_VERSION
    {
        public string MARC_WERKS { get; set; } = null!;

        public string MARA_MATNR { get; set; } = null!;

        public string VERID { get; set; } = null!;

        public string? DISPO { get; set; }

        public string? STTAG { get; set; }

        public string? PLNTY { get; set; }

        public string PLNNR { get; set; } = null!;

        public string? MDV01 { get; set; }

        public string TEXT1 { get; set; } = null!;

        public string? MKSP { get; set; }

        public string? ADATU { get; set; }

        public string? BDATU { get; set; }

        public string? BSTMI { get; set; }

        public string? BSTMA { get; set; }

        public string STLAL { get; set; } = null!;

        public string STLAN { get; set; } = null!;

        public string? CSPLT { get; set; }

        public string ALNAL { get; set; } = null!;

        public string? UCMAT { get; set; }

        public string? SERKZ { get; set; }

        public string? MDV02 { get; set; }

        public string? MATKO { get; set; }

        public string? VERTO { get; set; }

        public string? ALORT { get; set; }

        public string? ELPRO { get; set; }

        public string? PRVBE { get; set; }

        public string? NON_SC { get; set; }

        public string? INP_RECORD { get; set; }

        public string STLNR { get; set; } = null!;

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
