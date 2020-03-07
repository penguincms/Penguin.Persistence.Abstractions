using System;

namespace Penguin.Persistence.Abstractions
{
    /// <summary>
    /// An injectable representation of a database connection definition, to simplify the process of ensuring that all systems use the same database connection information
    /// </summary>
    public class PersistenceConnectionInfo
    {
        /// <summary>
        /// The Raw connection string used to construct this instance
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// The name of the provider type (Specifically for EF)
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// An enum representation of the provider type as the prefered method of accessing the information
        /// </summary>
        public ProviderType ProviderType { get; set; }

        /// <summary>
        /// Constructs a new instance of this connection information
        /// </summary>
        /// <param name="connectionString">The Raw connection string used to construct this instance</param>
        /// <param name="providerName">The name of the provider type (Specifically for EF)</param>
        public PersistenceConnectionInfo(string connectionString, string providerName = "")
        {
            this.ProviderName = providerName;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return;
            }

            this.ConnectionString = connectionString;

            this.ProviderType = connectionString.IndexOf(".sdf", StringComparison.CurrentCultureIgnoreCase) > 0 ? ProviderType.SQLCE : ProviderType.SQL;
        }
    }

    /// <summary>
    /// Enum with the intent of simplifying identification of storage types
    /// </summary>
    public enum ProviderType
    {
        /// <summary>
        /// An MSSQL connection
        /// </summary>
        SQL,

        /// <summary>
        /// An SQLCE connection
        /// </summary>
        SQLCE
    }
}