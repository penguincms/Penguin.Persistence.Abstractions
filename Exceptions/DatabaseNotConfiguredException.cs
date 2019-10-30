using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Persistence.Abstractions.Exceptions
{
    public class DatabaseNotConfiguredException : Exception
    {
        public DatabaseNotConfiguredException(string message) : base(message)
        {
        }

        public DatabaseNotConfiguredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}