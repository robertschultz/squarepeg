namespace SquarePeg.ServiceModel.Types
{
    using ServiceStack.DataAnnotations;

    /// <summary>
    /// Permission entity type.
    /// </summary>
    [Alias("Permissions")]
    public class Permission
    {
        /// <summary>
        /// Gets or sets the permission id.
        /// </summary>
        /// <value>
        /// The permission id.
        /// </value>
        public short PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
