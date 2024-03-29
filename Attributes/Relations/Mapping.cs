﻿using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Enums;
using Penguin.Reflection.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// Contains information defining both ends of a relationship mapping
    /// </summary>
    public class Mapping
    {
        /// <summary>
        /// The owner of the relationship and the class where the attribute is found
        /// </summary>
        public MappingEnd Left { get; set; }

        /// <summary>
        /// The child of the relationship, this side does not have an attribute
        /// </summary>
        public MappingEnd Right { get; set; }

        /// <summary>
        /// Optional table name for generating Many-To-Many relationships
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        public Mapping()
        {
            Left = new MappingEnd
            {
                //Left property should always be found since its where the attribute is declared
                PropertyFound = true
            };

            Right = new MappingEnd();
        }
    }

    /// <summary>
    /// The base class for any attribute that defines relationships (one-to-many, optional, ex) between entities
    /// </summary>
    public abstract class MappingAttribute : RelationalAttribute
    {
        /// <summary>
        /// Sets/gets the mapping data for this relationship as defined when constructed
        /// </summary>
        public Mapping SetMapping { get; internal set; }

        /// <summary>
        /// Gets the mapping data for this relationship by attempting to fill in any undefined values
        /// </summary>
        /// <param name="leftProperty">The property on the defined end of the relationship</param>
        /// <param name="rightPropertyRequirement"></param>
        /// <returns>The filled in mapping data that may contain assumed definitions if there were unspecified properties</returns>
        public Mapping GetMapping(PropertyInfo leftProperty, RightPropertyRequirement rightPropertyRequirement = RightPropertyRequirement.Single)
        {
            if (leftProperty is null)
            {
                throw new ArgumentNullException(nameof(leftProperty));
            }

            Mapping mapping = new();

            mapping.Left.Type = SetMapping.Left.Type ?? leftProperty.ReflectedType;

            mapping.Right.Type = SetMapping.Right.Type ?? leftProperty.PropertyType;

            if (typeof(ICollection).IsAssignableFrom(mapping.Right.Type))
            {
                mapping.Right.Type = mapping.Right.Type.GetGenericArguments()[0];
            }

            if (SetMapping.Right.Property is null)
            {
                Type searchType = GetRightPropertyType(leftProperty.ReflectedType);

                List<PropertyInfo> rightProperties = mapping.Right.Type.GetProperties()
                                                                       .Where(p => CheckPropertyAssignment(p, searchType))
                                                                       .ToList();
                if (!rightProperties.Any())
                {
                    rightProperties = mapping.Right.Type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                                             .Where(p => CheckPropertyAssignment(p, searchType))
                                             .ToList();
                }

                if (rightProperties.Count != 1 && rightPropertyRequirement == RightPropertyRequirement.Single)
                {
                    throw new Exception($"Did not find exactly 1 property of type {searchType.FullName} on type {mapping.Right.Type.FullName}. Can not imply navigation. Please specify the property name to be used on the other end of this relationship");
                }
                else
                {
                    if (rightPropertyRequirement == RightPropertyRequirement.SingleOrNull && rightProperties.Count > 1)
                    {
                        throw new Exception($"{nameof(RightPropertyRequirement.SingleOrNull)} right property requirement specified, but {rightProperties.Count} entries matching the property requirements were found");
                    }
                    else
                    {
                        PropertyInfo p = rightProperties.SingleOrDefault();

                        if (p != null)
                        {
                            SetMapping.Right.PropertyFound = true;
                            SetMapping.Right.Property = p.Name;
                        }
                    }
                }
            }

            mapping.Right.Property = SetMapping.Right.Property;
            mapping.Right.PropertyFound = SetMapping.Right.PropertyFound;
            mapping.Left.Property = leftProperty.Name;

            mapping.Left.Key = SetMapping.Left.Key ?? GetKey(mapping.Left.Type);
            mapping.Right.Key = SetMapping.Right.Key ?? GetKey(mapping.Right.Type);

            if (mapping.Right.PropertyFound)
            {
                mapping.TableName = SetMapping.TableName ?? $"{mapping.Left.Type.Name}{mapping.Right.Type.Name}";
            }

            return mapping;
        }

        /// <summary>
        /// If the child property referencing BACK to the parent is undefined, we assume its "obvious" (only one matching member type) and use this
        /// method to determine if its a collection or a single link (many to many vs many to one)
        /// </summary>
        /// <param name="LeftPropertyType"></param>
        /// <returns></returns>
        public abstract Type GetRightPropertyType(Type LeftPropertyType);

        /// <summary>
        /// Attempts to get the "Key" (or identifying field) for a type used for mapping
        /// </summary>
        /// <param name="type">The type to get the key for</param>
        /// <returns>The full name (Type.FullName + Property) for the property that should be used as a key</returns>
        protected static string GetKey(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            PropertyInfo leftKey = type.GetProperties().FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            return leftKey != null ? $"{type.Name}{leftKey.Name}" : $"{type.Name}";
        }

        /// <summary>
        /// Attempts to get the type of the property being used as the key for the requested type
        /// </summary>
        /// <param name="type">The type to get the key for</param>
        /// <returns>The key for that property, or null if not defined</returns>
        protected static Type GetKeyType(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            PropertyInfo leftKey = type.GetProperties().FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            return leftKey?.ReflectedType;
        }

        private static bool CheckPropertyAssignment(PropertyInfo toCheck, Type target)
        {
            Type leftType;
            Type rightType;

            if (toCheck.GetIndexParameters().Length != 0)
            {
                return false;
            }

            if (toCheck.PropertyType.IsCollection() && target.IsCollection())
            {
                leftType = toCheck.PropertyType.GetCollectionType();
                rightType = target.GetCollectionType();
            }
            else
            {
                leftType = toCheck.PropertyType;
                rightType = target;
            }

            return leftType.IsAssignableFrom(rightType);
        }
    }

    /// <summary>
    /// A collection of data required to define one end of a two ended mapping
    /// </summary>
    public class MappingEnd
    {
        /// <summary>
        /// The primary ID for the class used for declaring mapping tables
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The property that forms the link between the classes
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// True if the mapping end property is defined
        /// </summary>
        public bool PropertyFound { get; set; }

        /// <summary>
        /// The type of the class holding this end of the relationship
        /// </summary>
        public Type Type { get; set; }
    }
}