using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartText
{
    public class SmartTextReadHelper : ISmartTextReadHelper
    {
        public T ReadLine<T>(List<Property> properties, string textLine, ref T result)
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
    }
}