using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_S4_ZMT_OPN_OSAT
    {
        public string MARA_MATNR { get; set; } = null!;
        public string T001W_WERKS { get; set; } = null!;
        public string T001L_LGORT { get; set; } = null!;
        public string? Z_SOPN { get; set; }
    }
}
