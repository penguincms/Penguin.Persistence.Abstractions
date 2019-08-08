using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Maps a property on one object to a property on another object for entity relations. This should be used when the mapped property is only a key
    /// and not an actual entity type
    /// </summary>
    public class MapAttribute : MappingAttribute
    {
        #region Constructors


        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The property name on the far end of the relationship</param>
        public MapAttribute(string rightProperty)
        {
            this.SetMapping = new Mapping()
            {
                Right = new End()
                {
                    Property = rightProperty
                }
            };
        }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="rightType">The type of the object that this property (assumed key) references</param>
        /// <param name="rightProperty">The property name that defines the key referenced</param>
        public MapAttribute(Type rightType, string rightProperty)
        {
            this.SetMapping = new Mapping()
            {
                Right = new End()
                {
                    Property = rightProperty,
                    Type = rightType
                }
            };
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns the type of the property on the other end of the relationship. This seems weird
        /// </summary>
        /// <param name="LeftPropertyType">The left property type</param>
        /// <returns>Gets the key type of the left property</returns>
        public override Type GetRightPropertyType(Type LeftPropertyType)
        {
            return GetKeyType(LeftPropertyType);
        }

        #endregion Methods
    }
}