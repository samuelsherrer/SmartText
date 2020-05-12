using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartText.Builder
{
    public static class SectionBuilderExtensions
    {

        public static ISectionBuilder<T> WithBlankSpace<T>(this ISectionBuilder<T> builder, int start, int end, int order) where T : class, new()
        {
            return WithProperty(builder, new Property(start, end, order));
        }

        public static ISectionBuilder<T> WithProperty<T>(this ISectionBuilder<T> builder, Property property) where T : class, new()
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

        public static ISectionBuilder<TSection> WithProperty<TSection, TProperty>(this ISectionBuilder<TSection> builder, Expression<Func<TSection, TProperty>> source, int start, int end)
            where TSection : class, new()
        {
            return WithProperty(builder, source, start, end, order: null);
        }

        public static ISectionBuilder<TSection> WithProperty<TSection, TProperty>(this ISectionBuilder<TSection> builder, Expression<Func<TSection, TProperty>> source, int start, int end, int? order, Padding padding = Padding.Left, char paddingchar = ' ')
            where TSection : class, new()
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var _order = order ?? builder?.Properties?.Count ?? 0;

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
