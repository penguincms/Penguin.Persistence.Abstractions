using System.Collections.Generic;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A nongeneric interface for a persistence context to allow access to data without knowing the underlying type
    /// </summary>
    public interface IPersistenceContext : ICrud, IManageWriteContexts
    {
        /// <summary>
        /// This should return a true if the object used to construct this persistence context has an associated data store (ex DbSet)
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// This should add the passed in IWriteContext to the list of open contexts, and enable persistence
        /// </summary>
        /// <param name="context">The IWriteContext that will be controlling this persistence instance</param>
        void BeginWrite(IWriteContext context);

        /// <summary>
        /// This should check to ensure that the IWriteContext is registered with the persistence context, remove it, and if it was the LAST open
        /// Write context it should persist all unsaved changes to the underlying data store
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        void EndWrite(IWriteContext context);

        /// <summary>
        /// This should return an array of any IWriteContexts that are currently registered by this persistence context
        /// </summary>
        /// <returns>An array of any IWriteContexts that are currently registered by this persistence context</returns>
        IEnumerable<IWriteContext> GetWriteContexts();
    }
}