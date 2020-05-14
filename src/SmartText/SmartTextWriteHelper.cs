using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartText
{
    internal class SmartTextStringWriter : ISmartTextWriter
    {
        private readonly StringBuilder _builder;
        private readonly IEnumerable<Property> properties;

        public SmartTextStringWriter()
        {
            _builder = new StringBuilder();
        }

        public SmartTextStringWriter(StringBuilder builder, IEnumerable<Property> properties)
        {
            _builder = builder;
            this.properties = properties;
        }

        /// <summary>
        /// Lines always starts on index 1.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public void CreateLine(object item)
        {
            CreateLine<object>(item);
        }

        public void CreateLine<T>(T item)
        {
            string line = string.Empty;

            foreach (var property in properties.OrderBy(a => a.Order))
            {
                if (property.Name is null)
                {
                    line = line.Insert(property.Begin, "".PadRight(property.Space));
                }
                else
                {
                    var value = item.GetType().GetProperty(property.Name).GetValue(item, null);

                    line = line.Insert(property.Begin, property.Padding == Padding.Left
                                ? value.ToString().PadLeft(property.Space, property.PaddingChar)
                                : value.ToString().PadRight(property.Space, property.PaddingChar));
                }
            };

            _builder.Append(line);
        }

        public void CreateLine()
        {
            _builder.AppendLine();
        }

        public string Content => _builder.ToString();
    }
}
