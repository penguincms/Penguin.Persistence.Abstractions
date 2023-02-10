using Penguin.Persistence.Abstractions.Attributes;
using Penguin.Persistence.Abstractions.Attributes.Control;
using System;

namespace Penguin.Persistence.Abstractions
{
    /// <summary>
    /// Smallest possible persistable unit, containing only a definition for a unique int key
    /// </summary>
    [Serializable]
    [Entity(EntityType.Link)]
    public abstract class KeyedObject
    {
        /// <summary>
        /// The default unique int Key for any objects deriving from this type
        /// </summary>
        [Key]
        [DontAllow(DisplayContexts.Edit | DisplayContexts.List)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Named to prevent conficts with common fields")]
        public virtual int _Id { get; set; }
    }
}