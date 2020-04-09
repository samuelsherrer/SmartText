using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public interface ISmartTextReader
    {
        T ReadContent<T>(string textLine, ref T result);
        T ReadContent<T>(string textLine) where T : class, new();
        //T ReadLine<T>(List<Property> properties, string textLine, ref T result);
    }
}
