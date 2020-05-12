using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartText.Builder
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        private string _filePath;
        private bool _autoLoad;
        private readonly List<Section> _sections;

        public ConfigurationBuilder()
        {
            _filePath = string.Empty;
            _autoLoad = false;
            _sections = new List<Section>();
        }

        //public SectionBuilder<T> AddSection<T>() where T : class, new()
        //{
        //    var builder = new SectionBuilder<T>(new List<Property>());
        //    _builders.Add(builder);
        //    return builder;

        //} 


        public IPropertyBuilder AddSection<T>() where T : class, new()
        {
            var properties = new List<Property>();
            _sections.Add(new Section(typeof(T), properties));

            return new PropertyBuilder(properties);
        }

        public ConfigurationBuilder UseFilePath(string filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            _filePath = filePath;

            return this;
        }

        public ConfigurationBuilder SetAutoLoadFile(bool autoLoad = false)
        {
            _autoLoad = autoLoad;

            return this;
        }


        public Configuration Build()
        {
            return new Configuration
            {
                Sections = _sections,
                AutoLoadFile = _autoLoad,
                FilePath = _filePath
            };
        }
    }
}
