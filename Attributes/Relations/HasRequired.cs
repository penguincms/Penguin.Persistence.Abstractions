using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// An attribute to denote that a property should be required by the persistence system
    /// </summary>
    public class HasRequiredAttribute : RelationalAttribute
    {
        #region Properties
        /// <summary>
        /// The property name that defines the key referenced
        /// </summary>
        public string TargetProperty { get; set; }

        /// <summary>
        /// The type of the object that this property (assumed key) references
        /// </summary>
        public Type TargetType { get; set; }

        #endregion Properties

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetProperty">The property name that defines the key referenced</param>
        /// <param name="targetType">The type of the object that this property (assumed key) references</param>
        public HasRequiredAttribute(string targetProperty, Type targetType = null)
        {
            TargetProperty = targetProperty;
            TargetType = targetType;
        }

        #endregion Constructors
    }
}