using CatFacts.Core.Interfaces;
using System.IO;

namespace CatFacts.Core.Services
{
    public class FileService : IFileService
    {
        public void SaveToFile(string outputFileName, string content)
        {
            using (var stream = File.AppendText(outputFileName))
            {
                stream.WriteLine(content);
            }
        }
    }
}
