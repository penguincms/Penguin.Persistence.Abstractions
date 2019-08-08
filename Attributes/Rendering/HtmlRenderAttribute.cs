using System;

namespace Penguin.Persistence.Abstractions.Attributes.Rendering
{
    /// <summary>
    /// Attribute used to tell a dynamic rendering system that this string value should use the provided Input type when rendering to the browser
    /// </summary>
    public sealed class HtmlRenderAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// The rendering type to use for the field
        /// </summary>
        public RenderingType Type { get; set; }

        #endregion Properties

        #region Enums

        /// <summary>
        /// An enum representing the various HTML5 input options for a text property
        /// </summary>
        public enum RenderingType
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
            text,
            textarea,
            email,
            html,
            tel
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }

        #endregion Enums

        #region Constructors

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="type">The HTML5 type to use when rendering the field</param>
        public HtmlRenderAttribute(RenderingType type)
        {
            this.Type = type;
        }

        #endregion Constructors
    }
}