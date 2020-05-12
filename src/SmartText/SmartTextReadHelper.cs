using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartText
{
    internal class SmartTextReadHelper<TSection> : ISectionReader<TSection>
        where TSection : class, new()
    {
        private readonly IEnumerable<Property> properties;

        public SmartTextReadHelper(IEnumerable<Property> properties)
        {
            this.properties = properties;
        }

        public IEnumerable<T> ReadSection<T>()
        {
            throw new NotImplementedException();
        }

        public T Read<T>(string content)
        {
            throw new NotImplementedException();
        }

        public T ReadContent<T>(string textLine, ref T result)
        {
            foreach (var property in properties)
            {
                var value = textLine.Substring(property.Begin, property.Space);

                if (property.Name is null)
                    continue;

                PropertyInfo fieldPropertyInfo = result.GetType().GetProperties()
                    .FirstOrDefault(f => f.Name.ToLower() == property.Name.ToLower());

                fieldPropertyInfo?.SetValue(result, Convert.ChangeType(value, fieldPropertyInfo.PropertyType), null);
            }

            return result;
        }

        public T ReadContent<T>(string textLine) where T : class, new()
        {
            var result = new T();
            ReadContent(textLine, ref result);
            return result;
        }



        public bool TryReadContent(string textLine, out TSection result)
        {
            throw new NotImplementedException();
        }

        public TSection ReadContent(string textLine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TSection> ReadSection()
        {
            throw new NotImplementedException();
        }
    }
}