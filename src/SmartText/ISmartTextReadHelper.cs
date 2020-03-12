using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public interface ISmartTextReadHelper
    {
        T ReadLine<T>(List<Property> properties, string textLine, ref T result);
    }
}
