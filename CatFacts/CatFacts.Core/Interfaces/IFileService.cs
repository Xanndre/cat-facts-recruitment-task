namespace CatFacts.Core.Interfaces
{
    public interface IFileService
    {
        void SaveToFile(string outputFileName, string content);
    }
}
