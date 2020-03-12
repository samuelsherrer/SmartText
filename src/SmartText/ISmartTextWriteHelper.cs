using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public interface ISmartTextWriteHelper
    {
        void CreateLine(List<Property> properties, object item);
    }
}
