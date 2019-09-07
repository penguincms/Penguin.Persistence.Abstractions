namespace Penguin.Persistence.Abstractions.Attributes.Relations
{
    /// <summary>
    /// A class to denote common properties for data storage
    /// </summary>
    public class TableAttribute : RelationalAttribute
    {
        /// <summary>
        /// For EF, whether or not to map inherited types to this collection
        /// </summary>
        public bool MapInherited { get; set; }

        /// <summary>
        /// The name that the collection should be given, or for databases, the table name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructs a new instance of this attribute
        /// </summary>
        /// <param name="name">The name that the collection should be given, or for databases, the table name</param>
        /// <param name="mapInherited">For EF, whether or not to map inherited types to this collection</param>
        public TableAttribute(string name, bool mapInherited = true)
        {
            this.Name = name;
            this.MapInherited = mapInherited;
        }
    }
}