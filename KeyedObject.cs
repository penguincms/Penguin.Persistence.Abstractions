using Penguin.Persistence.Abstractions.Attributes;
using Penguin.Persistence.Abstractions.Attributes.Control;
using System;

namespace Penguin.Persistence.Abstractions.Models.Base
{
    /// <summary>
    /// Smallest possible persistable unit, containing only a definition for a unique int key
    /// </summary>
    [Serializable]
    [Entity(EntityType.Link)]
    public abstract class KeyedObject
    {
        #region Properties

        /// <summary>
        /// The default unique int Key for any objects deriving from this type
        /// </summary>
        [Key]
        [DontAllow(DisplayContext.Edit | DisplayContext.List)]
        public int _Id { get; set; }

        #endregion Properties
    }
}