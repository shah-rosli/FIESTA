using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Models
{
    public class CfgBulkImport
    {
        public int id { get; set; }
        public string? insertOrUpdate { get; set; }
        public object? bulkImportObj { get; set; }
        public bool haveError { get; set; }
        public string? errorMessage { get; set; }
        public bool haveDifference { get; set; }
        public bool selected { get; set; }
    }
}
