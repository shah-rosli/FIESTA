using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_AGL_PRODUCTION_FULL
    {
        public decimal recordKey { get; set; }
        public string opn { get; set; } = null!;
        public long plmBomSortingLevel { get; set; }
        public string originalPartNumber { get; set; } = null!;
        public string groupStage { get; set; } = null!;
        public string structure { get; set; } = null!;
        public long grouping { get; set; }
        public string routing { get; set; } = null!;
        public long findNum { get; set; }
        public long qty { get; set; }
        public string groupStageFlowNumber { get; set; } = null!;
        public string groupStageFlow { get; set; } = null!;
        public string groupStageFlowPlmStatus { get; set; } = null!;
        public string groupStageStep { get; set; } = null!;
        public string groupStageStepPlmStatus { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
    }
}
