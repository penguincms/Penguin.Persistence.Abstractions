using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A nongeneric interface for a persistence context to allow access to data without knowing the underlying type
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010:Collections should implement generic interface", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>")]
    public interface IPersistenceContext : IQueryable
    {
        /// <summary>
        /// This should return a true if the object used to construct this persistence context has an associated data store (ex DbSet)
        /// </summary>
        bool IsValid { get; }

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
        /// This should add the passed in IWriteContext to the list of open contexts, and enable persistence
        /// </summary>
        /// <param name="context">The IWriteContext that will be controlling this persistence instance</param>
        void BeginWrite(IWriteContext context);

        /// <summary>
        /// This should clear out all open object references and close the write contexts without commiting any changes
        /// </summary>
        void CancelWrite();

        /// <summary>
        /// If all WriteContexts have been deregistered, this should persist any changes to the underlying data store
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        void Commit(IWriteContext context);

        /// <summary>
        /// If all WriteContexts have been deregistered, this should persist any changes to the underlying data store in an ASYNC manner
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        Task CommitASync(IWriteContext context);

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
        /// This should check to ensure that the IWriteContext is registered with the persistence context, remove it, and if it was the LAST open
        /// Write context it should persist all unsaved changes to the underlying data store
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        void EndWrite(IWriteContext context);

        /// <summary>
        /// This should return any object with a key that matches the provided
        /// </summary>
        object Find(object Key);

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        IEnumerable FindRange(IEnumerable Key);

        /// <summary>
        /// This should return an array of any IWriteContexts that are currently registered by this persistence context
        /// </summary>
        /// <returns>An array of any IWriteContexts that are currently registered by this persistence context</returns>
        IEnumerable<IWriteContext> GetWriteContexts();

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

        /// <summary>
        /// This should spawn a new IWriteContext instance that is pre-registered with this persistence context
        /// </summary>
        /// <returns>A new IWriteContext instance that is pre-registered with this persistence context</returns>
        IWriteContext WriteContext();
    }
}