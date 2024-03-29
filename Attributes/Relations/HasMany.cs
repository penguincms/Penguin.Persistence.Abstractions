﻿using System;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Denotes that this property should contain multiple references to the target type
    /// </summary>
    public sealed class HasManyAttribute : RelationalAttribute
    {
        /// <summary>
        /// The property name that defines the key referenced
        /// </summary>
        public string TargetProperty { get; internal set; }

        /// <summary>
        /// The type of the object that this property (assumed key) references
        /// </summary>
        public Type TargetType { get; internal set; }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="targetProperty">The property name that defines the key referenced</param>
        /// <param name="targetType">The type of the object that this property (assumed key) references</param>
        public HasManyAttribute(string targetProperty = null, Type targetType = null)
        {
            TargetProperty = targetProperty;
            TargetType = targetType;
        }
    }
}