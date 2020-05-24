using SmartText.Implementation;
using System;

namespace SmartText.Builder
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder FilePath(this IConfigurationBuilder builder, string filePath)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            builder.FilePath = filePath;

            return UseFileReader(builder, () => new FileContentReader(filePath));
        }

        public static IConfigurationBuilder AutoLoadFile(this IConfigurationBuilder builder, bool autoLoad = false)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AutoLoadFile = autoLoad;

            return builder;
        }

        public static IConfigurationBuilder UseFileReader(this IConfigurationBuilder builder, IContentReader reader)
        {
            if (reader is null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            return UseFileReader(builder, () => reader);
        }

        public static IConfigurationBuilder UseFileReader<T>(this IConfigurationBuilder builder, T reader)
             where T : IContentReader
        {
            return UseFileReader(builder, () => reader);
        }

        public static IConfigurationBuilder UseFileReader(this IConfigurationBuilder builder, Func<IContentReader> readerFactory)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (readerFactory is null)
            {
                throw new ArgumentNullException(nameof(readerFactory));
            }

            builder.ContentReaderFactory = readerFactory;

            return builder;
        }

        public static IConfigurationBuilder AddSection<T>(this IConfigurationBuilder builder, Action<ISectionBuilder<T>> sectionConfiguration)
            where T : class, new()
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (sectionConfiguration is null)
            {
                throw new ArgumentNullException(nameof(sectionConfiguration));
            }

            var section = new Section(typeof(T));
            builder.Sections.Add(section);
            sectionConfiguration(new SectionBuilder<T>(section));

            return builder;
        }
    }
}
