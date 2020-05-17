using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartText.Implementation
{
    internal class SectionReader<TSection> : ISectionReader<TSection>
        where TSection : class, new()
    {
        private readonly Section _section;
        private readonly IReadOnlyList<string> _content;

        private IEnumerable<Property> Properties => _section.Properties;

        public SectionReader(Section section, IReadOnlyList<string> content)
        {
            _section = section ?? throw new ArgumentNullException(nameof(section));
            _content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public IEnumerable<TSection> ReadSection()
        {
            var result = new List<TSection>();

            var lines = new ContentEnumerable(_content, _section.StartLine, _section.EndLine);

            foreach (var line in lines)
            {
                if (TryReadContent(line, out var section))
                {
                    result.Add(section);
                }
            }

            return result;
        }

        public bool TryReadContent(string textLine, out TSection result)
        {
            try
            {
                if (textLine is null)
                {
                    result = null;
                    return false;
                }

                result = ReadContent(textLine);

                return true;
            }
            catch (Exception ex) // TODO: Remover the exception variable
            {
                result = default;
                return false;
            }
        }

        public TSection ReadContent(string textLine)
        {
            if (textLine is null)
            {
                throw new ArgumentNullException(nameof(textLine));
            }

            var result = new TSection();

            foreach (var property in Properties.OrderBy(p => p.Order))
            {
                var value = textLine.Substring(property.Begin, property.Space);

                if (property.Name is null)
                    continue;

                var fieldPropertyInfo = result.GetType()
                    .GetProperties()
                    .FirstOrDefault(f => f.Name.ToLower() == property.Name.ToLower());

                fieldPropertyInfo?.SetValue(result, Convert.ChangeType(value, fieldPropertyInfo.PropertyType), null);
            }

            return result;
        }
    }
}