using System;
using System.Collections.Generic;

namespace FIESTA_Backend.EfModels
{
    public partial class RAW_PROCESS_CONVERT_MASTER
    {
        public string? DetailWaferProcess { get; set; }
        public string? Technology { get; set; }
        public string? RoughWaferProcess { get; set; }
        public DateTimeOffset? createDateAndTime { get; set; }
        public DateTimeOffset? updateDateAndTime { get; set; }
        public bool? ActiveFlag { get; set; }
    }
}
