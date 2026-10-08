using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_CFG_PRODUCTION_LEADTIME_BY_G
    {
        public decimal? recordKey { get; set; }

        public string partNumber { get; set; } = null!;

        public string plant { get; set; } = null!;

        public string storageLocation { get; set; } = null!;

        public string? legacyLine { get; set; }

        public string? legacyOrganization { get; set; }

        public string? plmStatus { get; set; }

        public string? processTechnology { get; set; }

        public string? waferTechnology { get; set; }

        public string? roughWaferProcess { get; set; }

        public string? productHierarchyCode { get; set; }

        public string? packageCode { get; set; }

        public string? packageGroup { get; set; }

        public string? packageType { get; set; }

        public string? packageBodySize { get; set; }

        public long? packagePinCount { get; set; }

        public string? groupStage { get; set; }

        public string? glmStage { get; set; }

        public string? pattern { get; set; }

        public decimal? defaultLeadTime { get; set; }

        public decimal? leadTime { get; set; }

        public DateTime validFromDate { get; set; }

        public string deleteFlag { get; set; } = null!;

        public DateTimeOffset? createDateAndTime { get; set; }

        public DateTimeOffset? updateDateAndTime { get; set; }

        public string? lastUpdateBy { get; set; }
    }
}
