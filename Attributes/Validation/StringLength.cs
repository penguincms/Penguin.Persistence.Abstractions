namespace Penguin.Persistence.Abstractions.Attributes.Validation
{
    /// <summary>
    /// Defines a maximum string length for a property
    /// </summary>
    public class StringLengthAttribute : PersistenceAttribute
    {
        /// <summary>
        /// The maximum string length for the property
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="length">The maximum string length for the property</param>
        public StringLengthAttribute(int length)
        {
            Length = length;
        }
    }
}