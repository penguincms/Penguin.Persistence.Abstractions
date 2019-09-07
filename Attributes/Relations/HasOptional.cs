using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Denotes that this relationship should be optional, which should be the default
    /// </summary>
    public class HasOptionalAttribute : RelationalAttribute
    {
        /// <summary>
        /// The property name that defines the key referenced
        /// </summary>
        public string TargetProperty { get; set; }

        /// <summary>
        /// The type of the object that this property (assumed key) references
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="targetProperty">The property name that defines the key referenced</param>
        /// <param name="targetType">The type of the object that this property (assumed key) references</param>
        public HasOptionalAttribute(string targetProperty, Type targetType = null)
        {
            TargetProperty = targetProperty;
            TargetType = targetType;
        }
    }
}