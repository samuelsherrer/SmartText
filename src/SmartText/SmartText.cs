using SmartText.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartText
{
    public class SmartText
    {
        public Configuration Configuration { get; }

        private string[] _data = null;

        public IReadOnlyCollection<string> Content => Array.AsReadOnly(_data);

        private readonly IContentReader _contentReader;

        public SmartText(Configuration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _ = Configuration.ContentReader ?? throw new ArgumentNullException(nameof(Configuration.ContentReader));

            _contentReader = Configuration.ContentReader;

            if (Configuration.AutoLoadFile)
            {
                LoadContent();
            }
        }

        public void LoadContent()
        {
            _data = _contentReader.ReadAllLines();
        }

        public async Task LoadContentAsync()
        {
            _data = await _contentReader.ReadAllLinesAsync();
        }

        public ISectionReader<TSection> Reader<TSection>() where TSection : class, new()
        {
            if (_data is null)
            {
                LoadContent();
            }

            var section = Configuration.Sections.FirstOrDefault(p => p.DataType == typeof(TSection));

            if (section is null)
            {
                throw new Exception("Section not found");
            }

            return new SectionReader<TSection>(section, _data.ToList());
        }

        public ISectionWriter<TSection> Writer<TSection>()
        {
            var section = Configuration.Sections.FirstOrDefault(p => p.DataType == typeof(TSection));

            if (section is null)
            {
                throw new Exception("Section not found");
            }

            return new SectionWriter<TSection>(section);
        }
    }
}
