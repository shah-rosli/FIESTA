using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class V_PRODUCT_PIR_AS_FULL_LOAD
    {
        public string OSAT { get; set; } = null!;
        public string MPN { get; set; } = null!;
        public string? WIRE_TYPE { get; set; }
        public string? CONSIGNED_LF { get; set; }
        public string? DISCRETE { get; set; }
        public string? SUBSTRATE_NUMLAYER1 { get; set; }
        public string? HEATSINK { get; set; }
        public string? BACKGRIND { get; set; }
        public string? CNSIGNED_TRAY { get; set; }
        public string? NUM_OF_WIRE { get; set; }
        public string? SPECIAL_PRO_ADDER { get; set; }
        public string? WIRE_DIAMETER { get; set; }
    }
}
