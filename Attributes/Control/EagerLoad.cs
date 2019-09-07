using System;

namespace Penguin.Persistence.Abstractions.Attributes.Control
{
    /// <summary>
    /// 1 loads only the entity. Each additional loads one more level.
    /// No depth supplied is infinite until reaching a tag with a supplied depth
    /// </summary>
    public class EagerLoad : Attribute
    {
        /// <summary>
        /// The number of steps to travel down the object graph
        /// </summary>
        public int? Depth { get; set; }

        /// <summary>
        /// Creates a new instance of this attribute with the specified depth
        /// </summary>
        /// <param name="depth">The number of steps to travel down the object graph</param>
        public EagerLoad(int depth)
        {
            this.Depth = depth;
        }

        /// <summary>
        /// Creates a new instance of this attribute with the specified depth
        /// </summary>
        public EagerLoad()
        {
            this.Depth = null;
        }
    }
}