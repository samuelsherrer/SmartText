using System.IO;

namespace SmartText
{
    internal class FileContentReader : IContentReader
    {
        public string[] ReadAllLines(string filePath) => File.ReadAllLines(filePath);
    }
}
