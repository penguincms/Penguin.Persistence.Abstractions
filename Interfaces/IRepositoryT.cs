using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// An interface intended to allow for access to a persistence context of a given type
    /// </summary>
    /// <typeparam name="T">The type of data used in the persistence context</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>")]
    public interface IRepository<T> : IRepositoryI<T>, IRepositoryO<T>, IRepository, IQueryable<T> where T : class
    {
        /// <summary>
        /// The persistence context containing the data this repository accesses
        /// </summary>
        IPersistenceContext<T> Context { get; }

        /// <summary>
        /// An accessor for only derived types
        /// </summary>
        IQueryable<TDerived> OfType<TDerived>() where TDerived : T;

        /// <summary>
        /// Resets the object unique fields and adds a copy to the context
        /// </summary>
        /// <param name="o">The object to copy and add</param>
        void AddCopy(T o);

        /// <summary>
        /// Resets the object unique fields and adds or updates a copy to the context
        /// </summary>
        /// <param name="o">The object to copy and add</param>
        void AddOrUpdateCopy(T o);

        /// <summary>
        /// Creates a shallow clone of an object with new keys
        /// </summary>
        /// <param name="o">The object to clone</param>
        T ShallowClone(T o);
    }
}
