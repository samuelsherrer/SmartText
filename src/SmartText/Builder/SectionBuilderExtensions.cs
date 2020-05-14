using System;
using System.Linq.Expressions;

namespace SmartText.Builder
{
    public static class SectionBuilderExtensions
    {
        public static ISectionBuilder<T> StartLine<T>(this ISectionBuilder<T> builder, int line)
             where T : class, new()
        {
            if (line < 0)
            {
                throw new ArgumentException("Value must be greater than 0", nameof(line));
            }

            builder.Section.StartLine = line;

            return builder;
        }

        public static ISectionBuilder<T> EndLine<T>(this ISectionBuilder<T> builder, int line)
             where T : class, new()
        {
            if (line < 0)
            {
                throw new ArgumentException("Value must be greater than 0", nameof(line));
            }

            builder.Section.EndLine = line;

            return builder;
        }

        public static ISectionBuilder<T> WithBlankSpace<T>(this ISectionBuilder<T> builder, int start, int end, int order)
            where T : class, new()
        {
            return WithProperty(builder, new Property(start, end, order));
        }

        public static ISectionBuilder<T> WithProperty<T>(this ISectionBuilder<T> builder, Property property)
            where T : class, new()
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            builder.Section.Properties.Add(property);

            return builder;
        }

        public static ISectionBuilder<T> WithProperty<T, TProperty>(this ISectionBuilder<T> builder,
            Expression<Func<T, TProperty>> source,
            int start,
            int end,
            int? order = null,
            Padding padding = Padding.Left,
            char paddingchar = ' ') where T : class, new()
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var _order = order ?? builder?.Section.Properties?.Count ?? 0;

            var expression = (MemberExpression)source.Body;
            var name = expression.Member.Name;

            var property = new Property(
                name: name,
                begin: start,
                end: end,
                order: _order,
                padding: padding,
                padChar: paddingchar);

            return WithProperty(builder, property);
        }
    }
}
