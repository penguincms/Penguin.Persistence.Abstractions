using System;
using System.Collections.Generic;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Denotes a property as being the owning end of a Many To Many relationship
    /// </summary>
	public class ManyToManyAttribute : MappingAttribute
    {
        /// <summary>
        /// Creates a new instance of this attribute. All properties are inferred from usage
        /// </summary>
        public ManyToManyAttribute()
        {
            this.SetMapping = new Mapping()
            {
            };
        }

        /// <summary>
        /// Creates a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The name of the property that links back to this property from the other end of the relationship</param>
		public ManyToManyAttribute(string rightProperty)
        {
            this.SetMapping = new Mapping()
            {
                Right = new MappingEnd()
                {
                    Property = rightProperty
                }
            };
        }

        /// <summary>
        /// Creates a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The name of the property that links back to this property from the other end of the relationship</param>
        /// <param name="leftKey">The name of the identifying property from this type</param>
        /// <param name="rightKey">The name of the identifying property from the other end of the relationship</param>
		public ManyToManyAttribute(string rightProperty, string leftKey, string rightKey)
        {
            this.SetMapping = new Mapping()
            {
                Right = new MappingEnd()
                {
                    Property = rightProperty,
                    Key = rightKey
                }
                ,
                Left = new MappingEnd()
                {
                    Key = leftKey
                }
            };
        }

        /// <summary>
        /// Creates a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The name of the property that links back to this property from the other end of the relationship</param>
        /// <param name="tableName">The name of the table used to store this relationship</param>
		public ManyToManyAttribute(string rightProperty, string tableName)
        {
            this.SetMapping = new Mapping()
            {
                Right = new MappingEnd()
                {
                    Property = rightProperty
                },
                TableName = tableName
            };
        }

        /// <summary>
        /// Creates a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The name of the property that links back to this property from the other end of the relationship</param>
        /// <param name="leftKey">The name of the identifying property from this type</param>
        /// <param name="rightKey">The name of the identifying property from the other end of the relationship</param>
        /// <param name="tableName">The name of the table used to store this relationship</param>
		public ManyToManyAttribute(string rightProperty, string leftKey, string rightKey, string tableName)
        {
            this.SetMapping = new Mapping()
            {
                Right = new MappingEnd()
                {
                    Property = rightProperty,
                    Key = rightKey
                },
                Left = new MappingEnd()
                {
                    Key = leftKey
                },

                TableName = tableName
            };
        }

        /// <summary>
        /// Attempts to resolve the type of the property that links back to this one
        /// </summary>
        /// <param name="LeftPropertyType">The type of this property</param>
        /// <returns>A collection of this type, since this is Many to Many</returns>
        public override Type GetRightPropertyType(Type LeftPropertyType)
        {
            return typeof(ICollection<>).MakeGenericType(LeftPropertyType);
        }
    }
}