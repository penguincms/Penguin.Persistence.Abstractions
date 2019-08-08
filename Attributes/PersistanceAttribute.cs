using System;

namespace Penguin.Persistence.Abstractions.Attributes
{
    /// <summary>
    /// The root class used to define attributes as being relevant to persistence systems. All persistence attribute classes should inherit from this and this should be used to retrieve relevant attributes from types when generating models
    /// </summary>
    public abstract class PersistenceAttribute : Attribute
    {
    }
}