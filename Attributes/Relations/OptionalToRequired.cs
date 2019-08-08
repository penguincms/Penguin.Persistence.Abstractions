using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Specifies that the property this applies to is optional, however the property linking back to this must 
    /// be set
    /// </summary>
    public class OptionalToRequiredAttribute : MappingAttribute
    {
        #region Constructors

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        public OptionalToRequiredAttribute()
        {
            this.SetMapping = new Mapping()
            {
            };
        }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The optional name for the property that links back to this object</param>
        public OptionalToRequiredAttribute(string rightProperty)
        {
            this.SetMapping = new Mapping()
            {
                Right = new End()
                {
                    Property = rightProperty
                }
            };
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns the expected type of the property that links back to this one
        /// </summary>
        /// <param name="LeftPropertyType">The type of the class containing this attribute. Its a one-to-one so it just returns this type</param>
        /// <returns>The type of the class containing this attribute</returns>
        public override Type GetRightPropertyType(Type LeftPropertyType) => LeftPropertyType;

        #endregion Methods
    }
}