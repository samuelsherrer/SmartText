using System.Threading.Tasks;

namespace SmartText
{
    public interface IContentReader
    {
        string[] ReadAllLines();

        Task<string[]> ReadAllLinesAsync();
    }
}
