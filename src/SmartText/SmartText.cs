using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public class SmartText
    {
        private readonly SmartTextConfiguration Configuration;


        public SmartText()
        {
            Reader = new SmartTextReadHelper();
            Writer = new SmartTextStringWriter();
        }

        public SmartText(ISmartTextReader reader, ISmartTextWriter writer)
        {
            Reader = reader ?? throw new ArgumentNullException(nameof(reader));
            Writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public ISmartTextReader Reader { get; }

        public ISmartTextWriter Writer { get; }
    }
}
