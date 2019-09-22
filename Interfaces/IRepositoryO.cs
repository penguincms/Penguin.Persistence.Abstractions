using System.Linq;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// An interface intended to allow for access to a persistence context of a given type
    /// </summary>
    /// <typeparam name="T">The type of data used in the persistence context</typeparam>
    public interface IRepositoryO<out T> : IRepository where T : class
    {
        /// <summary>
        /// Returns the (possibly) overridden IQueriable used to access database by the underlying persistence context
        /// </summary>
        new IQueryable<T> All { get; }
    }
}