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
    public interface IRepository : ICrud, IManageWriteContexts
    {
        /// <summary>
        /// Returns a bool indicating whether or not the underlying persistence context contains a set for storing the
        /// type represented by this repository
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Resets the object unique fields and adds a copy to the context
        /// </summary>
        /// <param name="o">The object to copy and add</param>
        void AddCopy(object o);

        /// <summary>
        /// Resets the object unique fields and adds or updates a copy to the context
        /// </summary>
        /// <param name="o">The object to copy and add</param>
        void AddOrUpdateCopy(object o);

        /// <summary>
        /// Creates a shallow clone of an object with new keys
        /// </summary>
        /// <param name="o">The object to clone</param>
        object ShallowClone(object o);

        /// <summary>
        /// Allows for a "Where" call on a non generic instance by converting the provided expression tree to the implemented type
        /// </summary>
        /// <typeparam name="T">An assumed type/base for this non-generic instance of the repository</typeparam>
        /// <param name="predicate">The Expression to pass to the underlying IQueriable</param>
        /// <returns>The results of evaluating the expression against the underlying IQueriable</returns>
        IEnumerable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}