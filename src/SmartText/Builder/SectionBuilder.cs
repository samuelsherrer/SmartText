using System;

namespace SmartText.Builder
{
    public class SectionBuilder<T> : ISectionBuilder<T>
        where T : class, new()
    {
        public SectionBuilder(Section section)
        {
            Section = section ?? throw new ArgumentNullException(nameof(section));
        }

        public Section Section { get; }

        public Section Build() => Section;
    }
}
