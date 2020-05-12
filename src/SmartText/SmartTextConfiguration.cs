using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public class Configuration
    {
        public IEnumerable<Section> Sections { get; set; }

        public string FilePath { get; set; }

        public bool AutoLoadFile { get; set; }
    }
}
