﻿using System;
using System.Collections.Generic;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Specifies that the property this applies to is optional, and the other end of the reference may contain a list of
    /// the class containing this property.
    /// </summary>
    public sealed class OptionalToManyAttribute : MappingAttribute
    {
        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        public OptionalToManyAttribute()
        {
            SetMapping = new Mapping()
            {
            };
        }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="rightProperty">The optional name for the property that links back to this object</param>
        public OptionalToManyAttribute(string rightProperty)
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
        /// <param name="LeftPropertyType">The type containing this property</param>
        /// <returns>It returns an ICollection of this type since its a one-to-many relationship</returns>
        public override Type GetRightPropertyType(Type LeftPropertyType)
        {
            return typeof(ICollection<>).MakeGenericType(LeftPropertyType);
        }

        public string RightProperty { get; }
    }
}