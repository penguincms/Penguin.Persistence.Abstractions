using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Specifies that this property is not required to be set, which should be the default either way so this should probably be avoided
    /// </summary>
    public class OptionalAttribute : RelationalAttribute
    {
        #region Properties

        /// <summary>
        /// The name of the property linking back to this one
        /// </summary>
        public string TargetProperty { get; set; }

        /// <summary>
        /// The type of the property
        /// </summary>
        public Type TargetType { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="targetProperty">The name of the property linking back to this one </param>
        /// <param name="targetType">The type of the property</param>
        public OptionalAttribute(string targetProperty, Type targetType = null)
        {
            TargetProperty = targetProperty;
            TargetType = targetType;
        }

        #endregion Constructors
    }
}