namespace Penguin.Persistence.Abstractions.Attributes
{
    /// <summary>
    /// Describes how this object should be treated in the context of a persistence context or serialization
    /// </summary>
    public enum EntityType
    {
        /// <summary>
        /// This entity is a fully qualified top level object. Each relationship is important and it should have its own persistence context (Ex a user)
        /// </summary>
        Entity,

        /// <summary>
        /// This entity is used only to hold complex information from other entites. It does not need a persistence context, will only be accessed through relationships, and
        /// is only as distinct as the values of its properties (ex a weight class)
        /// </summary>
        Link
    }

    /// <summary>
    /// Describes how this object should be treated in the context of a persistence context or serialization
    /// </summary>
    public class EntityAttribute : PersistenceAttribute
    {
        #region Properties

        /// <summary>
        /// What kind of entity this is
        /// </summary>
        public EntityType Type { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="type">What kind of entity this is</param>
        public EntityAttribute(EntityType type)
        {
            Type = type;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns the type as a string (for use in dynamic rendering paths)
        /// </summary>
        /// <returns>The type as a string</returns>
        public override string ToString()
        {
            return Type.ToString();
        }

        #endregion Methods
    }
}