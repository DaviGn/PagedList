namespace PagedList.Interfaces
{
    /// <summary>
    /// Represents a property information
    /// </summary>
    public interface IFieldProperties
    {
        /// <summary>
        /// Column/List order
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// Friendly name to display in front-end
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Real property name
        /// </summary>
        string PropertyName { get; }
    }
}