namespace SmartText.Builder
{
    public interface ISectionBuilder<T> where T : class, new()
    {
        Section Section { get; }
    }
}
