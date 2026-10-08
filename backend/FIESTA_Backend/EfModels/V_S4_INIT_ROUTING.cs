using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_ROUTING
    {
        public string MAPL_MATNR { get; set; } = null!;

        public string MAPL_WERKS { get; set; } = null!;

        public string? VBELN { get; set; }

        public string? POSNR { get; set; }

        public string? POSID { get; set; }

        public string? MAPL_PLNNR { get; set; }

        public string? STTAG { get; set; }

        public string? MAPL_DATUV { get; set; }

        public string? MAPL_PLNAL { get; set; }

        public string PLKO_KTEXT { get; set; } = null!;

        public string? PLKO_VERWE { get; set; }

        public string? PLKO_STATU { get; set; }

        public string? PLKO_LOSVN { get; set; }

        public string? PLKO_LOSBS { get; set; }

        public string PLKO_PLNME { get; set; } = null!;

        public string? DELKZ { get; set; }

        public string PLPO_VORNR { get; set; } = null!;

        public string? UVORN { get; set; }

        public string? CRHD_ARBPL { get; set; }

        public string? WERKS { get; set; }

        public string PLPO_STEUS { get; set; } = null!;

        public string? PLPO_KTSCH { get; set; }

        public string PLPO_LTXA1 { get; set; } = null!;

        public long? PLPO_BMSCH { get; set; }

        public string? PLPO_MEINH { get; set; }

        public string? PLPO_UMREZ { get; set; }

        public string? PLPO_UMREN { get; set; }

        public string? OPR_UNIT { get; set; }

        public decimal? PLPO_VGW01 { get; set; }

        public decimal? PLPO_VGW02 { get; set; }

        public decimal? PLPO_VGW03 { get; set; }

        public string? PLPO_VGW04 { get; set; }

        public string? PLPO_VGW05 { get; set; }

        public string? PLPO_VGW06 { get; set; }

        public string PLPO_VGE01 { get; set; } = null!;

        public string PLPO_VGE02 { get; set; } = null!;

        public string? PLPO_VGE03_ { get; set; }

        public string? PLPO_VGE04 { get; set; }

        public string? PLPO_VGE05 { get; set; }

        public string? PLPO_VGE06 { get; set; }

        public string? AUFAK { get; set; }

        public string? SLWID { get; set; }

        public string? NVADD { get; set; }

        public string? IDNRK { get; set; }

        public string? STLAL { get; set; }

        public string? PLPO_LAR01 { get; set; }

        public string? PLPO_LAR02 { get; set; }

        public string? PLPO_LAR03 { get; set; }

        public string? FRDLB { get; set; }

        public string? INFNR { get; set; }

        public string? EKORG { get; set; }

        public string? EBELN { get; set; }

        public string? EBELP { get; set; }

        public string? SORTL { get; set; }

        public string? MATKL { get; set; }

        public string? EKGRP { get; set; }

        public string? LIFNR { get; set; }

        public string? PLIFZ { get; set; }

        public string? PEINH { get; set; }

        public string? SAKTO { get; set; }

        public string? PREIS { get; set; }

        public string? WAERS { get; set; }

        public string? QPART { get; set; }

        public string PLPO_USR00 { get; set; } = null!;

        public string PLPO_USR01 { get; set; } = null!;

        public string PLPO_USR02 { get; set; } = null!;

        public string? MLST_SMLNR { get; set; }

        public string? LTEXT { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
