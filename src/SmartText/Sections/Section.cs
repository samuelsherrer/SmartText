using System;
using System.Collections.Generic;

namespace SmartText
{
    public class Section
    {
        public Section(Type dataType)
        {
            DataType = dataType;
        }

        public Section(Type dataType, IList<Property> properties)
            : this(dataType)
        {
            Properties = properties;
        }

        public virtual Type DataType { get; }

        public virtual IList<Property> Properties { get; set; }
    }
}
