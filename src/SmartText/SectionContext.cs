using System.Collections.Generic;

namespace SmartText
{
    public class SectionReaderContext
    {
        internal SectionReaderContext(Section section, IEnumerable<string> content)
        {
            Section = section;
            Content = content;
        }

        public Section Section { get; }

        public IEnumerable<string> Content { get; }
    }

    public class SectionWriterContext
    {
        internal SectionWriterContext(Section section)
        {
            Section = section;
        }

        public Section Section { get; }
    }
}
