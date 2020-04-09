using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public class ConfigurationBuilder
    {
        private readonly List<Property> _properties = new List<Property>();

        private ISmartTextReader _customReader;
        private ISmartTextWriter _customWriter;

        public ConfigurationBuilder()
        {

        }

        public ConfigurationBuilder AddProperty(Property property) 
        {
            _properties.Add(property);
            return this;
        }

        public ConfigurationBuilder AddProperty(int begin, int end, int order)
        {
            _properties.Add(new Property(begin, end, order));
            return this;
        }

        public ConfigurationBuilder AddProperty(string name, int begin, int end)
        {
            _properties.Add(new Property(name, begin, end));
            return this;
        }

        public ConfigurationBuilder AddProperty(string name, int begin, int end, int order, Padding padding = Padding.Left, char padChar = ' ')
        {
            _properties.Add(new Property(name, begin, end, order, padding, padChar));
            return this;
        }

        public ConfigurationBuilder WithWriter(ISmartTextWriter writer)
        {
            _customWriter = writer;
            return this;
        }

        public ConfigurationBuilder WithWriter(Func<Configuration, ISmartTextWriter> builder)
        {
            return this;
        }

        public ConfigurationBuilder WithReader(ISmartTextReader reader)
        {
            _customReader = reader;
            return this;
        }

        public ConfigurationBuilder WithReader(Func<Configuration, ISmartTextReader> builder)
        {
            return this;
        }


        public void Build()
        {
            /*
             * build Configuration
             * check if Writer/REader builders are set
             * if so, then call Func to get the Writer/REader
             * 
             * if wirter/reader are not set, use default
             */
           

        }
    }
}
