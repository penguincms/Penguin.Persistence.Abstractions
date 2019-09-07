using Penguin.Persistence.Abstractions.Attributes.Relations;

namespace Penguin.Persistence.Abstractions.Models.Complex
{
    /// <summary>
    /// A complex 2D size representation for simplifying the data type
    /// </summary>
    [ComplexType]
    public class Size
    {
        /// <summary>
        /// The Height of the object being represented
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The Width of the object being represented
        /// </summary>
        public int Width { get; set; }
    }
}