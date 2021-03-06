﻿using System.Linq;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// An interface intended to allow for access to a persistence context of a given type
    /// </summary>
    /// <typeparam name="T">The type of data used in the persistence context</typeparam>
    public interface IRepository<T> : ICrudI<T>, ICrud<T>, IRepository, IQueryable<T> where T : class
    {
        /// <summary>
        /// The persistence context containing the data this repository accesses
        /// </summary>
        IPersistenceContext<T> Context { get; }

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
        /// An accessor for only derived types
        /// </summary>
        IQueryable<TDerived> OfType<TDerived>() where TDerived : T;

        /// <summary>
        /// Creates a shallow clone of an object with new keys
        /// </summary>
        /// <param name="o">The object to clone</param>
        T ShallowClone(T o);
    }
}