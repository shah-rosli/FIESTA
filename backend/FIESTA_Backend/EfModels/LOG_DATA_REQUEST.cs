using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class LOG_DATA_REQUEST
    {
        public decimal ID { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public string? PAYLOAD { get; set; }
        public string? MESSAGE { get; set; }
        public string? OBJECT { get; set; }
        public string? EXEC_BY { get; set; }
    }
}
