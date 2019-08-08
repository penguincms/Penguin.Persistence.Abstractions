namespace Penguin.Persistence.Abstractions.Attributes.Rendering
{
    /// <summary>
    /// Used for defining common display properties
    /// </summary>
    public class DisplayAttribute : PersistenceAttribute
    {
        #region Properties

        /// <summary>
        /// Should fields be created during scaffolding? Unused
        /// </summary>
        public bool AutoGenerateField { get; set; }

        /// <summary>
        /// The group name or method of grouping/displaying properties. Implementation independent
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The Display Name for this property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order int of this property to be used when rendering properties dynamically
        /// </summary>
        public int Order { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new instance of this attribute
        /// </summary>
        public DisplayAttribute()
        {
        }

        #endregion Constructors
    }
}