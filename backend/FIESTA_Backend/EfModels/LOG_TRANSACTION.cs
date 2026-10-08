using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class LOG_TRANSACTION
    {
        public decimal ID { get; set; }
        public DateTimeOffset? START_TIME { get; set; }
        public DateTimeOffset? END_TIME { get; set; }
        public string? PAYLOAD { get; set; }
        public string? MESSAGE { get; set; }
        public string? OBJECT { get; set; }
        public decimal? REC_COUNT { get; set; }
        public string? STATUS { get; set; }
        public string? EXEC_BY { get; set; }
    }
}
