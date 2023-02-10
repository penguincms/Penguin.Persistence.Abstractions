using Penguin.Persistence.Abstractions.Attributes.Rendering;
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
            if (property is null)
            {
                throw new System.ArgumentNullException(nameof(property));
            }

            DisplayAttribute display = property.GetCustomAttribute<DisplayAttribute>();

            return string.IsNullOrWhiteSpace(display?.Name) ? property.Name : display.Name;
        }
    }
}