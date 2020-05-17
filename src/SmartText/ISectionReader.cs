using System.Collections.Generic;

namespace SmartText
{
    public interface ISectionReader<T> where T : class, new()
    {
        bool TryReadContent(string textLine, out T result);

        T ReadContent(string textLine);

        IEnumerable<T> ReadSection();
    }
}
