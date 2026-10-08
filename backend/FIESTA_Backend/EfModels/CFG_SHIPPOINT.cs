using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class CFG_SHIPPOINT
    {
        public decimal recordKey { get; set; }

        public string opn { get; set; } = null!;

        public string lineName { get; set; } = null!;

        public string defaultShipPoint { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? deleteDateAndTime { get; set; }

        public string? createdBy { get; set; }

        public string? modifiedBy { get; set; }

        public string? plannable { get; set; }

        public string supplyLineName { get; set; } = null!;

        public string? fiestaRules { get; set; }

        public string activeFlag { get; set; } = null!;
    }
}
