using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PRODUCT_PIR_WT
    {
        public string OSAT { get; set; } = null!;
        public string MPN { get; set; } = null!;
        public string? TESTER { get; set; }
        public string? ZHANDLER { get; set; }
        public string? TEMPERATURE { get; set; }
        public string? INDEX_TIME { get; set; }
        public string? TEST_TIME { get; set; }
        public string? NUM_WT_SITE { get; set; }
        public string INSERTION { get; set; } = null!;
        public string? WAFER_DIAMETER { get; set; }
    }
}
