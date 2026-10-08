using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_SALES_PLANT
    {
        public string MARA_MATNR { get; set; } = null!;

        public string MARC_WERKS { get; set; } = null!;

        public string MARA_MTART { get; set; } = null!;

        public string? MAKT_MBRSH { get; set; }

        public string? MARA_MAKTX { get; set; }

        public string MARA_MEINS { get; set; } = null!;

        public string? MARC_ATPKZ { get; set; }

        public decimal? MARA_BRGEW { get; set; }

        public string? MARA_GEWEI { get; set; }

        public decimal? MARA_NTGEW { get; set; }

        public string? MARA_NRFHG { get; set; }

        public string? MARA_MFRGR { get; set; }

        public string? MARC_MTVFP { get; set; }

        public string? MARA_XGCHP { get; set; }

        public string? MARA_XCHPF { get; set; }

        public string? MARA_TRAGR { get; set; }

        public string? MARC_LADGR { get; set; }

        public string? MARC_VRVEZ { get; set; }

        public string? MARC_VBAMG { get; set; }

        public string? MARC_VBEAZ { get; set; }

        public string? MARC_XMCNG { get; set; }

        public string MARC_PRCTR { get; set; } = null!;

        public string? MARC_SERNP { get; set; }

        public string? MARC_FPRFM { get; set; }

        public string? MARC_FSH_MG_ARUN_REQ { get; set; }

        public string? MARC_ARUN_FIX_BATCH { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? updateType { get; set; }

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
