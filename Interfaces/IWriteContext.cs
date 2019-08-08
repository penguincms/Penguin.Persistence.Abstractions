using System;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A context that should be used to determine whether or not a block of code is in scope by registering itself with a PersistenceContext on creation,
    /// and closing out and commiting any unsaved changes on disposal
    /// </summary>
    public interface IWriteContext : IDisposable
    {
        #region Methods

        /// <summary>
        /// This should clear out all open object references and close the write contexts without commiting any changes
        /// </summary>
        void CancelWrite();

        #endregion Methods
    }
}