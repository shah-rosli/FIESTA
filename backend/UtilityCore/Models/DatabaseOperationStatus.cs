using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Models
{
    public class DatabaseOperationStatus
    {
        public bool isSuccessful { get; set; }
        public int recordCount { get; set; }
        public string message { get; set; }
    }
}
