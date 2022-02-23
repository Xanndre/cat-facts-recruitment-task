using CatFacts.Core.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace CatFacts.Core.Services
{
    public class FileService : IFileService
    {
        public async Task SaveToFile(string outputFileName, string content)
        {
            using (var stream = File.AppendText(outputFileName))
            {
                await stream.WriteLineAsync(content);
            }
        }
    }
}