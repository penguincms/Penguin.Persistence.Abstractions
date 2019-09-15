using Penguin.Persistence.Abstractions.Interfaces;
using Penguin.Persistence.Abstractions.Models.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penguin.Persistence.Abstractions
{
    /// <summary>
    /// A base class representing a context used for persisting information to a database or other format
    /// </summary>
    /// <typeparam name="T">The type of object being specifically referenced to by this instance</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>")]
    public abstract class PersistenceContext<T> : IPersistenceContext<T> where T : KeyedObject
    {
        /// <summary>
        /// This should access the underlying queriable data provider, and be overridden for persistence contexts
        /// that require any form of data filtering
        /// </summary>
        public virtual IQueryable<T> All
        {
            get
            {
                IQueryable<T> root = PrimaryDataSource;

                return root;
            }
        }

        /// <summary>
        /// This returns the core type of the underlying IQueriable
        /// </summary>
        public Type ElementType => All.ElementType;

        /// <summary>
        /// This returns the Expression of the underlying IQueriable
        /// </summary>
        public virtual Expression Expression => All.Expression;

        /// <summary>
        /// This should return a true if the object used to construct this persistence context has an associated data store (ex DbSet)
        /// </summary>
        public abstract bool IsValid { get; }

        /// <summary>
        /// This returns the Provider of the underlying IQueriable
        /// </summary>
        public IQueryProvider Provider => All.Provider;

        /// <summary>
        /// Constructs a new instance of the Persistence Context
        /// </summary>
        /// <param name="t">The type of entity being stored by this context</param>
        /// <param name="dataSource">The IQueriable being used to retrieve instances of this object</param>
        public PersistenceContext(Type t, IQueryable<T> dataSource)
        {
            this.PrimaryDataSource = dataSource;

            this.BaseType = t;
        }

        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        public abstract void Add(params object[] o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        public abstract void AddOrUpdate(params T[] o);

        /// <summary>
        /// This should add the passed in IWriteContext to the list of open contexts, and enable persistence
        /// </summary>
        /// <param name="context">The IWriteContext that will be controlling this persistence instance</param>
        public abstract void BeginWrite(IWriteContext context);

        /// <summary>
        /// This should clear out all open object references and close the write contexts without commiting any changes
        /// </summary>
        public abstract void CancelWrite();

        /// <summary>
        /// If all WriteContexts have been deregistered, this should persist any changes to the underlying data store
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        public abstract void Commit(IWriteContext context);

        /// <summary>
        /// If all WriteContexts have been deregistered, this should persist any changes to the underlying data store in an ASYNC manner
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        public abstract Task CommitASync(IWriteContext context);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        public abstract void Delete(params object[] o);

        /// <summary>
        /// This should check to ensure that the IWriteContext is registered with the persistence context, remove it, and if it was the LAST open
        /// Write context it should persist all unsaved changes to the underlying data store
        /// </summary>
        /// <param name="context">The IWriteContext that has finished making changes</param>
        public abstract void EndWrite(IWriteContext context);

        /// <summary>
        /// This returns the Enumerator for the underlying IQueriable
        /// </summary>
        /// <returns>The Enumerator for the underlying IQueriable</returns>
        public IEnumerator<T> GetEnumerator() => All.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => All.GetEnumerator();

        /// <summary>
        /// This should return an array of any IWriteContexts that are currently registered by this persistence context
        /// </summary>
        /// <returns>An array of any IWriteContexts that are currently registered by this persistence context</returns>
        public abstract IWriteContext[] GetWriteContexts();

        /// <summary>
        /// This should return a list from the data source containing only the derived type with any applicable relations/filters
        /// </summary>
        /// <typeparam name="TDerived">A type stored in the context that is derived from the main context type</typeparam>
        /// <returns>An IQueriable to access this child list of objects</returns>
        public abstract IQueryable<TDerived> OfType<TDerived>() where TDerived : T;

        /// <summary>
        /// This should update any objects that already exist in the underlying data store
        /// </summary>
        /// <param name="o">The objects to update from the underlying data store</param>
        public abstract void Update(params object[] o);

        /// <summary>
        /// This should spawn a new IWriteContext instance that is pre-registered with this persistence context
        /// </summary>
        /// <returns>A new IWriteContext instance that is pre-registered with this persistence context</returns>
        public abstract IWriteContext WriteContext();

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        public abstract T[] Find(object[] Keys);

        /// <summary>
        /// This should return any object with a key that matches the provided
        /// </summary>
        public abstract T Find(object Key);

        /// <summary>
        /// This should return any object with a key in the provided list
        /// </summary>
        object[] IPersistenceContext.Find(object[] Keys) => this.Find(Keys);

        /// <summary>
        /// This should return any object with a key that matches the provided
        /// </summary>
        object IPersistenceContext.Find(object Key) => this.Find(Key);

        /// <summary>
        /// This should contain any additional sources for objects that are READ ONLY (ex caches)
        /// </summary>
        protected virtual IEnumerable<IEnumerable<T>> AdditionalDataSources { get; set; }

        /// <summary>
        /// This returns the type of the object being persisted in this context
        /// </summary>
        protected Type BaseType { get; set; }

        /// <summary>
        /// This should return the IQuerable that accesses the primary store where data is persisted
        /// </summary>
        protected virtual IQueryable<T> PrimaryDataSource { get; set; }
    }
}