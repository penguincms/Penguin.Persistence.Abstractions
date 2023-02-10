namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// A base class intended to be used by any attributes used to define entity relations
    /// </summary>
    public abstract class RelationalAttribute : PersistenceAttribute
    {
        /// <summary>
        /// Returns Relations + TypeName. Used by the Dynamic rendering system to allow for routing based on entity relations
        /// </summary>
        /// <returns>Returns Relations + TypeName. Used by the Dynamic rendering system to allow for routing based on entity relations</returns>
        public override string ToString()
        {
            return $"Relations.{GetType().Name}";
        }
    }
}