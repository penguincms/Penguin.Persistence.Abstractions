using Penguin.Persistence.Abstractions.Attributes.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// A collection of data required to define one end of a two ended mapping
    /// </summary>
    public class End
    {
        #region Properties

        /// <summary>
        /// The primary ID for the class used for declaring mapping tables
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The property that forms the link between the classes
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// The type of the class holding this end of the relationship
        /// </summary>
        public Type Type { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Contains information defining both ends of a relationship mapping
    /// </summary>
    public class Mapping
    {
        #region Properties

        /// <summary>
        /// The owner of the relationship and the class where the attribute is found
        /// </summary>
        public End Left { get; set; }

        /// <summary>
        /// The child of the relationship, this side does not have an attribute
        /// </summary>
        public End Right { get; set; }

        /// <summary>
        /// Optional table name for generating Many-To-Many relationships
        /// </summary>
        public string TableName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        public Mapping()
        {
            Left = new End();
            Right = new End();
        }

        #endregion Constructors
    }

    /// <summary>
    /// The base class for any attribute that defines relationships (one-to-many, optional, ex) between entities
    /// </summary>
    public abstract class MappingAttribute : RelationalAttribute
    {
        #region Properties

        /// <summary>
        /// Sets/gets the mapping data for this relationship as defined when constructed
        /// </summary>
        public Mapping SetMapping { get; internal set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the mapping data for this relationship by attempting to fill in any undefined values
        /// </summary>
        /// <param name="leftProperty">The property on the defined end of the relationship</param>
        /// <returns>The filled in mapping data that may contain assumed definitions if there were unspecified properties</returns>
        public Mapping GetMapping(PropertyInfo leftProperty)
        {
            Mapping mapping = new Mapping();

            mapping.Left.Type = SetMapping.Left.Type ?? leftProperty.ReflectedType;

            mapping.Right.Type = SetMapping.Right.Type ?? leftProperty.PropertyType;

            if (typeof(ICollection).IsAssignableFrom(mapping.Right.Type))
            {
                mapping.Right.Type = mapping.Right.Type.GetGenericArguments()[0];
            }

            if (this.SetMapping.Right.Property is null)
            {
                Type searchType = GetRightPropertyType(leftProperty.ReflectedType);

                List<PropertyInfo> rightProperties = mapping.Right.Type.GetProperties()
                                                                       .Where(p => searchType.IsAssignableFrom(p.PropertyType))
                                                                       .ToList();

                if (rightProperties.Count() != 1)
                {
                    throw new Exception($"Did not find exactly 1 property of type {searchType.FullName} on type {mapping.Right.Type.FullName}. Can not imply navigation. Please specify the property name to be used on the other end of this relationship");
                }
                else
                {
                    this.SetMapping.Right.Property = rightProperties.Single().Name;
                }
            }

            mapping.Right.Property = this.SetMapping.Right.Property;
            mapping.Left.Property = leftProperty.Name;

            mapping.Left.Key = this.SetMapping.Left.Key ?? this.GetKey(mapping.Left.Type);
            mapping.Right.Key = this.SetMapping.Right.Key ?? this.GetKey(mapping.Right.Type);

            mapping.TableName = this.SetMapping.TableName ?? $"{mapping.Left.Type.Name}{mapping.Right.Type.Name}";

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
        protected string GetKey(Type type)
        {
            PropertyInfo leftKey = type.GetProperties().FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if (leftKey != null)
            {
                return $"{type.Name}{leftKey.Name}";
            }
            else
            {
                return $"{type.Name}";
            }
        }

        /// <summary>
        /// Attempts to get the type of the property being used as the key for the requested type
        /// </summary>
        /// <param name="type">The type to get the key for</param>
        /// <returns>The key for that property, or null if not defined</returns>
        protected Type GetKeyType(Type type)
        {
            PropertyInfo leftKey = type.GetProperties().FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if (leftKey != null)
            {
                return leftKey.ReflectedType;
            }
            else
            {
                return null;
            }
        }

        #endregion Methods
    }
}