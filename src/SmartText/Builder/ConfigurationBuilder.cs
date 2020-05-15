using System;
using System.Collections.Generic;

namespace SmartText.Builder
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        
        private ConfigurationBuilder(string filePath,
                                    bool autoLoadFile,
                                    IContentReader contentReader,
                                    List<Section> sections)
        {
            FilePath = filePath;
            AutoLoadFile = autoLoadFile;
            ContentReader = contentReader;
            Sections = sections;
        }

        public List<Section> Sections { get; }

        public string FilePath { get; set; }

        public bool AutoLoadFile { get; set; }

        public IContentReader ContentReader { get; set; }


        public static IConfigurationBuilder Create()
        {
            return new ConfigurationBuilder(
                filePath: string.Empty,
                autoLoadFile: false,
                contentReader: new FileContentReader(),
                new List<Section>());
        }

        public Configuration Build()
        {
            return new Configuration
            {
                AutoLoadFile = AutoLoadFile,
                ContentReader = ContentReader,
                FilePath = FilePath,
                Sections = Sections
            };
        }

        public void SetSectionReader<T>(Func<SectionReaderContext, ISectionReader<T>> factory) where T : class, new()
        {
            
        }

        public void SetSectionWriter<T>(Func<SectionWriterContext, ISectionWriter<T>> factory)
        {
            
        }
    }
}
