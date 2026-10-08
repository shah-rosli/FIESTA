using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_SHIPPOINT
    {
        public decimal recordKey { get; set; }

        public string opn { get; set; } = null!;

        public string? legacyOrganization { get; set; }

        public string? plmStatus { get; set; }

        public string lineName { get; set; } = null!;

        public string defaultShipPoint { get; set; } = null!;

        public string supplyLineName { get; set; } = null!;

        public string? plannable { get; set; }

        public string? fiestaRules { get; set; }

        public string deleteFlag { get; set; } = null!;

        public string activeFlag { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? lastUpdateBy { get; set; }
    }
}
