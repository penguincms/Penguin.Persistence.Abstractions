namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// An interface intended to allow for access to a persistence context of a given type
    /// </summary>
    /// <typeparam name="T">The type of data used in the persistence context</typeparam>
    public interface IRepositoryI<in T> : IRepository where T : class
    {
        /// <summary>
        /// This should add a new object to the underlying data store
        /// </summary>
        /// <param name="o">The object(s) to add to the data store</param>
        void Add(params T[] o);

        /// <summary>
        /// This should add a new object to the data store, or update an existing matching object
        /// </summary>
        /// <param name="o">The object(s) to add or update</param>
        void AddOrUpdate(params T[] o);

        /// <summary>
        /// This should remove objects from the underlying data store, or make them inaccessible (if deleting is not prefered)
        /// </summary>
        /// <param name="o">The object(s) to remove from the data store</param>
        void Delete(params T[] o);

        /// <summary>
        /// This should update any objects that already exist in the underlying data store
        /// </summary>
        /// <param name="o">The objects to update from the underlying data store</param>
        void Update(params T[] o);
    }
}