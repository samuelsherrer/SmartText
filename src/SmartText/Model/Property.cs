namespace SmartText
{
    public class Property
    {
        public Property(int begin, int end, int order)
        {
            _begin = begin;
            _end = end;
            Order = order;
        }

        public Property(string name, int begin, int end, int order, Padding padding = Padding.Left, char padChar = ' ')
        {
            Name = name;
            _begin = begin;
            _end = end;
            Order = order;
            Padding = padding;
            PaddingChar = padChar;
        }

        public Property(string name, int begin, int end)
        {
            Name = name;
            _begin = begin;
            _end = end;
        }

        public string Name { get; private set; }

        public int Order { get; private set; }

        public Padding Padding { get; private set; }

        private int _begin
        {
            get { return this.Begin; }
            set { this.Begin = value - 1; }
        }

        public int Begin { get; private set; }

        private int _end
        {
            get { return this.End; }
            set { this.End = value - 1; }
        }

        public int End { get; private set; }

        public char PaddingChar { get; private set; }

        public int Space
            => (this._end - this._begin) + 1;
    }
}
