using System.IO;
using System.Threading.Tasks;

namespace SmartText
{
    internal class FileContentReader : IContentReader
    {
        public string[] ReadAllLines(string filePath) => File.ReadAllLines(filePath);

        public Task<string[]> ReadAllLinesAsync(string filePath)
        {
            return Task.FromResult(File.ReadAllLines(filePath));
        }
    }
}
