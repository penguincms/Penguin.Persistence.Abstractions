namespace Penguin.Persistence.Abstractions.Attributes.Control
{
    /// <summary>
    /// Denotes that a property should be used as the index of a class
    /// </summary>
    public class IndexAttribute : PersistenceAttribute
    {
        /// <summary>
        /// True if no duplicate values should be allowed between persisted objects
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="isUnique">If true, no duplicate values should be persisted among members of this class</param>
        public IndexAttribute(bool isUnique = false)
        {
            IsUnique = isUnique;
        }
    }
}