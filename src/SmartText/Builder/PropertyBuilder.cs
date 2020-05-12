using System;
using System.Collections.Generic;

namespace SmartText.Builder
{
    public class PropertyBuilder : IPropertyBuilder
    {
        public PropertyBuilder(List<Property> properties)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public List<Property> Properties { get; }
    }
}
