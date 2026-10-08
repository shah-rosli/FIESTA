using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_INIT_ACCOUNTING
    {
        public string MARA_MATNR { get; set; } = null!;

        public string MBEW_BWKEY { get; set; } = null!;

        public string? MBEW_BWTAR { get; set; }

        public string? MARA_MTART { get; set; }

        public string? MAKT_MBRSH { get; set; }

        public string? MAKT_MAKTX { get; set; }

        public string? MARA_MEINS { get; set; }

        public string? MARA_BWTTY { get; set; }

        public string? MARA_SPART { get; set; }

        public string? MBEW_MLAST { get; set; }

        public string? MBEW_MLMAA { get; set; }

        public string? MBEW_BKLAS { get; set; }

        public string? MBEW_EKLAS { get; set; }

        public string? MBEW_QKLAS { get; set; }

        public string? MBEW_VPRSV { get; set; }

        public string? MBEW_PEINH { get; set; }

        public string? MBEW_VERPR { get; set; }

        public string? MBEW_STPRS { get; set; }

        public string? MBEW_ZKDAT { get; set; }

        public string? MBEW_STPRV { get; set; }

        public string? MBEW_LAEPR { get; set; }

        public string? MBEW_VMBKL { get; set; }

        public string? MBEW_VMVPR { get; set; }

        public string? MBEW_VMPEI { get; set; }

        public string? MBEW_VMSTP { get; set; }

        public string? MBEW_VMVER { get; set; }

        public string? MBEW_VJBKL { get; set; }

        public string? MBEW_VJVPR { get; set; }

        public string? MBEW_VJPEI { get; set; }

        public string? MBEW_VJSTP { get; set; }

        public string? MBEW_VJVER { get; set; }

        public string? MBEW_BWPRS { get; set; }

        public string? MBEW_BWPRH { get; set; }

        public string? MBEW_BWPS1 { get; set; }

        public string? MBEW_BWPH1 { get; set; }

        public string? MBEW_VJBWS { get; set; }

        public string? MBEW_VJBWH { get; set; }

        public string? MBEW_ABWKZ { get; set; }

        public string? MBEW_BWPEI { get; set; }

        public string? MBEW_XLIFO { get; set; }

        public string? MBEW_MYPOL { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string updateType { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }
    }
}
