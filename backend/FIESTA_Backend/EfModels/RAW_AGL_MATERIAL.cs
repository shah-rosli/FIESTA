using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_AGL_MATERIAL
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string partType { get; set; } = null!;
        public string description { get; set; } = null!;
        public string plmStatus { get; set; } = null!;
        public string legacyOrganization { get; set; } = null!;
        public string? specNo { get; set; }
        public decimal? wireDiameter { get; set; }
        public string? wireType { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
