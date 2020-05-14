namespace SmartText
{
    public interface ISmartTextWriter
    {
        void CreateLine(object item);
        void CreateLine();
        void CreateLine<T>(T item);
        //void CreateLine(List<Property> properties, object item);
    }
}
