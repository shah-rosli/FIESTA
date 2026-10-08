using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIESTA_Inbound_Console.Models
{
    public class FiestaValidationResult
    {
        public string? TableName { get; set; }
        public string? Status { get; set; }

        public DataTable? Records { get; set; }
    }
}
