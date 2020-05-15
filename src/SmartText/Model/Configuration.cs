using System;
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
            ContentReader = new FileContentReader();
        }

        public IEnumerable<Section> Sections { get; set; }

        public string FilePath { get; set; }

        public bool AutoLoadFile { get; set; }

        public IContentReader ContentReader { get; set; }
    }
}
