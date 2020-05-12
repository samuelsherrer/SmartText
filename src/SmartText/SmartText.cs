using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartText
{
    public class SmartText
    {
        public Configuration Configuration { get; }

        private string[] _data = null; //readonly?

        private readonly IContentReader _contentReader = new FileContentReader();

        public SmartText(Configuration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            if (Configuration.AutoLoadFile)
            {
                _data = _contentReader.ReadAllLines(Configuration.FilePath);
            }
        }

        public void LoadContent()
        {
            _data = _contentReader.ReadAllLines(Configuration.FilePath);
        }

        public ISectionReader<TSection> Reader<TSection>() where TSection : class, new()
        {
            if (_data is null)
            {
                LoadContent();
            }

            /*
             * obter a secao solicitada
             * instanciar um reader daquela secao, passando a lista de propriedades no construtor
             */
            var section = Configuration.Sections.FirstOrDefault(p => p.DataType == typeof(TSection));

            if (section is null)
            {
                throw new Exception("Section not found");
            }

            return new SmartTextReadHelper<TSection>(section.Properties);
        }
    }
}
