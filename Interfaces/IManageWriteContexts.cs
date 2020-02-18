using System.Threading.Tasks;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// Supports the basic operations required to use write contexts
    /// </summary>
    public interface IManageWriteContexts
    {
        /// <summary>
        /// This should clear out all open object references and close the write contexts without commiting any changes
        /// </summary>
        void CancelWrite();

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
        /// Returns a new write context for the underlying persistence context
        /// </summary>
        /// <returns> a new write context for the underlying persistence context</returns>
        IWriteContext WriteContext();
    }
}