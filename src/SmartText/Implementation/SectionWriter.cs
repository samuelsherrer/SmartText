using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartText
{
    internal class SectionWriter<T> : ISectionWriter<T>
    {
        private readonly Section _section;

        private IEnumerable<Property> Properties => _section.Properties;

        public SectionWriter(Section section)
        {
            _section = section ?? throw new System.ArgumentNullException(nameof(section));
        }

        internal string BuildLine(T item)
        {
            var line = string.Empty;

            foreach (var property in Properties.OrderBy(a => a.Order))
            {
                if (property.Name is null)
                {
                    line = line.Insert(property.Begin, string.Empty.PadRight(property.Space));
                }
                else
                {
                    var value = item.GetType().GetProperty(property.Name).GetValue(item, null);

                    line = line.Insert(property.Begin, property.Padding == Padding.Left
                                ? value.ToString().PadLeft(property.Space, property.PaddingChar)
                                : value.ToString().PadRight(property.Space, property.PaddingChar));
                }
            };

            return line;
        }

        public void WriteTo(string path, IEnumerable<T> items, bool append = false)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path is empty", nameof(path));
            }

            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var fileMode = append ? FileMode.Append : FileMode.Create;

            using (var stream = new FileStream(path, fileMode))
            {
                WriteTo(stream, items);
            }
        }

        public async Task WriteToAsync(string path, IEnumerable<T> items, bool append = false)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path is empty", nameof(path));
            }

            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var fileMode = append ? FileMode.Append : FileMode.Create;

            using (var stream = new FileStream(path, fileMode))
            {
                await WriteToAsync(stream, items);
            }
        }

        public void WriteTo(Stream stream, IEnumerable<T> items)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            using (var writer = new StreamWriter(stream))
            {
                foreach (var item in items)
                {
                    writer.WriteLine(BuildLine(item));
                }
            }
        }

        public async Task WriteToAsync(Stream stream, IEnumerable<T> items)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            using (var writer = new StreamWriter(stream))
            {
                foreach (var item in items)
                {
                    await writer.WriteLineAsync(BuildLine(item));
                }
            }
        }

        public string WriteToString(IEnumerable<T> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var builder = new StringBuilder();

            foreach (var item in items)
            {
                builder.Append(BuildLine(item));
            }

            return builder.ToString();
        }
    }
}
