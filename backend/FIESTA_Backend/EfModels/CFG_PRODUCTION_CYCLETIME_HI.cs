using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_CYCLETIME_HI
    {
        public decimal CFG_PRODUCTION_CYCLETIME_HIS_ID { get; set; }

        public DateTimeOffset? CFG_PRODUCTION_CYCLETIME_HIS_DATE { get; set; }

        public string? CFG_PRODUCTION_CYCLETIME_HIS_USERID { get; set; }

        public string? CFG_PRODUCTION_CYCLETIME_HIS_DELEGATE { get; set; }

        public decimal? recordKey { get; set; }

        public string partNumber { get; set; } = null!;

        public string plant { get; set; } = null!;

        public string storageLocation { get; set; } = null!;

        public string groupStage { get; set; } = null!;

        public string glmStage { get; set; } = null!;

        public string unitOfTime { get; set; } = null!;

        public long? quantityUnitOfTime { get; set; }

        public string classification { get; set; } = null!;

        public decimal? time { get; set; }

        public DateTime validFromDate { get; set; }

        public string deleteFlag { get; set; } = null!;
    }
}
