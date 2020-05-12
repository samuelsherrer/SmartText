using System.Collections.Generic;

namespace SmartText.Builder
{
    public interface ISectionBuilder
    {
        Section Section { get; }
    }

    public interface ISectionBuilder<TSection> : ISectionBuilder
        where TSection : class, new()
    {
        List<Property> Properties { get; }

    }
}
