namespace Penguin.Persistence.Abstractions.Interfaces
{
    /// <summary>
    /// An interface designed to perform any migrations required for the persistence context
    /// </summary>
    public interface IPersistenceContextMigrator
    {
        bool IsConfigured { get; }

        /// <summary>
        /// This should perform any setup required for the persistence context to function
        /// </summary>
        void Migrate();
    }
}