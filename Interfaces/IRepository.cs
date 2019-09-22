using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A nongeneric representation of a repository allowing for access without knowing the underlying data type
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Returns the (possibly) overridden IQueriable used to access database by the underlying persistence context
        /// </summary>
        IQueryable All { get; }

        /// <summary>
        /// Returns a bool indicating whether or not the underlying persistence context contains a set for storing the
        /// type represented by this repository
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        void Add(params object[] o);

        /// <summary>
        /// Resets the object unique fields and adds a copy to the context
        /// </summary>
        /// <param name="o">The object to copy and add</param>
        void AddCopy(object o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdate(params object[] o);

        /// <summary>
        /// Resets the object unique fields and adds or updates a copy to the context
        /// </summary>
        /// <param name="o">The object to copy and add</param>
        void AddOrUpdateCopy(object o);

        /// <summary>
        /// If all WriteContexts have been deregistered, this should persist any changes to the underlying data store
        /// </summary>
        /// <param name="writeContext">The IWriteContext that has finished making changes</param>
        void Commit(IWriteContext writeContext);

        /// <summary>
        /// If all WriteContexts have been deregistered, this should persist any changes to the underlying data store in an ASYNC manner
        /// </summary>
        /// <param name="writeContext">The IWriteContext that has finished making changes</param>
        Task CommitASync(IWriteContext writeContext);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        void Delete(params object[] o);

        /// <summary>
        /// Should return every object from the repository
        /// </summary>
        /// <returns>Every object from the repository</returns>
        List<object> Find();

        /// <summary>
        /// Creates a shallow clone of an object with new keys
        /// </summary>
        /// <param name="o">The object to clone</param>
        object ShallowClone(object o);

        /// <summary>
        /// This should update any objects that already exist in the underlying data store
        /// </summary>
        /// <param name="o">The objects to update from the underlying data store</param>
        void Update(params object[] o);

        /// <summary>
        /// Allows for a "Where" call on a non generic instance by converting the provided expression tree to the implemented type
        /// </summary>
        /// <typeparam name="T">An assumed type/base for this non-generic instance of the repository</typeparam>
        /// <param name="predicate">The Expression to pass to the underlying IQueriable</param>
        /// <returns>The results of evaluating the expression against the underlying IQueriable</returns>
        IEnumerable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Returns a new write context for the underlying persistence context
        /// </summary>
        /// <returns> a new write context for the underlying persistence context</returns>
        IWriteContext WriteContext();
    }
}