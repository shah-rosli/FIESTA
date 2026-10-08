using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_STORAGE_LOCATION
    {
        public string MARA_MATNR { get; set; } = null!;

        public string MARC_WERKS { get; set; } = null!;

        public string MARD_LGORT { get; set; } = null!;

        public string MARA_MTART { get; set; } = null!;

        public string? MAKT_MBRSH { get; set; }

        public string? MAKT_MAKTX { get; set; }

        public string MARA_MEINS { get; set; } = null!;

        public string? MARC_AUSME { get; set; }

        public string? MARD_LGPBE { get; set; }

        public string? MARD_LWMKB { get; set; }

        public string? MARA_TEMPB { get; set; }

        public string? MARA_RAUBE { get; set; }

        public string? MARA_BEHVO { get; set; }

        public string? MARA_STOFF { get; set; }

        public string? MARC_ABCIN { get; set; }

        public string? MARC_CCFIX { get; set; }

        public string? MARA_WESCH { get; set; }

        public string? MARA_ETIAR { get; set; }

        public string? MARA_ETIFO { get; set; }

        public string? MARA_XGCHP { get; set; }

        public string? MARA_XCHPF { get; set; }

        public string? MARC_MAXLZ { get; set; }

        public string? MARC_LZEIH { get; set; }

        public string? MARA_MHDRZ { get; set; }

        public long? MARA_MHDHB { get; set; }

        public string? PRDKZT___EPRKZ { get; set; }

        public string? MARA_RDMHD { get; set; }

        public string? MARA_MHDLP { get; set; }

        public decimal? MARA_BRGEW { get; set; }

        public string? MARA_GEWEI { get; set; }

        public decimal? MARA_NTGEW { get; set; }

        public string? MARA_VOLUM { get; set; }

        public string? MARA_VOLEH { get; set; }

        public string? MARA_GROES { get; set; }

        public string? MARC_XMCNG { get; set; }

        public string? MARC_LOGGR { get; set; }

        public string? MARC_SERNP { get; set; }

        public string? MARA_SERLV { get; set; }

        public string? MARC_FPRFM { get; set; }

        public string MARC_PRCTR { get; set; } = null!;

        public string? MARC_EPRIO { get; set; }

        public string? MARA_IPRKZ { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
