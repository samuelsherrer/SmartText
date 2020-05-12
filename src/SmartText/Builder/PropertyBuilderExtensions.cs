using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartText.Builder
{
    public static class PropertyBuilderExtensions
    {
        public static IPropertyBuilder WithBlankSpace(this IPropertyBuilder builder, int start, int end, int order)
        {
            return WithProperty(builder, new Property(start, end, order));
        }

        public static IPropertyBuilder WithProperty(this IPropertyBuilder builder, Property property)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            builder.Properties.Add(property);

            return builder;
        }
    }
}
