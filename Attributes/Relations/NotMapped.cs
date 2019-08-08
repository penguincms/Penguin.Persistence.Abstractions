namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// On classes, used to specify that the object should not be part of any database context. On properties, used to specify that the property should not be persisted
    /// </summary>
    public class NotMappedAttribute : PersistenceAttribute
    {
    }
}