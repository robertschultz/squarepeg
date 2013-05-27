namespace SquarePeg.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using ServiceStack.OrmLite;
    using SquarePeg.Model.Types;

    /// <summary>
    /// Repository to work with the Boards data source.
    /// </summary>
    public class BoardsRepository : IBoardsRepository
    {
        /// <summary>
        /// The connection.
        /// </summary>
        private IDbConnection connection = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardsRepository"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public BoardsRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Gets a list of boards.
        /// </summary>
        /// <returns>A list of <see cref="Board"/> objects.</returns>
        public List<Board> Get()
        {
            return connection.Select<Board>();
        }
    }
}
