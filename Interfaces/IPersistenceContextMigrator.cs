using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// An interface designed to perform any migrations required for the persistence context
    /// </summary>
    public interface IPersistenceContextMigrator
    {
        /// <summary>
        /// This should perform any setup required for the persistence context to function
        /// </summary>
        void Migrate();
    }
}
