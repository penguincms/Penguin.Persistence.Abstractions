using System;

namespace Penguin.Persistence.Abstractions.Attributes.Control
{
    /// <summary>
    /// Specifies that during dynamic rendering, this property should be hidden from the specified DisplayContext
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class DontAllowAttribute : Attribute
    {
        /// <summary>
        /// This DisplayContext(s) this attribute specifies
        /// </summary>
        public DisplayContexts Context { get; internal set; }

        /// <summary>
        /// Creates a new instance of this attribute
        /// </summary>
        /// <param name="context">The display context(s) that this property should be hidden from</param>
        public DontAllowAttribute(DisplayContexts context)
        {
            Context = context;
        }
    }
}