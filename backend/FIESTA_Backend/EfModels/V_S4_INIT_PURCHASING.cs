using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_PURCHASING
    {
        public string MARA_MATNR { get; set; } = null!;

        public string MARC_WERKS { get; set; } = null!;

        public string MARA_MTART { get; set; } = null!;

        public string? MAKT_MBRSH { get; set; }

        public string? MARA_MAKTX { get; set; }

        public string MARA_MATKL { get; set; } = null!;

        public string MARA_BSTME { get; set; } = null!;

        public string MARA_MEINS { get; set; } = null!;

        public string? MARA_VABME { get; set; }

        public string? MARC_EKGRP { get; set; }

        public string? MARC_MMSTA { get; set; }

        public string? MARC_MMSTD { get; set; }

        public string? MLAN_TAXIM1 { get; set; }

        public string? MARA_NRFHG { get; set; }

        public string? MARA_MFRGR { get; set; }

        public string? MARC_KAUTB { get; set; }

        public string? MARA_XCHPF { get; set; }

        public string? MARA_EKWSL { get; set; }

        public string? MARC_WEBAZ { get; set; }

        public string? MARC_INSMK { get; set; }

        public string? MARC_KZKRI { get; set; }

        public string? MARC_USEQU { get; set; }

        public string? MARC_KORDB { get; set; }

        public string? MARC_FABKZ { get; set; }

        public string? MARA_MPROF { get; set; }

        public string? MARA_MFRPN { get; set; }

        public string? MARA_MFRNR { get; set; }

        public string? MARC_STAWN { get; set; }

        public string? MARC_MTVER { get; set; }

        public string? MARC_CASNR { get; set; }

        public string? MARC_GPNUM { get; set; }

        public string? MARC_STEUC { get; set; }

        public string? MARA_HERKL { get; set; }

        public string? MARC_HERKR { get; set; }

        public string? MARC_MOWNR { get; set; }

        public string? MARC_MOGRU { get; set; }

        public string? MARC_PRENC { get; set; }

        public string? MARC_PRENO { get; set; }

        public string? MARC_PREND { get; set; }

        public string? MARC_ITARK { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
