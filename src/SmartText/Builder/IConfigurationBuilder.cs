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
    }
}
