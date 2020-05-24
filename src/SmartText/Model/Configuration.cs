using SmartText.Implementation;
using System.Collections.Generic;

namespace SmartText
{
    public class Configuration
    {
        public Configuration()
        {
            Sections = new List<Section>();
            FilePath = string.Empty;
            AutoLoadFile = false;
        }

        public IEnumerable<Section> Sections { get; set; }

        public string FilePath { get; set; }

        public bool AutoLoadFile { get; set; }

        public IContentReader ContentReader { get; set; }
    }
}
