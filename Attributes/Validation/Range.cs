using System;

namespace Penguin.Persistence.Abstractions.Attributes.Validation
{
    /// <summary>
    /// A range attribute stolen from MS to represent a possible range of values for a property
    /// </summary>
    public class RangeAttribute : PersistenceAttribute
    {
        /// <summary>
        /// Gets the maximum value for the range
        /// </summary>
        public object Maximum { get; private set; }

        /// <summary>
        /// Gets the minimum value for the range
        /// </summary>
        public object Minimum { get; private set; }

        /// <summary>
        /// Gets the type of the <see cref="Minimum"/> and <see cref="Maximum"/> values (e.g. Int32, Double, or some custom type)
        /// </summary>
        public Type OperandType { get; private set; }

        /// <summary>
        /// Constructs an empty instance of this attribute
        /// </summary>
        public RangeAttribute()
        {
        }

        /// <summary>
        /// Constructor that takes integer minimum and maximum values
        /// </summary>
        /// <param name="minimum">The minimum value, inclusive</param>
        /// <param name="maximum">The maximum value, inclusive</param>
        public RangeAttribute(int minimum, int maximum)
            : this()
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
            this.OperandType = typeof(int);
        }

        /// <summary>
        /// Constructor that takes double minimum and maximum values
        /// </summary>
        /// <param name="minimum">The minimum value, inclusive</param>
        /// <param name="maximum">The maximum value, inclusive</param>
        public RangeAttribute(double minimum, double maximum)
            : this()
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
            this.OperandType = typeof(double);
        }

        /// <summary>
        /// Allows for specifying range for arbitrary types. The minimum and maximum strings will be converted to the target type.
        /// </summary>
        /// <param name="type">The type of the range parameters. Must implement IComparable.</param>
        /// <param name="minimum">The minimum allowable value.</param>
        /// <param name="maximum">The maximum allowable value.</param>
        public RangeAttribute(Type type, string minimum, string maximum)
            : this()
        {
            this.OperandType = type;
            this.Minimum = minimum;
            this.Maximum = maximum;
        }
    }
}