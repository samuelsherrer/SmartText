using System.Threading.Tasks;

namespace SmartText
{
    public interface IContentReader
    {
        string[] ReadAllLines(string filePath);

        Task<string[]> ReadAllLinesAsync(string filePath);
    }
}
