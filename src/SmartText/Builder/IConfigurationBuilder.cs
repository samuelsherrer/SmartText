using System;
using System.Collections.Generic;

namespace SmartText.Builder
{
    public interface IConfigurationBuilder : IBuildable<Configuration>
    {
        List<Section> Sections { get; }

        string FilePath { get; set; }

        bool AutoLoadFile { get; set; }

        IContentReader ContentReader { get; set; }

        void SetSectionReader<T>(Func<SectionReaderContext, ISectionReader<T>> factory) where T : class, new();

        void SetSectionWriter<T>(Func<SectionWriterContext, ISectionWriter<T>> factory);
    }
}
