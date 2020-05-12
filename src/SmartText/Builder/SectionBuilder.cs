using System;
using System.Collections.Generic;

namespace SmartText.Builder
{
    public class SectionBuilder<TSection> : ISectionBuilder<TSection>
        where TSection : class, new()
    {
    //    public List<Property> Properties { get; }

       public Section Section => throw new NotImplementedException();

    //    public SectionBuilder(List<Property> properties = null)
    //    {
    //        Properties = properties ?? new List<Property>();
    //    }
       
    //    public Section Build()
    //    {
    //        return new Section(
    //            dataType: typeof(TSection),
    //            properties: Properties);
    //    }

    }
}
