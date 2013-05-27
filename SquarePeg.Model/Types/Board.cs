namespace SquarePeg.Model.Types
{
    using ServiceStack.DataAnnotations;

    /// <summary>
    /// Board entity type.
    /// </summary>
    [Alias("Boards")]
    public class Board
    {
        /// <summary>
        /// Gets or sets the board id.
        /// </summary>
        /// <value>
        /// The board id.
        /// </value>
        [AutoIncrement]
        public long BoardId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
