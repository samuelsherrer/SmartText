using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartText
{
    internal class SmartTextReadHelper : ISmartTextReader
    {
        private readonly IEnumerable<Property> properties;

        public SmartTextReadHelper(IEnumerable<Property> properties)
        {
            this.properties = properties;
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
    }
}