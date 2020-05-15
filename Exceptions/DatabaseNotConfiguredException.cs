using System;

namespace Penguin.Persistence.Abstractions.Exceptions
{
    /// <summary>
    /// An exception thrown when the database is not configured
    /// </summary>
    public class DatabaseNotConfiguredException : Exception
    {
        /// <summary>
        /// Constructs a new instance of the exception with the specified message
        /// </summary>
        /// <param name="message">The error message</param>
        public DatabaseNotConfiguredException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructs a new instance of the exception with the specified message and inner exception
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The exception to wrap</param>
        public DatabaseNotConfiguredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructs a new instance of the exception with the specified message
        /// </summary>
        public DatabaseNotConfiguredException()
        {
        }
    }
}