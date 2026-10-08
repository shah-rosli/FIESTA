using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class PLM_PRO_VERSION
    {
        public decimal recordKey { get; set; }
        public string partNumber { get; set; } = null!;
        public string plant { get; set; } = null!;
        public string storageLocation { get; set; } = null!;
        public string productionVersion { get; set; } = null!;
        public string? bomUsage { get; set; }
        public string? bomAlternative { get; set; }
        public string? routingKey { get; set; }
        public string? glmWF { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }
        public DateTimeOffset? fiestaCreateDateAndTime { get; set; }
        public DateTimeOffset? fiestaUpdateDateAndTime { get; set; }
    }
}
