namespace FIESTA_Inbound_Console.Models
{
    public class CpiInboundResult
    {
        public string? TableName { get; set; }
        public string? Status { get; set; }
        public int RecordInserted { get; set; } = 0;
        public int RecordUpdated { get; set; } = 0;
        public int RecordError { get; set; } = 0;
        public bool isError { get; set; } = false;
    }
}
