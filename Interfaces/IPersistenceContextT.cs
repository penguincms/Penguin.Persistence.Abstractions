using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A interface representing a context used for persisting information to a database or other format
    /// </summary>
    /// <typeparam name="T">The type of object being specifically referenced to by this instance</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>")]
    public interface IPersistenceContext<T> : IQueryable<T>, IPersistenceContext where T : class
    {
        /// <summary>
        /// This should access the underlying queriable data provider, and be overridden for persistence contexts
        /// that require any form of data filtering
        /// </summary>
        IQueryable<T> All { get; }

        /// <summary>
        /// This should perform all of the same data filtering and population as All, however it should
        /// do all of this specific to the derived type and return the derived type as though it was a top
        /// level persistence context
        /// </summary>
        IQueryable<TDerived> OfType<TDerived>() where TDerived : T;

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdate(params T[] o);

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        new T[] Find(object[] Keys);

        /// <summary>
        /// This should return any object with a key that matches the provided
        /// </summary>
        new T Find(object Key);
    }
}
