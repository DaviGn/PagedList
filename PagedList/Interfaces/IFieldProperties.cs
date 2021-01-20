namespace PagedList.Interfaces
{
    public interface IFieldProperties
    {
        int Order { get; set; }
        string Name { get; set; }
        string PropertyName { get; }
    }
}