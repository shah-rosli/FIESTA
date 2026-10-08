using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models.PROSTER
{
    public class CSV_PRO_ROUTING
    {
        public string? partNumber { get; set; }
        public string? plant { get; set; }
        public string? storageLocation { get; set; }
        public string? routingKey { get; set; }
        public string? operationNumber { get; set; }
        public string? groupStage { get; set; }
        public decimal? conversionFactor { get; set; }
        public string? unitOfMeasure { get; set; }
        public string? glmWF { get; set; }
        public string? glmSequence { get; set; }
        public string? glmAlternative { get; set; }
        public string? connectFromGLMSeq { get; set; }
        public string? connectFromGLMAlternative { get; set; }
        public string? glmStage { get; set; }
        public string? endOfGroupStage { get; set; }
        public string? mpnToOPNFlag { get; set; }
        public string? costCenter { get; set; }
        public string? originalPartNumber { get; set; }
        public string? hmeType { get; set; }
        public DateTime? createDateAndTime { get; set; }
        public DateTime? updateDateAndTime { get; set; }
        public string? updateType { get; set; }
        public string? deleteFlag { get; set; }

    }
}
