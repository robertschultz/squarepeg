namespace SquarePeg.ServiceModel
{
    using System.Collections.Generic;
    using ServiceStack.ServiceHost;
    using SquarePeg.ServiceModel.Types;

    /// <summary>
    /// Boards service operation.
    /// </summary>
    [Route("/Boards/{Name}")]
    public class Boards
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }

    /// <summary>
    /// Boards service operation response.
    /// </summary>
    public class BoardsResponse
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public List<Board> Results { get; set; }
    }
}
