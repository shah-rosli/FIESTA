using System.Text.Json.Serialization;

namespace FIESTA_Inbound_Console.Models
{
    public class CpiInboundObj
    {
        public List<CpiRow>? rows { get; set; } = new List<CpiRow>();

        public CpiPagination? pagination { get; set; }
    }
}
