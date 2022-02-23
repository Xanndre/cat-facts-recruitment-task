using System.Threading.Tasks;

namespace CatFacts.Core.Interfaces
{
    public interface IFileService
    {
        Task SaveToFile(string outputFileName, string content);
    }
}
