using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Models
{
    public class EmailDto
    {
        public List<string> To { get; set; } = new List<string>();
        public List<string> Cc { get; set; } = new List<string>();
        public List<string> Bcc { get; set; } = new List<string>();
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
