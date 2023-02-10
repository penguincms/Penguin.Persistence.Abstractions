namespace Penguin.Persistence.Abstractions.Attributes.Validation
{
    /// <summary>
    /// Used to denote that this property should not be default/null when persisted
    /// </summary>
    public sealed class RequiredAttribute : PersistenceAttribute
    {
    }
}