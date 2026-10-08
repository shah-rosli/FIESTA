using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_SALE
    {
        public string MARA_MATNR { get; set; } = null!;

        public string? MARC_WERKS { get; set; }

        public string MVKE_VKORG { get; set; } = null!;

        public string MVKE_VTWEG { get; set; } = null!;

        public string MARA_MTART { get; set; } = null!;

        public string? MAKT_MBRSH { get; set; }

        public string? MAKT_MAKTX { get; set; }

        public string? MARA_SPART { get; set; }

        public string MARA_MEINS { get; set; } = null!;

        public string? MVKE_VRKME { get; set; }

        public string? MVKE_VAVME { get; set; }

        public string? MARA_MEGRU { get; set; }

        public string? MARA_MSTAV { get; set; }

        public string? MARA_MSTDV { get; set; }

        public string? MVKE_VMSTA { get; set; }

        public string? MVKE_VMSTD { get; set; }

        public string? MVKE_DWERK { get; set; }

        public string? MVKE_SKTOF { get; set; }

        public string? MLAN_ALAND { get; set; }

        public string? TSKM_TATYP { get; set; }

        public string? MLAN_TAXM1 { get; set; }

        public long? MVKE_AUMNG { get; set; }

        public long? MVKE_LFMNG { get; set; }

        public long? MVKE_SCMNG { get; set; }

        public string MVKE_SCHME { get; set; } = null!;

        public string? MVKE_RDPRF { get; set; }

        public string? MVKE_VERSG { get; set; }

        public string? MVKE_KONDM { get; set; }

        public string? MVKE_BONUS { get; set; }

        public string? MVKE_KTGRM { get; set; }

        public string? MARA_MTPOS_MARA { get; set; }

        public string? MVKE_MTPOS { get; set; }

        public string? MVKE_PMATN { get; set; }

        public string MVKE_PRODH { get; set; } = null!;

        public string? MVKE_PROVG { get; set; }

        public string? MVKE_PRAT1 { get; set; }

        public string? MVKE_PRAT2 { get; set; }

        public string? MVKE_PRAT3 { get; set; }

        public string? MVKE_PRAT4 { get; set; }

        public string? MVKE_PRAT5 { get; set; }

        public string? MVKE_PRAT6 { get; set; }

        public string? MVKE_PRAT7 { get; set; }

        public string? MVKE_PRAT8 { get; set; }

        public string? PRAT9 { get; set; }

        public string? PRATA { get; set; }

        public string? MVKE_MVGR1 { get; set; }

        public string? MVKE_MVGR2 { get; set; }

        public string? MVKE_MVGR3 { get; set; }

        public string? MVKE_MVGR4 { get; set; }

        public string? MVKE_MVGR5 { get; set; }

        public string? MARA_TRAGR { get; set; }

        public string? DEPCOUNTRY { get; set; }

        public string? MARC_MTVFP { get; set; }

        public string? MARC_XCHPF { get; set; }

        public string? MARC_LADGR { get; set; }

        public string? MARA_MAGRV { get; set; }

        public string? MARC_PRCTR { get; set; }

        public string? MARC_SERNP { get; set; }

        public string? MARA_MFRGR { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
