namespace SquarePeg.ServiceModel.Types
{
    using ServiceStack.DataAnnotations;

    /// <summary>
    /// BoardPermission entity type.
    /// </summary>
    [Alias("BoardPermissions")]
    public class BoardPermission
    {
        /// <summary>
        /// Gets or sets the board id.
        /// </summary>
        /// <value>
        /// The board id.
        /// </value>
        public long BoardId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        public long UserId { get; set; }
    }
}
