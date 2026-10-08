using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class FIESTA_SHIPPOINT
    {
        public string opn { get; set; } = null!;
        public string companyCode { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string legacyLine { get; set; } = null!;
        public string defaultShipPoint { get; set; } = null!;
    }
}
