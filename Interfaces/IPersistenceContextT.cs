using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// A interface representing a context used for persisting information to a database or other format
    /// </summary>
    /// <typeparam name="T">The type of object being specifically referenced to by this instance</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>")]
    public interface IPersistenceContext<T> : ICrud<T>, IPersistenceContext where T : class
    {
        /// <summary>
        /// This should perform all of the same data filtering and population as All, however it should
        /// do all of this specific to the derived type and return the derived type as though it was a top
        /// level persistence context
        /// </summary>
        IQueryable<TDerived> OfType<TDerived>() where TDerived : T;
    }
}