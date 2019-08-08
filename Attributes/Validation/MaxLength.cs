namespace Penguin.Persistence.Abstractions.Attributes.Validation
{
    /// <summary>
    /// Specifies the max length of a property when persisted
    /// </summary>
    public class MaxLengthAttribute : PersistenceAttribute
    {
        #region Properties

        /// <summary>
        /// The max length of the property
        /// </summary>
        public int Length { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="length">The max length of the property</param>
        public MaxLengthAttribute(int length)
        {
            Length = length;
        }

        /// <summary>
        /// Constructs a new instance of this property with a length of Int.Max
        /// </summary>
        public MaxLengthAttribute()
        {
            Length = int.MaxValue;
        }

        #endregion Constructors
    }
}