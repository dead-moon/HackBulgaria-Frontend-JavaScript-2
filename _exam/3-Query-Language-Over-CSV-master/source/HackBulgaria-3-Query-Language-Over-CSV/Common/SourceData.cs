namespace HackBulgaria_3_Query_Language_Over_CSV.Common
{
    public class SourceData
    {
        public int ColumnNumber { get; set; }
        public string[] Headers { get; set; }
        public string[][] RowsData { get; set; }
    }
}
