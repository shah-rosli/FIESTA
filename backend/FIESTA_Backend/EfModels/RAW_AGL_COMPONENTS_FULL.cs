using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_AGL_COMPONENTS_FULL
    {
        public decimal recordKey { get; set; }
        public string originalPartNumber { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public string componentPartNumber { get; set; } = null!;
        public decimal? componentStandardUsage { get; set; }
        public string componentUOM { get; set; } = null!;
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
