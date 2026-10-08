using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_PRODUCTION_CYCLETIME
    {
        public decimal recordKey { get; set; }

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

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public DateTimeOffset? deleteDateAndTime { get; set; }

        public string? createdBy { get; set; }

        public string? modifiedBy { get; set; }

        public string deleteFlag { get; set; } = null!;
    }
}
