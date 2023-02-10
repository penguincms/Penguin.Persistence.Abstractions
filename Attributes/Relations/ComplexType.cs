namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Tags an entity to prefer embedding the object data within the parent object, for database saved classes
    /// </summary>
    public sealed class ComplexTypeAttribute : PersistenceAttribute
    {
    }
}