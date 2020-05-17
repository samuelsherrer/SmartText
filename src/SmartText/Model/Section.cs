using System;
using System.Collections.Generic;

namespace SmartText
{
    public class Section
    {
        public Section(Type dataType)
        {
            DataType = dataType;
            Properties = new List<Property>();
        }

        public Section(Type dataType, IList<Property> properties)
            : this(dataType)
        {
            Properties = properties;
        }

        public virtual Type DataType { get; internal set; }

        public virtual IList<Property> Properties { get; internal set; }

        public int? StartLine { get; set; }

        public int? EndLine { get; set; }
    }
}
