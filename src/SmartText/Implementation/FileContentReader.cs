using System.IO;
using System.Threading.Tasks;

namespace SmartText.Implementation
{
    internal class FileContentReader : IContentReader
    {
        private readonly string _filePath;

        public FileContentReader(string filePath)
        {
            _filePath = filePath ?? throw new System.ArgumentNullException(nameof(filePath));
        }

        public string[] ReadAllLines() => File.ReadAllLines(_filePath);

        public Task<string[]> ReadAllLinesAsync() => Task.FromResult(File.ReadAllLines(_filePath));
    }
}
