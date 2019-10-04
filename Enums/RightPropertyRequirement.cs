using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Persistence.Abstractions.Enums
{
    /// <summary>
    /// Specifies the requirement for the right property for mappings which may be unidirectional, OR bidirectional ex Required => Optional where the Required type may not contain a reference back to it, at all
    /// </summary>
    public enum RightPropertyRequirement
    {
        /// <summary>
        /// Will throw an error if there is not exactly one property linking back
        /// </summary>
        Single,

        /// <summary>
        /// Will allow for a single or missing link back, but will throw an error if multiple are found
        /// </summary>
        SingleOrNull,

        /// <summary>
        /// Will allow for any property matching type, and will return null if many are found
        /// </summary>
        SingleOrNullIfMany
    }
}
