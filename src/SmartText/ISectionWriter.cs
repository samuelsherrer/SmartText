using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartText
{
    public interface ISectionWriter<T>
    {
        void WriteTo(string path, IEnumerable<T> items, bool append = false);

        Task WriteToAsync(string path, IEnumerable<T> items, bool append = false);

        void WriteTo(Stream stream, IEnumerable<T> items);

        Task WriteToAsync(Stream stream, IEnumerable<T> items);

        string WriteToString(IEnumerable<T> items);
    }
}
