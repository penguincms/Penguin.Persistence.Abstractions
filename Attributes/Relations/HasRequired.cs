using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// An attribute to denote that a property should be required by the persistence system
    /// </summary>
    public sealed class HasRequiredAttribute : MappingAttribute
    {
        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        public HasRequiredAttribute()
        {
            SetMapping = new Mapping()
            {
            };
        }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The optional name for the property that links back to this object</param>
        public HasRequiredAttribute(string rightProperty)
        {
            SetMapping = new Mapping()
            {
                Right = new MappingEnd()
                {
                    Property = rightProperty
                }
            };
        }

        /// <summary>
        /// Returns the expected type of the property that links back to this one
        /// </summary>
        /// <param name="LeftPropertyType">The type of the class containing this attribute. Its a one-to-one so it just returns this type</param>
        /// <returns>The type of the class containing this attribute</returns>
        public override Type GetRightPropertyType(Type LeftPropertyType)
        {
            return LeftPropertyType;
        }

        public string RightProperty { get; }
    }
}