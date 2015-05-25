using HackBulgaria_3_Query_Language_Over_CSV.Common;

namespace HackBulgaria_3_Query_Language_Over_CSV.Interfaces
{
    public interface  ISourceProveder
    {
        string FilePath { get; set; }
        SourceData GetSourceData();
    }
}
