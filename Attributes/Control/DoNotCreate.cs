using System;

namespace Penguin.Persistence.Abstractions.Attributes.Control
{
    /// <summary>
    /// Attribute for static instances to clarify that they should not be persisted in the database
    /// Ex, A User representing a guest
    /// </summary>
    public sealed class DoNotCreateAttribute : Attribute
    {
    }
}