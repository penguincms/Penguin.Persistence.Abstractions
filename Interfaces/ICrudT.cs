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
        /// This should return any object with a key that matches the provided
        /// </summary>
        new T Find(object Key);

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        new IEnumerable<T> FindRange(IEnumerable Keys);
    }
}