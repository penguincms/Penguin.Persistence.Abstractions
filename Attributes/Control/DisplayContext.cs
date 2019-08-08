using System;

namespace Penguin.Persistence.Abstractions.Attributes.Control
{
    /// <summary>
    /// Represents a method of displaying information to a user, used to attribute properties in a way that only applies to a single method of display
    /// </summary>
    [Flags]
    public enum DisplayContext
    {
        /// <summary>
        /// Should not be used
        /// </summary>
        None = 0,

        /// <summary>
        /// Only applies when the used is making alterations to an object. Disallowing should still show the data, but it should not be editable
        /// </summary>
        Edit = 1,

        /// <summary>
        /// Only applies when a this property is being rendered as part of editing a large list of objects
        /// </summary>
        BatchEdit = 2,

        /// <summary>
        /// Only applies when this object is being listed out as part of a group
        /// </summary>
        List = 4,

        /// <summary>
        /// Applies to any interaction that makes this object visible
        /// </summary>
        View = 8,

        /// <summary>
        /// Any context in which this property is not accessed through a derived class
        /// </summary>
        NotInherited = 16,

        /// <summary>
        /// Any context in which this property is being bound via macros to a template (ex Email system)
        /// </summary>
        TemplateBinding = 32,

        /// <summary>
        /// Applies to all contexts
        /// </summary>
        Any = Edit | List | View | TemplateBinding | BatchEdit
    }
}