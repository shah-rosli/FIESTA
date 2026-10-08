using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Models
{
    public class LogObject
    {
        public decimal? ID { get; set; }
        public string? PAYLOAD { get; set; }
        public string? MESSAGE { get; set; }
        public string? OBJECT { get; set; }
        public decimal? REC_COUNT { get; set; }
        public decimal? STATUS { get; set; }
        public string? EXEC_BY { get; set; }
        public string? OPERATION { get; set; }
    }
}
