using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_CFG_SHIPPOINT
    {
        public string? createdBy { get; set; }

        public string? opn { get; set; }

        public string? lineName { get; set; }

        public string? defaultShipPoint { get; set; }

        public string? supplyLineName { get; set; }

        public string? plannable { get; set; }

        public string? activeFlag { get; set; }

        public string? insertOrUpdate { get; set; }

        public bool? haveError { get; set; }

        public string? errorMessage { get; set; }

        public bool? haveDifference { get; set; }

        public DateTimeOffset? createdDate { get; set; }

        public decimal recordKey { get; set; }

        
    }
}
