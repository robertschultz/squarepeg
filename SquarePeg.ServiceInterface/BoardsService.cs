namespace SquarePeg.ServiceInterface
{
    using ServiceStack.CacheAccess;
    using ServiceStack.Logging;
    using ServiceStack.ServiceInterface;
    using SquarePeg.Core.Repository;
    using SquarePeg.ServiceModel;
    using SquarePeg.ServiceModel.Types;
    using System.Collections.Generic;

    /// <summary>
    /// Boards service that executes the service logic from the repository and performs any other business logic.
    /// </summary>
    public class BoardsService : Service, IBoardsService
    {
        /// <summary>
        /// The boards repository.
        /// </summary>
        private readonly IBoardsRepository boardsRepository = null;

        /// <summary>
        /// The cache client.
        /// </summary>
        private readonly ICacheClient cacheClient = null;

        public BoardsService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardsService"/> class.
        /// </summary>
        /// <param name="boardsRepository">
        /// The boards repository.
        /// </param>
        /// <param name="cacheClient">
        /// The cache Client.
        /// </param>
        public BoardsService(IBoardsRepository boardsRepository, ICacheClient cacheClient)
        {
            this.boardsRepository = boardsRepository;
            this.cacheClient = cacheClient;
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Instance of a <see cref="BoardsResponse"/> class.</returns>
        public virtual BoardsResponse Get(Boards request)
        {
            //var boards = this.cacheClient.Get<List<Board>>("Boards_Get");
            //if (boards == null)
            //{
              var  boards = this.boardsRepository.Get();

           //     this.cacheClient.Add("Boards_Get", boards);
            //}

            return new BoardsResponse { Results = boards };
        }
    }
}
