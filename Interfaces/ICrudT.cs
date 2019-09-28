using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A typed interface for basic crud operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrud<T> : ICrud, IQueryable<T>
    {
        /// <summary>
        /// This should access the underlying queriable data provider, and be overridden for persistence contexts
        /// that require any form of data filtering
        /// </summary>
        new IQueryable<T> All { get; }

        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        void Add(T o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdate(T o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdateRange(IEnumerable<T> o);

        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        void AddRange(IEnumerable<T> o);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        void Delete(T o);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        void DeleteRange(IEnumerable<T> o);

        /// <summary>
        /// This should return any object with a key that matches the provided
        /// </summary>
        new T Find(object Key);

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        new IEnumerable<T> FindRange(IEnumerable Keys);

        /// <summary>
        /// This should update existing objects in the data store, but not add new ones
        /// </summary>
        /// <param name="o">The object(s) to update</param>
        void Update(T o);

        /// <summary>
        /// This should update existing objects in the data store, but not add new ones
        /// </summary>
        /// <param name="o">The object(s) to update</param>
        void UpdateRange(IEnumerable<T> o);
    }
}