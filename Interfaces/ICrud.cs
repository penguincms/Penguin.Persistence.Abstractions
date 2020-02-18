using System.Collections;
using System.Linq;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// Supports basic crud operations
    /// </summary>
    public interface ICrud : IQueryable
    {
        /// <summary>
        /// This should access the underlying queriable data provider, and be overridden for persistence contexts
        /// that require any form of data filtering
        /// </summary>
        IQueryable All { get; }

        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        void Add(object o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdate(object o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdateRange(IEnumerable o);

        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        void AddRange(IEnumerable o);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        void Delete(object o);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        void DeleteRange(IEnumerable o);

        /// <summary>
        /// This should return any object with a key that matches the provided
        /// </summary>
        object Find(object Key);

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        IEnumerable FindRange(IEnumerable Key);

        /// <summary>
        /// This should update any objects that already exist in the underlying data store
        /// </summary>
        /// <param name="o">The objects to update from the underlying data store</param>
        void Update(object o);

        /// <summary>
        /// This should update any objects that already exist in the underlying data store
        /// </summary>
        /// <param name="o">The objects to update from the underlying data store</param>
        void UpdateRange(IEnumerable o);
    }
}