using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SmartText.Implementation
{
    internal class ContentEnumerable : IEnumerable<string>
    {
        private readonly IEnumerable<string> _content;
        private readonly int? _start;
        private readonly int? _end;

        public ContentEnumerable(IEnumerable<string> content, int? start, int? end)
        {
            _content = content;
            _start = start;
            _end = end;
        }

        private IEnumerable<string> Filter()
        {
            var lines = _content;

            var skip = _start - 1;

            if (_start.HasValue)
            {
                lines = lines.Skip(skip.GetValueOrDefault(0));
            }

            if (_end.HasValue)
            {
                var take = _end.Value - skip;
                lines = lines.Take(take.GetValueOrDefault(0));
            }

            return lines;
        }

        public IEnumerator<string> GetEnumerator() => Filter().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Filter().GetEnumerator();
    }
}
