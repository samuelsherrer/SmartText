using SmartText.Implementation;
using System;
using System.Collections.Generic;

namespace SmartText.Builder
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {

        private ConfigurationBuilder(string filePath,
                                    bool autoLoadFile,
                                    List<Section> sections)
        {
            FilePath = filePath;
            AutoLoadFile = autoLoadFile;
            Sections = sections;
        }

        public List<Section> Sections { get; }

        public string FilePath { get; set; }

        public bool AutoLoadFile { get; set; }

        public Func<IContentReader> ContentReaderFactory { get; set; }

        private readonly Func<string, IContentReader> DefaultReaderFactory = (filePath) =>
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            return new FileContentReader(filePath);
        };

        public static IConfigurationBuilder Create()
        {
            return new ConfigurationBuilder(
                filePath: string.Empty,
                autoLoadFile: false,
                new List<Section>());
        }

        public Configuration Build()
        {
            var reader = ContentReaderFactory is null
                ? DefaultReaderFactory(FilePath)
                : ContentReaderFactory();

            return new Configuration
            {
                AutoLoadFile = AutoLoadFile,
                ContentReader = reader,
                FilePath = FilePath,
                Sections = Sections
            };
        }
    }
}
