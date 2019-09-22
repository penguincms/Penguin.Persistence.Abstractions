using Penguin.Persistence.Abstractions.Attributes.Rendering;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Penguin.Persistence.Abstractions.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public static class PropertyInfoExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Attempts to get a name from a set DisplayAttribute, and if not found, falls back on the property name
        /// </summary>
        /// <param name="property">The property to retrieve the name from</param>
        /// <returns>The proper display name for the property</returns>
        public static string DisplayName(this PropertyInfo property)
        {
            Contract.Requires(property != null);

            DisplayAttribute display = property.GetCustomAttribute<DisplayAttribute>();

            if (string.IsNullOrWhiteSpace(display?.Name))
            {
                return property.Name;
            }
            else
            {
                return display.Name;
            }
        }
    }
}