namespace FIESTA_Backend.Models.Test
{
    public class MdmResult
    {
        public string sourceSystem { get; set; }
        public int totalPage { get; set; } = 1;
        public List<MdmContent> recordContent { get; set; } = new List<MdmContent>();
    }

    public class MdmContent
    {
        public string tablePath { get; set; }
        public object content { get; set; }
    }
}
